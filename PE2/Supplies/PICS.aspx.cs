using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2.Supplies
{
    public partial class PICS : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();
        Model.Supplies modSupplies = new Model.Supplies();
        protected void Page_Load(object sender, EventArgs e)
        {
            hfSupplies_sn.Value = Request.QueryString["Mode"];
            if (!IsPostBack)
            {

                if (hfSupplies_sn.Value != "0" && hfSupplies_sn.Value != string.Empty)
                {
                    modSupplies = bllSupplies.GetModel(Convert.ToInt32(hfSupplies_sn.Value));
                    SetEidt(modSupplies);

                }
                else
                {

                }
            }
        }
        public void SetEidt(Model.Supplies model)
        {
            imgUpload.ImageUrl = model.Supplies_File.ToString();
        }

        protected void imgUpload_PreRender(object sender, EventArgs e)
        {
            if (Convert.ToInt32(imgUpload.Height.Value) >= 600)
            {
                imgUpload.Height = 600;
            }
            if (Convert.ToInt32(imgUpload.Width.Value) >= 800)
            {
                imgUpload.Height = 800;
            }
        }
    }
}