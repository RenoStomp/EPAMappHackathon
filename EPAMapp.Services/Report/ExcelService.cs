using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YourProject.Services
{
    public static class ExcelService
    {
        public static byte[] ExportToExcel<TEntity>(List<TEntity> data) where TEntity : class
        {
            byte[] result = null;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                var properties = typeof(TEntity).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    workSheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                var rows = data.ToList();
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < properties.Length; j++)
                    {
                        var value = properties[j].GetValue(rows[i], null);
                        workSheet.Cells[i + 2, j + 1].Value = value;
                    }
                }

                result = package.GetAsByteArray();
            }

            return result;
        }
    }
}
