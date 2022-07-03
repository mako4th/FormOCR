using System;
using OpenCvSharp;
using OpenCvSharp.Text;

namespace FormOCR
{
    public class OCRhelper
    {
        OCRTesseract ot;

        public OCRhelper()
        {
            
        }


        public OCRTesseract setWhiteList(String path)
        {
            if (!ot.Equals(null))
            {
                ot.Dispose();
            }

            string whitelist = "";
            using(StreamReader reader = new StreamReader(path))
            {
                whitelist = reader.ReadToEnd();
            }
            ot =  OCRTesseract.Create("./", "jpn", whitelist, 1, 6);
            return ot;
        }

        public void ocrRun(FormInfo info)
        {
            using (Mat mat = new Mat(info.file.FullName))
            {
                string word = "";




            }
        }

    }
}