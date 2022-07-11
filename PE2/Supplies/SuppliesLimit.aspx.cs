using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace PE2.Supplies
{
    public partial class SuppliesLimit : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }
        public void LoadData()
        {
            SearchModel.Supplies model = new SearchModel.Supplies();
            DataTable dt = bllSupplies.GetSuppliesList(model.Model);
            dt.DefaultView.RowFilter = "  Supplies_Stock <= Supplies_Warm  and Valid = 1 ";
            if (dt != null)
            {
                gvList.DataSource = dt.DefaultView;
                gvList.DataBind();
            }


            if (dt != null)
                lbCount.Text = dt.DefaultView.Count.ToString();

                model.ClearModel();
        }

        protected void gvList_PreRender(object sender, EventArgs e)
        {

        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbWarm = (Label)e.Row.FindControl("lbWarm");
                Label lbLimit = (Label)e.Row.FindControl("lbLimit");
                Label lbStock = (Label)e.Row.FindControl("lbStock");
                Label lbResult = (Label)e.Row.FindControl("lbResult");
                lbResult.ForeColor = Color.Green;
                //lbResult
                if (Convert.ToInt32(lbStock.Text) <= Convert.ToInt32(lbLimit.Text))
                {
                    lbResult.Text = "庫存不足";
                    lbResult.ForeColor = Color.Red;
                }
                else if (Convert.ToInt32(lbStock.Text) <= Convert.ToInt32(lbWarm.Text))
                {
                    lbResult.Text = "庫存即將不足";
                    lbResult.ForeColor = Color.YellowGreen;
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SearchModel.Supplies model = new SearchModel.Supplies();
            DataTable dt = bllSupplies.GetSuppliesList(model.Model);
            dt.DefaultView.RowFilter = "  Supplies_Stock <= Supplies_Warm  and Valid = 1 ";

            List<string> LstColnums = new List<string>();
            LstColnums.Add("Supplies_no");
            LstColnums.Add("Supplies_Name");
            LstColnums.Add("Supplies_Stock");
            LstColnums.Add("Supplies_sn");
            LstColnums.Add("Supplies_File");
            LstColnums.Add("Note");
            

           // ExcelOutport.OutportToClient(ExcelOutport.RenderDataTableByOpenXML(dt.DefaultView.ToTable(), LstColnums), "耗材不足查詢.xls");

            model.ClearModel();
        }
    }
}