using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace PE2.DAL
{
    public partial class Place
    {
        public DataTable GetPlace(int Class, int Refer_sn, int PowerPlace) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM Place WHERE 1 = 1 ");

            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Class", SqlDbType.Int),
                    new SqlParameter("@Refer_sn", SqlDbType.Int)
            };
            if (Class != 0)
            {
                strSql.Append(" And Class = @Class ");
                parameters[0].Value = Class;
            }
            if (Refer_sn != 0)
            {
                strSql.Append(" And Refer_sn = @Refer_sn ");
                parameters[1].Value = Refer_sn;
            }
            if (PowerPlace != 0)
            {
                //strSql.Append(" And ([Userfor] & " + PowerPlace + ") = " + PowerPlace);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
