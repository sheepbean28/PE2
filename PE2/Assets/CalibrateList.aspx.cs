using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI.XWPF.UserModel;
using System.Text;
using System.Reflection;

namespace PE2.Assets
{
    public partial class CalibrateList : System.Web.UI.Page
    {
        List<EQ> lst = new List<EQ>();
        BLL.v_Calibrate bllv_Calibrate = new BLL.v_Calibrate();
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            LoadData(false);

            btnAdd.Visible = (modUser.Power_sn(Convert.ToInt32(Power.校驗管理)) == 0);
        }
        public void LoadData(bool isResearch)
        {
            SearchModel.v_Calibrate model = new SearchModel.v_Calibrate();
            DataTable dt = bllv_Calibrate.GetCalibrateList(model.Model);
            gvCalibrate.DataSource = dt;
            gvCalibrate.DataBind();
            if (dt != null)
                lbCount.Text = dt.Rows.Count.ToString();
            //if (isResearch)
            //    model.ClearModel();
        }

        protected void btnHideSearch_Click(object sender, EventArgs e)
        {
            LoadData(false);
        }

        protected void gvAssets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCalibrate.PageIndex = e.NewPageIndex;
            LoadData(false);
        }

        protected void gvAssets_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnReturnCalibrate = (LinkButton)e.Row.FindControl("btnReturnCalibrate");
                LinkButton btnToCalibrate = (LinkButton)e.Row.FindControl("btnToCalibrate");
                HiddenField hfCp_Status = (HiddenField)e.Row.FindControl("hfCp_Status");
                HiddenField hfCp_Type = (HiddenField)e.Row.FindControl("hfCp_Type");
                if (hfCp_Type.Value != Convert.ToInt32(CP_Type.免校驗).ToString())
                {

                    btnReturnCalibrate.Visible = (hfCp_Status.Value == Convert.ToInt32(CP_Status.送驗中).ToString() || hfCp_Status.Value == Convert.ToInt32(CP_Status.送修中).ToString());
                    btnToCalibrate.Visible = (hfCp_Status.Value == Convert.ToInt32(CP_Status.已送回).ToString());
                }
                else
                {
                    btnReturnCalibrate.Visible = false;
                    btnToCalibrate.Visible = false;
                }
            }

        }

        protected void gvCalibrate_PreRender(object sender, EventArgs e)
        {

            SearchModel.User modUser = new SearchModel.User(this.Page);
            gvCalibrate.Columns[0].Visible = (modUser.Power_sn(Convert.ToInt32(Power.校驗管理)) == 0);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SearchModel.v_Calibrate model = new SearchModel.v_Calibrate();
            DataTable dt = bllv_Calibrate.GetCalibrateList(model.Model);
        //    ExcelOutport.OutportToClient(ExcelOutport.RenderDataTableByOpenXML(dt.DefaultView.ToTable()), "效驗列表.xls");
        }

        protected void btnExportWord_Click(object sender, EventArgs e)
        {
            SearchModel.v_Calibrate model = new SearchModel.v_Calibrate();
            DataTable dt = bllv_Calibrate.GetCalibrateList(model.Model);
            foreach (DataRow dr in dt.Rows)
            {
                EQ eq = new EQ();
                eq.E1 = dr["Eq_id"].ToString();
                eq.E2 = dr["Eq_name"].ToString();
                eq.E3 = dr["Eq_factory_no"].ToString();
                eq.E4 = dr["Assts_id"].ToString();
                eq.E5 = dr["Assts_eq_id"].ToString();

                lst.Add(eq);
            }
            string filepath = Server.MapPath("../File/儀器校驗委託單.docx");
            using (FileStream stream = File.OpenRead(filepath))
            {

                XWPFDocument doc = new XWPFDocument(stream);
                //遍历段落
                foreach (var para in doc.Paragraphs)
                {
                    ReplaceKey(para);
                }
                //遍历表格
                var tables = doc.Tables;
                foreach (var table in tables)
                {
                    foreach (var row in table.Rows)
                    {
                        if (row.GetCell(2).GetText() == "送 校 日 期")
                        {
                            row.GetCell(3).SetText(DateTime.Now.ToString("yyyy-MM-dd"));
                        }
                        if (row.GetCell(2).GetText() == "簽 收 日 期")
                        {
                            row.GetCell(3).SetText(DateTime.Now.ToString("yyyy-MM-dd"));
                        }
                        for (int j = 1; j <= lst.Count;j++ )
                        {
                            if (row.GetCell(0).GetText() == j.ToString())
                            {
                                row.GetCell(1).SetText(lst[j - 1].E1);
                                row.GetCell(2).SetText(lst[j - 1].E2);
                                row.GetCell(3).SetText(lst[j - 1].E3);
                                row.GetCell(4).SetText(lst[j - 1].E4);
                                row.GetCell(5).SetText(lst[j - 1].E5);
                            }
                        }
                    }
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    doc.Write(ms);

                    Response.ContentType = "application/vnd.ms-word";
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.Charset = "";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("儀器校驗委託單.doc", Encoding.UTF8));
                    Response.BinaryWrite(ms.GetBuffer());
                    Response.End();

                }
            }
        }
        private void ReplaceKey(XWPFParagraph para)
        {
            string text = para.ParagraphText;
            var runs = para.Runs;
            string styleid = para.Style;
            for (int i = 0; i < runs.Count; i++)
            {
                var run = runs[i];
                text = run.ToString(); //获得run的文本
                //runs[i].SetText(text.Replace("@S_DATE", DateTime.Now.ToString("yyyy-MM-dd")), 0);
                runs[i].SetText(ReplaceData(text));
            }
        }
        public string ReplaceData(string str)
        {
            if (str == "@S_DATE")
                return DateTime.Now.ToString("yyyy-MM-dd");
            if (str == "@S2_DATE")
                return DateTime.Now.ToString("yyyy-MM-dd");

            return str;
        }
        public class EQ
        {
            public string E1 { get; set; }
            public string E2 { get; set; }
            public string E3 { get; set; }
            public string E4 { get; set; }
            public string E5 { get; set; }
        }
    }
}