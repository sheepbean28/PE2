using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:Code
    /// </summary>
    public partial class Code
    {
        public Code()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Code_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Code");
            strSql.Append(" where Code_sn=@Code_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Code_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Code_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.Code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Code(");
            strSql.Append("Class_sn,Code_name,Code_value,Code_note)");
            strSql.Append(" values (");
            strSql.Append("@Class_sn,@Code_name,@Code_value,@Code_note)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Class_sn", SqlDbType.Int,4),
					new SqlParameter("@Code_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Code_value", SqlDbType.NVarChar,50),
					new SqlParameter("@Code_note", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Class_sn;
            parameters[1].Value = model.Code_name;
            parameters[2].Value = model.Code_value;
            parameters[3].Value = model.Code_note;

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
        public bool Update(PE2.Model.Code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Code set ");
            strSql.Append("Class_sn=@Class_sn,");
            strSql.Append("Code_name=@Code_name,");
            strSql.Append("Code_value=@Code_value,");
            strSql.Append("Code_note=@Code_note");
            strSql.Append(" where Code_sn=@Code_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Class_sn", SqlDbType.Int,4),
					new SqlParameter("@Code_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Code_value", SqlDbType.NVarChar,50),
					new SqlParameter("@Code_note", SqlDbType.NVarChar,50),
					new SqlParameter("@Code_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Class_sn;
            parameters[1].Value = model.Code_name;
            parameters[2].Value = model.Code_value;
            parameters[3].Value = model.Code_note;
            parameters[4].Value = model.Code_sn;

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
        public bool Delete(int Code_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Code ");
            strSql.Append(" where Code_sn=@Code_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Code_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Code_sn;

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
        public bool DeleteList(string Code_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Code ");
            strSql.Append(" where Code_sn in (" + Code_snlist + ")  ");
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
        public PE2.Model.Code GetModel(int Code_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Code_sn,Class_sn,Code_name,Code_value,Code_note from Code ");
            strSql.Append(" where Code_sn=@Code_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Code_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Code_sn;

            PE2.Model.Code model = new PE2.Model.Code();
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
        public PE2.Model.Code DataRowToModel(DataRow row)
        {
            PE2.Model.Code model = new PE2.Model.Code();
            if (row != null)
            {
                if (row["Code_sn"] != null && row["Code_sn"].ToString() != "")
                {
                    model.Code_sn = int.Parse(row["Code_sn"].ToString());
                }
                if (row["Class_sn"] != null && row["Class_sn"].ToString() != "")
                {
                    model.Class_sn = int.Parse(row["Class_sn"].ToString());
                }
                if (row["Code_name"] != null)
                {
                    model.Code_name = row["Code_name"].ToString();
                }
                if (row["Code_value"] != null)
                {
                    model.Code_value = row["Code_value"].ToString();
                }
                if (row["Code_note"] != null)
                {
                    model.Code_note = row["Code_note"].ToString();
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
            strSql.Append("select Code_sn,Class_sn,Code_name,Code_value,Code_note ");
            strSql.Append(" FROM Code ");
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
            strSql.Append(" Code_sn,Class_sn,Code_name,Code_value,Code_note ");
            strSql.Append(" FROM Code ");
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
            strSql.Append("select count(1) FROM Code ");
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
                strSql.Append("order by T.Code_sn desc");
            }
            strSql.Append(")AS Row, T.*  from Code T ");
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
            parameters[0].Value = "Code";
            parameters[1].Value = "Code_sn";
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

