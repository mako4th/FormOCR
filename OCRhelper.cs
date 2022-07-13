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
            using Mat mat = new Mat(info.imageFile.FullName);
            string outputText = "";
            Rect[] componentRects = new Rect[10];
            string?[] componentTexts = new string[100];
            float[] componentConfidences = new float[10];


            foreach (Rect rect in info.ROIs)
            {
                Mat roi = new Mat(mat, rect);
                ot.Run(roi, out outputText, out componentRects, out componentTexts, out componentConfidences);
            }
        }

    }
}