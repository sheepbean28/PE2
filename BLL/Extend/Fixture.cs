using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PE2.BLL
{
    public partial class Fixture
    {
        public DataTable GetUsefor()
        {
            return dal.GetUsefor();
        }
        public DataTable GetFixtureList(Model.Fixture model)
        {
            return dal.GetFixtureList(model);
        }
        public List<Model.Fixture> GetFixtureListList(Model.Fixture model)
        {
            return DataTableToList(dal.GetFixtureList(model));
            
        }


        
        public DataTable GetFixtureList(Model.Fixture model,int User_sn)
        {
            return dal.GetFixtureList(model, User_sn);
        }
        public Model.Fixture GetFixturebyFixture_no(Model.Fixture model)
        {
            if (model.Fixture_no != string.Empty)
            {
                model.Status = -1;
                DataTable dt = dal.GetFixtureList(model);
                if (dt != null)
                {
                    return dal.GetModel(Convert.ToInt32(dt.Rows[0]["Fixture_sn"]));
                }

            }
            return null;

        }
    }
}
