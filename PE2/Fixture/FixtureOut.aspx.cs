using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Fixture
{
    public partial class FixtureOut : System.Web.UI.Page
    {
        BLL.Place bllPlace = new BLL.Place();
        BLL.Fixture bllFixture = new BLL.Fixture();
        BLL.OutFixture bllOutFixture = new BLL.OutFixture();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtFixture_no.Attributes.Add("onkeydown", "if (event.keyCode==13){document.getElementById('" + btnConfirm.ClientID + "').focus();return true;}");
            if (!IsPostBack)
            {
                SearchModel.OutFixture model = new SearchModel.OutFixture();
                model.ClearList();
                Settings();
            }
        }
        

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.OutFixture model = new SearchModel.OutFixture();
            Model.OutFixture modOutFixture = new Model.OutFixture();
            Model.Fixture modFixture = new Model.Fixture();
            if (ddlPlace_sn1.SelectedValue != string.Empty)
            {
                modOutFixture.Place_name = ddlPlace_sn1.SelectedItem.Text;
                modOutFixture.Place_sn = Convert.ToInt32(ddlPlace_sn1.SelectedValue);
                modOutFixture.Note = txtNote.Text;
                modOutFixture.OutStatus = Convert.ToInt32(ddlOutStatus.SelectedValue);

                modFixture.Status = Convert.ToInt32(Status.在庫);
                modFixture.Fixture_no = txtFixture_no.Text;
                modFixture = bllFixture.GetFixturebyFixture_no(modFixture);

                if (modFixture != null)
                {
                    modOutFixture.ChangeFixture(modFixture);
                    model.Add(modOutFixture);
                }
                else 
                {
                    ServerJavascrpit.Alert.Warn(this.Page, "找不到此治具資料");
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
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.治具出借));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
        }


        public void LoadData() 
        {
            SearchModel.OutFixture model = new SearchModel.OutFixture();
            gvOutFixture.DataSource = model.List;
            gvOutFixture.DataBind();
            
        }

        public void Settings()
        {
            ddlPlace_sn1.Items.Clear();
            //第一段位置
            DataTable dtPlace = bllPlace.GetPlace(Convert.ToInt32(Place.樓層), 0, Convert.ToInt32(PlacePower.治具出借));
            ddlPlace_sn.DataSource = dtPlace;
            ddlPlace_sn.DataBind();
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.治具出借));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
        }

        protected void gvOutFixture_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowUpdate")
            { 
            
            }
            if (e.CommandName.ToString() == "RowDelete")
            {
                SearchModel.OutFixture model = new SearchModel.OutFixture();
                model.Delete(e.CommandArgument.ToString());
                LoadData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.OutFixture model = new SearchModel.OutFixture();
            
            foreach(Model.OutFixture item  in model.List)
            {
                item.Out_date = DateTime.Now;
                item.Create_date = DateTime.Now;
                item.User_sn = modUser.Model.User_sn;
                item.Valid = 1;
                
                int LastOut_sn = bllOutFixture.Add(item);
                
                item.Fixture.LastOut_sn = LastOut_sn;
                item.Fixture.LastOut_date = item.Out_date;
                item.Fixture.Place_sn = item.Place_sn;
                item.Fixture.Status = Convert.ToInt32(PE2.Status.已領出);

                bllFixture.Update(item.Fixture);
            }
            model.ClearList();
            ServerJavascrpit.Alert.Success(this.Page,"共借出" + model.List.Count + "筆治具");
        }

        
    }
}