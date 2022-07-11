using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PE2.Model;
namespace PE2.BLL
{
    /// <summary>
    /// Supplies
    /// </summary>
    public partial class Supplies
    {
        public DataTable GetSuppliesList(Model.Supplies model)
        {
            return dal.GetSuppliesList(model);
        }
        public Model.Supplies GetSuppliesbySupplies_no(Model.Supplies model)
        {
            if (model.Supplies_no != string.Empty)
            {
                Model.Supplies model2 = new Model.Supplies();
                model2.Supplies_no = model.Supplies_no;
                DataTable dt = dal.GetSuppliesList(model2,true);
                if (dt != null)
                {
                    return dal.GetModel(Convert.ToInt32(dt.Rows[0]["Supplies_sn"]));
                }

            }
            return null;

        }
        public string GetSupplies_no(string Supplies_Class)
        {
            return dal.GetSupplies_no(Supplies_Class);
        }
    }
}

