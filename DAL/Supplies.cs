using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:Supplies
    /// </summary>
    public partial class Supplies
    {
        public Supplies()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Supplies_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Supplies");
            strSql.Append(" where Supplies_sn=@Supplies_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Supplies_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PE2.Model.Supplies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Supplies(");
            strSql.Append("Supplies_no,Supplies_Class,Supplies_C_No,Supplies_Name,Supplies_Price,Supplies_Add,Supplies_In,Supplies_Out,Supplies_R_IN,Supplies_R_OUT,Supplies_Limit,Supplies_Warm,Supplies_Stock,Supplies_File,Note,User_sn,Input_date,Valid,Place_code_sn)");
            strSql.Append(" values (");
            strSql.Append("@Supplies_no,@Supplies_Class,@Supplies_C_No,@Supplies_Name,@Supplies_Price,@Supplies_Add,@Supplies_In,@Supplies_Out,@Supplies_R_IN,@Supplies_R_OUT,@Supplies_Limit,@Supplies_Warm,@Supplies_Stock,@Supplies_File,@Note,@User_sn,@Input_date,@Valid,@Place_code_sn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_no", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_Class", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_C_No", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_Name", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_Price", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Add", SqlDbType.Int,4),
					new SqlParameter("@Supplies_In", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Out", SqlDbType.Int,4),
					new SqlParameter("@Supplies_R_IN", SqlDbType.Int,4),
					new SqlParameter("@Supplies_R_OUT", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Limit", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Warm", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Stock", SqlDbType.Int,4),
					new SqlParameter("@Supplies_File", SqlDbType.NVarChar,-1),
					new SqlParameter("@Note", SqlDbType.NVarChar,-1),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Input_date", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@Place_code_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Supplies_no;
            parameters[1].Value = model.Supplies_Class;
            parameters[2].Value = model.Supplies_C_No;
            parameters[3].Value = model.Supplies_Name;
            parameters[4].Value = model.Supplies_Price;
            parameters[5].Value = model.Supplies_Add;
            parameters[6].Value = model.Supplies_In;
            parameters[7].Value = model.Supplies_Out;
            parameters[8].Value = model.Supplies_R_IN;
            parameters[9].Value = model.Supplies_R_OUT;
            parameters[10].Value = model.Supplies_Limit;
            parameters[11].Value = model.Supplies_Warm;
            parameters[12].Value = model.Supplies_Stock;
            parameters[13].Value = model.Supplies_File;
            parameters[14].Value = model.Note;
            parameters[15].Value = model.User_sn;
            parameters[16].Value = model.Input_date;
            parameters[17].Value = model.Valid;
            parameters[18].Value = model.Place_code_sn;

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
        public bool Update(PE2.Model.Supplies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Supplies set ");
            strSql.Append("Supplies_no=@Supplies_no,");
            strSql.Append("Supplies_Class=@Supplies_Class,");
            strSql.Append("Supplies_C_No=@Supplies_C_No,");
            strSql.Append("Supplies_Name=@Supplies_Name,");
            strSql.Append("Supplies_Price=@Supplies_Price,");
            strSql.Append("Supplies_Add=@Supplies_Add,");
            strSql.Append("Supplies_In=@Supplies_In,");
            strSql.Append("Supplies_Out=@Supplies_Out,");
            strSql.Append("Supplies_R_IN=@Supplies_R_IN,");
            strSql.Append("Supplies_R_OUT=@Supplies_R_OUT,");
            strSql.Append("Supplies_Limit=@Supplies_Limit,");
            strSql.Append("Supplies_Warm=@Supplies_Warm,");
            strSql.Append("Supplies_Stock=@Supplies_Stock,");
            strSql.Append("Supplies_File=@Supplies_File,");
            strSql.Append("Note=@Note,");
            strSql.Append("User_sn=@User_sn,");
            strSql.Append("Input_date=@Input_date,");
            strSql.Append("Valid=@Valid,");
            strSql.Append("Place_code_sn=@Place_code_sn");
            strSql.Append(" where Supplies_sn=@Supplies_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_no", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_Class", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_C_No", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_Name", SqlDbType.NVarChar,-1),
					new SqlParameter("@Supplies_Price", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Add", SqlDbType.Int,4),
					new SqlParameter("@Supplies_In", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Out", SqlDbType.Int,4),
					new SqlParameter("@Supplies_R_IN", SqlDbType.Int,4),
					new SqlParameter("@Supplies_R_OUT", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Limit", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Warm", SqlDbType.Int,4),
					new SqlParameter("@Supplies_Stock", SqlDbType.Int,4),
					new SqlParameter("@Supplies_File", SqlDbType.NVarChar,-1),
					new SqlParameter("@Note", SqlDbType.NVarChar,-1),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Input_date", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@Place_code_sn", SqlDbType.Int,4),
					new SqlParameter("@Supplies_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Supplies_no;
            parameters[1].Value = model.Supplies_Class;
            parameters[2].Value = model.Supplies_C_No;
            parameters[3].Value = model.Supplies_Name;
            parameters[4].Value = model.Supplies_Price;
            parameters[5].Value = model.Supplies_Add;
            parameters[6].Value = model.Supplies_In;
            parameters[7].Value = model.Supplies_Out;
            parameters[8].Value = model.Supplies_R_IN;
            parameters[9].Value = model.Supplies_R_OUT;
            parameters[10].Value = model.Supplies_Limit;
            parameters[11].Value = model.Supplies_Warm;
            parameters[12].Value = model.Supplies_Stock;
            parameters[13].Value = model.Supplies_File;
            parameters[14].Value = model.Note;
            parameters[15].Value = model.User_sn;
            parameters[16].Value = model.Input_date;
            parameters[17].Value = model.Valid;
            parameters[18].Value = model.Place_code_sn;
            parameters[19].Value = model.Supplies_sn;

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
        public bool Delete(int Supplies_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Supplies ");
            strSql.Append(" where Supplies_sn=@Supplies_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Supplies_sn;

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
        public bool DeleteList(string Supplies_snlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Supplies ");
            strSql.Append(" where Supplies_sn in (" + Supplies_snlist + ")  ");
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
        public PE2.Model.Supplies GetModel(int Supplies_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Supplies_sn,Supplies_no,Supplies_Class,Supplies_C_No,Supplies_Name,Supplies_Price,Supplies_Add,Supplies_In,Supplies_Out,Supplies_R_IN,Supplies_R_OUT,Supplies_Limit,Supplies_Warm,Supplies_Stock,Supplies_File,Note,User_sn,Input_date,Valid,Place_code_sn from Supplies ");
            strSql.Append(" where Supplies_sn=@Supplies_sn");
            SqlParameter[] parameters = {
					new SqlParameter("@Supplies_sn", SqlDbType.Int,4)
			};
            parameters[0].Value = Supplies_sn;

            PE2.Model.Supplies model = new PE2.Model.Supplies();
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
        public PE2.Model.Supplies DataRowToModel(DataRow row)
        {
            PE2.Model.Supplies model = new PE2.Model.Supplies();
            if (row != null)
            {
                if (row["Supplies_sn"] != null && row["Supplies_sn"].ToString() != "")
                {
                    model.Supplies_sn = int.Parse(row["Supplies_sn"].ToString());
                }
                if (row["Supplies_no"] != null)
                {
                    model.Supplies_no = row["Supplies_no"].ToString();
                }
                if (row["Supplies_Class"] != null)
                {
                    model.Supplies_Class = row["Supplies_Class"].ToString();
                }
                if (row["Supplies_C_No"] != null)
                {
                    model.Supplies_C_No = row["Supplies_C_No"].ToString();
                }
                if (row["Supplies_Name"] != null)
                {
                    model.Supplies_Name = row["Supplies_Name"].ToString();
                }
                if (row["Supplies_Price"] != null && row["Supplies_Price"].ToString() != "")
                {
                    model.Supplies_Price = int.Parse(row["Supplies_Price"].ToString());
                }
                if (row["Supplies_Add"] != null && row["Supplies_Add"].ToString() != "")
                {
                    model.Supplies_Add = int.Parse(row["Supplies_Add"].ToString());
                }
                if (row["Supplies_In"] != null && row["Supplies_In"].ToString() != "")
                {
                    model.Supplies_In = int.Parse(row["Supplies_In"].ToString());
                }
                if (row["Supplies_Out"] != null && row["Supplies_Out"].ToString() != "")
                {
                    model.Supplies_Out = int.Parse(row["Supplies_Out"].ToString());
                }
                if (row["Supplies_R_IN"] != null && row["Supplies_R_IN"].ToString() != "")
                {
                    model.Supplies_R_IN = int.Parse(row["Supplies_R_IN"].ToString());
                }
                if (row["Supplies_R_OUT"] != null && row["Supplies_R_OUT"].ToString() != "")
                {
                    model.Supplies_R_OUT = int.Parse(row["Supplies_R_OUT"].ToString());
                }
                if (row["Supplies_Limit"] != null && row["Supplies_Limit"].ToString() != "")
                {
                    model.Supplies_Limit = int.Parse(row["Supplies_Limit"].ToString());
                }
                if (row["Supplies_Warm"] != null && row["Supplies_Warm"].ToString() != "")
                {
                    model.Supplies_Warm = int.Parse(row["Supplies_Warm"].ToString());
                }
                if (row["Supplies_Stock"] != null && row["Supplies_Stock"].ToString() != "")
                {
                    model.Supplies_Stock = int.Parse(row["Supplies_Stock"].ToString());
                }
                if (row["Supplies_File"] != null)
                {
                    model.Supplies_File = row["Supplies_File"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["User_sn"] != null && row["User_sn"].ToString() != "")
                {
                    model.User_sn = int.Parse(row["User_sn"].ToString());
                }
                if (row["Input_date"] != null && row["Input_date"].ToString() != "")
                {
                    model.Input_date = DateTime.Parse(row["Input_date"].ToString());
                }
                if (row["Valid"] != null && row["Valid"].ToString() != "")
                {
                    model.Valid = int.Parse(row["Valid"].ToString());
                }
                if (row["Place_code_sn"] != null && row["Place_code_sn"].ToString() != "")
                {
                    model.Place_code_sn = int.Parse(row["Place_code_sn"].ToString());
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
            strSql.Append("select Supplies_sn,Supplies_no,Supplies_Class,Supplies_C_No,Supplies_Name,Supplies_Price,Supplies_Add,Supplies_In,Supplies_Out,Supplies_R_IN,Supplies_R_OUT,Supplies_Limit,Supplies_Warm,Supplies_Stock,Supplies_File,Note,User_sn,Input_date,Valid,Place_code_sn ");
            strSql.Append(" FROM Supplies ");
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
            strSql.Append(" Supplies_sn,Supplies_no,Supplies_Class,Supplies_C_No,Supplies_Name,Supplies_Price,Supplies_Add,Supplies_In,Supplies_Out,Supplies_R_IN,Supplies_R_OUT,Supplies_Limit,Supplies_Warm,Supplies_Stock,Supplies_File,Note,User_sn,Input_date,Valid,Place_code_sn ");
            strSql.Append(" FROM Supplies ");
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
            strSql.Append("select count(1) FROM Supplies ");
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
                strSql.Append("order by T.Supplies_sn desc");
            }
            strSql.Append(")AS Row, T.*  from Supplies T ");
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
            parameters[0].Value = "Supplies";
            parameters[1].Value = "Supplies_sn";
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

