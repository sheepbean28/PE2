using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class AssetsGroup
    {
        public AssetsGroup() 
        {
            if (HttpContext.Current.Session["AssetsGroupList"] != null)
            {
                List = (List<PE2.Model.Assets>)(HttpContext.Current.Session["AssetsGroupList"]);
            }
            else 
            {
                List = new List<PE2.Model.Assets>();
                HttpContext.Current.Session["AssetsGroupList"] = List;
            }
        }
        public List<PE2.Model.Assets> List
        {
            set;
            get;
        }
        public void Add(PE2.Model.Assets Model) 
        {
            if (!isFind(Model))
                List.Add(Model);
        }
        public bool isFind(PE2.Model.Assets Model) 
        {
            return List.Exists(x => x.Assts_no == Model.Assts_no);
        }
        public bool isFind(string Assts_no)
        {
            return List.Exists(x => x.Assts_no == Assts_no);
        }
        public void Update(PE2.Model.Assets Model)
        { 
        
        }
        public void Delete(string Assts_no)
        {
            if (isFind(Assts_no))
            {
                List.Remove(List.Find(x => x.Assts_no == Assts_no));
            }
        }
        public void ClearList()
        {
            HttpContext.Current.Session["AssetsGroupList"] = null;
        }
    }
}