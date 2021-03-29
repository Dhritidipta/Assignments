using OfficeOpenXml;
using System;
using System.IO;

namespace ExcelRW
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string path = @"F:\BCT Training\ExcelRead.xlsx";
            var filePath = new FileInfo(path);
            try
            {
                using (var package = new ExcelPackage(filePath))
                {
                    var ws1 = package.Workbook.Worksheets["Marksheet"];
                    var ws2 = package.Workbook.Worksheets["Output"];

                    int rowCountSheet2 = 2;
                            for (int i = 2; i <= 10; i++)
                            {
                      
                                double percentageMark = int.Parse(ws1.Cells[i, 2].Value.ToString()) / 10;
                                if (percentageMark > 35)
                                {
                                    ws2.Cells[rowCountSheet2, 1].Value = ws1.Cells[i, 1].Value;
                                    ws2.Cells[rowCountSheet2, 2].Value = percentageMark;
                                    rowCountSheet2++;
                                }
                            }

                    package.Save();

                }
            }

            catch(Exception e)
            {
                Console.WriteLine("Program stopped due to an error, the error is "+ e.Message);
            }

        }
    }
}
