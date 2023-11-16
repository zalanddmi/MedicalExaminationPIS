using OfficeOpenXml;

namespace ServerME.Utils
{
    public class ExcelConverter
    {
        public static byte[] GenerateExcelFile(List<string[]> data, string[] columnNames)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var exPac = new ExcelPackage();
            var worksheet = exPac.Workbook.Worksheets.Add("animal");

            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1].Value = columnNames[j];
            }
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = data[i][j + 1];
                }
            }

            worksheet.Cells.AutoFitColumns();
            return exPac.GetAsByteArray();
        }
    }
}
