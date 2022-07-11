using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class ShieldingBoxList : System.Web.UI.Page
    {
        BLL.v_ShieldingBox bllv_ShieldingBox = new BLL.v_ShieldingBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            LoadData(false);

            btnAdd.Visible = (modUser.Power_sn(Convert.ToInt32(Power.隔離箱管理)) == 0);
        }
        public void LoadData(bool isResearch)
        {
            SearchModel.v_ShieldingBox model = new SearchModel.v_ShieldingBox();
            DataTable dt = bllv_ShieldingBox.GetShieldingBoxList(model.Model);
            gvShieldingBox.DataSource = dt;
            gvShieldingBox.DataBind();
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
            gvShieldingBox.PageIndex = e.NewPageIndex;
            LoadData(false);
        }

        protected void gvAssets_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            

        }

        protected void gvCalibrate_PreRender(object sender, EventArgs e)
        {

            SearchModel.User modUser = new SearchModel.User(this.Page);
            gvShieldingBox.Columns[0].Visible = (modUser.Power_sn(Convert.ToInt32(Power.隔離箱管理)) == 0);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SearchModel.v_ShieldingBox model = new SearchModel.v_ShieldingBox();
            DataTable dt = bllv_ShieldingBox.GetShieldingBoxList(model.Model);
       //     ExcelOutport.OutportToClient(ExcelOutport.RenderDataTableByOpenXML(dt.DefaultView.ToTable()), "隔離箱列表.xls");
        }
    }
}