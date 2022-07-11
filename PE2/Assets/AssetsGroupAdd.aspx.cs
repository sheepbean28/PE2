using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class AssetsGroupAdd : System.Web.UI.Page
    {
        BLL.Place bllPlace = new BLL.Place();
        BLL.Assets bllAssets = new BLL.Assets();
        Model.Assets modAssets = new Model.Assets();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
                model.ClearList();
                Settings();
            }
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.User user = new SearchModel.User();
            SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
            modAssets.Place_sn = ddlPlace_sn1.SelectedValue == string.Empty ? 0 : Convert.ToInt32(ddlPlace_sn1.SelectedValue);
            modAssets.Place_name = ddlPlace_sn1.SelectedItem.Text;
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
            modAssets.Assts_Sttatus = 1;
            modAssets.LastChange_date =  DateTime.Now;
            modAssets.LastUser_sn = user.Model.User_sn;

            if (txtQuantity.Text != string.Empty)
                modAssets.Assts_Quantity = Convert.ToInt32(txtQuantity.Text);
            modAssets.Assts_Station = ddlAssts_Station.SelectedValue;
            if (txtAssts_Station_num.Text != string.Empty)
                modAssets.Assts_Station_num = Convert.ToInt32(txtAssts_Station_num.Text);
            modAssets.Note = txtNote.Text;
            modAssets.SysNote = txtSysNote.Text;


            if (!model.isFind(modAssets))
            {
                if (bllAssets.GetModelList(" Assts_no = '" + txtAsset_no.Text + "'").Count > 0)
                {
                    ServerJavascrpit.Alert.Warn(this.Page, "此標籤代碼已被使用");
                }
                else 
                {
                    model.Add(modAssets);
                    LoadData();
                    ToEmpty();
                }
                
            }
            else
            {
                ServerJavascrpit.Alert.Warn(this.Page, "已在綁定項目");
            }
           
            
        }
        
        public void LoadData() 
        {
             SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
             gvAssets.DataSource = model.List;
             gvAssets.DataBind();
        }
        public void Settings()
        {
            ddlPlace_sn1.Items.Clear();
            //第一段位置
            DataTable dtPlace = bllPlace.GetPlace(Convert.ToInt32(Place.樓層), 0, Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn.DataSource = dtPlace;
            ddlPlace_sn.DataBind();


            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
            

            ddlAssts_Station.DataSource = bllAssets.GetAsstsStation();
            ddlAssts_Station.DataBind();
            ddlAssts_Station.Items.Insert(0, new ListItem("所有", ""));
        }
        public void ToEmpty()
        {
            //ddlPlace_sn1.SelectedValue
            txtAsset_no.Text = "";
            txtPlace_Assets_sn.Text = "";
            txtPlace_Assets_Detail_sn.Text = "";
            txtAssts_Station.Text = "";
            txtCustomer.Text = "";
            txtAssts_id.Text = "";
            txtAssts_eq_id.Text = "";
            txtAssts_eq_name.Text = "";
            txtAssts_name.Text = "";
            txtQuantity.Text = "0";
            txtAssts_Station_num.Text = "0";
            txtNote.Text = "";
            txtSysNote.Text = "";
        }

        protected void ddlPlace_sn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlace_sn1.Items.Clear();
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
        }
        protected void ddlAssts_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssts_Station.Text = ddlAssts_Station.SelectedValue;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
            foreach(var item in model.List)
            {
                bllAssets.Add(item);

            }
            model.ClearList();
            LoadData();
            ServerJavascrpit.Alert.Warn(this.Page, "新增成功");
        }

        protected void gvAssets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowUpdate")
            {

            }
            if (e.CommandName.ToString() == "RowDelete")
            {
                SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
                model.Delete(e.CommandArgument.ToString());
                LoadData();
            }
        }
    }
}