using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:OutFixture
    /// </summary>
    public partial class OutFixture
    {
        public OutFixture()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Out_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OutFixture");
            strSql.Append(" where Out_sn=@Out_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Out_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Out_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.OutFixture model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OutFixture(");
            strSql.Append("Fixture_sn,User_sn,Place_sn,Note,Create_date,Out_date,Valid,OutStatus)");
            strSql.Append(" values (");
            strSql.Append("@Fixture_sn,@User_sn,@Place_sn,@Note,@Create_date,@Out_date,@Valid,@OutStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Create_date", SqlDbType.Date,3),
					new SqlParameter("@Out_date", SqlDbType.Date,3),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@OutStatus", SqlDbType.Int,4)};
            parameters[0].Value = model.Fixture_sn;
            parameters[1].Value = model.User_sn;
            parameters[2].Value = model.Place_sn;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.Create_date;
            parameters[5].Value = model.Out_date;
            parameters[6].Value = model.Valid;
            parameters[7].Value = model.OutStatus;

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
        public bool Update(PE2.Model.OutFixture model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OutFixture set ");
            strSql.Append("Fixture_sn=@Fixture_sn,");
            strSql.Append("User_sn=@User_sn,");
            strSql.Append("Place_sn=@Place_sn,");
            strSql.Append("Note=@Note,");
            strSql.Append("Create_date=@Create_date,");
            strSql.Append("Out_date=@Out_date,");
            strSql.Append("Valid=@Valid,");
            strSql.Append("OutStatus=@OutStatus");
            strSql.Append(" where Out_sn=@Out_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Create_date", SqlDbType.Date,3),
					new SqlParameter("@Out_date", SqlDbType.Date,3),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@OutStatus", SqlDbType.Int,4),
					new SqlParameter("@Out_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Fixture_sn;
            parameters[1].Value = model.User_sn;
            parameters[2].Value = model.Place_sn;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.Create_date;
            parameters[5].Value = model.Out_date;
            parameters[6].Value = model.Valid;
            parameters[7].Value = model.OutStatus;
            parameters[8].Value = model.Out_sn;

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
        public bool Delete(int Out_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OutFixture ");
            strSql.Append(" where Out_sn=@Out_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Out_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Out_sn;

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
        public bool DeleteList(string Out_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OutFixture ");
            strSql.Append(" where Out_sn in (" + Out_snlist + ")  ");
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
        public PE2.Model.OutFixture GetModel(int Out_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Out_sn,Fixture_sn,User_sn,Place_sn,Note,Create_date,Out_date,Valid,OutStatus from OutFixture ");
            strSql.Append(" where Out_sn=@Out_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Out_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Out_sn;

            PE2.Model.OutFixture model = new PE2.Model.OutFixture();
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
        public PE2.Model.OutFixture DataRowToModel(DataRow row)
        {
            PE2.Model.OutFixture model = new PE2.Model.OutFixture();
            if (row != null)
            {
                if (row["Out_sn"] != null && row["Out_sn"].ToString() != "")
                {
                    model.Out_sn = int.Parse(row["Out_sn"].ToString());
                }
                if (row["Fixture_sn"] != null && row["Fixture_sn"].ToString() != "")
                {
                    model.Fixture_sn = int.Parse(row["Fixture_sn"].ToString());
                }
                if (row["User_sn"] != null && row["User_sn"].ToString() != "")
                {
                    model.User_sn = int.Parse(row["User_sn"].ToString());
                }
                if (row["Place_sn"] != null && row["Place_sn"].ToString() != "")
                {
                    model.Place_sn = int.Parse(row["Place_sn"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["Create_date"] != null && row["Create_date"].ToString() != "")
                {
                    model.Create_date = DateTime.Parse(row["Create_date"].ToString());
                }
                if (row["Out_date"] != null && row["Out_date"].ToString() != "")
                {
                    model.Out_date = DateTime.Parse(row["Out_date"].ToString());
                }
                if (row["Valid"] != null && row["Valid"].ToString() != "")
                {
                    model.Valid = int.Parse(row["Valid"].ToString());
                }
                if (row["OutStatus"] != null && row["OutStatus"].ToString() != "")
                {
                    model.OutStatus = int.Parse(row["OutStatus"].ToString());
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
            strSql.Append("select Out_sn,Fixture_sn,User_sn,Place_sn,Note,Create_date,Out_date,Valid,OutStatus ");
            strSql.Append(" FROM OutFixture ");
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
            strSql.Append(" Out_sn,Fixture_sn,User_sn,Place_sn,Note,Create_date,Out_date,Valid,OutStatus ");
            strSql.Append(" FROM OutFixture ");
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
            strSql.Append("select count(1) FROM OutFixture ");
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
                strSql.Append("order by T.Out_sn desc");
            }
            strSql.Append(")AS Row, T.*  from OutFixture T ");
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
            parameters[0].Value = "OutFixture";
            parameters[1].Value = "Out_sn";
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

