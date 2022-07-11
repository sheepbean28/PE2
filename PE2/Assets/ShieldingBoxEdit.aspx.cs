using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Assets
{
    public partial class ShieldingBoxEdit : System.Web.UI.Page
    {
        BLL.ShieldingBox bllShieldingBox = new BLL.ShieldingBox();
        Model.ShieldingBox modShieldingBox = new Model.ShieldingBox();
        BLL.Assets bllAssets = new BLL.Assets();
        Model.Assets modAssets = new Model.Assets();

        protected void Page_Load(object sender, EventArgs e)
        {
            hfShieldingBox_sn.Value = Request.QueryString["Mode"];
            if (!IsPostBack)
            {
                if (hfShieldingBox_sn.Value != "0")
                {
                    LoadData();
                }
            }
        }
        protected void txtAsset_no_TextChanged(object sender, EventArgs e)
        {
            List<Model.Assets> lst = bllAssets.GetModelList(" Assts_no = '" + txtAsset_no.Text + "'");
            if (lst.Count > 0)
            {
                hfAssets_sn.Value = lst[0].Assets_sn.ToString();
            }
            LoadAssets();
        }

        public void LoadData()
        {
            modShieldingBox = bllShieldingBox.GetModel(Convert.ToInt32(hfShieldingBox_sn.Value));
            txt2GOpen.Text = modShieldingBox.Cp2G_Open.ToString();
            txt2GClose.Text = modShieldingBox.Cp2G_Close.ToString();
            txt2GShild.Text = modShieldingBox.Cp2G_Shileld.ToString();
            txt5GOpen.Text = modShieldingBox.Cp5G_Open.ToString();
            txt5GClose.Text = modShieldingBox.Cp5G_Close.ToString();
            txt5GShild.Text = modShieldingBox.Cp5G_Shileld.ToString();
            txtCp_date.Text = Convert.ToDateTime(modShieldingBox.Cp_date).ToString("yyyy-MM-dd");
            txtLimit_date.Text = Convert.ToDateTime(modShieldingBox.Limit_date).ToString("yyyy-MM-dd");
            txtNote.Text = modShieldingBox.Note;


            //
            if (modShieldingBox.Assets_sn != "0")
            {
                hfAssets_sn.Value = modShieldingBox.Assets_sn.ToString();
                LoadAssets();
            }
        }
        public void LoadAssets()
        {
            modAssets = bllAssets.GetModel(Convert.ToInt32(hfAssets_sn.Value));
            txtAsset_no.Text = modAssets.Assts_no;
            txtAssts_eq_name.Text = modAssets.Assts_eq_name;
            //txtAssts_name.Text = modAssets.Assts_name;
            //txtAssts_id.Text = modAssets.Assts_id;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            if (hfShieldingBox_sn.Value != "0")
            {
                modShieldingBox = bllShieldingBox.GetModel(Convert.ToInt32(hfShieldingBox_sn.Value));
            }
            else
            {
                modShieldingBox = new Model.ShieldingBox();
            }
           
            modShieldingBox.Cp2G_Open = Convert.ToDecimal(txt2GOpen.Text);
            modShieldingBox.Cp2G_Close = Convert.ToDecimal(txt2GClose.Text);
            modShieldingBox.Cp2G_Shileld = Convert.ToDecimal(txt2GShild.Text);
            modShieldingBox.Cp5G_Open = Convert.ToDecimal(txt5GOpen.Text);
            modShieldingBox.Cp5G_Close = Convert.ToDecimal(txt5GClose.Text);
            modShieldingBox.Cp5G_Shileld = Convert.ToDecimal(txt5GShild.Text);
            modShieldingBox.Note = txtNote.Text;
            modShieldingBox.Assets_sn = hfAssets_sn.Value;
            modShieldingBox.Cp_date = Convert.ToDateTime(txtCp_date.Text);
            modShieldingBox.Limit_date = Convert.ToDateTime(txtCp_date.Text).AddDays(90);
            if (hfShieldingBox_sn.Value != "0")
            {
                bllShieldingBox.Update(modShieldingBox);
            }
            else 
            {
                bllShieldingBox.Add(modShieldingBox);
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CloseJavascrpit", " window.parent.CloseAndreFresh();", true);
        }

        protected void txt2GShild_TextChanged(object sender, EventArgs e)
        {
            //輸入隔離度(2G)後,自動帶出隔離度(2G關閉).
            Double sum  = Convert.ToDouble(txt2GShild.Text) - 7;
            txt2GClose.Text = sum.ToString();
        }

        protected void txt5GShild_TextChanged(object sender, EventArgs e)
        {
            //輸入隔離度(5G)後,自動帶出隔離度(5G關閉).
            Double sum = Convert.ToDouble(txt5GShild.Text) - 18;
            txt5GClose.Text = sum.ToString();
        }

       
    }
}