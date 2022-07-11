using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;

namespace PE2.Excel
{
    public partial class ObjExcel
    {
        public static MemoryStream CreateExcelFile(DataTable srcTable)
        {

            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();
            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);

            #region 標題CSS
            //欄位為數值 注意不可為字串
            HSSFCellStyle csHeader = (HSSFCellStyle)workbook.CreateCellStyle();
            //啟動多行文字
            //cs.WrapText = true;
            //文字置中
            csHeader.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            csHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //框線樣式及顏色
            csHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;
            csHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            csHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            csHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            //背景顏色
            HSSFFont fontHeader = (HSSFFont)workbook.CreateFont();
            //字體顏色
            fontHeader.Color = NPOI.HSSF.Util.HSSFColor.Blue.Index;
            //字體粗體
            fontHeader.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //字體尺寸
            fontHeader.FontHeightInPoints = 12;
            csHeader.SetFont(fontHeader);

            //欄位為數值 注意不可為字串
            HSSFCellStyle csHeaderBG = (HSSFCellStyle)workbook.CreateCellStyle();
            //啟動多行文字
            //cs.WrapText = true;
            //文字置中
            csHeaderBG.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            csHeaderBG.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //框線樣式及顏色
            csHeaderBG.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;
            csHeaderBG.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            csHeaderBG.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            csHeaderBG.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            //背景顏色
            fontHeader.FontHeightInPoints = 12;
            //背景顏色
            csHeaderBG.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Orange.Index;
            csHeaderBG.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
            csHeaderBG.SetFont(fontHeader);


            #endregion
            #region 內容CSS
            //欄位為數值 注意不可為字串
            HSSFCellStyle csBlueFont = (HSSFCellStyle)workbook.CreateCellStyle();
            //啟動多行文字
            //cs.WrapText = true;
            //文字置中
            csBlueFont.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            csBlueFont.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //框線樣式及顏色
            csBlueFont.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;
            csBlueFont.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            csBlueFont.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            csBlueFont.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            //背景顏色
            HSSFFont fontBlue = (HSSFFont)workbook.CreateFont();
            //字體顏色
            fontBlue.Color = NPOI.HSSF.Util.HSSFColor.Blue.Index;
            //字體粗體
            fontBlue.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //字體尺寸
            fontBlue.FontHeightInPoints = 11;
            csBlueFont.SetFont(fontBlue);


            //欄位為數值 注意不可為字串
            HSSFCellStyle csBlackFont = (HSSFCellStyle)workbook.CreateCellStyle();
            //啟動多行文字
            //cs.WrapText = true;
            //文字置中
            csBlackFont.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            csBlackFont.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //框線樣式及顏色
            csBlackFont.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;
            csBlackFont.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            csBlackFont.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            csBlackFont.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            //背景顏色
            HSSFFont fontBlack = (HSSFFont)workbook.CreateFont();
            //字體顏色
            fontBlack.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;
            //字體粗體
            fontBlack.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //字體尺寸
            fontBlack.FontHeightInPoints = 11;
            csBlackFont.SetFont(fontBlack);


            #endregion

            // handling header.
            foreach (DataColumn column in srcTable.Columns)
            {
                string Cn = string.Empty;
                Cn = column.ColumnName;
                headerRow.CreateCell(column.Ordinal).SetCellValue(Cn);
                headerRow.GetCell(headerRow.Cells.Count - 1).CellStyle = csHeader;
                sheet.SetColumnWidth(headerRow.Cells.Count - 1, 4000);
            }


            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in srcTable.Rows)
            {
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);

                foreach (DataColumn column in srcTable.Columns)
                {

                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    dataRow.GetCell(dataRow.Cells.Count - 1).CellStyle = csBlackFont;
                }

                rowIndex++;
            }

            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            stream.Flush();
            stream.Position = 0;

            sheet = null;
            headerRow = null;
            //workbook = null;
            return stream;
        }
        public static void OutportExcel(DataTable srcTable, string FileName)
        {
            MemoryStream ms = CreateExcelFile(srcTable);
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + FileName + ".xls"));
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            ms.Close();
            ms.Dispose();
        }
    }
}