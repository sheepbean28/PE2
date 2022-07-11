using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
	/// <summary>
	/// 数据访问类:Place
	/// </summary>
	public partial class Place
	{
		public Place()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Place_sn", "Place"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Place_sn)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Place");
			strSql.Append(" where Place_sn=@Place_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Place_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = Place_sn;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PE2.Model.Place model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Place(");
			strSql.Append("Place_name,Place_id,Refer_sn,Class)");
			strSql.Append(" values (");
			strSql.Append("@Place_name,@Place_id,@Refer_sn,@Class)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Place_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Refer_sn", SqlDbType.Int,4),
					new SqlParameter("@Class", SqlDbType.Int,4)};
			parameters[0].Value = model.Place_name;
			parameters[1].Value = model.Place_id;
			parameters[2].Value = model.Refer_sn;
			parameters[3].Value = model.Class;

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
		public bool Update(PE2.Model.Place model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Place set ");
			strSql.Append("Place_name=@Place_name,");
			strSql.Append("Place_id=@Place_id,");
			strSql.Append("Refer_sn=@Refer_sn,");
			strSql.Append("Class=@Class");
			strSql.Append(" where Place_sn=@Place_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Place_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Refer_sn", SqlDbType.Int,4),
					new SqlParameter("@Class", SqlDbType.Int,4),
					new SqlParameter("@Place_sn", SqlDbType.Int,4)};
			parameters[0].Value = model.Place_name;
			parameters[1].Value = model.Place_id;
			parameters[2].Value = model.Refer_sn;
			parameters[3].Value = model.Class;
			parameters[4].Value = model.Place_sn;

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
		public bool Delete(int Place_sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Place ");
			strSql.Append(" where Place_sn=@Place_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Place_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = Place_sn;

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
		public bool DeleteList(string Place_snlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Place ");
			strSql.Append(" where Place_sn in ("+Place_snlist + ")  ");
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
		public PE2.Model.Place GetModel(int Place_sn)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Place_sn,Place_name,Place_id,Refer_sn,Class from Place ");
			strSql.Append(" where Place_sn=@Place_sn");
			SqlParameter[] parameters = {
					new SqlParameter("@Place_sn", SqlDbType.Int,4)
			};
			parameters[0].Value = Place_sn;

			PE2.Model.Place model=new PE2.Model.Place();
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
		public PE2.Model.Place DataRowToModel(DataRow row)
		{
			PE2.Model.Place model=new PE2.Model.Place();
			if (row != null)
			{
				if(row["Place_sn"]!=null && row["Place_sn"].ToString()!="")
				{
					model.Place_sn=int.Parse(row["Place_sn"].ToString());
				}
				if(row["Place_name"]!=null)
				{
					model.Place_name=row["Place_name"].ToString();
				}
				if(row["Place_id"]!=null)
				{
					model.Place_id=row["Place_id"].ToString();
				}
				if(row["Refer_sn"]!=null && row["Refer_sn"].ToString()!="")
				{
					model.Refer_sn=int.Parse(row["Refer_sn"].ToString());
				}
				if(row["Class"]!=null && row["Class"].ToString()!="")
				{
					model.Class=int.Parse(row["Class"].ToString());
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
			strSql.Append("select Place_sn,Place_name,Place_id,Refer_sn,Class ");
			strSql.Append(" FROM Place ");
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
			strSql.Append(" Place_sn,Place_name,Place_id,Refer_sn,Class ");
			strSql.Append(" FROM Place ");
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
			strSql.Append("select count(1) FROM Place ");
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
				strSql.Append("order by T.Place_sn desc");
			}
			strSql.Append(")AS Row, T.*  from Place T ");
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
			parameters[0].Value = "Place";
			parameters[1].Value = "Place_sn";
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

