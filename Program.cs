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
            Console.WriteLine(elem.Elements("firstLowY").First().Value);
            //showElements(elem);

            //string name = form.Element("name").Value　?? "";
            //string delivDateX = form.Element("delivDateX").Value;
            //string useDateX = form.Element("useDateX").Value;
            //string itemNameX = form.Element("i")



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