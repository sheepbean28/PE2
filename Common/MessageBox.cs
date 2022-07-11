using System;
using System.Text;
namespace Maticsoft.Common
{
	/// <summary>
	/// 珆尨秏洘枑尨勤趕遺﹝
    /// Copyright (C) Maticsoft
	/// </summary>
	public class MessageBox
	{		
		private  MessageBox()
		{			
		}

		/// <summary>
		/// 珆尨秏洘枑尨勤趕遺
		/// </summary>
		/// <param name="page">絞珜醱硌渀ㄛ珨啜峈this</param>
		/// <param name="msg">枑尨陓洘</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{            
            page.ClientScript.RegisterStartupScript(page.GetType(),"message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

		/// <summary>
		/// 諷璃萸僻 秏洘枑尨遺
		/// </summary>
		/// <param name="page">絞珜醱硌渀ㄛ珨啜峈this</param>
		/// <param name="msg">枑尨陓洘</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// 珆尨秏洘枑尨勤趕遺ㄛ甜輛俴珜醱泐蛌
		/// </summary>
		/// <param name="page">絞珜醱硌渀ㄛ珨啜峈this</param>
		/// <param name="msg">枑尨陓洘</param>
		/// <param name="url">泐蛌腔醴梓URL</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{			
            //Response.Write("<script>alert('梛誧机瞄籵徹ㄐ珋婓峈珛喃硉﹝');window.location=\"" + pageurl + "\"</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');window.location=\"" + url + "\"</script>");


		}
        /// <summary>
        /// 珆尨秏洘枑尨勤趕遺ㄛ甜輛俴珜醱泐蛌
        /// </summary>
        /// <param name="page">絞珜醱硌渀ㄛ珨啜峈this</param>
        /// <param name="msg">枑尨陓洘</param>
        /// <param name="url">泐蛌腔醴梓URL</param>
        public static void ShowAndRedirects(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

		/// <summary>
		/// 怀堤赻隅砱褐掛陓洘
		/// </summary>
		/// <param name="page">絞珜醱硌渀ㄛ珨啜峈this</param>
		/// <param name="script">怀堤褐掛</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
             
		}

	}
}
