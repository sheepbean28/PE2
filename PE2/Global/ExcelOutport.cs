using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

using System.Drawing;
using System.Net;
using System.Drawing.Imaging;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Spreadsheet;



namespace PE2
{
    public partial class ExcelOutport
    {
       

        //public static MemoryStream RenderDataTableByOpenXML(DataTable dt, List<string> LstColnums)
        //{

        //    var memoryStream = new MemoryStream();
        //    using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
        //    {
        //        var workbookPart = document.AddWorkbookPart();
        //        workbookPart.Workbook = new Workbook();

        //        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //        worksheetPart.Worksheet = new Worksheet(new SheetData());

        //        var sheets = workbookPart.Workbook.AppendChild(new Sheets());
        //        sheets.Append(new Sheet()
        //        {
        //            Id = workbookPart.GetIdOfPart(worksheetPart),
        //            SheetId = 1,
        //            Name = "Sheet 1"
        //        });
        //        var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

        //        //title
        //        Row TitleRow = new Row();
        //        foreach (DataColumn column in dt.Columns)
        //        {
        //            if (LstColnums.Exists(X => X == column.ColumnName))
        //                TitleRow.Append(new Cell() { CellValue = new CellValue(ConvertHeaderToChinese(column.ColumnName)), DataType = CellValues.String });
                    
        //            // 也可以用單一欄位逐各插入
        //        }
        //        sheetData.AppendChild(TitleRow);
        //        //內容
               
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            Row Row = new Row();
        //            foreach (DataColumn column in dt.Columns)
        //            {
        //                if (LstColnums.Exists(X => X == column.ColumnName))
        //                {
        //                    if (column.ColumnName == "Type")
        //                    {
        //                        string result = row[column].ToString();
        //                        if (result == "0")
        //                            result = "進貨";
        //                        if (result == "1")
        //                            result = "耗材領用";
        //                        if (result == "2")
        //                            result = "耗材退庫";
        //                        if (result == "3")
        //                            result = "外單位借出";
        //                        if (result == "4")
        //                            result = "外單位歸還";

        //                        Row.Append(new Cell() { CellValue = new CellValue(result), DataType = CellValues.String});

        //                    }
        //                    else
        //                    {
        //                        Row.Append(new Cell() { CellValue = new CellValue(row[column.ColumnName].ToString()), DataType = CellValues.String });
        //                    }
        //                }
                           
                        
                        
        //            }
        //            sheetData.AppendChild(Row);
        //        }
             

        //    }
        //    return memoryStream;
        //}
        //public static MemoryStream RenderDataTableByOpenXML(DataTable dt)
        //{

        //    var memoryStream = new MemoryStream();
        //    using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
        //    {
        //        var workbookPart = document.AddWorkbookPart();
        //        workbookPart.Workbook = new Workbook();

        //        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //        worksheetPart.Worksheet = new Worksheet(new SheetData());

        //        var sheets = workbookPart.Workbook.AppendChild(new Sheets());
        //        sheets.Append(new Sheet()
        //        {
        //            Id = workbookPart.GetIdOfPart(worksheetPart),
        //            SheetId = 1,
        //            Name = "Sheet 1"
        //        });
        //        var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

        //        //title
        //        Row TitleRow = new Row();
        //        foreach (DataColumn column in dt.Columns)
        //        {
        //            // 也可以用單一欄位逐各插入
        //            TitleRow.Append(new Cell() { CellValue = new CellValue(ConvertHeaderToChinese(column.ColumnName)), DataType = CellValues.String });

        //        }
        //        sheetData.AppendChild(TitleRow);
        //        //內容
               
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            Row Row = new Row();
        //            foreach (DataColumn column in dt.Columns)
        //            {
        //                   Row.Append(new Cell() { CellValue = new CellValue(row[column.ColumnName].ToString()), DataType = CellValues.String });
        //            }
        //            sheetData.AppendChild(Row);
        //        }
               

        //    }
        //    return memoryStream;
        //}

        public static void OutportToClient(MemoryStream ms, string FileName)
        {

            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + FileName + ".xlsx"));
            ms.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            ms.Close();
            ms.Dispose();
        }
        public static string ConvertHeaderToChinese(string ColumnName)
        {
            string ChineseName = string.Empty;
            if (ColumnName == "Supplies_no")
                ChineseName = "條碼編號";
            else if (ColumnName == "Supplies_Name")
                ChineseName = "名稱";
            else if (ColumnName == "Supplies_Price")
                ChineseName = "價格";
            else if (ColumnName == "Supplies_Add")
                ChineseName = "入庫數量";
            else if (ColumnName == "Supplies_In")
                ChineseName = "退庫";
            else if (ColumnName == "Supplies_Out")
                ChineseName = "領用";
            else if (ColumnName == "Supplies_R_IN")
                ChineseName = "歸還";
            else if (ColumnName == "Supplies_R_OUT")
                ChineseName = "外借";
            else if (ColumnName == "Supplies_Limit")
                ChineseName = "不足";
            else if (ColumnName == "Supplies_Warm")
                ChineseName = "警告";
            else if (ColumnName == "Supplies_Stock")
                ChineseName = "庫存";
            else if (ColumnName == "Note")
                ChineseName = "備註";
            else if (ColumnName == "Supplies_sn")
                ChineseName = "圖片";
            else if (ColumnName == "Supplies_date")
                ChineseName = "領取日期";
            else if (ColumnName == "User_name")
                ChineseName = "領取者";
            else if (ColumnName == "Quantity")
                ChineseName = "領取數量";
            else if (ColumnName == "Type")
                ChineseName = "領用方式";
            else
                ChineseName = ColumnName;
            return ChineseName;


        }
    }
}