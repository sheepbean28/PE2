using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Fixture
{
    public partial class FixtureEdit : System.Web.UI.Page
    {
        BLL.Fixture bllFixture = new BLL.Fixture();
        Model.Fixture modFixture = new Model.Fixture();
        protected void Page_Load(object sender, EventArgs e)
        {
            hfFixture_sn.Value = Request.QueryString["Mode"];
            if (!IsPostBack)
            {
                Settings();
                modFixture = bllFixture.GetModel(Convert.ToInt32(hfFixture_sn.Value));
                if (hfFixture_sn.Value != "0")
                    SetEidt(modFixture);
            }
            
        }
        
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            modFixture.Fixture_no = txtFixture_no.Text;
            if (hfFixture_sn.Value != "0")
            {
                if (Request.QueryString["CP"].ToString() == "1")
                {
                    Add();
                }
                else
                {
                    Update();
                }
            }
            else
            {
                Add();
            }
        }

        public void Settings()
        {
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
            //ddlFixture_usefor.DataSource = bll.GetUsefor();
            //ddlFixture_usefor.DataBind();
            //ddlFixture_usefor.Items.Insert(0, new ListItem("所有", "-1"));

        }

        public Model.Fixture GetEidt(Model.Fixture modFixture)
        {
            modFixture.Fixture_no = txtFixture_no.Text;
            modFixture.Fixture_car = ddlFixture_car.SelectedValue + "-" +
                                     ddlFixture_car2.SelectedValue + "-" +
                                     ddlFixture_car3.SelectedValue;
            modFixture.Fixture_car1 = ddlFixture_car.SelectedValue;
            modFixture.Fixture_car2 = ddlFixture_car2.SelectedValue + "-" +
                                      ddlFixture_car3.SelectedValue;
            modFixture.Fixture_name = txtFixture_name.Text;
            modFixture.Fixture_usefor = txtFixture_usefor.Text;
            modFixture.Quantity = Convert.ToInt32(txtQuantity.Text);
            modFixture.Create_date = Convert.ToDateTime(txtCreateDate.Text);
            modFixture.Limit_date = Convert.ToDateTime(txtLimitDate.Text);
            modFixture.Note = txtNote.Text;

            return modFixture;
        }

        public void SetEidt(Model.Fixture modFixture)
        {
            hfFixture_no.Value = modFixture.Fixture_no;
            txtFixture_no.Text = modFixture.Fixture_no;
            ddlFixture_car.SelectedValue = modFixture.Fixture_car1;
            ddlFixture_car2.SelectedValue = modFixture.Fixture_car2.Split('-')[0];
            ddlFixture_car3.SelectedValue = modFixture.Fixture_car2.Split('-')[1];
            txtFixture_name.Text = modFixture.Fixture_name;
            txtFixture_usefor.Text = modFixture.Fixture_usefor;
            txtQuantity.Text = modFixture.Quantity.ToString();
            if (modFixture.Create_date.ToString() != string.Empty)
                txtCreateDate.Text = Convert.ToDateTime(modFixture.Create_date).ToString("yyyy-MM-dd");
            if (modFixture.Limit_date.ToString() != string.Empty)
                txtLimitDate.Text = Convert.ToDateTime(modFixture.Limit_date).ToString("yyyy-MM-dd");
            if (modFixture.Limit_date.ToString() != string.Empty)
                txtNote.Text = modFixture.Note.ToString();
           
        }

        public void Add()
        {

            if (bllFixture.GetFixturebyFixture_no(modFixture) != null)
            {
                ServerJavascrpit.Alert.Warn(this.Page, "治具編號" + txtFixture_no.Text + "<BR/>已被使用");
            }
            else
            {
                modFixture = GetEidt(modFixture);
                modFixture.Status = Convert.ToInt32(Status.在庫);
                bllFixture.Add(modFixture);
                ServerJavascrpit.Alert.Success(this.Page, "治具新增完成");
            }
        }

        public void Update()
        {

            if (bllFixture.GetFixturebyFixture_no(modFixture) != null)
            {
                if (hfFixture_no.Value == modFixture.Fixture_no)
                {
                    modFixture = bllFixture.GetModel(Convert.ToInt32(hfFixture_sn.Value));
                    GetEidt(modFixture);
                    bllFixture.Update(modFixture);
                    ServerJavascrpit.Alert.Success(this.Page, "治具修改完成");
                }
                else 
                {
                    ServerJavascrpit.Alert.Warn(this.Page, "治具編號" + txtFixture_no.Text + "<BR/>已被使用"); 
                }
               
            }
            else
            {
                modFixture = bllFixture.GetModel(Convert.ToInt32(hfFixture_sn.Value));
                GetEidt(modFixture);
                bllFixture.Update(modFixture);
                ServerJavascrpit.Alert.Success(this.Page, "治具修改完成");
            }
        }

    }
}