using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class ShieldingBoxLimit : System.Web.UI.Page
    {
        BLL.v_ShieldingBox bll = new BLL.v_ShieldingBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.v_ShieldingBox model = new SearchModel.v_ShieldingBox();
            model.Model.Next_Cp_Date_d = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            DataTable dt = bll.GetShieldingBoxList(model.Model);
            gvCalibrate.DataSource = dt;
            gvCalibrate.DataBind();
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
                if (e.Row.Cells[0].Text.Replace("&nbsp;", "") != string.Empty)
                {

                    double days = new TimeSpan(DateTime.Now.Ticks - Convert.ToDateTime(e.Row.Cells[0].Text).Ticks).TotalDays;
                    if (days > -60)
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    }

                }

            }
        }
    }
}