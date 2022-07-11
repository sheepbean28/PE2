using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Fixture
{
    public partial class FixtureSearch : System.Web.UI.Page
    {
        BLL.Fixture bll = new BLL.Fixture();
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.Fixture model;
            if (Request.QueryString["M"].ToString() == "Out")
                 model = new SearchModel.Fixture("FixtureListOut");
            else
                 model = new SearchModel.Fixture();
            model.ClearModel();
            if(!IsPostBack)
                Settings();
        }
        
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.Fixture model;
            if (Request.QueryString["M"].ToString() == "Out")
                model = new SearchModel.Fixture("FixtureListOut");
            else
                model = new SearchModel.Fixture();

            model.Model.Fixture_name = txtFixture_name.Text;
            model.Model.Fixture_no = txtFixture_no.Text;
            model.Model.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            model.Model.Fixture_usefor = ddlFixture_usefor.SelectedValue;
            if (ddlFixture_car.SelectedValue != string.Empty)
                model.Model.Fixture_car = ddlFixture_car.SelectedValue + "-";
            if (ddlFixture_car2.SelectedValue != string.Empty)
                model.Model.Fixture_car += ddlFixture_car2.SelectedValue + "-";
            if (ddlFixture_car3.SelectedValue != string.Empty)
                model.Model.Fixture_car += ddlFixture_car3.SelectedValue;

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
        }

        public void Settings()
        {
            ListItem liEmpty = new ListItem();
            liEmpty.Text = "所有";
            liEmpty.Value = "";
            ddlFixture_car.Items.Add(liEmpty);

            ListItem li0 = new ListItem();
            li0.Text = 0 + "車";
            li0.Value = "0";
            ddlFixture_car.Items.Add(li0);

            for (int i = 1; i <= PE2.Settings.Car(); i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString() + "車";
                li.Value = i.ToString();
                ddlFixture_car.Items.Add(li);
            }
            ddlFixture_usefor.DataSource = bll.GetUsefor();
            ddlFixture_usefor.DataBind();
            ddlFixture_usefor.Items.Insert(0, new ListItem("所有", "-1"));

        }
    }
}