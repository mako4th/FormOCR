# FormOCR

事前準備  
注文フォーム（複数種類）の読み取り位置情報(ROI)をcsvで作成する。  
  
    public List<Rect> ROILow{
    
    }
    public List<>


スキャン画像から顧客名を読み取る。  
顧客名からROI情報を取得する。

入力画像から読み取るための情報  

## 出力
入力画像から読み取ったデータ    
  
    public class orderDatas
    {
        public List<orderData>;
    }
    public class orderData
    {
        public string customerName;
        public string delivDate;
        public string useDate;
        public string itemName;
        public string quant;
        public string unit;
    }



whiteListの読み込み  
OCRTesseract.Create  

対象画像の読み込み  
roi[]の読み込み  
roiでループ  
出力  


<hr>

VisualStudio for Mac 2022  
OpenCvSharp4  
OpenCvSharp4.runtime.osx.10.15-x64

