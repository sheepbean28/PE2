using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class OutFixture
    {
        public OutFixture() 
        {
            if (HttpContext.Current.Session["OutFixtureList"] != null)
            {
                List = (List<PE2.Model.OutFixture>)(HttpContext.Current.Session["OutFixtureList"]);
            }
            else 
            {
                List = new List<PE2.Model.OutFixture>();
                HttpContext.Current.Session["OutFixtureList"] = List;
            }
        }
        public List<PE2.Model.OutFixture> List
        {
            set;
            get;
        }
        public void Add(PE2.Model.OutFixture Model) 
        {
            if (!isFind(Model))
                List.Add(Model);
        }
        public bool isFind(PE2.Model.OutFixture Model) 
        {
            return List.Exists(x => x.Fixture_no == Model.Fixture_no);
        }
        public bool isFind(string Fixture_no)
        {
            return List.Exists(x => x.Fixture_no == Fixture_no);
        }
        public void Update(PE2.Model.OutFixture Model)
        { 
        
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
            HttpContext.Current.Session["OutFixtureList"] = null;
        }
    }
}