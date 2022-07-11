using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Assets
{
    public partial class EditCalibation : System.Web.UI.Page
    {
        BLL.Calibrate bllCalibrate = new BLL.Calibrate();
        Model.Calibrate modCalibrate = new Model.Calibrate();
        BLL.Assets bllAssets = new BLL.Assets();
        Model.Assets modAssets = new Model.Assets();
        protected void Page_Load(object sender, EventArgs e)
        {
            hfCalibrate_sn.Value = Request.QueryString["Mode"];
            if (!IsPostBack) 
            {
                if (hfCalibrate_sn.Value != "0")
                {
                    LoadData();
                }
            }
        }
        public void LoadData()
        {
            modCalibrate = bllCalibrate.GetModel(Convert.ToInt32(hfCalibrate_sn.Value));
            if (modAssets != null)
            {

                ddlCp_place.SelectedValue = modCalibrate.Cp_Place;
                ddlCp_type.SelectedValue = modCalibrate.Cp_Type;
                ddlCp_Date_Range.SelectedValue = modCalibrate.Cp_Date_Range;
                tbEq_id.Text = modCalibrate.Eq_id;
                txtCp_Note.Text = modCalibrate.Cp_Note;
                txtCp_Note1.Text = modCalibrate.Cp_Note1;
            }
            //資產資料
            if (modCalibrate.Assets_sn != 0 && modCalibrate.Assets_sn != null)
            {
                hfAssets_sn.Value = modCalibrate.Assets_sn.ToString();
                LoadAssets();
            }

        }
        public void LoadAssets()
        {
            modAssets = bllAssets.GetModel(Convert.ToInt32(hfAssets_sn.Value));
            txtAsset_no.Text = modAssets.Assts_no;
            txtAssts_eq_name.Text = modAssets.Assts_eq_name;
            txtAssts_name.Text = modAssets.Assts_name;
            txtAssts_id.Text = modAssets.Assts_id;

        }
        public void SetCalibrate() 
        {
            modCalibrate.Cp_Place = ddlCp_place.SelectedValue;
            modCalibrate.Cp_Type = ddlCp_type.SelectedValue;
            modCalibrate.Cp_Date_Range =  ddlCp_Date_Range.SelectedValue;
            modCalibrate.Eq_id = tbEq_id.Text;
            modCalibrate.Eq_no = txtAsset_no.Text;
            modCalibrate.Cp_Note = txtCp_Note.Text;
            modCalibrate.Cp_Note1 = txtCp_Note1.Text;
            modCalibrate.Assets_sn = Convert.ToInt32(hfAssets_sn.Value);
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
          
            if (hfCalibrate_sn.Value != "0")
            {
                modCalibrate = bllCalibrate.GetModel(Convert.ToInt32(hfCalibrate_sn.Value));
                SetCalibrate();
                bllCalibrate.Update(modCalibrate);
            }
            else 
            {
                SetCalibrate();
                modCalibrate.Cp_Status = 1;
                bllCalibrate.Add(modCalibrate);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
        }

        protected void txtAsset_no_TextChanged(object sender, EventArgs e)
        {
            List<Model.Assets> lst = bllAssets.GetModelList(" Assts_no = '" + txtAsset_no.Text + "'");
            if (lst.Count > 0)
            {
                hfAssets_sn.Value = lst[0].Assets_sn.ToString();
                LoadAssets();
            }
            else 
            {
                string Msg = txtAsset_no.Text;
                LoadAssets();
                PE2.ServerJavascrpit.Alert.Warn(this, "查無(" + Msg + ")此資產編號");
            }
            
        }
    }
}