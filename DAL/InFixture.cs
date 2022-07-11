using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
	/// <summary>
	/// 数据访问类:InFixture
	/// </summary>
	public partial class InFixture
	{
		public InFixture()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("In_sn", "InFixture"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int In_sn)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from InFixture");
			strSql.Append(" where In_sn=@In_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@In_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = In_sn;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PE2.Model.InFixture model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InFixture(");
			strSql.Append("Fixture_sn,User_sn,Out_sn,Note,Create_date,In_date,Look,Clean,Valid,Place_sn)");
			strSql.Append(" values (");
			strSql.Append("@Fixture_sn,@User_sn,@Out_sn,@Note,@Create_date,@In_date,@Look,@Clean,@Valid,@Place_sn)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Out_sn", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Create_date", SqlDbType.DateTime),
					new SqlParameter("@In_date", SqlDbType.DateTime),
					new SqlParameter("@Look", SqlDbType.Int,4),
					new SqlParameter("@Clean", SqlDbType.Int,4),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4)};
			parameters[0].Value = model.Fixture_sn;
			parameters[1].Value = model.User_sn;
			parameters[2].Value = model.Out_sn;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.Create_date;
			parameters[5].Value = model.In_date;
			parameters[6].Value = model.Look;
			parameters[7].Value = model.Clean;
			parameters[8].Value = model.Valid;
			parameters[9].Value = model.Place_sn;

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
		public bool Update(PE2.Model.InFixture model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InFixture set ");
			strSql.Append("Fixture_sn=@Fixture_sn,");
			strSql.Append("User_sn=@User_sn,");
			strSql.Append("Out_sn=@Out_sn,");
			strSql.Append("Note=@Note,");
			strSql.Append("Create_date=@Create_date,");
			strSql.Append("In_date=@In_date,");
			strSql.Append("Look=@Look,");
			strSql.Append("Clean=@Clean,");
			strSql.Append("Valid=@Valid,");
			strSql.Append("Place_sn=@Place_sn");
			strSql.Append(" where In_sn=@In_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Fixture_sn", SqlDbType.Int,4),
					new SqlParameter("@User_sn", SqlDbType.Int,4),
					new SqlParameter("@Out_sn", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Create_date", SqlDbType.Date,3),
					new SqlParameter("@In_date", SqlDbType.NChar,10),
					new SqlParameter("@Look", SqlDbType.Int,4),
					new SqlParameter("@Clean", SqlDbType.Int,4),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@In_sn", SqlDbType.Int,4)};
			parameters[0].Value = model.Fixture_sn;
			parameters[1].Value = model.User_sn;
			parameters[2].Value = model.Out_sn;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.Create_date;
			parameters[5].Value = model.In_date;
			parameters[6].Value = model.Look;
			parameters[7].Value = model.Clean;
			parameters[8].Value = model.Valid;
			parameters[9].Value = model.Place_sn;
			parameters[10].Value = model.In_sn;

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
		public bool Delete(int In_sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InFixture ");
			strSql.Append(" where In_sn=@In_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@In_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = In_sn;

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
		public bool DeleteList(string In_snlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InFixture ");
			strSql.Append(" where In_sn in ("+In_snlist + ")  ");
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
		public PE2.Model.InFixture GetModel(int In_sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Fixture_sn,In_sn,User_sn,Out_sn,Note,Create_date,In_date,Look,Clean,Valid,Place_sn from InFixture ");
			strSql.Append(" where In_sn=@In_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@In_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = In_sn;

			PE2.Model.InFixture model=new PE2.Model.InFixture();
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
		public PE2.Model.InFixture DataRowToModel(DataRow row)
		{
			PE2.Model.InFixture model=new PE2.Model.InFixture();
			if (row != null)
			{
				if(row["Fixture_sn"]!=null && row["Fixture_sn"].ToString()!="")
				{
					model.Fixture_sn=int.Parse(row["Fixture_sn"].ToString());
				}
				if(row["In_sn"]!=null && row["In_sn"].ToString()!="")
				{
					model.In_sn=int.Parse(row["In_sn"].ToString());
				}
				if(row["User_sn"]!=null && row["User_sn"].ToString()!="")
				{
					model.User_sn=int.Parse(row["User_sn"].ToString());
				}
				if(row["Out_sn"]!=null && row["Out_sn"].ToString()!="")
				{
					model.Out_sn=int.Parse(row["Out_sn"].ToString());
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Create_date"]!=null && row["Create_date"].ToString()!="")
				{
					model.Create_date=DateTime.Parse(row["Create_date"].ToString());
				}
                if (row["In_date"] != null && row["In_date"].ToString() != "")
				{
					model.In_date=DateTime.Parse(row["In_date"].ToString());
				}
				if(row["Look"]!=null && row["Look"].ToString()!="")
				{
					model.Look=int.Parse(row["Look"].ToString());
				}
				if(row["Clean"]!=null && row["Clean"].ToString()!="")
				{
					model.Clean=int.Parse(row["Clean"].ToString());
				}
				if(row["Valid"]!=null && row["Valid"].ToString()!="")
				{
					model.Valid=int.Parse(row["Valid"].ToString());
				}
				if(row["Place_sn"]!=null && row["Place_sn"].ToString()!="")
				{
					model.Place_sn=int.Parse(row["Place_sn"].ToString());
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
			strSql.Append("select Fixture_sn,In_sn,User_sn,Out_sn,Note,Create_date,In_date,Look,Clean,Valid,Place_sn ");
			strSql.Append(" FROM InFixture ");
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
			strSql.Append(" Fixture_sn,In_sn,User_sn,Out_sn,Note,Create_date,In_date,Look,Clean,Valid,Place_sn ");
			strSql.Append(" FROM InFixture ");
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
			strSql.Append("select count(1) FROM InFixture ");
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
				strSql.Append("order by T.In_sn desc");
			}
			strSql.Append(")AS Row, T.*  from InFixture T ");
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
			parameters[0].Value = "InFixture";
			parameters[1].Value = "In_sn";
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

