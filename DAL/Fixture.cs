using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
	/// <summary>
	/// 数据访问类:Fixture
	/// </summary>
	public partial class Fixture
	{
		public Fixture()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Fixture_sn", "Fixture"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Fixture_sn)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Fixture");
			strSql.Append(" where Fixture_sn=@Fixture_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = Fixture_sn;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PE2.Model.Fixture model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Fixture(");
			strSql.Append("Fixture_no,Fixture_name,Fixture_usefor,Fixture_no_old,Fixture_lic_old,Fixture_sn_old,Status,Quantity,LastOut_sn,LastOut_date,Create_date,Limit_date,Note,LastIn_sn,LastIn_date,Place_sn)");
			strSql.Append(" values (");
			strSql.Append("@Fixture_no,@Fixture_name,@Fixture_usefor,@Fixture_no_old,@Fixture_lic_old,@Fixture_sn_old,@Status,@Quantity,@LastOut_sn,@LastOut_date,@Create_date,@Limit_date,@Note,@LastIn_sn,@LastIn_date,@Place_sn)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_usefor", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_no_old", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_lic_old", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_sn_old", SqlDbType.NChar,10),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@LastOut_sn", SqlDbType.Int,4),
					new SqlParameter("@LastOut_date", SqlDbType.Date,3),
					new SqlParameter("@Create_date", SqlDbType.Date,3),
					new SqlParameter("@Limit_date", SqlDbType.Date,3),
					new SqlParameter("@Note", SqlDbType.NVarChar,-1),
					new SqlParameter("@LastIn_sn", SqlDbType.Int,4),
					new SqlParameter("@LastIn_date", SqlDbType.Date,3),
					new SqlParameter("@Place_sn", SqlDbType.Int,4)};
			parameters[0].Value = model.Fixture_no;

			parameters[1].Value = model.Fixture_name;
			parameters[2].Value = model.Fixture_usefor;
			parameters[3].Value = model.Fixture_no_old;
			parameters[4].Value = model.Fixture_lic_old;
			parameters[5].Value = model.Fixture_sn_old;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.Quantity;
			parameters[8].Value = model.LastOut_sn;
			parameters[9].Value = model.LastOut_date;
			parameters[10].Value = model.Create_date;
			parameters[11].Value = model.Limit_date;
			parameters[12].Value = model.Note;
			parameters[13].Value = model.LastIn_sn;
			parameters[14].Value = model.LastIn_date;
			parameters[15].Value = model.Place_sn;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(PE2.Model.Fixture model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Fixture set ");
			strSql.Append("Fixture_no=@Fixture_no,");
            strSql.Append("Fixture_name=@Fixture_name,");
			strSql.Append("Fixture_usefor=@Fixture_usefor,");
			strSql.Append("Fixture_no_old=@Fixture_no_old,");
			strSql.Append("Fixture_lic_old=@Fixture_lic_old,");
			strSql.Append("Fixture_sn_old=@Fixture_sn_old,");
			strSql.Append("Status=@Status,");
			strSql.Append("Quantity=@Quantity,");
			strSql.Append("LastOut_sn=@LastOut_sn,");
			strSql.Append("LastOut_date=@LastOut_date,");
			strSql.Append("Create_date=@Create_date,");
			strSql.Append("Limit_date=@Limit_date,");
			strSql.Append("Note=@Note,");
			strSql.Append("LastIn_sn=@LastIn_sn,");
			strSql.Append("LastIn_date=@LastIn_date,");
			strSql.Append("Place_sn=@Place_sn");
			strSql.Append(" where Fixture_sn=@Fixture_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_usefor", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_no_old", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_lic_old", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixture_sn_old", SqlDbType.NChar,10),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@LastOut_sn", SqlDbType.Int,4),
					new SqlParameter("@LastOut_date", SqlDbType.Date,3),
					new SqlParameter("@Create_date", SqlDbType.Date,3),
					new SqlParameter("@Limit_date", SqlDbType.Date,3),
					new SqlParameter("@Note", SqlDbType.NVarChar,-1),
					new SqlParameter("@LastIn_sn", SqlDbType.Int,4),
					new SqlParameter("@LastIn_date", SqlDbType.Date,3),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4)};
			parameters[0].Value = model.Fixture_no;

			parameters[1].Value = model.Fixture_name;
			parameters[2].Value = model.Fixture_usefor;
			parameters[3].Value = model.Fixture_no_old;
			parameters[4].Value = model.Fixture_lic_old;
			parameters[5].Value = model.Fixture_sn_old;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.Quantity;
			parameters[8].Value = model.LastOut_sn;
			parameters[9].Value = model.LastOut_date;
			parameters[10].Value = model.Create_date;
			parameters[11].Value = model.Limit_date;
			parameters[12].Value = model.Note;
			parameters[13].Value = model.LastIn_sn;
			parameters[14].Value = model.LastIn_date;
			parameters[15].Value = model.Place_sn;
			parameters[16].Value = model.Fixture_sn;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Fixture_sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Fixture ");
			strSql.Append(" where Fixture_sn=@Fixture_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = Fixture_sn;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Fixture_snlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Fixture ");
			strSql.Append(" where Fixture_sn in ("+Fixture_snlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public PE2.Model.Fixture GetModel(int Fixture_sn)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 * from v_FixtureAll ");
			strSql.Append(" where Fixture_sn=@Fixture_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = Fixture_sn;

			PE2.Model.Fixture model=new PE2.Model.Fixture();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public PE2.Model.Fixture DataRowToModel(DataRow row)
		{
			PE2.Model.Fixture model=new PE2.Model.Fixture();
			if (row != null)
			{
				if(row["Fixture_sn"]!=null && row["Fixture_sn"].ToString()!="")
				{
					model.Fixture_sn=int.Parse(row["Fixture_sn"].ToString());
				}
				if(row["Fixture_no"]!=null)
				{
					model.Fixture_no=row["Fixture_no"].ToString();
				}
				if(row["Fixture_name"]!=null)
				{
					model.Fixture_name=row["Fixture_name"].ToString();
				}
				if(row["Fixture_usefor"]!=null)
				{
					model.Fixture_usefor=row["Fixture_usefor"].ToString();
				}
				if(row["Fixture_no_old"]!=null)
				{
					model.Fixture_no_old=row["Fixture_no_old"].ToString();
				}
				if(row["Fixture_lic_old"]!=null)
				{
					model.Fixture_lic_old=row["Fixture_lic_old"].ToString();
				}
				if(row["Fixture_sn_old"]!=null)
				{
					model.Fixture_sn_old=row["Fixture_sn_old"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Quantity"]!=null && row["Quantity"].ToString()!="")
				{
					model.Quantity=int.Parse(row["Quantity"].ToString());
				}
				if(row["LastOut_sn"]!=null && row["LastOut_sn"].ToString()!="")
				{
					model.LastOut_sn=int.Parse(row["LastOut_sn"].ToString());
				}
				if(row["LastOut_date"]!=null && row["LastOut_date"].ToString()!="")
				{
					model.LastOut_date=DateTime.Parse(row["LastOut_date"].ToString());
				}
				if(row["Create_date"]!=null && row["Create_date"].ToString()!="")
				{
					model.Create_date=DateTime.Parse(row["Create_date"].ToString());
				}
				if(row["Limit_date"]!=null && row["Limit_date"].ToString()!="")
				{
					model.Limit_date=DateTime.Parse(row["Limit_date"].ToString());
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["LastIn_sn"]!=null && row["LastIn_sn"].ToString()!="")
				{
					model.LastIn_sn=int.Parse(row["LastIn_sn"].ToString());
				}
				if(row["LastIn_date"]!=null && row["LastIn_date"].ToString()!="")
				{
					model.LastIn_date=DateTime.Parse(row["LastIn_date"].ToString());
				}
				if(row["Place_sn"]!=null && row["Place_sn"].ToString()!="")
				{
					model.Place_sn=int.Parse(row["Place_sn"].ToString());
				}
                if (row["Place_name"] != null)
                {
                    model.Place_name = row["Place_name"].ToString();
                }
                
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Fixture_sn,Fixture_name,Fixture_usefor,Fixture_no_old,Fixture_lic_old,Fixture_sn_old,Status,Quantity,LastOut_sn,LastOut_date,Create_date,Limit_date,Note,LastIn_sn,LastIn_date,Place_sn ");
			strSql.Append(" FROM Fixture ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Fixture_sn,Fixture_no,Fixture_name,Fixture_usefor,Fixture_no_old,Fixture_lic_old,Fixture_sn_old,Status,Quantity,LastOut_sn,LastOut_date,Create_date,Limit_date,Note,LastIn_sn,LastIn_date,Place_sn ");
			strSql.Append(" FROM Fixture ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Fixture ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Fixture_sn desc");
			}
			strSql.Append(")AS Row, T.*  from Fixture T ");
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
			parameters[0].Value = "Fixture";
			parameters[1].Value = "Fixture_sn";
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

