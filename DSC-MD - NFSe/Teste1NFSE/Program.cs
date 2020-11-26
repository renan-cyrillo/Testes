using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using DSC.NFe.Sefaz.XmlSefaz;
using DSC.NFe.Sefaz.Nfse.Versao1.WSDL.LoteNfe;

namespace Teste1NFSE
{
    class Program
    {
        static void Main(string[] args)
        {

            teste3();
        }

        public static void teste1()
        {
            var nfseXML = new LoteNFe();


            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var cert = store.Certificates.Find(X509FindType.FindBySubjectName, "MINERACAO MARACA INDUSTRIA E COMERCIO S A:86902053000113", true)[0];

            var add = new EndpointAddress(new Uri("https://nfe.prefeitura.sp.gov.br/ws/lotenfe.asmx"));
            var enc = new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8);
            var trans = new HttpsTransportBindingElement() { RequireClientCertificate = true };

            var cred = new ClientCredentials();
            cred.ClientCertificate.Certificate = cert;
            var bind = new CustomBinding(enc, trans);

            var end = new ServiceEndpoint(ContractDescription.GetContract(typeof(NFSe.LoteNFeSoap)), bind, add);
            end.EndpointBehaviors.Add(cred);

            var ch = new ChannelFactory<NFSe.LoteNFeSoap>(end);

            var nfsee = ch.CreateChannel();


            string cab = @"";
            string req = @"<?xml version=""1.0"" encoding=""utf-8""?><PedidoConsultaNFePeriodo xmlns=""http://www.prefeitura.sp.gov.br/nfe""><Cabecalho Versao=""1"" xmlns="""">  <CPFCNPJRemetente><CNPJ>86902053000113</CNPJ></CPFCNPJRemetente>  <dtInicio>2020-11-12</dtInicio>  <dtFim>2020-11-12</dtFim>  <NumeroPagina>1</NumeroPagina></Cabecalho></PedidoConsultaNFePeriodo>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;

            xmlDoc.LoadXml(req);
            var signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = cert.PrivateKey;

            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigSHA1Url;

            string refUri = "https://nfe.prefeitura.sp.gov.br/ws/lotenfe.asmx";
            refUri = String.IsNullOrEmpty(refUri) ? "" : $"#{refUri}";

            Reference reference = new Reference(refUri);
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());

            reference.DigestMethod = SignedXml.XmlDsigSHA1Url;

            signedXml.AddReference(reference);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(cert));
            signedXml.KeyInfo = keyInfo;

            try
            {
                signedXml.ComputeSignature();

                XmlElement xmlSignedInfo = signedXml.SignedInfo.GetXml();
                XmlElement xmlKeyInfo = signedXml.KeyInfo.GetXml();

                XmlElement xmlAssinado = signedXml.Signature.GetXml();

                string assinatura = xmlAssinado.OuterXml;






            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var ret = nfsee.ConsultaNFeRecebidas(new NFSe.ConsultaNFeRecebidasRequest(1, req)).RetornoXML;
            //XmlElement xmlSignature = doc.CreateElement(“Signature”, “http://www.w3.org/2000/09/xmldsig#”);


            //XmlElement xmlSignatureValue = doc.CreateElement("SignatureValue", xmlSignature.NamespaceURI);
            //string signBase64 = Convert.ToBase64String(signedXml.Signature.SignatureValue);
            //XmlText text = doc.CreateTextNode(signBase64);
            //xmlSignatureValue.AppendChild(text);
            //xmlSignature.AppendChild(xmlSignatureValue);






            Console.WriteLine("ok");
        }

        public static void teste2()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var cert = store.Certificates.Find(X509FindType.FindBySubjectName, "MINERACAO MARACA INDUSTRIA E COMERCIO S A:86902053000113", true)[0];

            string xmlString = @"<?xml version=""1.0"" encoding=""utf-8""?><PedidoConsultaNFePeriodo xmlns=""http://www.prefeitura.sp.gov.br/nfe""><Cabecalho Versao=""1"" xmlns="""">  <CPFCNPJRemetente><CNPJ>86902053000113</CNPJ></CPFCNPJRemetente>  <dtInicio>2020-11-12</dtInicio>  <dtFim>2020-11-12</dtFim>  <NumeroPagina>1</NumeroPagina></Cabecalho></PedidoConsultaNFePeriodo>";

            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Format the document to ignore white spaces.
            doc.PreserveWhitespace = false;

            // Load the passed XML file using it’s name.
            doc.LoadXml(xmlString);

            //XmlDocument XMLDoc;

            // Create a reference to be signed
            Reference reference = new Reference();
            reference.Uri = "";

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document
            signedXml.SigningKey = cert.PrivateKey;

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
            reference.AddTransform(c14);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Create a new KeyInfo object
            KeyInfo keyInfo = new KeyInfo();

            // Load the certificate into a KeyInfoX509Data object
            // and add it to the KeyInfo object.
            keyInfo.AddClause(new KeyInfoX509Data(cert));

            // Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo;
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            //doc.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            //XmlDocument XMLDoc;
            //XMLDoc = new XmlDocument();
            //XMLDoc.PreserveWhitespace = false;
            //XMLDoc = doc;


            string conteudoXMLAssinado = xmlString + xmlDigitalSignature.OuterXml;

            Console.WriteLine(conteudoXMLAssinado);








            var add = new EndpointAddress(new Uri("https://nfe.prefeitura.sp.gov.br/ws/lotenfe.asmx"));
            var enc = new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8);
            var trans = new HttpsTransportBindingElement() { RequireClientCertificate = true };

            var cred = new ClientCredentials();
            cred.ClientCertificate.Certificate = cert;
            var bind = new CustomBinding(enc, trans);

            var end = new ServiceEndpoint(ContractDescription.GetContract(typeof(NFSe.LoteNFeSoap)), bind, add);
            end.EndpointBehaviors.Add(cred);

            var ch = new ChannelFactory<NFSe.LoteNFeSoap>(end);

            var nfsee = ch.CreateChannel();


            var ret = nfsee.ConsultaNFeRecebidas(new NFSe.ConsultaNFeRecebidasRequest(1, conteudoXMLAssinado)).RetornoXML;

            Console.WriteLine("ok");
        }

        public static void teste3()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var cert = store.Certificates.Find(X509FindType.FindBySubjectName, "MINERACAO MARACA INDUSTRIA E COMERCIO S A:86902053000113", true)[0];

            string cab = @"<?xml version='1.0' encoding=""utf-8""?>
                        <cabecalho xmlns=""http://www.prefeitura.sp.gov.br/nfe"" versao=""1.00"" >
                            <versaoDados>1.00</versaoDados>
                        </cabecalho>";
            string req = @"<PedidoConsultaNFePeriodo xmlns=""http://www.prefeitura.sp.gov.br/nfe"">
                                <CPFCNPJRemetente>
                                    <CNPJ>86902053000113</CNPJ>
                                </CPFCNPJRemetente>  
                                <dtInicio>2020-11-12</dtInicio>  
                                <dtFim>2020-11-12</dtFim>  
                                <NumeroPagina>1</NumeroPagina></Cabecalho>
                            </PedidoConsultaNFePeriodo>";




            string mensagemXML = "<?xml version=\"1.0\" encoding = \"UTF -8\" ?>" +
            "<PedidoConsultaNFePeriodo xmlns=\"http://www.prefeitura.sp.gov.br/nfe\">" +
            "<Cabecalho Versao = \"1\" >" +
            "<CPFCNPJRemetente>" +
            "<CNPJ>00CNPJ00</CNPJ>" +
            " </CPFCNPJRemetente>" +
            "<CPFCNPJ>" +
            "<CNPJ>86902053000113</CNPJ>" +
            "</CPFCNPJ>" +
            "<Inscricao>00Inscricao00</Inscricao>" +
            " <dtInicio>2020-11-20</dtInicio>" +
            "<dtFim>2020-11-20</dtFim>" +
            "<NumeroPagina>1</NumeroPagina>" +
            "</Cabecalho>" +
            "</PedidoConsultaNFePeriodo>";

            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc = Assinar(mensagemXML,cert);

            var wse = new NFSe.LoteNFeSoapClient();
            wse.ClientCredentials.ClientCertificate.Certificate = cert;
             string aaa = wse.ConsultaNFeRecebidas(1, xmlDoc.OuterXml);
            Console.WriteLine(aaa);
            
        }

        public static XmlDocument Assinar(string mensagemXML, System.Security.Cryptography.X509Certificates.X509Certificate2 certificado ) {
            var xmlDoc = new System.Xml.XmlDocument();
            var Key = new System.Security.Cryptography.RSACryptoServiceProvider();
            var SignedDocument = new System.Security.Cryptography.Xml.SignedXml();
            var keyInfo = new System.Security.Cryptography.Xml.KeyInfo();
            xmlDoc.LoadXml(mensagemXML);
            //'Retira chave privada ligada ao certificado
            Key = (System.Security.Cryptography.RSACryptoServiceProvider)certificado.PrivateKey;
            //'Adiciona Certificado ao Key Info
            keyInfo.AddClause(new System.Security.Cryptography.Xml.KeyInfoX509Data(certificado));
            SignedDocument = new System.Security.Cryptography.Xml.SignedXml(xmlDoc);
            //Seta chaves
            SignedDocument.SigningKey = Key;
            SignedDocument.KeyInfo = keyInfo;

            //' Cria referencia
            var reference = new System.Security.Cryptography.Xml.Reference();
            reference.Uri = String.Empty;
           // ' Adiciona transformacao a referencia
            reference.AddTransform(new System.Security.Cryptography.Xml.XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new System.Security.Cryptography.Xml.XmlDsigC14NTransform(false));
            //' Adiciona referencia ao xml
            SignedDocument.AddReference(reference);
           // ' Calcula Assinatura
            SignedDocument.ComputeSignature();
            //' Pega representação da assinatura
            var xmlDigitalSignature =  SignedDocument.GetXml();
            //' Adiciona ao doc XML
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            return xmlDoc;
    }


    }
}
    