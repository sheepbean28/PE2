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
    public partial class SuppliesCheck : System.Web.UI.Page
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
            SearchModel.Supplies model = new SearchModel.Supplies();
            model.Model.Supplies_Name = Request.QueryString["Name"].ToString();
            model.Model.StockStart = -1;
            model.Model.StockEnd = -1;
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
            if (dt != null) 
            {
                dt.DefaultView.RowFilter = " Valid = 1 ";
            }

            
            if (dt != null)
            {
                gvList.DataSource = dt.DefaultView;
                gvList.DataBind();
            }
            if (isResearch)
                model.ClearModel();
            if (gvList.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndSave();", true);
            }
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
            
        }

        protected void gvList_PreRender(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            gvList.Columns[0].Visible = (modUser.Power_sn(Convert.ToInt32(Power.隔離箱管理)) == 0);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndSave();", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndCancel();", true);
        }
    }
}