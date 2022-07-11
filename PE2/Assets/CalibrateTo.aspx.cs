using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Assets
{
    public partial class ToCalibrate : System.Web.UI.Page
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
            if (model != null)
            {
                Model.Calibrate_Log modCL = new Model.Calibrate_Log();
                modCL.Calibrate_sn = model.Calibrate_sn;
                modCL.Start_Date = Convert.ToDateTime(tbStartEate.Text);
                modCL.Note = tbNote.Text;

                model.Last_Cp_Log_sn = bllCL.Add(modCL);
                model.Last_Cp_Date = modCL.Start_Date;
                if(ddlStatus.SelectedValue == "1")
                    model.Cp_Status = 2;
                else
                    model.Cp_Status = 3;
                model.Next_Cp_Date = modCL.Start_Date;

                bllCp.Update(model);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
            }
        }
    }
}