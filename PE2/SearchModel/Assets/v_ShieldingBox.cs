using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class v_ShieldingBox
    {
        public v_ShieldingBox()
        {
            if (HttpContext.Current.Session["v_ShieldingBoxModel"] != null)
            {
                Model = (PE2.Model.v_ShieldingBox)(HttpContext.Current.Session["v_ShieldingBoxModel"]);
            }
            else
            {
                Model = new PE2.Model.v_ShieldingBox();
                HttpContext.Current.Session["v_ShieldingBoxModel"] = Model;
            }
        }
        public PE2.Model.v_ShieldingBox Model
        {
            set;
            get;
        }
        public void ClearModel()
        {
            HttpContext.Current.Session["v_ShieldingBoxModel"] = new PE2.Model.v_ShieldingBox(); ;
        }
    }
}