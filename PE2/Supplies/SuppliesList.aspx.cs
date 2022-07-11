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
    public partial class SuppliesList : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            btnAdd.Visible = (modUser.Power_sn(Convert.ToInt32(Power.耗材管理)) == 0);
        }
        
        public void LoadData(bool isResearch)
        {
            SearchModel.Supplies model = new SearchModel.Supplies();
            DataTable dt = bllSupplies.GetSuppliesList(model.Model);
            if (dt != null)
            {
                if (model.Model.StockStatus == 1)
                {
                    dt.DefaultView.RowFilter = " Supplies_Stock > Supplies_Warm ";

                }
                else if (model.Model.StockStatus == 2)
                {
                    dt.DefaultView.RowFilter = "  Supplies_Stock <= Supplies_Warm and  Supplies_Stock > Supplies_Limit ";

                }
                else if (model.Model.StockStatus == 3)
                {
                    dt.DefaultView.RowFilter = " Supplies_Stock <= Supplies_Limit ";

                }
                if (model.Model.Valid != -1)
                {
                    dt.DefaultView.RowFilter = " Valid = " + model.Model.Valid;
                }
            }
            
            
            if (dt != null)
            {
                gvList.DataSource = dt.DefaultView;
                gvList.DataBind();
            }
            
            
            if (dt != null)
                lbCount.Text = dt.DefaultView.Count.ToString();
            if (isResearch)
                model.ClearModel();
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
            gvList.Columns[1].Visible = (modUser.Power_sn(Convert.ToInt32(Power.耗材管理)) == 0);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SearchModel.Supplies model = new SearchModel.Supplies();
            DataTable dt = bllSupplies.GetSuppliesList(model.Model);
            if (model.Model.StockStatus == 1)
            {
                dt.DefaultView.RowFilter = " Supplies_Stock > Supplies_Warm ";

            }
            else if (model.Model.StockStatus == 2)
            {
                dt.DefaultView.RowFilter = "  Supplies_Stock <= Supplies_Warm and  Supplies_Stock > Supplies_Limit ";

            }
            else if (model.Model.StockStatus == 3)
            {
                dt.DefaultView.RowFilter = " Supplies_Stock <= Supplies_Limit ";

            }
            if (model.Model.Valid != -1)
            {
                dt.DefaultView.RowFilter = " Valid = " + model.Model.Valid;
            }
          //  ExcelOutport.OutportToClient(ExcelOutport.RenderDataTable(dt.DefaultView.Table),"耗材列表.xls");
        }
    }
}