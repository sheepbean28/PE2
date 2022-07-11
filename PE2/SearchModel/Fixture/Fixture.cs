using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class Fixture
    {
        public Fixture() 
        {
            if (HttpContext.Current.Session["FixtureModel"] != null)
            {
                Model = (PE2.Model.Fixture)(HttpContext.Current.Session["FixtureModel"]);
            }
            else 
            {
                Model = new PE2.Model.Fixture();
                HttpContext.Current.Session["FixtureModel"] = Model;
            }
        }
        public Fixture(string str)
        {
            if (HttpContext.Current.Session[str] != null)
            {
                Model = (PE2.Model.Fixture)(HttpContext.Current.Session[str]);
            }
            else
            {
                Model = new PE2.Model.Fixture();
                HttpContext.Current.Session[str] = Model;
            }
        }
        public PE2.Model.Fixture Model
        {
            set;
            get;
        }
        public void ClearModel()
        {
            HttpContext.Current.Session["FixtureModel"] = null;
        }
        public void ClearModel(string str)
        {
            HttpContext.Current.Session[str] = null;
        }
    }
    
}