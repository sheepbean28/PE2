using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Fixture
{
    public partial class FixtureLimit : System.Web.UI.Page
    {
        BLL.Fixture bllFixture = new BLL.Fixture();
        BLL.User bllUser = new BLL.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                SearchModel.User modUser = new SearchModel.User(this.Page);
                btnHide.Visible = (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0);
                ddlUser.DataSource = bllUser.GetList("");
                ddlUser.DataBind();
                ddlUser.Items.Add(new ListItem("所有", "0"));
                ddlUser.SelectedValue = modUser.Power_sn(Convert.ToInt32(Power.治具管理)).ToString();
                ddlUser.Enabled = (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0);
                LoadData();
            }
        }
        public void LoadData()
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.Fixture model = new SearchModel.Fixture();
            model.Model.Status = Convert.ToInt32(PE2.Status.已領出);
            model.Model.sort = ddlSort.SelectedValue;
            //DataTable dt = bllFixture.GetFixtureList(model.Model, modUser.Power_sn(Convert.ToInt32(Power.治具管理)));
            DataTable dt = bllFixture.GetFixtureList(model.Model, Convert.ToInt32(ddlUser.SelectedValue));
            if (dt != null)
            {
                gvFixture.DataSource = dt;
                gvFixture.DataBind();
                //if (dt != null)
                //    lbCount.Text = dt.Rows.Count.ToString();
                lbTOtal.Text = dt.Rows.Count.ToString();
            }
            else 
            {
                dt = new DataTable();
                gvFixture.DataSource = dt;
                gvFixture.DataBind();
                //if (dt != null)
                //    lbCount.Text = dt.Rows.Count.ToString();
                lbTOtal.Text = dt.Rows.Count.ToString();
            }
            model.ClearModel();
        }

        protected void gvFixture_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                if (e.Row.Cells[3].Text != string.Empty)
                {
                    
                    double days = new TimeSpan(DateTime.Now.Ticks - Convert.ToDateTime(e.Row.Cells[4].Text).Ticks).TotalDays;
                    if (days > 60)
                    {
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    }
                    
                }
                
            }
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}