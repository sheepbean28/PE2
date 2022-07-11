using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE2.Model
{
    public partial class Fixture
    {
        public string StatusName 
        {
            get 
            {
                if (Status == 1)
                    return "在庫";
                if (Status == 0)
                    return "已領出";
                if (Status == 2)
                    return "報廢";
                if (Status == 3)
                    return "轉出";
                return "";
            }
        }
        public string Place_name
        {
            set;
            get;
        }
        public string sort
        {
            set;
            get;
        }
    }
}
