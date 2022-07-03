using OpenCvSharp;

namespace cvsharpWork
{
    public class Class1
    {
        static void Main(string[] args)
        {
            FileInfo orderFormImage = new FileInfo("Page0001.png");

            Mat m = new Mat(orderFormImage.FullName);
            Console.WriteLine("imageWidth = " + m.Width.ToString() + "\nimageHight = " + m.Height.ToString());



            //FileInfo patternImage = new FileInfo("usuage.png");
            //string stDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string filename = "result.jpg";
            //FileInfo res = new FileInfo(Path.Combine(stDesktop, filename));
            FileInfo whiteListFile = new FileInfo("whiteList.txt");

            textRecognizer tr = new textRecognizer();

            String whiteList = "";
            using (StreamReader reader = new StreamReader(whiteListFile.FullName))
            {
                whiteList = reader.ReadToEnd();
            }

            String st = tr.simpleRecognition(new FileInfo("Page0001.png"), "使用日");
            Console.WriteLine(st);

            return;
        }
    }
  //  OEM_TESSERACT_ONLY,           // Run Tesseract only - fastest; deprecated
  //267   OEM_LSTM_ONLY,                // Run just the LSTM line recognizer.
  //268   OEM_TESSERACT_LSTM_COMBINED,  // Run the LSTM recognizer, but allow fallback
  //269                                 // to Tesseract when things get difficult.
  //270                                 // deprecated
  //271   OEM_DEFAULT,                  // Specify this mode when calling init_*(),
  //272                                 // to indicate that any of the above modes
  //273                                 // should be automatically inferred from the
  //274                                 // variables in the language-specific config,
  //275                                 // command-line configs, or if not specified
  //276                                 // in any of the above should be set to the
  //277                                 // default OEM_TESSERACT_ONLY.
  //278   OEM_COUNT                     // Number of OEMs

    class textRecognizer
    {
        public String simpleRecognition(FileInfo targetFile,String whiteList)
        {
            String res = "";
            var ot = OpenCvSharp.Text.OCRTesseract.Create("./", "jpn", whiteList,1,6);
            String word = new String("");
            Rect[] rects = new Rect[10];
            string[]? strings = new string[100];
            float[] confs = new float[10];

            using (Mat mat = new Mat(targetFile.FullName))
            {
                ot.Run(mat, out word, out rects, out strings, out confs);
            }


            res = word.Replace(" ", "");
            ot.Dispose();
            return res;
        }
    }

    class class2
    {
        public void ocrtext()
        {
            string itemName = "Page0001";
            FileInfo orderFormImage = new FileInfo("Page0001.png");
            FileInfo patternImage = new FileInfo(itemName + ".png");
            string stDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "result.jpg";
            FileInfo res = new FileInfo(Path.Combine(stDesktop, filename));
            FileInfo whiteListFile = new FileInfo("whiteList.txt");

            using (Mat mat = new Mat(patternImage.FullName))
                using(Mat ofi = new Mat(orderFormImage.FullName))
            {
                var ot = OpenCvSharp.Text.OCRTesseract.Create("./","jpn",loadWhiteList(whiteListFile),1,6);
                String word = new string("testtest  ffsdfhsdfghsfdghsdfhsdfh");
                Rect[] rects = new Rect[10];
                string[]? strings = new string[100];
                float[] confs = new float[10];

                Rect roiRect = new Rect(new Point(600, 500), new Size(800, 50));
                Mat roi = new Mat(mat, roiRect);
                Mat roi1 = new Mat(mat, new Rect(new Point(600, 500), new Size(110, 50)));

                ot.Run(roi, out word, out rects, out strings, out confs);

                String outword = word.Replace(" ", "");
                Console.WriteLine(outword);
                Console.WriteLine("終了");
                ot.Dispose();

                //ProcessStartInfo psi = new ProcessStartInfo(res.FullName);
                //psi.UseShellExecute = true;
                //Process p = Process.Start(psi);
                //Rect rect = new Rect(maxloc.X, maxloc.Y, template.Width, template.Height);
                Cv2.Rectangle(mat, roiRect, new OpenCvSharp.Scalar(0, 0, 255), 2);



                string windowName = "showWindow";
                Cv2.NamedWindow(windowName, WindowFlags.Normal | WindowFlags.KeepRatio);
                Cv2.ImShow(windowName, mat);// new Mat(res.FullName));
                Cv2.ImShow("2", roi1);
                Cv2.WaitKey();

            }
            return;
        }


        void templateMatch(string itemName, FileInfo orderFormImage, FileInfo patternImage, FileInfo outfile)
        { 
            using (Mat mat = new Mat(orderFormImage.FullName))
            using (Mat template = new Mat(patternImage.FullName))
            using (Mat result = new Mat())
            {

                Cv2.MatchTemplate(mat, template, result, TemplateMatchModes.CCoeffNormed);
                Cv2.Threshold(result, result, 0.7, 1.0, ThresholdTypes.Tozero);

                Point minloc, maxloc;
                double minval, maxval;
                double threshold = 0.6;

                bool tf = true;
                while (tf)
                {
                    Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                    tf = maxval >= threshold;
                    if (tf)
                    {
                        Rect rect = new Rect(maxloc.X, maxloc.Y, template.Width, template.Height);
                        Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                        Cv2.PutText(mat, itemName, new Point(maxloc.X + template.Width + 4, maxloc.Y + template.Height), HersheyFonts.HersheySimplex, 1.0, new Scalar(0, 0, 255));

                        Rect outRect;
                        Cv2.FloodFill(result, maxloc, new OpenCvSharp.Scalar(0), out outRect, new OpenCvSharp.Scalar(0.1),
                                    new OpenCvSharp.Scalar(1.0), FloodFillFlags.Link4);
                    }
                }
                Cv2.ImWrite(outfile.FullName, mat);
            }
        }
    }
}