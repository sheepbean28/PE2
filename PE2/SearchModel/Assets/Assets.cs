using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public class Assets
    {
        public Assets()
        {
            if (HttpContext.Current.Session["AssetsModel"] != null)
            {
                Model = (PE2.Model.Assets)(HttpContext.Current.Session["AssetsModel"]);
            }
            else
            {
                Model = new PE2.Model.Assets();
                HttpContext.Current.Session["AssetsModel"] = Model;
            }
        }
        public PE2.Model.Assets Model
        {
            set;
            get;
        }
        public void ClearModel()
        {
            HttpContext.Current.Session["AssetsModel"] = new PE2.Model.Assets(); ;
        }
    }
}