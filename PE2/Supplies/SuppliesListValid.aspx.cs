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
    public partial class SuppliesListValid : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();

        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
              LoadData(false);
            //btnAdd.Visible = (modUser.Power_sn(Convert.ToInt32(Power.隔離箱管理)) == 0);
        }

        public void LoadData(bool isResearch)
        {
            Model.Supplies model = new Model.Supplies();
            
            DataTable dt = bllSupplies.GetSuppliesList(model);
            if (dt != null)
            {
                if (model.StockStatus == 1)
                {
                    dt.DefaultView.RowFilter = " Supplies_Stock > Supplies_Warm ";

                }
                else if (model.StockStatus == 2)
                {
                    dt.DefaultView.RowFilter = "  Supplies_Stock <= Supplies_Warm and  Supplies_Stock > Supplies_Limit ";

                }
                else if (model.StockStatus == 3)
                {
                    dt.DefaultView.RowFilter = " Supplies_Stock <= Supplies_Limit ";

                }
                dt.DefaultView.RowFilter = " Valid = 0 ";
            }
           
            if (dt != null)
            {
                gvList.DataSource = dt.DefaultView;
                gvList.DataBind();
            }


            if (dt != null)
                lbCount.Text = gvList.Rows.Count.ToString();
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

        protected void gvList_PreRender(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            gvList.Columns[0].Visible = (modUser.Power_sn(Convert.ToInt32(Power.隔離箱管理)) == 0);
        }
    }
}