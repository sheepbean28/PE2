using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace PE2.Supplies
{
    public partial class GetSuppliesLog : System.Web.UI.Page
    {
        BLL.SuppliesLog bllSuppliesLog = new BLL.SuppliesLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData(false);
        }
        public void LoadData(bool isResearch)
        {
            DataTable dt = bllSuppliesLog.GetSuppliesLogList();
            gvList.DataSource = dt;
            gvList.DataBind();
            if (dt != null)
                lbCount.Text = dt.Rows.Count.ToString();
        }
        protected void btnHideSearch_Click(object sender, EventArgs e)
        {
            LoadData(false);
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            LoadData(false);
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbWarm = (Label)e.Row.FindControl("lbWarm");
                Label lbLimit = (Label)e.Row.FindControl("lbLimit");
                Label lbStock = (Label)e.Row.FindControl("lbStock");
                Label lbResult = (Label)e.Row.FindControl("lbResult");
                Label lbType = (Label)e.Row.FindControl("lbType");

                string Name = string.Empty;
                if (lbType.Text == "0")
                {
                    Name = "進貨入庫";
                }
                if (lbType.Text == "1")
                {
                    Name = "耗材領用";
                }
                if (lbType.Text == "2")
                {
                    Name = "耗材退庫";
                }
                if (lbType.Text == "3")
                {
                    Name = "外單位借出";
                }
                if (lbType.Text == "4")
                {
                    Name = "外單位歸還";
                }
                lbType.Text = Name;

                lbResult.ForeColor = Color.Green;
                //lbResult
                if (Convert.ToInt32(lbStock.Text) < Convert.ToInt32(lbLimit.Text))
                {
                    lbResult.Text = "庫存不足";
                    lbResult.ForeColor = Color.Red;
                }
                else if (Convert.ToInt32(lbStock.Text) < Convert.ToInt32(lbWarm.Text))
                {
                    lbResult.Text = "庫存即將不足";
                    lbResult.ForeColor = Color.YellowGreen;
                }
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<string> LstColnums = new List<string>();
            LstColnums.Add("Supplies_no");
            LstColnums.Add("Supplies_Name");
            LstColnums.Add("Type");
            LstColnums.Add("Quantity");
            LstColnums.Add("Supplies_date");
            LstColnums.Add("User_name");
            LstColnums.Add("Supplies_Stock");
            LstColnums.Add("Note");
            DataTable dt = bllSuppliesLog.GetSuppliesLogList();

           // ExcelOutport.OutportToClient(ExcelOutport.RenderDataTableByOpenXML(dt.DefaultView.ToTable(), LstColnums), "耗材異動紀錄查詢");
        }
    }
}