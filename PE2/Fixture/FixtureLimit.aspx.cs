using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Fixture
{
    public partial class FixtureLimit1 : System.Web.UI.Page
    {
        BLL.Fixture bllFixture = new BLL.Fixture();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.Fixture model = new SearchModel.Fixture();
            model.Model.Limit_date = DateTime.Now;
            model.Model.Status = Convert.ToInt32(Status.已領出);
            
            DataTable dt = bllFixture.GetFixtureList(model.Model);
            gvFixture.DataSource = dt;
            gvFixture.DataBind();
            if (dt != null)
            {
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

                    double days = new TimeSpan(DateTime.Now.Ticks - Convert.ToDateTime(e.Row.Cells[3].Text).Ticks).TotalDays;
                    if (days > 60)
                    {
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    }

                }

            }
        }
    }
}