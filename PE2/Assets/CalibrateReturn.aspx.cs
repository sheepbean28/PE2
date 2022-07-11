using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Assets
{
    public partial class ReturnCalibrate : System.Web.UI.Page
    {
        BLL.Calibrate_Log bllCL = new BLL.Calibrate_Log();
        BLL.Calibrate bllCp = new BLL.Calibrate();
        protected void Page_Load(object sender, EventArgs e)
        {
            hfCalibrate_sn.Value = Request.QueryString["Mode"].ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Model.Calibrate model = bllCp.GetModel(Convert.ToInt32(hfCalibrate_sn.Value));
            Model.Calibrate_Log modCL = bllCL.GetModel((int)model.Last_Cp_Log_sn);
            if (modCL != null)
            {
                modCL.End_Date = Convert.ToDateTime(tbStartEate.Text);
                modCL.ReturnNote = tbNote.Text;
                bllCL.Update(modCL);

                model.Cp_Status = 1;
                model.Next_Cp_Date = Convert.ToDateTime(tbStartEate.Text).AddMonths(Convert.ToInt32(model.Cp_Date_Range));
                bllCp.Update(model);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
            }
        }
    }
}