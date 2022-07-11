using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE2
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            //panFixtureLimit.Visible = (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0);
            //panShieldingBox.Visible = (modUser.Power_sn(Convert.ToInt32(Power.隔離箱管理)) == 0);
            
        }
    }
}