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
    }

    public class FormInfo
    {
        public string FormName;
        public FileInfo imageFile;
        public List<Rect> ROIs;
        public List<OrderData> orderdatas;
    }
}

