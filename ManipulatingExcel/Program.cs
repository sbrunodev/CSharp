using System;
using System.Collections.Generic;
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

            DataSetToDataTable(resultDataSet);
            Console.ReadKey();   
        }

        public static DataTable DataSetToDataTable(DataSet resultDataSet)
        {
            var dt = resultDataSet.Tables;

            var dtPlanilhaPessoas = resultDataSet.Tables[0];

            List<string> columnsList = new List<string>();

            for (int i = 0; i < dtPlanilhaPessoas.Columns.Count; i++)
                columnsList.Add(dtPlanilhaPessoas.Columns[i].ToString());

            foreach (DataRow dr in dtPlanilhaPessoas.Rows)
            {
                foreach(string column in columnsList)
                {
                    Console.WriteLine(column);
                    Console.WriteLine(dr[column].ToString());
                }
            }


            return dtPlanilhaPessoas;
        }
    }
}
