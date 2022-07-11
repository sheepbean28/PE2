using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Supplies
{
    public partial class SuppliesSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Settings();
            }
        }
        public void Settings()
        {
            BLL.Code bllCode = new BLL.Code();
            ddlPlace_sn.Items.Clear();
            //第一段位置
            ddlPlace_sn.DataSource = bllCode.GetModelList(" Class_sn = 6");
            ddlPlace_sn.DataBind();
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.Supplies cl = new SearchModel.Supplies();
            cl.ClearModel();
            SearchModel.Supplies model = new SearchModel.Supplies();

            model.Model.Supplies_no = txtSupplies_no.Text;
            model.Model.Supplies_Name = txtSupplies_Name.Text;
            model.Model.Supplies_Class = ddlSupplies_Class.SelectedValue;
            model.Model.StockStatus = Convert.ToInt32(ddlStatus.SelectedValue);
            model.Model.StockStart = txtStockStart.Text == string.Empty ? -1 : Convert.ToInt32(txtStockStart.Text);
            model.Model.StockEnd = txtStockEnd.Text == string.Empty ? -1 : Convert.ToInt32(txtStockEnd.Text);
            model.Model.Valid = Convert.ToInt32(ddlValid.SelectedValue);
            model.Model.Note = txtNote.Text;
            model.Model.Place_code_sn = Convert.ToInt32(ddlPlace_sn.SelectedValue);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
        }
    }
}