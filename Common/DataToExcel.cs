using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel;
namespace Maticsoft.Common
{
    /// <summary>
    /// 紱釬EXCEL絳堤杅擂惆桶腔濬
    /// Copyright (C) Maticsoft
    /// </summary>
    public class DataToExcel
    {
        public DataToExcel()
        {
        }

        #region 紱釬EXCEL腔珨跺濬(剒猁Excel.dll盓厥)

        private int titleColorindex = 15;
        /// <summary>
        /// 梓枙掖劓伎
        /// </summary>
        public int TitleColorIndex
        {
            set { titleColorindex = value; }
            get { return titleColorindex; }
        }

        private DateTime beforeTime;			//Excel雄眳奀潔
        private DateTime afterTime;				//Excel雄眳綴奀潔

        #region 斐膘珨跺Excel尨瞰
        /// <summary>
        /// 斐膘珨跺Excel尨瞰
        /// </summary>
        public void CreateExcel()
        {
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Cells[1, 1] = "菴1俴菴1蹈";
            excel.Cells[1, 2] = "菴1俴菴2蹈";
            excel.Cells[2, 1] = "菴2俴菴1蹈";
            excel.Cells[2, 2] = "菴2俴菴2蹈";
            excel.Cells[3, 1] = "菴3俴菴1蹈";
            excel.Cells[3, 2] = "菴3俴菴2蹈";

            //悵湔
            excel.ActiveWorkbook.SaveAs("./tt.xls", XlFileFormat.xlExcel9795, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
            //湖羲珆尨
            excel.Visible = true;
            //			excel.Quit();
            //			excel=null;            
            //			GC.Collect();//嶼僵隙彶
        }
        #endregion

        #region 蔚DataTable腔杅擂絳堤珆尨峈惆桶
        /// <summary>
        /// 蔚DataTable腔杅擂絳堤珆尨峈惆桶
        /// </summary>
        /// <param name="dt">猁絳堤腔杅擂</param>
        /// <param name="strTitle">絳堤惆桶腔梓枙</param>
        /// <param name="FilePath">悵湔恅璃腔繚噤</param>
        /// <returns></returns>
        public string OutputExcel(System.Data.DataTable dt, string strTitle, string FilePath)
        {
            beforeTime = DateTime.Now;

            Excel.Application excel;
            Excel._Workbook xBk;
            Excel._Worksheet xSt;

            int rowIndex = 4;
            int colIndex = 1;

            excel = new Excel.ApplicationClass();
            xBk = excel.Workbooks.Add(true);
            xSt = (Excel._Worksheet)xBk.ActiveSheet;

            //腕蹈梓枙			
            foreach (DataColumn col in dt.Columns)
            {
                colIndex++;
                excel.Cells[4, colIndex] = col.ColumnName;

                //扢离梓枙跡宒峈懈笢勤
                xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Font.Bold = true;
                xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Select();
                xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Interior.ColorIndex = titleColorindex;//19;//扢离峈酴伎ㄛ僕數衄56笱
            }


            //腕桶跡笢腔杅擂			
            foreach (DataRow row in dt.Rows)
            {
                rowIndex++;
                colIndex = 1;
                foreach (DataColumn col in dt.Columns)
                {
                    colIndex++;
                    if (col.DataType == System.Type.GetType("System.DateTime"))
                    {
                        excel.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
                        xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//扢离倰腔趼僇跡宒峈懈笢勤
                    }
                    else
                        if (col.DataType == System.Type.GetType("System.String"))
                        {
                            excel.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                            xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//扢离趼睫倰腔趼僇跡宒峈懈笢勤
                        }
                        else
                        {
                            excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                        }
                }
            }

            //樓婥珨跺磁數俴			
            int rowSum = rowIndex + 1;
            int colSum = 2;
            excel.Cells[rowSum, 2] = "磁數";
            xSt.get_Range(excel.Cells[rowSum, 2], excel.Cells[rowSum, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //扢离恁笢腔窒煦腔晇伎			
            xSt.get_Range(excel.Cells[rowSum, colSum], excel.Cells[rowSum, colIndex]).Select();
            //xSt.get_Range(excel.Cells[rowSum,colSum],excel.Cells[rowSum,colIndex]).Interior.ColorIndex =Assistant.GetConfigInt("ColorIndex");// 1;//扢离峈酴伎ㄛ僕數衄56笱

            //腕淕跺惆桶腔梓枙			
            excel.Cells[2, 2] = strTitle;

            //扢离淕跺惆桶腔梓枙跡宒			
            xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Bold = true;
            xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Size = 22;

            //扢离惆桶桶跡峈郔巠茼遵僅			
            xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Select();
            xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Columns.AutoFit();

            //扢离淕跺惆桶腔梓枙峈輻蹈懈笢			
            xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).Select();
            xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //餅秶晚遺			
            xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Borders.LineStyle = 1;
            xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, 2]).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThick;//扢离酘晚盄樓棉
            xSt.get_Range(excel.Cells[4, 2], excel.Cells[4, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;//扢离奻晚盄樓棉
            xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[rowSum, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThick;//扢离衵晚盄樓棉
            xSt.get_Range(excel.Cells[rowSum, 2], excel.Cells[rowSum, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;//扢离狟晚盄樓棉



            afterTime = DateTime.Now;

            //珆尨虴彆			
            //excel.Visible=true;			
            //excel.Sheets[0] = "sss";

            ClearFile(FilePath);
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xls";
            excel.ActiveWorkbook.SaveAs(FilePath + filename, Excel.XlFileFormat.xlExcel9795, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);

            //wkbNew.SaveAs strBookName;
            //excel.Save(strExcelFileName);

            #region  賦旰Excel輛最

            //剒猁勤Excel腔DCOM勤砓輛俴饜离:dcomcnfg


            //excel.Quit();
            //excel=null;            

            xBk.Close(null, null, null);
            excel.Workbooks.Close();
            excel.Quit();


            //蛁砩ㄩ涴爵蚚善腔垀衄Excel勤砓飲猁硒俴涴跺紱釬ㄛ瘁寀賦旰祥賸Excel輛最
            //			if(rng != null)
            //			{
            //				System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
            //				rng = null;
            //			}
            //			if(tb != null)
            //			{
            //				System.Runtime.InteropServices.Marshal.ReleaseComObject(tb);
            //				tb = null;
            //			}
            if (xSt != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xSt);
                xSt = null;
            }
            if (xBk != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xBk);
                xBk = null;
            }
            if (excel != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                excel = null;
            }
            GC.Collect();//嶼僵隙彶
            #endregion

            return filename;

        }
        #endregion

        #region Kill Excel輛最

        /// <summary>
        /// 賦旰Excel輛最
        /// </summary>
        public void KillExcelProcess()
        {
            Process[] myProcesses;
            DateTime startTime;
            myProcesses = Process.GetProcessesByName("Excel");

            //腕祥善Excel輛最IDㄛ婃奀硐夔瓚剿輛最雄奀潔
            foreach (Process myProcess in myProcesses)
            {
                startTime = myProcess.StartTime;
                if (startTime > beforeTime && startTime < afterTime)
                {
                    myProcess.Kill();
                }
            }
        }
        #endregion

        #endregion

        #region 蔚DataTable腔杅擂絳堤珆尨峈惆桶(祥妏蚚Excel勤砓ㄛ妏蚚COM.Excel)

        #region 妏蚚尨瞰
        /*妏蚚尨瞰ㄩ
		 * DataSet ds=(DataSet)Session["AdBrowseHitDayList"];
			string ExcelFolder=Assistant.GetConfigString("ExcelFolder");
			string FilePath=Server.MapPath(".")+"\\"+ExcelFolder+"\\";
			
			//汜傖蹈腔笢恅勤茼桶
			Hashtable nameList = new Hashtable();
			nameList.Add("ADID", "嫘豢晤鎢");
			nameList.Add("ADName", "嫘豢靡備");
			nameList.Add("year", "爛");
			nameList.Add("month", "堎");
			nameList.Add("browsum", "珆尨杅");
			nameList.Add("hitsum", "萸僻杅");
			nameList.Add("BrowsinglIP", "黃蕾IP珆尨");
			nameList.Add("HitsinglIP", "黃蕾IP萸僻");
			//瞳蚚excel勤砓
			DataToExcel dte=new DataToExcel();
			string filename="";
			try
			{			
				if(ds.Tables[0].Rows.Count>0)
				{
					filename=dte.DataExcel(ds.Tables[0],"梓枙",FilePath,nameList);
				}
			}
			catch
			{
				//dte.KillExcelProcess();
			}
			
			if(filename!="")
			{
				Response.Redirect(ExcelFolder+"\\"+filename,true);
			}
		 * 
		 * */

        #endregion

        /// <summary>
        /// 蔚DataTable腔杅擂絳堤珆尨峈惆桶(祥妏蚚Excel勤砓)
        /// </summary>
        /// <param name="dt">杅擂DataTable</param>
        /// <param name="strTitle">梓枙</param>
        /// <param name="FilePath">汜傖恅璃腔繚噤</param>
        /// <param name="nameList"></param>
        /// <returns></returns>
        public string DataExcel(System.Data.DataTable dt, string strTitle, string FilePath, Hashtable nameList)
        {
            COM.Excel.cExcelFile excel = new COM.Excel.cExcelFile();
            ClearFile(FilePath);
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xls";
            excel.CreateFile(FilePath + filename);
            excel.PrintGridLines = false;

            COM.Excel.cExcelFile.MarginTypes mt1 = COM.Excel.cExcelFile.MarginTypes.xlsTopMargin;
            COM.Excel.cExcelFile.MarginTypes mt2 = COM.Excel.cExcelFile.MarginTypes.xlsLeftMargin;
            COM.Excel.cExcelFile.MarginTypes mt3 = COM.Excel.cExcelFile.MarginTypes.xlsRightMargin;
            COM.Excel.cExcelFile.MarginTypes mt4 = COM.Excel.cExcelFile.MarginTypes.xlsBottomMargin;

            double height = 1.5;
            excel.SetMargin(ref mt1, ref height);
            excel.SetMargin(ref mt2, ref height);
            excel.SetMargin(ref mt3, ref height);
            excel.SetMargin(ref mt4, ref height);

            COM.Excel.cExcelFile.FontFormatting ff = COM.Excel.cExcelFile.FontFormatting.xlsNoFormat;
            string font = "冼极";
            short fontsize = 9;
            excel.SetFont(ref font, ref fontsize, ref ff);

            byte b1 = 1,
                b2 = 12;
            short s3 = 12;
            excel.SetColumnWidth(ref b1, ref b2, ref s3);

            string header = "珜羹";
            string footer = "珜褐";
            excel.SetHeader(ref header);
            excel.SetFooter(ref footer);


            COM.Excel.cExcelFile.ValueTypes vt = COM.Excel.cExcelFile.ValueTypes.xlsText;
            COM.Excel.cExcelFile.CellFont cf = COM.Excel.cExcelFile.CellFont.xlsFont0;
            COM.Excel.cExcelFile.CellAlignment ca = COM.Excel.cExcelFile.CellAlignment.xlsCentreAlign;
            COM.Excel.cExcelFile.CellHiddenLocked chl = COM.Excel.cExcelFile.CellHiddenLocked.xlsNormal;

            // 惆桶梓枙
            int cellformat = 1;
            //			int rowindex = 1,colindex = 3;					
            //			object title = (object)strTitle;
            //			excel.WriteValue(ref vt, ref cf, ref ca, ref chl,ref rowindex,ref colindex,ref title,ref cellformat);

            int rowIndex = 1;//宎俴
            int colIndex = 0;



            //腕蹈梓枙				
            foreach (DataColumn colhead in dt.Columns)
            {
                colIndex++;
                string name = colhead.ColumnName.Trim();
                object namestr = (object)name;
                IDictionaryEnumerator Enum = nameList.GetEnumerator();
                while (Enum.MoveNext())
                {
                    if (Enum.Key.ToString().Trim() == name)
                    {
                        namestr = Enum.Value;
                    }
                }
                excel.WriteValue(ref vt, ref cf, ref ca, ref chl, ref rowIndex, ref colIndex, ref namestr, ref cellformat);
            }

            //腕桶跡笢腔杅擂			
            foreach (DataRow row in dt.Rows)
            {
                rowIndex++;
                colIndex = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    colIndex++;
                    if (col.DataType == System.Type.GetType("System.DateTime"))
                    {
                        object str = (object)(Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd"); ;
                        excel.WriteValue(ref vt, ref cf, ref ca, ref chl, ref rowIndex, ref colIndex, ref str, ref cellformat);
                    }
                    else
                    {
                        object str = (object)row[col.ColumnName].ToString();
                        excel.WriteValue(ref vt, ref cf, ref ca, ref chl, ref rowIndex, ref colIndex, ref str, ref cellformat);
                    }
                }
            }
            int ret = excel.CloseFile();

            //			if(ret!=0)
            //			{
            //				//MessageBox.Show(this,"Error!");
            //			}
            //			else
            //			{
            //				//MessageBox.Show(this,"湖羲恅璃c:\\test.xls!");
            //			}
            return filename;

        }

        #endregion

        #region  燴徹奀腔Excel恅璃

        private void ClearFile(string FilePath)
        {
            String[] Files = System.IO.Directory.GetFiles(FilePath);
            if (Files.Length > 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        System.IO.File.Delete(Files[i]);
                    }
                    catch
                    {
                    }

                }
            }
        }
        #endregion

    }
}
