using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QuanLyKhoHang.Model;

namespace QuanLyKhoHang.Utils
{
    public class ExcelExporter
    {
        public static void ExportToExcel(List<MaterialModel> materials, string filePath)
        {
            IWorkbook workbook;
            ISheet sheet;

            if (File.Exists(filePath))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    workbook = new XSSFWorkbook(fileStream);
                    sheet = workbook.CreateSheet(DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));
                }
            }
            else
            {
                workbook = new XSSFWorkbook();
                sheet = workbook.CreateSheet("Danh sách nguyên liệu");
            }

            // Tạo tiêu đề nếu tạo sheet mới
            if (sheet.LastRowNum == 0)
            {
                IRow headerRow = sheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("ID");
                headerRow.CreateCell(1).SetCellValue("Tên nguyên liệu");
                headerRow.CreateCell(2).SetCellValue("Số lượng");
                headerRow.CreateCell(3).SetCellValue("Ngày nhập");
            }

            int lastRow = sheet.LastRowNum;
            for (int i = 0; i < materials.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(lastRow + i + 1);
                dataRow.CreateCell(0).SetCellValue(materials[i].id);
                dataRow.CreateCell(1).SetCellValue(materials[i].name);
                dataRow.CreateCell(2).SetCellValue(materials[i].quantity);

                string formattedDate = materials[i].createdAt.ToString("dd-MM-yyyy");
                dataRow.CreateCell(3).SetCellValue(formattedDate);

                ICellStyle cellStyle = workbook.CreateCellStyle();
                cellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("dd-MM-yyyy");
                dataRow.GetCell(3).CellStyle = cellStyle;
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }

            Console.WriteLine($"Đã xuất dữ liệu ra file Excel: {filePath}");
        }
    }


}
