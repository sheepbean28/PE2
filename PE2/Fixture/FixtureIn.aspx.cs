using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Fixture
{
    public partial class FixtureIn : System.Web.UI.Page
    {
        BLL.Place bllPlace = new BLL.Place();
        BLL.Fixture bllFixture = new BLL.Fixture();
        BLL.InFixture bllInFixture = new BLL.InFixture();

        protected void Page_Load(object sender, EventArgs e)
        {

            txtFixture_no.Attributes.Add("onkeydown", "if (event.keyCode==13){document.getElementById('" + btnConfirm.ClientID + "').focus();return true;}");
            if (!IsPostBack)
            {
                SearchModel.InFixture model = new SearchModel.InFixture();
                model.ClearList();
                Settings();
            }
        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            SearchModel.InFixture model = new SearchModel.InFixture();
            Model.InFixture modInFixture = new Model.InFixture();
            Model.Fixture modFixture = new Model.Fixture();
            if (ddlPlace_sn1.SelectedValue != string.Empty)
            {
                modInFixture.Place_name = ddlPlace_sn1.SelectedItem.Text;
                modInFixture.Place_sn = Convert.ToInt32(ddlPlace_sn1.SelectedValue);
                //  modInFixture.Look = cbLook.Checked == true ? 1 : 0;
                //  modInFixture.Clean = cbClean.Checked == true ? 1 : 
                //不管怎勾選都是True
                modInFixture.Look = 1;
                modInFixture.Clean = 1;
                modInFixture.Note = txtNote.Text;

                modFixture.Status = Convert.ToInt32(Status.已領出);
                modFixture.Fixture_no = txtFixture_no.Text;
                modFixture = bllFixture.GetFixturebyFixture_no(modFixture);

                if (modFixture != null)
                {
                    modInFixture.ChangeFixture(modFixture);
                    model.Add(modInFixture);
                }
                else
                {
                    ServerJavascrpit.Alert.Warn(this.Page, "找不到此出借資料");
                }

                LoadData();
            }
            else
            {
                ServerJavascrpit.Alert.Warn(this.Page, "使用位置尚未選擇");
            }
            ServerJavascrpit.Textbox.Focus(this.Page, "txtFixture_no");
        }

        protected void ddlPlace_sn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlace_sn1.Items.Clear();
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.治具歸還));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
        }


        public void LoadData()
        {
            SearchModel.InFixture model = new SearchModel.InFixture();
            gvInFixture.DataSource = model.List;
            gvInFixture.DataBind();
        }

        public void Settings()
        {
            ddlPlace_sn1.Items.Clear();
            //第一段位置
            DataTable dtPlace = bllPlace.GetPlace(Convert.ToInt32(Place.樓層), 0, Convert.ToInt32(PlacePower.治具歸還));
            ddlPlace_sn.DataSource = dtPlace;
            ddlPlace_sn.DataBind();
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.治具歸還));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
        }

        protected void gvInFixture_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowUpdate")
            {

            }
            if (e.CommandName.ToString() == "RowDelete")
            {
                SearchModel.InFixture model = new SearchModel.InFixture();
                model.Delete(e.CommandArgument.ToString());
                LoadData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.InFixture model = new SearchModel.InFixture();

            foreach (Model.InFixture item in model.List)
            {
                item.In_date = DateTime.Now;
                item.Create_date = DateTime.Now;
                item.User_sn = modUser.Model.User_sn;
                item.Valid = 1;
                item.Fixture_sn = item.Fixture.Fixture_sn;

                int LastIn_sn = bllInFixture.Add(item);

                item.Fixture.LastIn_sn = LastIn_sn;
                item.Fixture.LastIn_date = item.In_date;
                item.Fixture.Place_sn = item.Place_sn;
                item.Fixture.Status = Convert.ToInt32(PE2.Status.在庫);
               
                bllFixture.Update(item.Fixture);
            }
            model.ClearList();
            ServerJavascrpit.Alert.Success(this.Page, "共歸還" + model.List.Count + "筆治具");
        }

       
    }
}