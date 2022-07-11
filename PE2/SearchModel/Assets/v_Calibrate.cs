using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class v_Calibrate
    {
        public v_Calibrate()
        {
            if (HttpContext.Current.Session["v_CalibrateModel"] != null)
            {
                Model = (PE2.Model.v_Calibrate)(HttpContext.Current.Session["v_CalibrateModel"]);
            }
            else
            {
                Model = new PE2.Model.v_Calibrate();
                HttpContext.Current.Session["v_CalibrateModel"] = Model;
            }
        }
        public PE2.Model.v_Calibrate Model
        {
            set;
            get;
        }
        public void ClearModel()
        {
            HttpContext.Current.Session["v_CalibrateModel"] = new PE2.Model.v_Calibrate(); ;
        }
    }
}