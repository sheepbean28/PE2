using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class AssetsEdit : System.Web.UI.Page
    {
        BLL.Place bllPlace = new BLL.Place();
        BLL.Assets bllAssets = new BLL.Assets();
        Model.Assets modAssets = new Model.Assets();
        string change = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            hfAssets_sn.Value = Request.QueryString["Mode"];
            change = Request.QueryString["change"];
            if (!IsPostBack)
            {
                Settings();
                modAssets = bllAssets.GetModel(Convert.ToInt32(hfAssets_sn.Value));
                if (hfAssets_sn.Value != "0")
                    SetEidt(modAssets);
            }
            if (change == "1")
                CloseObject();
        }
        public void CloseObject() 
        {
            txtAsset_no.Enabled = false;
            txtAssts_Station.Enabled = false;
            txtCustomer.Enabled = false;
            txtAssts_id.Enabled = false;
            txtAssts_eq_id.Enabled = false;
            txtAssts_eq_name.Enabled = false;
            txtAssts_name.Enabled = false;
            txtQuantity.Enabled = false;
            txtAssts_Station_num.Enabled = false;
            txtNote.Enabled = false;
            txtSysNote.Enabled = false;
            ddlAssts_Station.Enabled = false;
        }
        public void SetEidt(Model.Assets modAssets)
        {
            ddlPlace_sn1.SelectedValue = modAssets.Place_sn.ToString();
            txtAsset_no.Text = modAssets.Assts_no;
            txtPlace_Assets_sn.Text = modAssets.Place_Assets_sn;
            txtPlace_Assets_Detail_sn.Text = modAssets.Place_Assets_sn;
            txtAssts_Station.Text = modAssets.Assts_Station;
            txtCustomer.Text = modAssets.Assts_Customer;
            txtAssts_id.Text = modAssets.Assts_id;
            txtAssts_eq_id.Text = modAssets.Assts_eq_id;
            txtAssts_eq_name.Text = modAssets.Assts_eq_name;
            txtAssts_name.Text = modAssets.Assts_name;
            txtQuantity.Text = modAssets.Assts_Quantity.ToString();
            txtAssts_Station_num.Text = modAssets.Assts_Station_num.ToString();
            txtNote.Text = modAssets.Note;
            txtSysNote.Text = modAssets.SysNote;
            
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            modAssets = bllAssets.GetModel(Convert.ToInt32(hfAssets_sn.Value));
            SearchModel.User user = new SearchModel.User();

            modAssets.LastChange_date = DateTime.Now;
            modAssets.LastUser_sn = user.Model.User_sn;
            modAssets.Place_sn = ddlPlace_sn1.SelectedValue == string.Empty ? 0 : Convert.ToInt32(ddlPlace_sn1.SelectedValue);
            modAssets.Place_Assets_sn = txtPlace_Assets_sn.Text;
            modAssets.Place_Assets_Detail_sn = txtPlace_Assets_Detail_sn.Text;
            modAssets.Assts_Station = ddlAssts_Station.Text;
            modAssets.Assts_Customer = txtCustomer.Text;
            modAssets.Assts_id = txtAssts_id.Text;
            modAssets.Assts_eq_id = txtAssts_eq_id.Text;
            modAssets.Assts_name = txtAssts_name.Text;
            modAssets.Assts_eq_name = txtAssts_eq_name.Text;
            modAssets.Assts_no = txtAsset_no.Text;
            modAssets.Floor_sn = Convert.ToInt32(ddlPlace_sn.SelectedValue);
            if (txtQuantity.Text != string.Empty)
                modAssets.Assts_Quantity = Convert.ToInt32(txtQuantity.Text);
            modAssets.Assts_Station = ddlAssts_Station.SelectedValue;
            if (txtAssts_Station_num.Text != string.Empty)
                modAssets.Assts_Station_num = Convert.ToInt32(txtAssts_Station_num.Text);
            modAssets.Note = txtNote.Text;
            modAssets.SysNote = txtSysNote.Text;
            
            bllAssets.Update(modAssets);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
        }
       
        public void Settings()
        {
            ddlPlace_sn1.Items.Clear();
            //第一段位置
            DataTable dtPlace = bllPlace.GetPlace(Convert.ToInt32(Place.樓層), 0, Convert.ToInt32(PlacePower.資產管理));
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
            ddlPlace_sn1.Items.Clear();
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
            ddlPlace_sn1.Items.Insert(0, new ListItem("所有", "0"));
        }

        protected void ddlAssts_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssts_Station.Text = ddlAssts_Station.SelectedValue;
        }
    }
}