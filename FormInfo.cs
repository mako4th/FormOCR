using System;
using OpenCvSharp;

namespace FormOCR
{
    public class FormInfo
    {
        public FileInfo file;
        public Rect[] RoiList;

        public FormInfo(FileInfo file,Rect[] RoiList)
        {
            this.file = file;
            this.RoiList = RoiList;
        }
    }
}

