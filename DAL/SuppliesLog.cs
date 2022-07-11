using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:SuppliesLog
    /// </summary>
    public partial class SuppliesLog
    {
        public SuppliesLog()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SuppliesLog_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SuppliesLog");
            strSql.Append(" where SuppliesLog_sn=@SuppliesLog_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@SuppliesLog_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = SuppliesLog_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.SuppliesLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SuppliesLog(");
            strSql.Append("Supplies_sn,StockBefore,Quantity,Type,Note,User_sn,Supplies_date)");
            strSql.Append(" values (");
            strSql.Append("@Supplies_sn,@StockBefore,@Quantity,@Type,@Note,@User_sn,@Supplies_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_sn", SqlDbType.Int,4),
					new SqlParameter("@StockBefore", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,-1),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Supplies_date", SqlDbType.DateTime)};
            parameters[0].Value = model.Supplies_sn;
            parameters[1].Value = model.StockBefore;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Note;
            parameters[5].Value = model.User_sn;
            parameters[6].Value = model.Supplies_date;

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
        public bool Update(PE2.Model.SuppliesLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SuppliesLog set ");
            strSql.Append("Supplies_sn=@Supplies_sn,");
            strSql.Append("StockBefore=@StockBefore,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Type=@Type,");
            strSql.Append("Note=@Note,");
            strSql.Append("User_sn=@User_sn,");
            strSql.Append("Supplies_date=@Supplies_date");
            strSql.Append(" where SuppliesLog_sn=@SuppliesLog_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_sn", SqlDbType.Int,4),
					new SqlParameter("@StockBefore", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,-1),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Supplies_date", SqlDbType.DateTime),
					new SqlParameter("@SuppliesLog_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Supplies_sn;
            parameters[1].Value = model.StockBefore;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Note;
            parameters[5].Value = model.User_sn;
            parameters[6].Value = model.Supplies_date;
            parameters[7].Value = model.SuppliesLog_sn;

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
        public bool Delete(int SuppliesLog_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SuppliesLog ");
            strSql.Append(" where SuppliesLog_sn=@SuppliesLog_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@SuppliesLog_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = SuppliesLog_sn;

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
        public bool DeleteList(string SuppliesLog_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SuppliesLog ");
            strSql.Append(" where SuppliesLog_sn in (" + SuppliesLog_snlist + ")  ");
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
        public PE2.Model.SuppliesLog GetModel(int SuppliesLog_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SuppliesLog_sn,Supplies_sn,StockBefore,Quantity,Type,Note,User_sn,Supplies_date from SuppliesLog ");
            strSql.Append(" where SuppliesLog_sn=@SuppliesLog_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@SuppliesLog_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = SuppliesLog_sn;

            PE2.Model.SuppliesLog model = new PE2.Model.SuppliesLog();
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
        public PE2.Model.SuppliesLog DataRowToModel(DataRow row)
        {
            PE2.Model.SuppliesLog model = new PE2.Model.SuppliesLog();
            if (row != null)
            {
                if (row["SuppliesLog_sn"] != null && row["SuppliesLog_sn"].ToString() != "")
                {
                    model.SuppliesLog_sn = int.Parse(row["SuppliesLog_sn"].ToString());
                }
                if (row["Supplies_sn"] != null && row["Supplies_sn"].ToString() != "")
                {
                    model.Supplies_sn = int.Parse(row["Supplies_sn"].ToString());
                }
                if (row["StockBefore"] != null && row["StockBefore"].ToString() != "")
                {
                    model.StockBefore = int.Parse(row["StockBefore"].ToString());
                }
                if (row["Quantity"] != null && row["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(row["Quantity"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["User_sn"] != null && row["User_sn"].ToString() != "")
                {
                    model.User_sn = int.Parse(row["User_sn"].ToString());
                }
                if (row["Supplies_date"] != null && row["Supplies_date"].ToString() != "")
                {
                    model.Supplies_date = DateTime.Parse(row["Supplies_date"].ToString());
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
            strSql.Append("select SuppliesLog_sn,Supplies_sn,StockBefore,Quantity,Type,Note,User_sn,Supplies_date ");
            strSql.Append(" FROM SuppliesLog ");
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
            strSql.Append(" SuppliesLog_sn,Supplies_sn,StockBefore,Quantity,Type,Note,User_sn,Supplies_date ");
            strSql.Append(" FROM SuppliesLog ");
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
            strSql.Append("select count(1) FROM SuppliesLog ");
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
                strSql.Append("order by T.SuppliesLog_sn desc");
            }
            strSql.Append(")AS Row, T.*  from SuppliesLog T ");
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
            parameters[0].Value = "SuppliesLog";
            parameters[1].Value = "SuppliesLog_sn";
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

