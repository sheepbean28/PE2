using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PE2.BLL
{
    public partial class v_ShieldingBox
    {
        private readonly PE2.DAL.v_ShieldingBox dal = new PE2.DAL.v_ShieldingBox();
        public DataTable GetShieldingBoxList(Model.v_ShieldingBox model)
        {
            return dal.GetShieldingBoxList(model);
        }
    }
}
