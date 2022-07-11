using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class AssetsList : System.Web.UI.Page
    {
        BLL.Assets bllAssets = new BLL.Assets();
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            btnAdd.Visible = (modUser.Power_sn(Convert.ToInt32(Power.資產管理)) == 0);
        }
        public void LoadData(bool isResearch)
        {
            SearchModel.Assets model = new SearchModel.Assets();
            DataTable dt = bllAssets.GetAssetsList(model.Model);
            gvAssets.DataSource = dt;
            gvAssets.DataBind();
            if (dt != null)
                lbCount.Text = dt.Rows.Count.ToString();
            if(isResearch)
                model.ClearModel();
        }

       

        protected void gvAssets_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvAssets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAssets.PageIndex = e.NewPageIndex;
            LoadData(false);
        }

        protected void btnSeedSearch_Click(object sender, EventArgs e)
        {

            SearchModel.Assets model = new SearchModel.Assets();
            model.ClearModel();
            model = new SearchModel.Assets();
            if (ddlSpeedRin.SelectedValue == "儲位代碼")
            { 
                model.Model.Place_Assets_sn = tbSpeedSearch.Text;
            }
            if (ddlSpeedRin.SelectedValue == "標籤代碼")
            {
                model.Model.Assts_no = tbSpeedSearch.Text;
            }
            if (ddlSpeedRin.SelectedValue == "關聯儲位")
            {
                model.Model.Place_Assets_Detail_sn = tbSpeedSearch.Text;
            }
            if (ddlSpeedRin.SelectedValue == "資產編號")
            {
                model.Model.Assts_id = tbSpeedSearch.Text;
            }
            LoadData(true);
            ServerJavascrpit.Textbox.Focus(this.Page, "tbSpeedSearch");
        }

        protected void btnHideSearch_Click(object sender, EventArgs e)
        {
            LoadData(false);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SearchModel.Assets model = new SearchModel.Assets();
            DataTable dt = bllAssets.GetAssetsList(model.Model);
            Excel.ObjExcel.OutportExcel(dt, "資產列表" + DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}