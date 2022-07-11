using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:Supplies
    /// </summary>
    public partial class SuppliesLog
    {
        public DataTable GetSuppliesLogList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_SuppliesLog]  order by Supplies_date desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}

