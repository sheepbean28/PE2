using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PE2
{
    public partial class ServerJavascrpit
    {
        public partial class Alert
        {
            public static void Success(Page page, string Msg)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "successJavascrpit", "$.ligerDialog.success('" + Msg + "');", true);
            }
            public static void Warn(Page page, string Msg)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "warnJavascrpit", "$.ligerDialog.warn('" + Msg + "');", true);
            }
        }
        public partial class Textbox
        { 
            public static void Focus(Page page, string Textbox)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "FocusJavascrpit", "$('#" + Textbox  + "').select();", true);
            }
        }
        public partial class ReturnLogin
        {
            public static void ToReturnLogin(Page page)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "ReturnLoginJavascrpit", "window.parent.ReturnLogin();", true);
            }
        }
        
    }
}