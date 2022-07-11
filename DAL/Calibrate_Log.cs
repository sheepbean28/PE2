using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:Calibrate_Log
    /// </summary>
    public partial class Calibrate_Log
    {
        public Calibrate_Log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Calibrate_Log_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Calibrate_Log");
            strSql.Append(" where Calibrate_Log_sn=@Calibrate_Log_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_Log_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Calibrate_Log_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.Calibrate_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Calibrate_Log(");
            strSql.Append("Calibrate_sn,Start_Date,End_Date,Note,ReturnNote)");
            strSql.Append(" values (");
            strSql.Append("@Calibrate_sn,@Start_Date,@End_Date,@Note,@ReturnNote)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Start_Date", SqlDbType.DateTime),
					new SqlParameter("@End_Date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@ReturnNote", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Calibrate_sn;
            parameters[1].Value = model.Start_Date;
            parameters[2].Value = model.End_Date;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.ReturnNote;

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
        public bool Update(PE2.Model.Calibrate_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Calibrate_Log set ");
            strSql.Append("Calibrate_sn=@Calibrate_sn,");
            strSql.Append("Start_Date=@Start_Date,");
            strSql.Append("End_Date=@End_Date,");
            strSql.Append("Note=@Note,");
            strSql.Append("ReturnNote=@ReturnNote");
            strSql.Append(" where Calibrate_Log_sn=@Calibrate_Log_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Start_Date", SqlDbType.DateTime),
					new SqlParameter("@End_Date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@ReturnNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Calibrate_Log_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Calibrate_sn;
            parameters[1].Value = model.Start_Date;
            parameters[2].Value = model.End_Date;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.ReturnNote;
            parameters[5].Value = model.Calibrate_Log_sn;

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
        public bool Delete(int Calibrate_Log_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Calibrate_Log ");
            strSql.Append(" where Calibrate_Log_sn=@Calibrate_Log_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_Log_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Calibrate_Log_sn;

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
        public bool DeleteList(string Calibrate_Log_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Calibrate_Log ");
            strSql.Append(" where Calibrate_Log_sn in (" + Calibrate_Log_snlist + ")  ");
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
        public PE2.Model.Calibrate_Log GetModel(int Calibrate_Log_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Calibrate_Log_sn,Calibrate_sn,Start_Date,End_Date,Note,ReturnNote from Calibrate_Log ");
            strSql.Append(" where Calibrate_Log_sn=@Calibrate_Log_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_Log_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Calibrate_Log_sn;

            PE2.Model.Calibrate_Log model = new PE2.Model.Calibrate_Log();
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
        public PE2.Model.Calibrate_Log DataRowToModel(DataRow row)
        {
            PE2.Model.Calibrate_Log model = new PE2.Model.Calibrate_Log();
            if (row != null)
            {
                if (row["Calibrate_Log_sn"] != null && row["Calibrate_Log_sn"].ToString() != "")
                {
                    model.Calibrate_Log_sn = int.Parse(row["Calibrate_Log_sn"].ToString());
                }
                if (row["Calibrate_sn"] != null && row["Calibrate_sn"].ToString() != "")
                {
                    model.Calibrate_sn = int.Parse(row["Calibrate_sn"].ToString());
                }
                if (row["Start_Date"] != null && row["Start_Date"].ToString() != "")
                {
                    model.Start_Date = DateTime.Parse(row["Start_Date"].ToString());
                }
                if (row["End_Date"] != null && row["End_Date"].ToString() != "")
                {
                    model.End_Date = DateTime.Parse(row["End_Date"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["ReturnNote"] != null)
                {
                    model.ReturnNote = row["ReturnNote"].ToString();
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
            strSql.Append("select Calibrate_Log_sn,Calibrate_sn,Start_Date,End_Date,Note,ReturnNote ");
            strSql.Append(" FROM Calibrate_Log ");
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
            strSql.Append(" Calibrate_Log_sn,Calibrate_sn,Start_Date,End_Date,Note,ReturnNote ");
            strSql.Append(" FROM Calibrate_Log ");
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
            strSql.Append("select count(1) FROM Calibrate_Log ");
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
                strSql.Append("order by T.Calibrate_Log_sn desc");
            }
            strSql.Append(")AS Row, T.*  from Calibrate_Log T ");
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
            parameters[0].Value = "Calibrate_Log";
            parameters[1].Value = "Calibrate_Log_sn";
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

