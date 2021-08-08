using System.Data;
using System.IO;
using ExcelDataReader;

namespace ManipulatingExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                ExcelDataReader
                ExcelDataReader.DataSet
            */

            FileStream fStream = File.Open(@"C:\temp\Dados.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
            DataSet resultDataSet = excelDataReader.AsDataSet();
            excelDataReader.Close();
        }
    }
}
