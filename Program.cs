

namespace FormOCR
{
    public class MainClass
    {
        static void Main()
        {
            FileInfo fi = new FileInfo(@"FormInfo.xml");
            FormInfo f = new FormInfo(fi);
            f.searchByName("Mako4thForm1");
        }


       
    }
}