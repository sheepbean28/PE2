using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PE2.SearchModel
{
    
    public partial class User
    {
        BLL.User bll = new BLL.User();
        public User(Page page) 
        {
            if (HttpContext.Current.Session["UserModel"] != null)
            {
                Model = (PE2.Model.User)(HttpContext.Current.Session["UserModel"]);
            }
            else 
            {
                Model = new PE2.Model.User();
                HttpContext.Current.Session["UserModel"] = Model;
            }
            if (Model.User_sn == 0)
            {
                ServerJavascrpit.ReturnLogin.ToReturnLogin(page);
              //   HttpContext.Current.Response.Redirect("/PE2/Login.aspx");
            }
        }
        public User()
        {
            if (HttpContext.Current.Session["UserModel"] != null)
            {
                Model = (PE2.Model.User)(HttpContext.Current.Session["UserModel"]);
            }
            else
            {
                Model = new PE2.Model.User();
                HttpContext.Current.Session["UserModel"] = Model;
            }
        }
        public int Power_sn(int Power) 
        {
            int Power_sn = Model.User_sn;
            if (Power == Model.Power)
            {
                Power_sn = 0;
            }
            if (Model.Power == -1)
            {
                Power_sn = 0;
            }
            return Power_sn;
        }
        public PE2.Model.User Model
        {
            set;
            get;
        }
        
        public bool LoginStatus() 
        {
           Model = bll.GetModel(Model.User_name,Model.Password);
           HttpContext.Current.Session["UserModel"] = Model;
           if (Model != null)
           {
               return true;
           }
           else 
           {
               return false;
           }
        }
        public void ClearModel()
        {
            HttpContext.Current.Session["UserModel"] = null;
        }
    }
}