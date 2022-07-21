using OpenCvSharp;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FormOCR
{
    public class MainClass
    {
        static void Main()
        {
            List<Rect> rects = new List<Rect>();

            var elem = getxelements(@"CustomerInfo.xml", "Mako4thForm2");

            int rx = int.Parse(elem.Elements("delivDateX").First().Value);
            int ry = int.Parse(elem.Elements("firstLowY").First().Value);
            int rw = int.Parse(elem.Elements("delivDateW").First().Value);
            int rh = int.Parse(elem.Elements("rowHeight").First().Value);

            rects.Add(new Rect(rx, ry, rw, rh));
            Console.WriteLine(rects.First().ToString());
            showElements(elem);
        }
        static IEnumerable<XElement> getxelements(string xmlfile,string formName)
        {
            XElement xe = XElement.Load(xmlfile);
            var formInfos = xe.Elements("FormInfo");
            var result = formInfos.Where(x => x.Element("formName").Value == formName);
            return result;
        }

        static void showElements(IEnumerable<XElement> elements)
        {
            string elemCount = elements.Count().ToString();
            Console.WriteLine("detect " + elemCount + " forms.");

            foreach (var elem in elements)
            {
                Console.WriteLine("===============");

                var elems = elem.Elements();

                foreach (var element in elems)
                {
                    Console.WriteLine(element.Name + "=" + element.Value);
                }
            }
        }
    }
}