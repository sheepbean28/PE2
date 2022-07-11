using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:Calibrate
    /// </summary>
    public partial class Calibrate
    {
        public Calibrate()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Calibrate_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Calibrate");
            strSql.Append(" where Calibrate_sn=@Calibrate_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Calibrate_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.Calibrate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Calibrate(");
            strSql.Append("Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn,Assets_sn)");
            strSql.Append(" values (");
            strSql.Append("@Eq_id,@Eq_no,@Eq_name,@Eq_factory,@Eq_factory_no,@Eq_Assets_no,@Cp_Date_Range,@Last_Cp_Date,@Next_Cp_Date,@Cp_Place,@Cp_Type,@Cp_Note,@Cp_Note1,@Cp_Status,@Last_Cp_Log_sn,@Assets_sn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4),
					new SqlParameter("@Assets_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Eq_id;
            parameters[1].Value = model.Eq_no;
            parameters[2].Value = model.Eq_name;
            parameters[3].Value = model.Eq_factory;
            parameters[4].Value = model.Eq_factory_no;
            parameters[5].Value = model.Eq_Assets_no;
            parameters[6].Value = model.Cp_Date_Range;
            parameters[7].Value = model.Last_Cp_Date;
            parameters[8].Value = model.Next_Cp_Date;
            parameters[9].Value = model.Cp_Place;
            parameters[10].Value = model.Cp_Type;
            parameters[11].Value = model.Cp_Note;
            parameters[12].Value = model.Cp_Note1;
            parameters[13].Value = model.Cp_Status;
            parameters[14].Value = model.Last_Cp_Log_sn;
            parameters[15].Value = model.Assets_sn;

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
        public bool Update(PE2.Model.Calibrate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Calibrate set ");
            strSql.Append("Eq_id=@Eq_id,");
            strSql.Append("Eq_no=@Eq_no,");
            strSql.Append("Eq_name=@Eq_name,");
            strSql.Append("Eq_factory=@Eq_factory,");
            strSql.Append("Eq_factory_no=@Eq_factory_no,");
            strSql.Append("Eq_Assets_no=@Eq_Assets_no,");
            strSql.Append("Cp_Date_Range=@Cp_Date_Range,");
            strSql.Append("Last_Cp_Date=@Last_Cp_Date,");
            strSql.Append("Next_Cp_Date=@Next_Cp_Date,");
            strSql.Append("Cp_Place=@Cp_Place,");
            strSql.Append("Cp_Type=@Cp_Type,");
            strSql.Append("Cp_Note=@Cp_Note,");
            strSql.Append("Cp_Note1=@Cp_Note1,");
            strSql.Append("Cp_Status=@Cp_Status,");
            strSql.Append("Last_Cp_Log_sn=@Last_Cp_Log_sn");
            //strSql.Append("Assets_sn=@Assets_sn");
            strSql.Append(" where Calibrate_sn=@Calibrate_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4),
					//new SqlParameter("@Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Eq_id;
            parameters[1].Value = model.Eq_no;
            parameters[2].Value = model.Eq_name;
            parameters[3].Value = model.Eq_factory;
            parameters[4].Value = model.Eq_factory_no;
            parameters[5].Value = model.Eq_Assets_no;
            parameters[6].Value = model.Cp_Date_Range;
            parameters[7].Value = model.Last_Cp_Date;
            parameters[8].Value = model.Next_Cp_Date;
            parameters[9].Value = model.Cp_Place;
            parameters[10].Value = model.Cp_Type;
            parameters[11].Value = model.Cp_Note;
            parameters[12].Value = model.Cp_Note1;
            parameters[13].Value = model.Cp_Status;
            parameters[14].Value = model.Last_Cp_Log_sn;
           // parameters[15].Value = model.Assets_sn;
            parameters[15].Value = model.Calibrate_sn;

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
        public bool Delete(int Calibrate_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Calibrate ");
            strSql.Append(" where Calibrate_sn=@Calibrate_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Calibrate_sn;

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
        public bool DeleteList(string Calibrate_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Calibrate ");
            strSql.Append(" where Calibrate_sn in (" + Calibrate_snlist + ")  ");
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
        public PE2.Model.Calibrate GetModel(int Calibrate_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from v_Calibrate ");
            strSql.Append(" where Calibrate_sn=@Calibrate_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Calibrate_sn;

            PE2.Model.Calibrate model = new PE2.Model.Calibrate();
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
        public PE2.Model.Calibrate DataRowToModel(DataRow row)
        {
            PE2.Model.Calibrate model = new PE2.Model.Calibrate();
            if (row != null)
            {
                if (row["Calibrate_sn"] != null && row["Calibrate_sn"].ToString() != "")
                {
                    model.Calibrate_sn = int.Parse(row["Calibrate_sn"].ToString());
                }
                if (row["Eq_id"] != null)
                {
                    model.Eq_id = row["Eq_id"].ToString();
                }
                if (row["Eq_no"] != null)
                {
                    model.Eq_no = row["Eq_no"].ToString();
                }
                if (row["Eq_name"] != null)
                {
                    model.Eq_name = row["Eq_name"].ToString();
                }
                if (row["Eq_factory"] != null)
                {
                    model.Eq_factory = row["Eq_factory"].ToString();
                }
                if (row["Eq_factory_no"] != null)
                {
                    model.Eq_factory_no = row["Eq_factory_no"].ToString();
                }
                if (row["Eq_Assets_no"] != null)
                {
                    model.Eq_Assets_no = row["Eq_Assets_no"].ToString();
                }
                if (row["Cp_Date_Range"] != null)
                {
                    model.Cp_Date_Range = row["Cp_Date_Range"].ToString();
                }
                if (row["Last_Cp_Date"] != null && row["Last_Cp_Date"].ToString() != "")
                {
                    model.Last_Cp_Date = DateTime.Parse(row["Last_Cp_Date"].ToString());
                }
                if (row["Next_Cp_Date"] != null && row["Next_Cp_Date"].ToString() != "")
                {
                    model.Next_Cp_Date = DateTime.Parse(row["Next_Cp_Date"].ToString());
                }
                if (row["Cp_Place"] != null)
                {
                    model.Cp_Place = row["Cp_Place"].ToString();
                }
                if (row["Cp_Type"] != null)
                {
                    model.Cp_Type = row["Cp_Type"].ToString();
                }
                if (row["Cp_Note"] != null)
                {
                    model.Cp_Note = row["Cp_Note"].ToString();
                }
                if (row["Cp_Note1"] != null)
                {
                    model.Cp_Note1 = row["Cp_Note1"].ToString();
                }
                if (row["Cp_Status"] != null && row["Cp_Status"].ToString() != "")
                {
                    model.Cp_Status = int.Parse(row["Cp_Status"].ToString());
                }
                if (row["Last_Cp_Log_sn"] != null && row["Last_Cp_Log_sn"].ToString() != "")
                {
                    model.Last_Cp_Log_sn = int.Parse(row["Last_Cp_Log_sn"].ToString());
                }
                if (row["Assets_sn"] != null && row["Assets_sn"].ToString() != "")
                {
                    model.Assets_sn = int.Parse(row["Assets_sn"].ToString());
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
            strSql.Append("select Calibrate_sn,Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn,Assets_sn ");
            strSql.Append(" FROM Calibrate ");
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
            strSql.Append(" Calibrate_sn,Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn,Assets_sn ");
            strSql.Append(" FROM Calibrate ");
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
            strSql.Append("select count(1) FROM Calibrate ");
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
                strSql.Append("order by T.Calibrate_sn desc");
            }
            strSql.Append(")AS Row, T.*  from Calibrate T ");
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
            parameters[0].Value = "Calibrate";
            parameters[1].Value = "Calibrate_sn";
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

