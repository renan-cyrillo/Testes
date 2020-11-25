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

using WebSupergoo.ABCpdf11;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ImageMagick;

namespace OcrTesteDois
{
    class TesteOcrDois
    {
        private static Tesseract _ocr;

        private static bool InitOcr(String path, String lang, OcrEngineMode mode)
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

        private static OCRMode Mode
        {
            //get { return ocrOptionsComboBox.SelectedIndex == 0 ? OCRMode.FullPage : OCRMode.TextDetection; }
            get { return OCRMode.FullPage; }
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

        private static string OcrImagee(Mat source)
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

        public static bool  ValidaData(string sData)
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



        public void lerPdfOCR(string caminho)
        {
            
            string notaInteira = PDFtoIMG(caminho);
            Bitmap myBitmap = new Bitmap(notaInteira);

            //string numeroNota = lerNumero(myBitmap, 77, 5, 900, 300);
            string numeroNota = lerNumero(myBitmap, 73, 5, 1200, 300);

            //string  dataEmissao = lerDataEmissao(myBitmap, 74, 8, 1400, 300);
            //string dataEmissao = lerDataEmissao(myBitmap, 70, 8, 1450, 290);
            string dataEmissao = lerDataEmissao(myBitmap, 70, 8, 1700, 290);

            //string cnpjEmitente = lerCnpjEmitente(myBitmap, 25, 12, 1700, 290);
            string cnpjEmitente = lerCnpjEmitente(myBitmap, 29, 13, 1000, 200);

            numeroNota = numeroNota.Replace("\r","");
            numeroNota = numeroNota.Replace("\n","");
            Console.WriteLine("Numero da nota: ");
            Console.WriteLine(numeroNota);
            Console.WriteLine("\nData de Emissao: ");
            Console.WriteLine(dataEmissao);
            Console.WriteLine("\nCNPJ Prestador: ");
            Console.WriteLine(cnpjEmitente);

            //Console.WriteLine(RemoveSpecialCharacters(resultado));

            //string numeroNota = localizarNumero(resultado);
            //string dataEmissao = localizarDataEmissao(resultado);
            //Console.WriteLine("numero:"+numeroNota);
            //Console.WriteLine("data:" + dataEmissao);

            Console.ReadLine();
        }

        //mesclando cod

        public static string PDFtoIMG(string caminho)
        {

            MagickImage image = new MagickImage();
            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(1000);
            image.Read(caminho, settings);

            image.Write(@"D:\tmp\ocr\notaInteira.png");
            return @"D:\tmp\ocr\notaInteira.png";

            //Bitmap Output = image;
            //image
            //return Output;
            

        }

        public static Bitmap ResizeImgg(System.Drawing.Image imgToResize, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(imgToResize, new System.Drawing.Rectangle(0, 0, width, height));
                gr.Dispose();

            }
            return newImage;
        }

        public static string lerNumero(Bitmap myBitmap, int percWidth, int percHeight, int tamWidth, int tamHeight)
        {

            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth, myBitmap.Height / 100 * percHeight, tamWidth, tamHeight);
            //System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth,282, tamWidth, tamHeight);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            //Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 6, cloneBitmap.Height * 6);
            Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 3, cloneBitmap.Height * 3);

            cloneBitmapBig.Save(@"d:\tmp\ocr\numeroOCR.png", System.Drawing.Imaging.ImageFormat.Png);



            InitOcr(@"D:\tmp\ocr\ocrTT.png", "eng", OcrEngineMode.Default);

            Mat source = new Mat(@"d:\tmp\ocr\numeroOCR.png");

            string resultados = OcrImagee(source);

            string[] resultado = resultados.Split(' ','\r');

            string numeroNota = resultado[resultado.Length-2];
            numeroNota = numeroNota.Replace("Q", "0");
            numeroNota = numeroNota.Replace("U", "0");
            numeroNota = numeroNota.Replace("O", "0");
            //for (int i =0; i<resultado.Length;i++)
            //{
            //    string aa = RemoveSpecialCharacters(resultado[i]);
            //    Console.WriteLine(aa + " - " + i);
            //}
            return numeroNota;



        }

        public static string lerDataEmissao(Bitmap myBitmap, int percWidth, int percHeight, int tamWidth, int tamHeight)
        {

            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth, myBitmap.Height / 100 * percHeight, tamWidth, tamHeight);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 2, cloneBitmap.Height * 2);

            cloneBitmapBig.Save(@"d:\tmp\ocr\dataEmissaoOCR.png", System.Drawing.Imaging.ImageFormat.Png);



            InitOcr(@"D:\tmp\ocr\ocrTT.png", "eng", OcrEngineMode.Default);

            Mat source = new Mat(@"d:\tmp\ocr\dataEmissaoOCR.png");

            string resultados = OcrImagee(source);
            //Console.WriteLine(resultados);
            //Console.WriteLine(":::::::::::");

            string[] resultado = resultados.Split(' ', '\r');

            string dataEmissao = resultado[resultado.Length - 3] + " " +  resultado[resultado.Length - 2];
            

            //dataEmissao = dataEmissao.Replace("O", "");

            //for (int i = 0; i < resultado.Length; i++)
            //{
            //    resultado[i] = resultado[i].Replace(@"?", "0");
            //    resultado[i] = resultado[i].Replace("f", "/");
            //    resultado[i] = resultado[i].Replace("|", "");
            //    resultado[i] = resultado[i].Replace(":", "");
            //    Console.WriteLine(resultado[i] + " - " + i);
            //}

            for (int i = 0; i < resultado.Length; i++)
            {
                //resultado[i].All(char.IsDigit
                resultado[i] = resultado[i].Replace(",", "");
                if (ValidaData(resultado[i])){
                    dataEmissao = resultado[i] + " " + resultado[i+1];
                    break;
                }

                //string aa = RemoveSpecialCharacters(resultado[i]);
                //Console.WriteLine(resultado[i] + " - " + i);
            }
         

            dataEmissao = dataEmissao.Replace("|", "");
            dataEmissao = dataEmissao.Replace("&", "8");
            dataEmissao = dataEmissao.Replace("?","0");
            dataEmissao = dataEmissao.Replace("f", "/");
            dataEmissao = dataEmissao.Replace("b", "6");
            dataEmissao = dataEmissao.Replace("U", "0");

            return dataEmissao;



        }

        public static string lerCnpjEmitente(Bitmap myBitmap, int percWidth, int percHeight, int tamWidth, int tamHeight)
        {

            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth, myBitmap.Height / 100 * percHeight, tamWidth, tamHeight);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            //Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 2, cloneBitmap.Height * 2);
            Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 3, cloneBitmap.Height * 3);

            cloneBitmapBig.Save(@"d:\tmp\ocr\cnpjEmitenteOCR.png", System.Drawing.Imaging.ImageFormat.Png);



            InitOcr(@"D:\tmp\ocr\ocrTT.png", "eng", OcrEngineMode.Default);

            Mat source = new Mat(@"d:\tmp\ocr\cnpjEmitenteOCR.png");

            string resultados = OcrImagee(source);
            //Console.WriteLine(resultados);
            //Console.WriteLine(":::::::::::");

            string[] resultado = resultados.Split(' ', '\r');

            //string cnpjEmitente = resultado[resultado.Length - 3] + resultado[resultado.Length - 2];
            string cnpjEmitente = resultado[0] ;

            for (int i = 0; i < resultado.Length; i++)
            {
                Console.WriteLine(resultado[i]);
            }
                //dataEmissao = dataEmissao.Replace("O", "");

                //for (int i = 0; i < resultado.Length; i++)
                //{
                //    resultado[i] = resultado[i].Replace(@"?", "0");
                //    resultado[i] = resultado[i].Replace("f", "/");
                //    resultado[i] = resultado[i].Replace("|", "");
                //    resultado[i] = resultado[i].Replace(":", "");
                //    Console.WriteLine(resultado[i] + " - " + i);
                //}

                //for (int i = 0; i < resultado.Length; i++)
                //{
                //    //resultado[i].All(char.IsDigit
                //    resultado[i] = resultado[i].Replace(",", "");
                //    if (ValidaData(resultado[i]))
                //    {
                //        cnpjEmitente = resultado[i] + " " + resultado[i + 1];
                //        break;
                //    }

                //    //string aa = RemoveSpecialCharacters(resultado[i]);
                //    //Console.WriteLine(resultado[i] + " - " + i);
                //}


                //dataEmissao = dataEmissao.Replace("|", "");
                //dataEmissao = dataEmissao.Replace("&", "8");
                //dataEmissao = dataEmissao.Replace("?", "0");
                //dataEmissao = dataEmissao.Replace("f", "/");
                //dataEmissao = dataEmissao.Replace("b", "6");
                //dataEmissao = dataEmissao.Replace("U", "0");

                return cnpjEmitente;



        }

    }
}