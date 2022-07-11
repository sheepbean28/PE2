using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Maticsoft.DBUtility
{
	/// <summary>
    /// Enterprise Library 2.0 杅擂溼恀輛珨祭猾蚾濬
    /// Copyright (C) Maticsoft
	/// All rights reserved	
	/// </summary>
	public abstract class DbHelperSQL2
	{        
		public DbHelperSQL2()
		{
        }

        #region 鼠蚚源楊

        public static int GetMaxID(string FieldName,string TableName)
        {
            string strSql = "select max(" + FieldName + ")+1 from " + TableName;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);           
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }           
        }
		public static bool Exists(string strSql)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            object obj = db.ExecuteScalar(dbCommand);
			int cmdresult;
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            BuildDBParameter(db, dbCommand, cmdParms);            
            object obj = db.ExecuteScalar(dbCommand);           
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        /// <summary>
        /// 樓婥統杅
        /// </summary>
        public static void BuildDBParameter(Database db, DbCommand dbCommand, params SqlParameter[] cmdParms)
        {
            foreach (SqlParameter sp in cmdParms)
            {
                db.AddInParameter(dbCommand, sp.ParameterName, sp.DbType,sp.Value);
            }
        }
        #endregion

        #region  硒俴潠等SQL逄曆

        /// <summary>
		/// 硒俴SQL逄曆ㄛ殿隙荌砒腔暮翹杅
		/// </summary>
		/// <param name="strSql">SQL逄曆</param>
		/// <returns>荌砒腔暮翹杅</returns>
        public static int ExecuteSql(string strSql)
		{    
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            return db.ExecuteNonQuery(dbCommand);
		}

		public static int ExecuteSqlByTime(string strSql,int Times)
		{           
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            dbCommand.CommandTimeout = Times;
            return db.ExecuteNonQuery(dbCommand);
		}
		
		/// <summary>
		/// 硒俴嗣沭SQL逄曆ㄛ妗珋杅擂踱岈昢﹝
		/// </summary>
		/// <param name="SQLStringList">嗣沭SQL逄曆</param>		
		public static void ExecuteSqlTran(ArrayList SQLStringList)
		{

            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection dbconn = db.CreateConnection())
            { 
                dbconn.Open();
                DbTransaction dbtran = dbconn.BeginTransaction();
                try
                {
                    //硒俴逄曆
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(strsql);
                            db.ExecuteNonQuery(dbCommand);
                        }
                    }
                    //硒俴湔揣徹最
                    //db.ExecuteNonQuery(CommandType.StoredProcedure, "InserOrders");
                    //db.ExecuteDataSet(CommandType.StoredProcedure, "UpdateProducts");
                    dbtran.Commit();
                }
                catch
                {
                    dbtran.Rollback();
                }
                finally
                {
                    dbconn.Close();
                }
            }
        }

        #region 硒俴珨跺 杻忷趼僇湍統杅腔逄曆
        /// <summary>
		/// 硒俴湍珨跺湔揣徹最統杅腔腔SQL逄曆﹝
		/// </summary>
		/// <param name="strSql">SQL逄曆</param>
		/// <param name="content">統杅囀,掀珨跺趼僇岆跡宒葩娸腔恅梒ㄛ衄杻忷睫瘍ㄛ褫眕籵徹涴跺源宒氝樓</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSql(string strSql,string content)
		{	
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "@content", DbType.String, content);
            return db.ExecuteNonQuery(dbCommand);
		}		
		
        /// <summary>
		/// 硒俴湍珨跺湔揣徹最統杅腔腔SQL逄曆﹝
		/// </summary>
		/// <param name="strSql">SQL逄曆</param>
		/// <param name="content">統杅囀,掀珨跺趼僇岆跡宒葩娸腔恅梒ㄛ衄杻忷睫瘍ㄛ褫眕籵徹涴跺源宒氝樓</param>
		/// <returns>殿隙逄曆爵腔脤戙賦彆</returns>
		public static object ExecuteSqlGet(string strSql,string content)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "@content", DbType.String, content);
            object obj = db.ExecuteNonQuery(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return null;
            }
            else
            {
                return obj;
            }		
		}		
		
        /// <summary>
		/// 砃杅擂踱爵脣芞砉跡宒腔趼僇(睿奻醱錶濬侔腔鍚珨笱妗瞰)
		/// </summary>
		/// <param name="strSql">SQL逄曆</param>
		/// <param name="fs">芞砉趼誹,杅擂踱腔趼僇濬倰峈image腔錶</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSqlInsertImg(string strSql,byte[] fs)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "@fs", DbType.Byte, fs);
            return db.ExecuteNonQuery(dbCommand);			
        }
        #endregion

        /// <summary>
		/// 硒俴珨沭數呾脤戙賦彆逄曆ㄛ殿隙脤戙賦彆ㄗobjectㄘ﹝
		/// </summary>
		/// <param name="strSql">數呾脤戙賦彆逄曆</param>
		/// <returns>脤戙賦彆ㄗobjectㄘ</returns>
		public static object GetSingle(string strSql)
		{            
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return null;
            }
            else
            {
                return obj;
            }      
		}
		
        /// <summary>
        /// 硒俴脤戙逄曆ㄛ殿隙SqlDataReader ( 蛁砩ㄩ妏蚚綴珨隅猁勤SqlDataReader輛俴Close )
		/// </summary>
		/// <param name="strSql">脤戙逄曆</param>
		/// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSql)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(dbCommand);
            return dr;      
			
		}		
		
        /// <summary>
		/// 硒俴脤戙逄曆ㄛ殿隙DataSet
		/// </summary>
		/// <param name="strSql">脤戙逄曆</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string strSql)
		{            
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataSet(dbCommand);
            
		}
		public static DataSet Query(string strSql,int Times)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            dbCommand.CommandTimeout = Times;
            return db.ExecuteDataSet(dbCommand);
		}

		#endregion

		#region 硒俴湍統杅腔SQL逄曆

		/// <summary>
		/// 硒俴SQL逄曆ㄛ殿隙荌砒腔暮翹杅
		/// </summary>
		/// <param name="strSql">SQL逄曆</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSql(string strSql,params SqlParameter[] cmdParms)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            BuildDBParameter(db, dbCommand, cmdParms);    
            return db.ExecuteNonQuery(dbCommand);
		}
		
			
		/// <summary>
		/// 硒俴嗣沭SQL逄曆ㄛ妗珋杅擂踱岈昢﹝
		/// </summary>
		/// <param name="SQLStringList">SQL逄曆腔慇洷桶ㄗkey峈sql逄曆ㄛvalue岆蜆逄曆腔SqlParameter[]ㄘ</param>
		public static void ExecuteSqlTran(Hashtable SQLStringList)
		{
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection dbconn = db.CreateConnection())
            {
                dbconn.Open();
                DbTransaction dbtran = dbconn.BeginTransaction();
                try
                {
                    //硒俴逄曆
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string strsql = myDE.Key.ToString();
                        SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;                        
                        if (strsql.Trim().Length > 1)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(strsql);
                            BuildDBParameter(db, dbCommand, cmdParms);    
                            db.ExecuteNonQuery(dbCommand);
                        }
                    }
                    dbtran.Commit();
                }
                catch
                {
                    dbtran.Rollback();
                }
                finally
                {
                    dbconn.Close();
                }
            }
		}
	
				
		/// <summary>
		/// 硒俴珨沭數呾脤戙賦彆逄曆ㄛ殿隙脤戙賦彆ㄗobjectㄘ﹝
		/// </summary>
		/// <param name="strSql">數呾脤戙賦彆逄曆</param>
		/// <returns>脤戙賦彆ㄗobjectㄘ</returns>
		public static object GetSingle(string strSql,params SqlParameter[] cmdParms)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            BuildDBParameter(db, dbCommand, cmdParms);    
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return null;
            }
            else
            {
                return obj;
            }      
		}
		
		/// <summary>
        /// 硒俴脤戙逄曆ㄛ殿隙SqlDataReader ( 蛁砩ㄩ妏蚚綴珨隅猁勤SqlDataReader輛俴Close )
		/// </summary>
		/// <param name="strSql">脤戙逄曆</param>
		/// <returns>SqlDataReader</returns>
		public static SqlDataReader ExecuteReader(string strSql,params SqlParameter[] cmdParms)
		{		
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            BuildDBParameter(db, dbCommand, cmdParms);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(dbCommand);
            return dr;
			
		}		
		
		/// <summary>
		/// 硒俴脤戙逄曆ㄛ殿隙DataSet
		/// </summary>
		/// <param name="strSql">脤戙逄曆</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string strSql,params SqlParameter[] cmdParms)
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            BuildDBParameter(db, dbCommand, cmdParms);   
            return db.ExecuteDataSet(dbCommand);
		}


		private static void PrepareCommand(SqlCommand cmd,SqlConnection conn,SqlTransaction trans, string cmdText, SqlParameter[] cmdParms) 
		{
			if (conn.State != ConnectionState.Open)
				conn.Open();
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			if (trans != null)
				cmd.Transaction = trans;
			cmd.CommandType = CommandType.Text;//cmdType;
			if (cmdParms != null) 
			{
                foreach (SqlParameter parameter in cmdParms)
				{
					if ( ( parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input ) && 
						(parameter.Value == null))
					{
						parameter.Value = DBNull.Value;
					}
					cmd.Parameters.Add(parameter);
				}
			}
		}

		#endregion

		#region 湔揣徹最紱釬

        /// <summary>
        /// 硒俴湔揣徹最ㄛ殿隙荌砒腔俴杅		
        /// </summary>       
        public static int RunProcedure(string storedProcName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
            return db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 硒俴湔揣徹最ㄛ殿隙怀堤統杅腔硉睿荌砒腔俴杅		
        /// </summary>
        /// <param name="storedProcName">湔揣徹最靡</param>
        /// <param name="parameters">湔揣徹最統杅</param>
        /// <param name="OutParameter">怀堤統杅靡備</param>
        /// <param name="rowsAffected">荌砒腔俴杅</param>
        /// <returns></returns>
        public static object RunProcedure(string storedProcName, IDataParameter[] InParameters, SqlParameter OutParameter, int rowsAffected)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(storedProcName);
            BuildDBParameter(db, dbCommand, (SqlParameter[])InParameters);
            db.AddOutParameter(dbCommand, OutParameter.ParameterName, OutParameter.DbType, OutParameter.Size);
            rowsAffected = db.ExecuteNonQuery(dbCommand);
            return db.GetParameterValue(dbCommand,"@" + OutParameter.ParameterName);  //腕善怀堤統杅腔硉
        }

		/// <summary>
        /// 硒俴湔揣徹最ㄛ殿隙SqlDataReader ( 蛁砩ㄩ妏蚚綴珨隅猁勤SqlDataReader輛俴Close )
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <returns>SqlDataReader</returns>
		public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(storedProcName, parameters);            
            //BuildDBParameter(db, dbCommand, parameters);
            return (SqlDataReader)db.ExecuteReader(dbCommand);           
		}
				
		/// <summary>
        /// 硒俴湔揣徹最ㄛ殿隙DataSet
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <param name="tableName">DataSet賦彆笢腔桶靡</param>
		/// <returns>DataSet</returns>
		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{           
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(storedProcName, parameters);
            //BuildDBParameter(db, dbCommand, parameters);
            return db.ExecuteDataSet(dbCommand); 
		}
        /// <summary>
        /// 硒俴湔揣徹最ㄛ殿隙DataSet(扢隅脹渾奀潔)
        /// </summary>
		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName ,int Times)
		{           
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(storedProcName, parameters);
            dbCommand.CommandTimeout = Times;
            //BuildDBParameter(db, dbCommand, parameters);
            return db.ExecuteDataSet(dbCommand); 
		}

		
		/// <summary>
		/// 凳膘 SqlCommand 勤砓(蚚懂殿隙珨跺賦彆摩ㄛ奧祥岆珨跺淕杅硉)
		/// </summary>
		/// <param name="connection">杅擂踱蟀諉</param>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <returns>SqlCommand</returns>
		private static SqlCommand BuildQueryCommand(SqlConnection connection,string storedProcName, IDataParameter[] parameters)
		{			
			SqlCommand command = new SqlCommand( storedProcName, connection );
			command.CommandType = CommandType.StoredProcedure;
			foreach (SqlParameter parameter in parameters)
			{
				if( parameter != null )
				{
					// 潰脤帤煦饜硉腔怀堤統杅,蔚煦饜眕DBNull.Value.
					if ( ( parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input ) && 
						(parameter.Value == null))
					{
						parameter.Value = DBNull.Value;
					}
					command.Parameters.Add(parameter);
				}
			}			
			return command;			
		}		
		/// <summary>
		/// 斐膘 SqlCommand 勤砓妗瞰(蚚懂殿隙珨跺淕杅硉)	
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <returns>SqlCommand 勤砓妗瞰</returns>
		private static SqlCommand BuildIntCommand(SqlConnection connection,string storedProcName, IDataParameter[] parameters)
		{
			SqlCommand command = BuildQueryCommand(connection,storedProcName, parameters );
			command.Parameters.Add( new SqlParameter ( "ReturnValue",
				SqlDbType.Int,4,ParameterDirection.ReturnValue,
				false,0,0,string.Empty,DataRowVersion.Default,null ));
			return command;
		}
		#endregion	

	}

}
