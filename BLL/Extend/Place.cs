using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PE2.BLL
{
    public partial class Place
    {
        public DataTable GetPlace(int Class, int Refer_sn,int PowerPlace)
        {
            return dal.GetPlace(Class, Refer_sn, PowerPlace);
        }
    }
}
