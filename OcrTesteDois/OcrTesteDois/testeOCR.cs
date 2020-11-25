using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Text;
using Emgu.CV.Util;

namespace OcrTesteDois
{
    class testeOCR
    {

        private Tesseract _ocr;

        private bool InitOcr(String path, String lang, OcrEngineMode mode)
        {
            try
            {
                if (_ocr != null)
                {
                    _ocr.Dispose();
                    _ocr = null;
                }

                if (String.IsNullOrEmpty(path))
                    path = Emgu.CV.OCR.Tesseract.DefaultTesseractDirectory;

                TesseractDownloadLangFile(path, lang);
                TesseractDownloadLangFile(path, "osd"); //script orientation detection
                                                        /*
                                                        String pathFinal = path.Length == 0 || path.Substring(path.Length - 1, 1).Equals(Path.DirectorySeparatorChar.ToString())
                                                            ? path
                                                            : String.Format("{0}{1}", path, System.IO.Path.DirectorySeparatorChar);
                                                        */
                _ocr = new Tesseract(path, lang, mode);

                //languageNameLabel.Text = String.Format("{0} : {1} (tesseract version {2})", lang, mode.ToString(), Emgu.CV.OCR.Tesseract.VersionString);
                return true;
            }
            catch (Exception e)
            {
                _ocr = null;
                //MessageBox.Show(e.Message, "Failed to initialize tesseract OCR engine", MessageBoxButtons.OK);
                //languageNameLabel.Text = "Failed to initialize tesseract OCR engine";
                Console.WriteLine(e.Message, "Failed to initialize tesseract OCR engine");
                return false;
            }
        }

        private static void TesseractDownloadLangFile(String folder, String lang)
        {
            //String subfolderName = "tessdata";
            //String folderName = System.IO.Path.Combine(folder, subfolderName);
            String folderName = folder;
            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }
            String dest = System.IO.Path.Combine(folderName, String.Format("{0}.traineddata", lang));
            if (!System.IO.File.Exists(dest))
                using (System.Net.WebClient webclient = new System.Net.WebClient())
                {
                    String source = Emgu.CV.OCR.Tesseract.GetLangFileUrl(lang);

                    Console.WriteLine(String.Format("Downloading file from '{0}' to '{1}'", source, dest));
                    webclient.DownloadFile(source, dest);
                    Console.WriteLine(String.Format("Download completed"));
                }
        }

//        private void OcrImage(Mat source)
//        {
//            //imageBox1.Image = null;
//            //ocrTextBox.Text = String.Empty;
//            //hocrTextBox.Text = String.Empty;
//#if !DEBUG
//         try
//#endif
//            {

//                Mat result = new Mat();
//                String ocredText = OcrImage(_ocr, source, Mode, result);
//                imageBox1.Image = result;
//                ocrTextBox.Text = ocredText;
//                if (Mode == OCRMode.FullPage)
//                {
//                    hocrTextBox.Text = _ocr.GetHOCRText();
//                }
//            }
//#if !DEBUG
//         catch (Exception exception)
//         {
//            MessageBox.Show(exception.Message);
//         }
//#endif
//        }

        private enum OCRMode
        {
            /// <summary>
            /// Perform a full page OCR
            /// </summary>
            FullPage,

            /// <summary>
            /// Detect the text region before applying OCR.
            /// </summary>
            TextDetection
        }

        private OCRMode Mode
        {
            //get { return ocrOptionsComboBox.SelectedIndex == 0 ? OCRMode.FullPage : OCRMode.TextDetection; }
            get { return  OCRMode.FullPage; }
        }

        private static Rectangle ScaleRectangle(Rectangle r, double scale)
        {
            double centerX = r.Location.X + r.Width / 2.0;
            double centerY = r.Location.Y + r.Height / 2.0;
            double newWidth = Math.Round(r.Width * scale);
            double newHeight = Math.Round(r.Height * scale);
            return new Rectangle((int)Math.Round(centerX - newWidth / 2.0), (int)Math.Round(centerY - newHeight / 2.0),
               (int)newWidth, (int)newHeight);
        }

        private static String OcrImage(Tesseract ocr, Mat image, OCRMode mode, Mat imageColor)
        {
            Bgr drawCharColor = new Bgr(Color.Red);

            if (image.NumberOfChannels == 1)
                CvInvoke.CvtColor(image, imageColor, ColorConversion.Gray2Bgr);
            else
                image.CopyTo(imageColor);

            if (mode == OCRMode.FullPage)
            {
                ocr.SetImage(imageColor);

                if (ocr.Recognize() != 0)
                    throw new Exception("Failed to recognizer image");

                Tesseract.Character[] characters = ocr.GetCharacters();
                if (characters.Length == 0)
                {
                    Mat imgGrey = new Mat();
                    CvInvoke.CvtColor(image, imgGrey, ColorConversion.Bgr2Gray);
                    Mat imgThresholded = new Mat();
                    CvInvoke.Threshold(imgGrey, imgThresholded, 65, 255, ThresholdType.Binary);
                    ocr.SetImage(imgThresholded);
                    characters = ocr.GetCharacters();
                    imageColor = imgThresholded;
                    if (characters.Length == 0)
                    {
                        CvInvoke.Threshold(image, imgThresholded, 190, 255, ThresholdType.Binary);
                        ocr.SetImage(imgThresholded);
                        characters = ocr.GetCharacters();
                        imageColor = imgThresholded;
                    }
                }
                foreach (Tesseract.Character c in characters)
                {
                    CvInvoke.Rectangle(imageColor, c.Region, drawCharColor.MCvScalar);
                }

                return ocr.GetUTF8Text();

            }
            else
            {
                bool checkInvert = true;

                Rectangle[] regions;

                using (
                   ERFilterNM1 er1 = new ERFilterNM1("trained_classifierNM1.xml", 8, 0.00025f, 0.13f, 0.4f, true, 0.1f))
                using (ERFilterNM2 er2 = new ERFilterNM2("trained_classifierNM2.xml", 0.3f))
                {
                    int channelCount = image.NumberOfChannels;
                    UMat[] channels = new UMat[checkInvert ? channelCount * 2 : channelCount];

                    for (int i = 0; i < channelCount; i++)
                    {
                        UMat c = new UMat();
                        CvInvoke.ExtractChannel(image, c, i);
                        channels[i] = c;
                    }

                    if (checkInvert)
                    {
                        for (int i = 0; i < channelCount; i++)
                        {
                            UMat c = new UMat();
                            CvInvoke.BitwiseNot(channels[i], c);
                            channels[i + channelCount] = c;
                        }
                    }

                    VectorOfERStat[] regionVecs = new VectorOfERStat[channels.Length];
                    for (int i = 0; i < regionVecs.Length; i++)
                        regionVecs[i] = new VectorOfERStat();

                    try
                    {
                        for (int i = 0; i < channels.Length; i++)
                        {
                            er1.Run(channels[i], regionVecs[i]);
                            er2.Run(channels[i], regionVecs[i]);
                        }
                        using (VectorOfUMat vm = new VectorOfUMat(channels))
                        {
                            regions = ERFilter.ERGrouping(image, vm, regionVecs, ERFilter.GroupingMethod.OrientationHoriz,
                               "trained_classifier_erGrouping.xml", 0.5f);
                        }
                    }
                    finally
                    {
                        foreach (UMat tmp in channels)
                            if (tmp != null)
                                tmp.Dispose();
                        foreach (VectorOfERStat tmp in regionVecs)
                            if (tmp != null)
                                tmp.Dispose();
                    }

                    Rectangle imageRegion = new Rectangle(Point.Empty, imageColor.Size);
                    for (int i = 0; i < regions.Length; i++)
                    {
                        Rectangle r = ScaleRectangle(regions[i], 1.1);

                        r.Intersect(imageRegion);
                        regions[i] = r;
                    }

                }


                List<Tesseract.Character> allChars = new List<Tesseract.Character>();
                String allText = String.Empty;
                foreach (Rectangle rect in regions)
                {
                    using (Mat region = new Mat(image, rect))
                    {
                        ocr.SetImage(region);
                        if (ocr.Recognize() != 0)
                            throw new Exception("Failed to recognize image");
                        Tesseract.Character[] characters = ocr.GetCharacters();

                        //convert the coordinates from the local region to global
                        for (int i = 0; i < characters.Length; i++)
                        {
                            Rectangle charRegion = characters[i].Region;
                            charRegion.Offset(rect.Location);
                            characters[i].Region = charRegion;

                        }
                        allChars.AddRange(characters);

                        allText += ocr.GetUTF8Text() + Environment.NewLine;

                    }
                }

                Bgr drawRegionColor = new Bgr(Color.Red);
                foreach (Rectangle rect in regions)
                {
                    CvInvoke.Rectangle(imageColor, rect, drawRegionColor.MCvScalar);
                }
                foreach (Tesseract.Character c in allChars)
                {
                    CvInvoke.Rectangle(imageColor, c.Region, drawCharColor.MCvScalar);
                }

                return allText;

            }

        }

        private string OcrImagee(Mat source)
        {
            Mat result = new Mat();
            String ocredText = OcrImage(_ocr, source, Mode, result);
            //imageBox1.Image = result;
            //ocrTextBox.Text = ocredText;
            return ocredText; //_ocr.GetHOCRText(); // ou ocredText
        }

        public static string RemoveSpecialCharacters(string text, bool allowSpace = false)
        {
            string ret;

            if (allowSpace)
                ret = System.Text.RegularExpressions.Regex.Replace(text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
            else
                ret = System.Text.RegularExpressions.Regex.Replace(text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

            return ret;
        }

        public bool validaData(string sData)
        {
            try
            {
                DateTime.Parse(sData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string localizarNumero(string resultado)
        {
            //Console.WriteLine(">>> ");
            string[] numeroNota = resultado.Split(' ');
            //string numeroLimpo = RemoveSpecialCharacters(numeroNota[23]);
            //Console.WriteLine(numeroLimpo);
            string numeroLimpo;


            for (int i = 0; i < numeroNota.Length; i++)
            {

                numeroLimpo = validaData(numeroNota[i]) ? "" : RemoveSpecialCharacters(numeroNota[i]);

                //Console.WriteLine(numeroLimpo + "    " + i);

                //if (numeroLimpo.Equals("00015195"))
                if (numeroLimpo.Length == 8 && numeroLimpo.All(char.IsDigit)){

                    return numeroLimpo;

                }

            }
            return "numero nao identificado";
        }

        public string localizarDataEmissao(string resultado)
        {
            string[] dataEmissao = resultado.Split(' ');
            //string numeroLimpo = RemoveSpecialCharacters(numeroNota[23]);
            //Console.WriteLine(numeroLimpo);
            string numeroLimpo;


            for (int i = 0; i < dataEmissao.Length; i++)
            {
                string hora = "";
                try
                {
                    hora = RemoveSpecialCharacters(dataEmissao[i + 1]).Substring(0, 6);
                }
                catch(Exception e)
                {
                    //Console.WriteLine(">>> " + e);
                }
                
                if (validaData(dataEmissao[i]) && hora.All(char.IsDigit))
                {
                    return dataEmissao[i] + " " + hora.Substring(0,2) + ":" + hora.Substring(2,2) + ":" + hora.Substring(4,2);
                }

                numeroLimpo = validaData(dataEmissao[i]) ? "" : RemoveSpecialCharacters(dataEmissao[i]);


            }
            return "data nao identificada";
        }

        public void lerPdfOCR(string caminho)
        {
            InitOcr(@"D:\tmp\ocr\1524TT.png", "por", OcrEngineMode.Default);

            Mat source = new Mat(caminho);
            string resultado = OcrImagee(source);

            Console.WriteLine(resultado);
            //Console.WriteLine(RemoveSpecialCharacters(resultado));

            string numeroNota = localizarNumero(resultado);
            string dataEmissao = localizarDataEmissao(resultado);
            Console.WriteLine("numero:" + numeroNota);
            Console.WriteLine("data:" + dataEmissao);

            Console.ReadLine();
        }

    }
}
