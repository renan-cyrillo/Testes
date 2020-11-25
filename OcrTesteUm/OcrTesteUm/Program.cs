using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

using cs_pdf_to_image;
using PdfToImage;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text;
using WebSupergoo.ABCpdf11;


namespace OcrTesteUm
{
    class Program
    {

        public static Bitmap pdftiff(string dirOri)
        {
            Doc theDoc = new Doc();

            //theDoc.Read(Server.MapPath("../Pdfreports/Procedure_Report_" + ReportId.ToString() + ".pdf"));
            theDoc.Read(dirOri);

            // set up the rendering parameters

            theDoc.Rendering.ColorSpace = XRendering.ColorSpaceType.Gray;

            theDoc.Rendering.BitsPerChannel = 1;

            theDoc.Rendering.DotsPerInchX = 200;

            theDoc.Rendering.DotsPerInchY = 400;

            // loop through the pages

            int n = theDoc.PageCount;

            for (int i = 1; i <= n; i++)

            {

                theDoc.PageNumber = i;

                theDoc.Rect.String = theDoc.CropBox.String;

                theDoc.Rendering.SaveAppend = (i != 1);

                //theDoc.Rendering.SaveCompression = XRendering.Compression.G4;

                theDoc.SetInfo(0, "ImageCompression", "4");

                //theDoc.Rendering.Save(dirDest);

            }
            return theDoc.Rendering.GetBitmap();
            //theDoc.Clear();
        }

        public static void pdfimg()
        {
            TiffImage myTiff = new TiffImage(@"D:\tmp\ocr\1524T.tif");
            Bitmap myBitmap = new Bitmap(@"D:\tmp\ocr\1524T.tif");
            myBitmap.Save(@"D:\tmp\ocr\1524TT.png");
        }
        //public static void ConverterPDFimg()
        //{

        //    // open and load the file
        //    using (FileStream fs = new FileStream(@"Documents\TestFile.pdf", FileMode.Open))
        //    {
        //        // this object represents a PDF document
        //        Document document = new Document(fs);

        //        // default rendering settings
        //        RenderingSettings settings = new RenderingSettings();

        //        // process and save pages one by one
        //        for (int i = 0; i < document.Pages.Count; i++)
        //        {
        //            Page currentPage = document.Pages[i];

        //            // we use original page's width and height for image as well as default rendering settings
        //            using (Bitmap bitmap = currentPage.Render((int)currentPage.Width, (int)currentPage.Height, settings))
        //            {
        //                bitmap.Save(string.Format("{0}.png", i), ImageFormat.Png);
        //            }
        //        }
        //        // preview first rendered page
        //        Process.Start("0.png");
        //    }
        //}
       
        //--------------------------------------------------------------------

        public static string ExtrairTexto_PDF(string caminho)
        {
            using (PdfReader leitor = new PdfReader(caminho))
            {
                StringBuilder texto = new StringBuilder();
                for (int i = 1; i <= leitor.NumberOfPages; i++)
                {
                    texto.Append(PdfTextExtractor.GetTextFromPage(leitor, i));
                }
                return texto.ToString();
            }
        }


        //--------------------------------------------------------------------
        public static void converter()
        {
            try
            {
                string PdfFile = @"D:\tmp\ocr\1524.pdf";
                string PngFile = "Convert.png";
                List<string> Conversion = cs_pdf_to_image.Pdf2Image.Convert(PdfFile, PngFile);
                Bitmap Output = new Bitmap(PngFile);
                //PbConversion.Image = Output;
                Output.Save(@"d:\tmp\ocr\c.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }


        //-------------------------------------------------------------------

        //public static void convertPdfToImg()
        //{
        //    // Objeto de conversão
        //    PDFConvert converter = new PDFConvert();

        //    // Arquivo PDF selecionado de um OpenFileDialog
        //    string arquivo = @"D:\tmp\ocr\1524.pdf";

        //    // Local de saída do arquivo convertido
        //    string output = @"D:\tmp\ocr\nf_Scan_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".jpg";

        //    // Configurações de conversão
        //    converter.OutputToMultipleFile = false;
        //    converter.TextAlphaBit = 4;
        //    converter.FirstPageToConvert = 1;
        //    converter.LastPageToConvert = 1;
        //    converter.FitPage = false;
        //    converter.JPEGQuality = 10;
        //    converter.OutputFormat = "png16m";

        //    // Faz a conversão e retorna true se estiver tudo OK
        //    bool resultado = converter.Convert(arquivo, output);
        //}


        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        //-----------------------------------------------------------------------------------------
        //public static Bitmap ResizeImg(Image imgToResize, Size size)
        //{
        //    return new Bitmap(imgToResize, size);
        //}

        //----------------------------------------------------------------------------------------
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

        public static bool lerPdfFF(Bitmap myBitmap, int percWidth, int percHeight, int tamWidth, int tamHeight)
        {
            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(percWidth,percHeight, tamWidth, tamHeight);
            //System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth,282, tamWidth, tamHeight);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 5, cloneBitmap.Height * 5);


            cloneBitmapBig.Save(@"d:\tmp\ocr\d.png", System.Drawing.Imaging.ImageFormat.Png);

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
                {
                    //using (var img = Pix.LoadFromFile(testeImg))
                    using (var img = cloneBitmapBig)
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            texto = texto.Replace(" ", "");
                            texto = texto.Replace("\r", "");
                            texto = texto.Replace("\n", "");

                            int resultadoTexto = 0;
                            bool resultTexto = int.TryParse(texto, out resultadoTexto);

                            if (texto.Length == 8 && resultTexto == true)
                            {
                                Console.WriteLine("taxa leitura: {0}", page.GetMeanConfidence() * 100 + "%");
                                Console.WriteLine("Texto: \r\n{0} ", texto);
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Texto: \r\n{0} ", texto);
                                return false;
                                //lerPdf(myBitmap,75,6,200,55);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}: ", ex.Message);
                return false;
            }

        }

        public static bool lerPdfF(Bitmap myBitmap, int percWidth, int percHeight, int tamWidth, int tamHeight)
        {
            
            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth, myBitmap.Height / 100 * percHeight, tamWidth, tamHeight);
            //System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth,282, tamWidth, tamHeight);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 6, cloneBitmap.Height * 6);

            ////teste
            //Bitmap cloneBitmapBig1 = ResizeImgg(cloneBitmap, cloneBitmap.Width * 6, cloneBitmap.Height * 6);
            //Bitmap cloneBitmapBig2 = ResizeImgg(cloneBitmap, cloneBitmap.Width * 7, cloneBitmap.Height * 7);
            //Bitmap cloneBitmapBig3 = ResizeImgg(cloneBitmap, cloneBitmap.Width * 8, cloneBitmap.Height * 8);
            //Bitmap cloneBitmapBig4 = ResizeImgg(cloneBitmap, cloneBitmap.Width * 5, cloneBitmap.Height * 5);
            //cloneBitmapBig1.Save(@"d:\tmp\ocr\b1.png", System.Drawing.Imaging.ImageFormat.Png);
            //cloneBitmapBig2.Save(@"d:\tmp\ocr\b2.png", System.Drawing.Imaging.ImageFormat.Png);
            //cloneBitmapBig3.Save(@"d:\tmp\ocr\b3.png", System.Drawing.Imaging.ImageFormat.Png);
            //cloneBitmapBig4.Save(@"d:\tmp\ocr\b4.png", System.Drawing.Imaging.ImageFormat.Png);
            ////fim teste
            cloneBitmapBig.Save(@"d:\tmp\ocr\d.png", System.Drawing.Imaging.ImageFormat.Png);

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
                {
                    //using (var img = Pix.LoadFromFile(@"D:\tmp\ocr\z.png"))
                    using (var img = cloneBitmapBig)
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            texto = texto.Replace(" ", "");
                            texto = texto.Replace("\r", "");
                            texto = texto.Replace("\n", "");

                            int resultadoTexto = 0;
                            bool resultTexto = int.TryParse(texto, out resultadoTexto);

                            if (texto.Length == 8 && resultTexto == true)
                            {
                                Console.WriteLine("taxa leitura: {0}", page.GetMeanConfidence() * 100 + "%");
                                Console.WriteLine("Texto: \r\n{0} ", texto);
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Texto: \r\n{0} ", texto);
                                return false;
                                //lerPdf(myBitmap,75,6,200,55);
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}: ", ex.Message);
                return false;
            }

        }
        public static void lerPdf(Bitmap myBitmap, int percWidth, int percHeight, int tamWidth, int tamHeight)
        {
            System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * percWidth, myBitmap.Height / 100 * percHeight, tamWidth, tamHeight);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 5, cloneBitmap.Height * 5);


            cloneBitmapBig.Save(@"d:\tmp\ocr\d.png", System.Drawing.Imaging.ImageFormat.Png);

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
                {
                    //using (var img = Pix.LoadFromFile(testeImg))
                    using (var img = cloneBitmapBig)
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            texto = texto.Replace(" ", "");
                            texto = texto.Replace("\r", "");
                            texto = texto.Replace("\n", "");
                            if (texto.Length == 8)
                            {
                                Console.WriteLine("taxa leitura: {0}", page.GetMeanConfidence() * 100 + "%");
                                Console.WriteLine("Texto: \r\n{0} ", texto);
                            }
                            else
                            {
                                //lerPdf(myBitmap,75,6,200,55);
                                Console.WriteLine("taxa leitura: {0}", page.GetMeanConfidence() * 100 + "%");
                                Console.WriteLine("Texto: \r\n{0} ", texto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}: ", ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {

            Bitmap myBitmap =  pdftiff(@"D:\tmp\ocr\1505.pdf");
            //Bitmap myBitmap = pdftiff(@"D:\tmp\ocr\teste.png");

            //lerPdf(myBitmap,75,6,200,55);
            //lerPdf(myBitmap,78,6,200,60);
            //lerPdf(myBitmap, 78, 5, 200, 65);

            bool teste1 = lerPdfF(myBitmap, 75, 6, 200, 55);

            if (teste1 == false)
            {
                bool teste2 = lerPdfF(myBitmap, 78, 6, 200, 60);
                if(teste2 == false)
                {
                    bool teste3 = lerPdfF(myBitmap, 78, 5, 200, 64);
                    if(teste3 == false)
                    {
                        bool teste4 = lerPdfFF(myBitmap, 1216, 282, 200, 65);
                        Console.WriteLine(" NAO FOI POSSIVEL LER O NUMERO");

                        //for (int x = 1190; x < 1216; x++)
                        //{
                            for (int y = 278; y < 295; y++)
                            {
                                for (int xx = 185; xx < 216; xx++)
                                {
                                    for (int yy = 50; yy < 71; yy++)
                                    {
                                        bool teste5 = lerPdfFF(myBitmap, 1200, y, xx, yy);
                                        Console.WriteLine("x: " + 1200 + " - y: " + y + " - xx: " + xx + " - yy: " + yy);
                                        if (teste5 == true)
                                        {
                                            Console.WriteLine("ACHOU");
                                            break;

                                        }
                                    }
                                }
                            }

                        //}
                    }
                }
            }
            Console.ReadLine();


            ////Bitmap myBitmap = new Bitmap(@"D:\tmp\ocr\15195.tif");

            ////Bitmap myBitmapClone = (Bitmap)myBitmap.Clone();
            ////myBitmapClone.RotateFlip(RotateFlipType.Rotate180FlipNone);

            ////Rectangle cloneRect = new Rectangle(620, 150,300, 60);
            ////System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(404, 10, 106, 13);
            ////System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(1200, 275, 200, 55);

            ////System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * 75, 275, 200, 55);
            ////System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * 75, myBitmap.Height / 100 * 6, 200, 55);
            //System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * 78, myBitmap.Height / 1000 * 72, 200, 59);
            //System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            //Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            //Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 5, cloneBitmap.Height * 5);


            //cloneBitmapBig.Save(@"d:\tmp\ocr\d.png", System.Drawing.Imaging.ImageFormat.Png);


            ////int x = myBitmap.Width;
            ////int y = myBitmap.Height;
            ////for (int i = x / 100 * 75; i+200 <= x; i = i+10)
            ////{
            ////    for (int j = y / 100 * 6; j + 55 < y/100*20; j = j +10)
            ////    {
            ////        System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(i, j , 200, 55);
            ////        System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            ////        Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            ////        Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 5, cloneBitmap.Height * 5);


            ////        cloneBitmapBig.Save(@"d:\tmp\ocr\testeX" + i + "Y" + j + ".png", System.Drawing.Imaging.ImageFormat.Png);


            ////        using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
            ////        {
            ////            using (cloneBitmapBig)
            ////            {
            ////                using (var page = engine.Process(cloneBitmapBig))
            ////                {
            ////                    var texto = page.GetText();
            ////                    texto = texto.Replace(" ", "");
            ////                    texto = texto.Replace("\n", "");
            ////                    texto = texto.Replace("\r", "");
            ////                    //if (texto.Equals("00015195"))
            ////                    //{
            ////                        Console.WriteLine("testeX" + i + "Y" + j);
            ////                        Console.WriteLine("Texto: \r\n{0} ", texto);
            ////                        //cloneBitmapBig.Save(@"d:\tmp\ocr\testeX" + i + "Y" + j + ".png", System.Drawing.Imaging.ImageFormat.Png);
            ////                        //break;
            ////                    //}

            ////                }
            ////            }
            ////        }

            ////    }

            ////}


            ////System.Drawing.Rectangle cloneRect = new System.Drawing.Rectangle(myBitmap.Width / 100 * 75, myBitmap.Height / 100 * 6, 200, 55);
            ////System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            ////Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            ////Bitmap cloneBitmapBig = ResizeImgg(cloneBitmap, cloneBitmap.Width * 5, cloneBitmap.Height * 5);


            ////cloneBitmapBig.Save(@"d:\tmp\ocr\e.png", System.Drawing.Imaging.ImageFormat.Png);




            ////convertPdfToImg();

            //////le so texto no pdf
            ////try
            ////{
            ////    Console.WriteLine(ExtrairTexto_PDF(@"d:\tmp\ocr\nf.pdf"));
            ////}
            ////catch(Exception e)
            ////{
            ////    Console.WriteLine(e);
            ////}
            ////finally
            ////{
            ////    Console.ReadLine();
            ////}


            ////var testeImg = @"d:\tmp\ocr\d.png";
            //try
            //{
            //    using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
            //    {
            //        //using (var img = Pix.LoadFromFile(testeImg))
            //        using (var img = cloneBitmapBig)
            //        {
            //            using (var page = engine.Process(img))
            //            {
            //                var texto = page.GetText();
            //                texto = texto.Replace(" ", "");
            //                texto = texto.Replace("\r", "");
            //                texto = texto.Replace("\n", "");
            //                if (texto.Length == 8)
            //                {
            //                    Console.WriteLine("taxa leitura: {0}", page.GetMeanConfidence() * 100 + "%");
            //                    Console.WriteLine("Texto: \r\n{0} ", texto);
            //                }
            //                Console.WriteLine("taxa leitura: {0}", page.GetMeanConfidence() * 100 + "%");
            //                Console.WriteLine("Texto: \r\n{0} ", texto);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Erro: {0}: ", ex.Message);
            //}
            //finally
            //{
            //    Console.ReadLine();
            //}
        }
    }
}
