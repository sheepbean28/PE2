using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:ShieldingBox
    /// </summary>
    public partial class ShieldingBox
    {
        public ShieldingBox()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ShieldingBox_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ShieldingBox");
            strSql.Append(" where ShieldingBox_sn=@ShieldingBox_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@ShieldingBox_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = ShieldingBox_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.ShieldingBox model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ShieldingBox(");
            strSql.Append("Assets_sn,asset_no,Cp_date,Limit_date,SieldingBox_no,ShieldingBox_Class,ShieldingBox_Type,Cp2G_Open,Cp2G_Close,Cp2G_Shileld,Cp5G_Open,Cp5G_Close,Cp5G_Shileld,Leakage,Leakage_no,Note)");
            strSql.Append(" values (");
            strSql.Append("@Assets_sn,@asset_no,@Cp_date,@Limit_date,@SieldingBox_no,@ShieldingBox_Class,@ShieldingBox_Type,@Cp2G_Open,@Cp2G_Close,@Cp2G_Shileld,@Cp5G_Open,@Cp5G_Close,@Cp5G_Shileld,@Leakage,@Leakage_no,@Note)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.NChar,10),
					new SqlParameter("@asset_no", SqlDbType.NChar,10),
					new SqlParameter("@Cp_date", SqlDbType.DateTime),
					new SqlParameter("@Limit_date", SqlDbType.DateTime),
					new SqlParameter("@SieldingBox_no", SqlDbType.NVarChar,500),
					new SqlParameter("@ShieldingBox_Class", SqlDbType.NChar,10),
					new SqlParameter("@ShieldingBox_Type", SqlDbType.NChar,10),
					new SqlParameter("@Cp2G_Open", SqlDbType.Float,8),
					new SqlParameter("@Cp2G_Close", SqlDbType.Float,8),
					new SqlParameter("@Cp2G_Shileld", SqlDbType.Float,8),
					new SqlParameter("@Cp5G_Open", SqlDbType.Float,8),
					new SqlParameter("@Cp5G_Close", SqlDbType.Float,8),
					new SqlParameter("@Cp5G_Shileld", SqlDbType.Float,8),
					new SqlParameter("@Leakage", SqlDbType.Float,8),
					new SqlParameter("@Leakage_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Note", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Assets_sn;
            parameters[1].Value = model.asset_no;
            parameters[2].Value = model.Cp_date;
            parameters[3].Value = model.Limit_date;
            parameters[4].Value = model.SieldingBox_no;
            parameters[5].Value = model.ShieldingBox_Class;
            parameters[6].Value = model.ShieldingBox_Type;
            parameters[7].Value = model.Cp2G_Open;
            parameters[8].Value = model.Cp2G_Close;
            parameters[9].Value = model.Cp2G_Shileld;
            parameters[10].Value = model.Cp5G_Open;
            parameters[11].Value = model.Cp5G_Close;
            parameters[12].Value = model.Cp5G_Shileld;
            parameters[13].Value = model.Leakage;
            parameters[14].Value = model.Leakage_no;
            parameters[15].Value = model.Note;

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
        public bool Update(PE2.Model.ShieldingBox model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShieldingBox set ");
            strSql.Append("Assets_sn=@Assets_sn,");
            strSql.Append("asset_no=@asset_no,");
            strSql.Append("Cp_date=@Cp_date,");
            strSql.Append("Limit_date=@Limit_date,");
            strSql.Append("SieldingBox_no=@SieldingBox_no,");
            strSql.Append("ShieldingBox_Class=@ShieldingBox_Class,");
            strSql.Append("ShieldingBox_Type=@ShieldingBox_Type,");
            strSql.Append("Cp2G_Open=@Cp2G_Open,");
            strSql.Append("Cp2G_Close=@Cp2G_Close,");
            strSql.Append("Cp2G_Shileld=@Cp2G_Shileld,");
            strSql.Append("Cp5G_Open=@Cp5G_Open,");
            strSql.Append("Cp5G_Close=@Cp5G_Close,");
            strSql.Append("Cp5G_Shileld=@Cp5G_Shileld,");
            strSql.Append("Leakage=@Leakage,");
            strSql.Append("Leakage_no=@Leakage_no,");
            strSql.Append("Note=@Note");
            strSql.Append(" where ShieldingBox_sn=@ShieldingBox_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.NChar,10),
					new SqlParameter("@asset_no", SqlDbType.NChar,10),
					new SqlParameter("@Cp_date", SqlDbType.DateTime),
					new SqlParameter("@Limit_date", SqlDbType.DateTime),
					new SqlParameter("@SieldingBox_no", SqlDbType.NVarChar,500),
					new SqlParameter("@ShieldingBox_Class", SqlDbType.NChar,10),
					new SqlParameter("@ShieldingBox_Type", SqlDbType.NChar,10),
					new SqlParameter("@Cp2G_Open", SqlDbType.Float,8),
					new SqlParameter("@Cp2G_Close", SqlDbType.Float,8),
					new SqlParameter("@Cp2G_Shileld", SqlDbType.Float,8),
					new SqlParameter("@Cp5G_Open", SqlDbType.Float,8),
					new SqlParameter("@Cp5G_Close", SqlDbType.Float,8),
					new SqlParameter("@Cp5G_Shileld", SqlDbType.Float,8),
					new SqlParameter("@Leakage", SqlDbType.Float,8),
					new SqlParameter("@Leakage_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@ShieldingBox_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Assets_sn;
            parameters[1].Value = model.asset_no;
            parameters[2].Value = model.Cp_date;
            parameters[3].Value = model.Limit_date;
            parameters[4].Value = model.SieldingBox_no;
            parameters[5].Value = model.ShieldingBox_Class;
            parameters[6].Value = model.ShieldingBox_Type;
            parameters[7].Value = model.Cp2G_Open;
            parameters[8].Value = model.Cp2G_Close;
            parameters[9].Value = model.Cp2G_Shileld;
            parameters[10].Value = model.Cp5G_Open;
            parameters[11].Value = model.Cp5G_Close;
            parameters[12].Value = model.Cp5G_Shileld;
            parameters[13].Value = model.Leakage;
            parameters[14].Value = model.Leakage_no;
            parameters[15].Value = model.Note;
            parameters[16].Value = model.ShieldingBox_sn;

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
        public bool Delete(int ShieldingBox_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ShieldingBox ");
            strSql.Append(" where ShieldingBox_sn=@ShieldingBox_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@ShieldingBox_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = ShieldingBox_sn;

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
        public bool DeleteList(string ShieldingBox_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ShieldingBox ");
            strSql.Append(" where ShieldingBox_sn in (" + ShieldingBox_snlist + ")  ");
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
        public PE2.Model.ShieldingBox GetModel(int ShieldingBox_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ShieldingBox_sn,Assets_sn,asset_no,Cp_date,Limit_date,SieldingBox_no,ShieldingBox_Class,ShieldingBox_Type,Cp2G_Open,Cp2G_Close,Cp2G_Shileld,Cp5G_Open,Cp5G_Close,Cp5G_Shileld,Leakage,Leakage_no,Note from ShieldingBox ");
            strSql.Append(" where ShieldingBox_sn=@ShieldingBox_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@ShieldingBox_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = ShieldingBox_sn;

            PE2.Model.ShieldingBox model = new PE2.Model.ShieldingBox();
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
        public PE2.Model.ShieldingBox DataRowToModel(DataRow row)
        {
            PE2.Model.ShieldingBox model = new PE2.Model.ShieldingBox();
            if (row != null)
            {
                if (row["ShieldingBox_sn"] != null && row["ShieldingBox_sn"].ToString() != "")
                {
                    model.ShieldingBox_sn = int.Parse(row["ShieldingBox_sn"].ToString());
                }
                if (row["Assets_sn"] != null)
                {
                    model.Assets_sn = row["Assets_sn"].ToString();
                }
                if (row["asset_no"] != null)
                {
                    model.asset_no = row["asset_no"].ToString();
                }
                if (row["Cp_date"] != null && row["Cp_date"].ToString() != "")
                {
                    model.Cp_date = DateTime.Parse(row["Cp_date"].ToString());
                }
                if (row["Limit_date"] != null && row["Limit_date"].ToString() != "")
                {
                    model.Limit_date = DateTime.Parse(row["Limit_date"].ToString());
                }
                if (row["SieldingBox_no"] != null)
                {
                    model.SieldingBox_no = row["SieldingBox_no"].ToString();
                }
                if (row["ShieldingBox_Class"] != null)
                {
                    model.ShieldingBox_Class = row["ShieldingBox_Class"].ToString();
                }
                if (row["ShieldingBox_Type"] != null)
                {
                    model.ShieldingBox_Type = row["ShieldingBox_Type"].ToString();
                }
                if (row["Cp2G_Open"] != null && row["Cp2G_Open"].ToString() != "")
                {
                    model.Cp2G_Open = decimal.Parse(row["Cp2G_Open"].ToString());
                }
                if (row["Cp2G_Close"] != null && row["Cp2G_Close"].ToString() != "")
                {
                    model.Cp2G_Close = decimal.Parse(row["Cp2G_Close"].ToString());
                }
                if (row["Cp2G_Shileld"] != null && row["Cp2G_Shileld"].ToString() != "")
                {
                    model.Cp2G_Shileld = decimal.Parse(row["Cp2G_Shileld"].ToString());
                }
                if (row["Cp5G_Open"] != null && row["Cp5G_Open"].ToString() != "")
                {
                    model.Cp5G_Open = decimal.Parse(row["Cp5G_Open"].ToString());
                }
                if (row["Cp5G_Close"] != null && row["Cp5G_Close"].ToString() != "")
                {
                    model.Cp5G_Close = decimal.Parse(row["Cp5G_Close"].ToString());
                }
                if (row["Cp5G_Shileld"] != null && row["Cp5G_Shileld"].ToString() != "")
                {
                    model.Cp5G_Shileld = decimal.Parse(row["Cp5G_Shileld"].ToString());
                }
                if (row["Leakage"] != null && row["Leakage"].ToString() != "")
                {
                    model.Leakage = decimal.Parse(row["Leakage"].ToString());
                }
                if (row["Leakage_no"] != null)
                {
                    model.Leakage_no = row["Leakage_no"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
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
            strSql.Append("select ShieldingBox_sn,Assets_sn,asset_no,Cp_date,Limit_date,SieldingBox_no,ShieldingBox_Class,ShieldingBox_Type,Cp2G_Open,Cp2G_Close,Cp2G_Shileld,Cp5G_Open,Cp5G_Close,Cp5G_Shileld,Leakage,Leakage_no,Note ");
            strSql.Append(" FROM ShieldingBox ");
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
            strSql.Append(" ShieldingBox_sn,Assets_sn,asset_no,Cp_date,Limit_date,SieldingBox_no,ShieldingBox_Class,ShieldingBox_Type,Cp2G_Open,Cp2G_Close,Cp2G_Shileld,Cp5G_Open,Cp5G_Close,Cp5G_Shileld,Leakage,Leakage_no,Note ");
            strSql.Append(" FROM ShieldingBox ");
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
            strSql.Append("select count(1) FROM ShieldingBox ");
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
                strSql.Append("order by T.ShieldingBox_sn desc");
            }
            strSql.Append(")AS Row, T.*  from ShieldingBox T ");
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
            parameters[0].Value = "ShieldingBox";
            parameters[1].Value = "ShieldingBox_sn";
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

