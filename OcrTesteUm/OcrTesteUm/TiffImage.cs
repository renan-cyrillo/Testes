using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_pdf_to_image;
using PdfToImage;



namespace OcrTesteUm
{
    class TiffImage
    {
        private string myPath;
        private Guid myGuid;
        private FrameDimension myDimension;
        public ArrayList myImages = new ArrayList();
        private int myPageCount;
        private Bitmap myBMP;

        public TiffImage(string path)
        {
            MemoryStream ms;
            Image myImage;

            myPath = path;
            FileStream fs = new FileStream(myPath, FileMode.Open);
            myImage = Image.FromStream(fs);
            myGuid = myImage.FrameDimensionsList[0];
            myDimension = new FrameDimension(myGuid);
            myPageCount = myImage.GetFrameCount(myDimension);
            for (int i = 0; i < myPageCount; i++)
            {
                ms = new MemoryStream();
                myImage.SelectActiveFrame(myDimension, i);
                myImage.Save(ms, ImageFormat.Bmp);
                myBMP = new Bitmap(ms);
                myImages.Add(myBMP);
                ms.Close();
            }
            fs.Close();
        }

        //string PdfFile = @"D:\tmp\ocr\1505.pdf";
        //string PngFile = "Convert.png";
        //List<string> Conversion = cs_pdf_to_image.Pdf2Image.Convert(PdfFile, PngFile);
        //Bitmap Output = new Bitmap(PngFile);
        ////PbConversion.Image = Output;
        //Output.Save(@"D:\tmp\ocr\1505IMG.png");
    }
}
