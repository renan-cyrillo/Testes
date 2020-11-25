using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
namespace OcrTesteDois
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //private Tesseract ocrr;
            //ocrr = new Tesseract("", "por", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);


            testeOCR tOCR = new testeOCR();
            TesteOcrDois testeOCR = new TesteOcrDois();
            //tOCR.lerPdfOCR(@"D:\tmp\ocr\15195P.png"); //funcionando

            testeOCR.lerPdfOCR(@"D:\tmp\ocr\15195.pdf");
            //testeOCR.PDFtoIMG(@"D:\tmp\ocr\1505.pdf");



        }

    }
}
