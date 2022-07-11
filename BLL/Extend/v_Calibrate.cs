using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PE2.BLL
{
    public partial  class v_Calibrate
    {
        public DataTable GetCalibrateList(Model.v_Calibrate model)
        {
            return dal.GetCalibrateList(model);
        }
    }
}
