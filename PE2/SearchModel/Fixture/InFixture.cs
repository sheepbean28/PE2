using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class InFixture
    {
        public InFixture() 
        {
            if (HttpContext.Current.Session["InFixtureList"] != null)
            {
                List = (List<PE2.Model.InFixture>)(HttpContext.Current.Session["InFixtureList"]);
            }
            else 
            {
                List = new List<PE2.Model.InFixture>();
                HttpContext.Current.Session["InFixtureList"] = List;
            }
        }
        public List<PE2.Model.InFixture> List
        {
            set;
            get;
        }

        public void Add(PE2.Model.InFixture Model) 
        {
            if (!isFind(Model))
                List.Add(Model);
        }
        public bool isFind(PE2.Model.InFixture Model) 
        {
            return List.Exists(x => x.Fixture_no == Model.Fixture_no);
        }
        public bool isFind(string Fixture_no)
        {
            return List.Exists(x => x.Fixture_no == Fixture_no);
        }
        
        public void Delete(string Fixture_no)
        {
            if (isFind(Fixture_no))
            {
                List.Remove(List.Find(x => x.Fixture_no == Fixture_no));
            }
        }
        public void ClearList()
        {
            HttpContext.Current.Session["InFixtureList"] = null;
        }
    }
}