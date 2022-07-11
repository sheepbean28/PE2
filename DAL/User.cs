using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:User
    /// </summary>
    public partial class User
    {
        public User()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int User_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User");
            strSql.Append(" where User_sn=@User_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@User_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = User_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into User(");
            strSql.Append("User_no,User_name,Login_date,Valid,Password,Power,Place_sn)");
            strSql.Append(" values (");
            strSql.Append("@User_no,@User_name,@Login_date,@Valid,@Password,@Power,@Place_sn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@User_no", SqlDbType.NVarChar,50),
					new SqlParameter("@User_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Login_date", SqlDbType.Date,3),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.User_no;
            parameters[1].Value = model.User_name;
            parameters[2].Value = model.Login_date;
            parameters[3].Value = model.Valid;
            parameters[4].Value = model.Password;
            parameters[5].Value = model.Power;
            parameters[6].Value = model.Place_sn;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PE2.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update User set ");
            strSql.Append("User_no=@User_no,");
            strSql.Append("User_name=@User_name,");
            strSql.Append("Login_date=@Login_date,");
            strSql.Append("Valid=@Valid,");
            strSql.Append("Password=@Password,");
            strSql.Append("Power=@Power,");
            strSql.Append("Place_sn=@Place_sn");
            strSql.Append(" where User_sn=@User_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@User_no", SqlDbType.NVarChar,50),
					new SqlParameter("@User_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Login_date", SqlDbType.Date,3),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@User_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.User_no;
            parameters[1].Value = model.User_name;
            parameters[2].Value = model.Login_date;
            parameters[3].Value = model.Valid;
            parameters[4].Value = model.Password;
            parameters[5].Value = model.Power;
            parameters[6].Value = model.Place_sn;
            parameters[7].Value = model.User_sn;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int User_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User ");
            strSql.Append(" where User_sn=@User_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@User_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = User_sn;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string User_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User ");
            strSql.Append(" where User_sn in (" + User_snlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PE2.Model.User GetModel(int User_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 User_sn,User_no,User_name,Login_date,Valid,Password,Power,Place_sn from User ");
            strSql.Append(" where User_sn=@User_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@User_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = User_sn;

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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PE2.Model.User DataRowToModel(DataRow row)
        {
            PE2.Model.User model = new PE2.Model.User();
            if (row != null)
            {
                if (row["User_sn"] != null && row["User_sn"].ToString() != "")
                {
                    model.User_sn = int.Parse(row["User_sn"].ToString());
                }
                if (row["User_no"] != null)
                {
                    model.User_no = row["User_no"].ToString();
                }
                if (row["User_name"] != null)
                {
                    model.User_name = row["User_name"].ToString();
                }
                if (row["Login_date"] != null && row["Login_date"].ToString() != "")
                {
                    model.Login_date = DateTime.Parse(row["Login_date"].ToString());
                }
                if (row["Valid"] != null && row["Valid"].ToString() != "")
                {
                    model.Valid = int.Parse(row["Valid"].ToString());
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Power"] != null && row["Power"].ToString() != "")
                {
                    model.Power = int.Parse(row["Power"].ToString());
                }
                if (row["Place_sn"] != null && row["Place_sn"].ToString() != "")
                {
                    model.Place_sn = int.Parse(row["Place_sn"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_sn,User_no,User_name,Login_date,Valid,Password,Power,Place_sn ");
            strSql.Append(" FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" User_sn,User_no,User_name,Login_date,Valid,Password,Power,Place_sn ");
            strSql.Append(" FROM User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.User_sn desc");
            }
            strSql.Append(")AS Row, T.*  from User T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "User";
            parameters[1].Value = "User_sn";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

