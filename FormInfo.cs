using OpenCvSharp;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;

namespace FormOCR
{
    public class OrderData
    {
        public string customerName;
        public string delivDate;
        public string useDate;
        public string itemName;
        public string quant;
        public string unit;

        public OrderData(string customerName,string delivDate,string useDate,string itemName,string quant,string unit)
        {
            this.customerName = customerName;
            this.delivDate = delivDate;
            this.useDate = useDate;
            this.itemName = itemName;
            this.quant = quant;
            this.unit = unit;
        }
    }

    public class FormInfo
    {
        public FileInfo FormInfoXML;
        public List<string> FormNames;

        public FileInfo imageFile;
        public List<Rect> ROIs;
        public List<OrderData> orderdatas;

        public FormInfo(FileInfo xmlfile)
        {
            this.FormInfoXML = xmlfile;
        }

        public void searchByName(string formName)
        {
            var elements = getxelements(FormInfoXML.FullName, formName);
            if(elements.Count() > 0)
            {
                Debug.WriteLine("detect " + elements.Count().ToString() + " forms");
            }
            else
            {
                Debug.WriteLine("no detect ");
            }
        }


        public IEnumerable<XElement> getxelements(string xmlfile, string formName)
        {
            XElement xe = XElement.Load(xmlfile);
            var formInfos = xe.Elements("FormInfo");
            var result = formInfos.Where(x => x.Element("formName").Value == formName);
            return result;
        }

        public void elementListup(IEnumerable<XElement> elements)
        {

        }


    }
}

