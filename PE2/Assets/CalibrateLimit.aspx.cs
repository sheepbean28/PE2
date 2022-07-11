using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class CalibrateLimit : System.Web.UI.Page
    {
        BLL.v_Calibrate bll = new BLL.v_Calibrate();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.v_Calibrate model = new SearchModel.v_Calibrate();
            if (modUser.Model.Power == Convert.ToInt32(Power.校驗管理))
            {
                model.Model.Floor_sn = 0;
            }
            else 
            {
                model.Model.Floor_sn = modUser.Model.Place_sn;
            }
            model.Model.Non_In_Type = Convert.ToInt32(CP_Type.免校驗).ToString();
            model.Model.Cp_Status = Convert.ToInt32(CP_Status.已送回);
            model.Model.Next_Cp_Date_d = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            DataTable dt = bll.GetCalibrateList(model.Model);
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
                if (e.Row.Cells[1].Text.Replace("&nbsp;","") != string.Empty)
                {

                    double days = new TimeSpan(DateTime.Now.Ticks - Convert.ToDateTime(e.Row.Cells[1].Text).Ticks).TotalDays;
                    if (days > -60)
                    {
                        e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                    }

                }

            }
        }
    }
}