using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                SearchModel.User User = new SearchModel.User();
                User.ClearModel();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.User User = new SearchModel.User();
            User.Model.User_name = tbUsername.Text;
            User.Model.Password = tbPassword.Text;
            if (User.LoginStatus()) 
            {
                Response.Redirect("Default.aspx");
            }
            else 
            {
                ServerJavascrpit.Alert.Warn(this.Page, "帳號資訊有誤");
            }
        }
    }
}