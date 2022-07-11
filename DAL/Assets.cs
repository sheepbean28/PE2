using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:Assets
    /// </summary>
    public partial class Assets
    {
        public Assets()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Assets_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Assets");
            strSql.Append(" where Assets_sn=@Assets_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Assets_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.Assets model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Assets(");
            strSql.Append("Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus)");
            strSql.Append(" values (");
            strSql.Append("@Assts_no,@Assts_id,@Assts_name,@Assts_eq_id,@Assts_eq_name,@Assts_Quantity,@Assts_Customer,@Place_sn,@Place_Assets_sn,@Place_Assets_Detail_sn,@LastUser_sn,@LastChange_date,@Note,@SysNote,@Assts_Station,@Assts_Station_num,@Assts_Sttatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.Int,4),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4)};
            parameters[0].Value = model.Assts_no;
            parameters[1].Value = model.Assts_id;
            parameters[2].Value = model.Assts_name;
            parameters[3].Value = model.Assts_eq_id;
            parameters[4].Value = model.Assts_eq_name;
            parameters[5].Value = model.Assts_Quantity;
            parameters[6].Value = model.Assts_Customer;
            parameters[7].Value = model.Place_sn;
            parameters[8].Value = model.Place_Assets_sn;
            parameters[9].Value = model.Place_Assets_Detail_sn;
            parameters[10].Value = model.LastUser_sn;
            parameters[11].Value = model.LastChange_date;
            parameters[12].Value = model.Note;
            parameters[13].Value = model.SysNote;
            parameters[14].Value = model.Assts_Station;
            parameters[15].Value = model.Assts_Station_num;
            parameters[16].Value = model.Assts_Sttatus;

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
        public bool Update(PE2.Model.Assets model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Assets set ");
            strSql.Append("Assts_no=@Assts_no,");
            strSql.Append("Assts_id=@Assts_id,");
            strSql.Append("Assts_name=@Assts_name,");
            strSql.Append("Assts_eq_id=@Assts_eq_id,");
            strSql.Append("Assts_eq_name=@Assts_eq_name,");
            strSql.Append("Assts_Quantity=@Assts_Quantity,");
            strSql.Append("Assts_Customer=@Assts_Customer,");
            strSql.Append("Place_sn=@Place_sn,");
            strSql.Append("Place_Assets_sn=@Place_Assets_sn,");
            strSql.Append("Place_Assets_Detail_sn=@Place_Assets_Detail_sn,");
            strSql.Append("LastUser_sn=@LastUser_sn,");
            strSql.Append("LastChange_date=@LastChange_date,");
            strSql.Append("Note=@Note,");
            strSql.Append("SysNote=@SysNote,");
            strSql.Append("Assts_Station=@Assts_Station,");
            strSql.Append("Assts_Station_num=@Assts_Station_num,");
            strSql.Append("Assts_Sttatus=@Assts_Sttatus");
            strSql.Append(" where Assets_sn=@Assets_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.Int,4),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4),
					new SqlParameter("@Assets_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Assts_no;
            parameters[1].Value = model.Assts_id;
            parameters[2].Value = model.Assts_name;
            parameters[3].Value = model.Assts_eq_id;
            parameters[4].Value = model.Assts_eq_name;
            parameters[5].Value = model.Assts_Quantity;
            parameters[6].Value = model.Assts_Customer;
            parameters[7].Value = model.Place_sn;
            parameters[8].Value = model.Place_Assets_sn;
            parameters[9].Value = model.Place_Assets_Detail_sn;
            parameters[10].Value = model.LastUser_sn;
            parameters[11].Value = model.LastChange_date;
            parameters[12].Value = model.Note;
            parameters[13].Value = model.SysNote;
            parameters[14].Value = model.Assts_Station;
            parameters[15].Value = model.Assts_Station_num;
            parameters[16].Value = model.Assts_Sttatus;
            parameters[17].Value = model.Assets_sn;

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
        public bool Delete(int Assets_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Assets ");
            strSql.Append(" where Assets_sn=@Assets_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Assets_sn;

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
        public bool DeleteList(string Assets_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Assets ");
            strSql.Append(" where Assets_sn in (" + Assets_snlist + ")  ");
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
        public PE2.Model.Assets GetModel(int Assets_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus from Assets ");
            strSql.Append(" where Assets_sn=@Assets_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Assets_sn;

            PE2.Model.Assets model = new PE2.Model.Assets();
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
        public PE2.Model.Assets DataRowToModel(DataRow row)
        {
            PE2.Model.Assets model = new PE2.Model.Assets();
            if (row != null)
            {
                if (row["Assets_sn"] != null && row["Assets_sn"].ToString() != "")
                {
                    model.Assets_sn = int.Parse(row["Assets_sn"].ToString());
                }
                if (row["Assts_no"] != null)
                {
                    model.Assts_no = row["Assts_no"].ToString();
                }
                if (row["Assts_id"] != null)
                {
                    model.Assts_id = row["Assts_id"].ToString();
                }
                if (row["Assts_name"] != null)
                {
                    model.Assts_name = row["Assts_name"].ToString();
                }
                if (row["Assts_eq_id"] != null)
                {
                    model.Assts_eq_id = row["Assts_eq_id"].ToString();
                }
                if (row["Assts_eq_name"] != null)
                {
                    model.Assts_eq_name = row["Assts_eq_name"].ToString();
                }
                if (row["Assts_Quantity"] != null && row["Assts_Quantity"].ToString() != "")
                {
                    model.Assts_Quantity = int.Parse(row["Assts_Quantity"].ToString());
                }
                if (row["Assts_Customer"] != null)
                {
                    model.Assts_Customer = row["Assts_Customer"].ToString();
                }
                if (row["Place_sn"] != null && row["Place_sn"].ToString() != "")
                {
                    model.Place_sn = int.Parse(row["Place_sn"].ToString());
                }
                if (row["Place_Assets_sn"] != null && row["Place_Assets_sn"].ToString() != "")
                {
                    model.Place_Assets_sn = row["Place_Assets_sn"].ToString();
                }
                if (row["Place_Assets_Detail_sn"] != null && row["Place_Assets_Detail_sn"].ToString() != "")
                {
                    model.Place_Assets_Detail_sn = row["Place_Assets_Detail_sn"].ToString();
                }
                if (row["LastUser_sn"] != null && row["LastUser_sn"].ToString() != "")
                {
                    model.LastUser_sn = int.Parse(row["LastUser_sn"].ToString());
                }
                if (row["LastChange_date"] != null && row["LastChange_date"].ToString() != "")
                {
                    model.LastChange_date = DateTime.Parse(row["LastChange_date"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["SysNote"] != null)
                {
                    model.SysNote = row["SysNote"].ToString();
                }
                if (row["Assts_Station"] != null)
                {
                    model.Assts_Station = row["Assts_Station"].ToString();
                }
                if (row["Assts_Station_num"] != null && row["Assts_Station_num"].ToString() != "")
                {
                    model.Assts_Station_num = int.Parse(row["Assts_Station_num"].ToString());
                }
                if (row["Assts_Sttatus"] != null && row["Assts_Sttatus"].ToString() != "")
                {
                    model.Assts_Sttatus = int.Parse(row["Assts_Sttatus"].ToString());
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
            strSql.Append("select Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus ");
            strSql.Append(" FROM Assets ");
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
            strSql.Append(" Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus ");
            strSql.Append(" FROM Assets ");
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
            strSql.Append("select count(1) FROM Assets ");
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
                strSql.Append("order by T.Assets_sn desc");
            }
            strSql.Append(")AS Row, T.*  from Assets T ");
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
            parameters[0].Value = "Assets";
            parameters[1].Value = "Assets_sn";
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

