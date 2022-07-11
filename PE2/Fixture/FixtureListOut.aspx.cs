using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Fixture
{
    public partial class FixtureListOut : System.Web.UI.Page
    {
        BLL.Fixture bllFixture = new BLL.Fixture();
        BLL.Place bllPlace = new BLL.Place();

        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            if (Request.UrlReferrer.ToString().Substring(Request.UrlReferrer.ToString().Length - 12,12) == "Default.aspx")
            {
                SearchModel.Fixture model = new SearchModel.Fixture("FixtureListOut");
                model.ClearModel("FixtureListOut");
            }

            if (!IsPostBack)
            {
                Settings();
            }
        }
        /// <summary>
        /// 資料讀取
        /// </summary>
        public void LoadData()
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.Fixture model = new SearchModel.Fixture("FixtureListOut");
            if (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0)
            {
                model.Model.Fixture_usefor = "-1";
            }
            List<Model.Fixture> lstFixture = bllFixture.GetFixtureListList(model.Model);
            gvFixture.DataSource = lstFixture;
            gvFixture.DataBind();
            if (lstFixture != null)
                lbCount.Text = lstFixture.Count.ToString();
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
        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFixture.PageIndex = e.NewPageIndex;
            LoadData();
        }
        protected void gvFixture_PreRender(object sender, EventArgs e)
        {
            
        }
        protected void gvFixture_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        protected void ddlPlace_sn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlace_sn1.Items.Clear();
            DataTable dtPlace2 = bllPlace.GetPlace(Convert.ToInt32(Place.線別), Convert.ToInt32(ddlPlace_sn.SelectedValue), Convert.ToInt32(PlacePower.資產管理));
            ddlPlace_sn1.DataSource = dtPlace2;
            ddlPlace_sn1.DataBind();
            
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {

            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.Fixture model = new SearchModel.Fixture("FixtureListOut");
            BLL.OutFixture bllOutFixture = new BLL.OutFixture();

            List<Model.Fixture> lstFixture = bllFixture.GetFixtureListList(model.Model);
            DateTime dt = Convert.ToDateTime(tbOutDate.Text);


            foreach (Model.Fixture item in lstFixture)
            {
                //寫入借出資料
                Model.OutFixture modOutFixture = new Model.OutFixture();
                modOutFixture.Fixture_sn = item.Fixture_sn;
                modOutFixture.Note = "test";
                modOutFixture.Place_sn = Convert.ToInt32(ddlPlace_sn1.SelectedValue);
                modOutFixture.Out_date = dt;
                modOutFixture.Create_date = DateTime.Now;
                modOutFixture.User_sn = modUser.Model.User_sn;
                modOutFixture.Valid = 1;
                modOutFixture.OutStatus = 1;
                int LastOut_sn = bllOutFixture.Add(modOutFixture);


                item.LastOut_sn = LastOut_sn;
                item.LastOut_date = modOutFixture.Out_date;
                item.Place_sn = modOutFixture.Place_sn;
                item.Status = Convert.ToInt32(PE2.Status.已領出);
                bllFixture.Update(item);
                ServerJavascrpit.Alert.Success(this.Page, "共借出" + lstFixture.Count.ToString() + "筆治具");              
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}