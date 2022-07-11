using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.SearchModel
{
    public partial class Supplies
    {
           public Supplies() 
        {
            if (HttpContext.Current.Session["SuppliesModel"] != null)
            {
                Model = (PE2.Model.Supplies)(HttpContext.Current.Session["SuppliesModel"]);
                List = (List<PE2.Model.Supplies>)(HttpContext.Current.Session["SuppliesList"]);
            }
            else 
            {
                Model = new PE2.Model.Supplies();
                List = new List<PE2.Model.Supplies>();
                HttpContext.Current.Session["SuppliesModel"] = Model;
                HttpContext.Current.Session["SuppliesList"] = List;
            }
        }
        public PE2.Model.Supplies Model
        {
            set;
            get;
        }
        public void ClearModel()
        {
            HttpContext.Current.Session["SuppliesModel"] = null;
        }

        //LIST
        public List<PE2.Model.Supplies> List
        {
            set;
            get;
        }
        public void ClearList()
        {
            List.Clear();
        }

        public void Add(PE2.Model.Supplies Model)
        {
            if (!isFind(Model))
                List.Add(Model);
            else
            {
               // Delete(Model.Supplies_no);
                List.Add(Model);
            }
            HttpContext.Current.Session["SuppliesList"] = List;
        }
        public bool isFind(PE2.Model.Supplies Model)
        {
            return List.Exists(x => x.Supplies_no == Model.Supplies_no);
        }
        public bool isFind(string Supplies_no)
        {
            return List.Exists(x => x.Supplies_no == Supplies_no);
        }

        public void Delete(string Supplies_no)
        {
            if (isFind(Supplies_no))
            {
                List.Remove(List.Find(x => x.Supplies_no == Supplies_no));
            }
            HttpContext.Current.Session["SuppliesList"] = List;
        }
      
    }
}