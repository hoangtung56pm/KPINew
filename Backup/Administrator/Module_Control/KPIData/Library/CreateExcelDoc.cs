using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;

namespace VmgPortal.Modules.KPIData.Library
{
    public class CreateExcelDoc
    {
        private static Excel.Worksheet worksheet = null;
        private static Excel.Range workSheet_range = null;
        public CreateExcelDoc(int sheet, Excel.Workbook workbook, string name)
        {
            createDoc(sheet, workbook, name);
        }
        public void createDoc(int sheet, Excel.Workbook workbook, string name)
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                worksheet = (Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//.Sheets[sheet];
                worksheet.Name = name;
            }
            catch (Exception e)
            {
            }
            finally
            {
            }
        }

        public void createHeaders(int row, int col, string htext, string cell1,
        string cell2, int mergeColumns, string b, bool font, int size, string
        fcolor)
        {
            worksheet.Cells[row, col] = htext;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            //workSheet_range.Merge(mergeColumns);
            switch (b)
            {
                case "YELLOW":
                    workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                    break;
                case "GRAY":
                    workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                    break;
                case "GAINSBORO":
                    workSheet_range.Interior.Color =
            System.Drawing.Color.Gainsboro.ToArgb();
                    break;
                case "Turquoise":
                    workSheet_range.Interior.Color =
            System.Drawing.Color.Turquoise.ToArgb();
                    break;
                case "PeachPuff":
                    workSheet_range.Interior.Color =
            System.Drawing.Color.PeachPuff.ToArgb();
                    break;
                default:
                    //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
                    break;
            }

            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.Font.Bold = font;
            workSheet_range.ColumnWidth = size;
            if (fcolor.Equals(""))
            {
                workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();
            }
            else
            {
                workSheet_range.Font.Color = System.Drawing.Color.Red;
            }
        }

        public void addData(int row, int col, string data,
            string cell1, string cell2, string format)
        {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.NumberFormat = format;
        }

        public static void SaveExcel(string filePath, Excel.Workbook workbook)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                workbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                workbook.Close(true, misValue, misValue);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

