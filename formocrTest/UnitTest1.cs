using FormOCR;
using System.Diagnostics;
using OpenCvSharp;
using System.Xml.Linq;

using Xunit.Abstractions;

namespace formocrtest;


public class UnitTest1
{
    readonly ITestOutputHelper oh;

    public UnitTest1(ITestOutputHelper h)
    {
        oh = h;
    }

    [Fact]
    public void elementListup()
    {
        FormInfo info = new FormInfo();
        List<Rect> rects = new List<Rect>();

        var elements = info.getxelements(@"FormInfo.xml", "Mako4thForm2");

        if(elements.Count() > 0)
        {
            oh.WriteLine("detect " + elements.Count().ToString() + " forms");

            foreach (var elem in elements)
            {
                oh.WriteLine("===============");
                var elems = elem.Elements();
                foreach (var el in elems)
                {
                    oh.WriteLine(el.Name + "=" + el.Value);
                }
                int rx = int.Parse(elements.Elements("delivDateX").First().Value);
                int ry = int.Parse(elements.Elements("firstLowY").First().Value);
                int rw = int.Parse(elements.Elements("delivDateW").First().Value);
                int rh = int.Parse(elements.Elements("rowHeight").First().Value);

                rects.Add(new Rect(rx, ry, rw, rh));
            }


        }
        else
        {
            oh.WriteLine("no detect");

        }

        foreach(Rect rec in rects)
        {
            oh.WriteLine(rec.ToString());
        }

        FileInfo fi = new FileInfo(@"sampleImages/orderForm/Page0001.png");
        using (Mat mat = new Mat(fi.FullName))
        {
            Cv2.ImShow("window",mat);
        }
        Cv2.WaitKey();
    }
}