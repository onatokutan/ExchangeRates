using System.Data.Common;
using System.Xml;

internal class Program
{
    private static void Main()
    {
        DateTime curDate = DateTime.Now;
        var link = "https://www.tcmb.gov.tr/kurlar/today.xml";
        var xmlCur = new XmlDocument();
        xmlCur.Load(link);
        string curUsd = xmlCur.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/BanknoteSelling").InnerXml;
        Console.WriteLine("{0} SalePrice : {1} " , curDate, curUsd );
        int counter = 30;
        while (counter !=0 )
        {
            curDate = curDate.AddDays(-1);
            counter--;
            link = "https://www.tcmb.gov.tr/kurlar/"+curDate.ToString("yyyy")+curDate.ToString("MM")+"/"+curDate.ToString("dd")+curDate.ToString("MM")+curDate.ToString("yyyy")+".xml";
            try{
                xmlCur.Load(link);
                curUsd = xmlCur.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/BanknoteSelling").InnerXml;
                Console.WriteLine("{0} SalePrice : {1} " , curDate, curUsd );
            }
            catch (Exception e)
            {
                //Console.WriteLine(curDate + " Hata : " + e.Message);
                        }
            }
        Console.WriteLine("End");
        Console.ReadLine();
    }
}