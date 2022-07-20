using System;
using OpenCvSharp;

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
        public string FormName;
        public FileInfo imageFile;
        public List<Rect> ROIs;
        public List<OrderData> orderdatas;

        public FormInfo(string formName,FileInfo imageFile,List<Rect> rois)
        {
            this.FormName = formName;
            this.imageFile = imageFile;
            this.ROIs = rois;

        }
    }
}

