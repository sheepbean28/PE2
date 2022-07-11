using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PE2.Model;
namespace PE2.BLL
{
    /// <summary>
    /// SuppliesLog
    /// </summary>
    public partial class SuppliesLog
    {
        public DataTable GetSuppliesLogList()
        {
            return dal.GetSuppliesLogList();
        }
    }
}

