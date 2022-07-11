using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
//using LTP.Accounts.Bus;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Text;
namespace Maticsoft.Common
{
	/// <summary>
	/// 珜醱脯(桶尨脯)價濬,垀衄珜醱樟創蜆珜醱
	/// </summary>
	public class PageBase:System.Web.UI.Page
	{
        public int PermissionID = -1;//蘇-1峈拸癹秶ㄛ褫眕婓祥肮珜醱樟創爵懂諷秶祥肮珜醱腔癹
        string virtualPath = Maticsoft.Common.ConfigHelper.GetConfigString("VirtualPath");
        		
		/// <summary>
		/// 凳婖滲杅
		/// </summary>
		public PageBase()
		{
            //this.Load+=new EventHandler(PageBase_Load);
		}
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(PageBase_Load);
            this.Error += new System.EventHandler(PageBase_Error);
        }
        //渣昫揭燴
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            Exception currentError = Server.GetLastError();
            errMsg = "<link rel=\"stylesheet\" href=\"/style.css\">";
            errMsg += "<h1>炵苀渣昫ㄩ</h1><hr/>炵苀楷汜渣昫ㄛ " +
                "蜆陓洘眒掩炵苀暮翹ㄛ尕綴笭彸麼迵奪燴埜薊炵﹝<br/>" +
                "渣昫華硊ㄩ " + Request.Url.ToString() + "<br/>" +
                "渣昫陓洘ㄩ <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
                "<b>Stack Trace:</b><br/>" +  currentError.ToString();
            Response.Write(errMsg);
            Server.ClearError();

        }
		private void PageBase_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack )
			{

                //癹桄痐
                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    if (Session["UserInfo"] == null)
                    {
                        LTP.Accounts.Bus.User currentUser = new LTP.Accounts.Bus.User(user);
                        Session["UserInfo"] = currentUser;
                        Session["Style"] = currentUser.Style;
                        Response.Write("<script defer>location.reload();</script>");
                    }
                    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                    {
                        Response.Clear();
                        Response.Write("<script defer>window.alert('蠟羶衄癹輛掛珜ㄐ\\n笭陔腎翹麼迵奪燴埜薊炵');history.back();</script>");
                        Response.End();
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    Response.Clear();
                    Response.Write("<script defer>window.alert('蠟羶衄癹輛掛珜麼絞腎翹蚚誧眒徹ㄐ\\n笭陔腎翹麼迵奪燴埜薊炵ㄐ');parent.location='" + virtualPath + "/Login.aspx';</script>");
                    Response.End();
                }		
			}            
			
		}
	}
}
