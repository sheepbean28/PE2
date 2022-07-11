using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User User = new SearchModel.User(this.Page);
            lbName.Text = User.Model.User_name;
            //User.Model.User_sn = 1;
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            SearchModel.User User = new SearchModel.User(this.Page);
            User.ClearModel();
            Response.Redirect("/PE2/Login.aspx");
        }
    }
}
