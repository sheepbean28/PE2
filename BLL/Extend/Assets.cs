using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PE2.BLL
{
    public partial class Assets
    {
        public DataTable GetAssetsList(Model.Assets model)
        {
            return dal.GetAssetsList(model);
        }
        public DataTable GetAsstsStation()
        {
            return dal.GetAsstsStation();
        }
        //public PE2.Model.Assets GetModel(string Assets_no)
        //{

        //    return dal.GetModel(Assets_sn);
        //}

    }
}
