using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class CalibrateSearch : System.Web.UI.Page
    {
        BLL.Place bllPlace = new BLL.Place();
        BLL.Assets bllAssets = new BLL.Assets();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Settings();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.v_Calibrate cl = new SearchModel.v_Calibrate();
            cl.ClearModel();
            SearchModel.v_Calibrate model = new SearchModel.v_Calibrate();

            model.Model.Place_sn = ddlPlace_sn1.Text == string.Empty ? 0 : Convert.ToInt32(ddlPlace_sn1.Text);
            model.Model.Place_Assets_sn = txtPlace_Assets_sn.Text;
            model.Model.Place_Assets_Detail_sn = txtPlace_Assets_Detail_sn.Text;
            model.Model.Assts_Station = ddlAssts_Station.Text;
            model.Model.Assts_Customer = txtCustomer.Text;
            model.Model.Assts_id = txtAssts_id.Text;
            model.Model.Assts_eq_id = txtAssts_eq_id.Text;
            model.Model.Assts_name = txtAssts_name.Text;
            model.Model.Assts_eq_name = txtAssts_eq_name.Text;
            model.Model.Assts_no = txtAsset_no.Text;
            model.Model.Floor_sn = Convert.ToInt32(ddlPlace_sn.SelectedValue);
            model.Model.Cp_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            model.Model.Last_Cp_Date_s = tbReturnStartDate.Text;
            model.Model.Last_Cp_Date_d = tbReturnEndDate.Text;
            model.Model.Next_Cp_Date_s = tbStartDate.Text;
            model.Model.Next_Cp_Date_d = tbEndDate.Text;

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
        }
        public void Settings()
        {
            ddlPlace_sn1.Items.Clear();
            //第一段位置
            DataTable dtPlace = bllPlace.GetPlace(Convert.ToInt32(Place.樓層), 0,Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn.DataSource = dtPlace;
            ddlPlace_sn.DataBind();
            ddlPlace_sn.Items.Insert(0, new ListItem("所有", "0"));

            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
            ddlPlace_sn1.Items.Insert(0, new ListItem("所有", "0"));

            ddlAssts_Station.DataSource = bllAssets.GetAsstsStation();
            ddlAssts_Station.DataBind();
            ddlAssts_Station.Items.Insert(0, new ListItem("所有", ""));
        }

        protected void ddlPlace_sn_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
            ddlPlace_sn1.Items.Insert(0, new ListItem("所有", "0"));
        }
    }
}