using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKP.MDRA.Domain.Entities
{
    class NotaServico : Nota
    {
        public string ValorTotal { get; set; }
        public string PrestadorCnpj { get; set; }
        public string TomadorCnpj { get; set; }
        public string DiscriminacaoServicos { get; set; }
        public string Inss { get; set; }
        public string Irff { get; set; }
        public string Csll { get; set; }
        public string Cofins { get; set; }
        public string PisPasep { get; set; }
        public string ValorTotalDeducoes { get; set; }
        public string BaseCalculo { get; set; }
        public string Aliquota { get; set; }
        public string Iss { get; set; }
        public string Credito { get; set; }
        public string OutrasInformacoes { get; set; }
    }
}
