using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace PE2.DAL
{
   public partial class User
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public PE2.Model.User GetModel(string User_no, string Password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from [User] ");
            strSql.Append(" where User_no=@User_no and Password = @Password");
            SqlParameter[] parameters = {
					new SqlParameter("@User_no", SqlDbType.NVarChar),
                    new SqlParameter("@Password", SqlDbType.NVarChar)
			};
            parameters[0].Value = User_no;
            parameters[1].Value = Password;

            PE2.Model.User model = new PE2.Model.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
