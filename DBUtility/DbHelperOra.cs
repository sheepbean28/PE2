using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;

namespace Maticsoft.DBUtility
{
	/// <summary>
    /// Copyright (C) Maticsoft
	/// 杅擂溼恀價插濬(價衾Oracle)
	/// 褫眕蚚誧褫眕党蜊雛逋赻撩砐醴腔剒猁﹝
	/// </summary>
	public abstract class DbHelperOra
	{
        //杅擂踱蟀諉趼睫揹(web.config懂饜离)ㄛ褫眕雄怓載蜊connectionString盓厥嗣杅擂踱.		
        public static string connectionString = PubConstant.ConnectionString;     
		public DbHelperOra()
		{			
		}

        #region 鼠蚚源楊
        
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
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
            object obj = GetSingle(strSql);
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

        public static bool Exists(string strSql, params OracleParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
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

       
        #endregion

		
		#region  硒俴潠等SQL逄曆

		/// <summary>
		/// 硒俴SQL逄曆ㄛ殿隙荌砒腔暮翹杅
		/// </summary>
		/// <param name="SQLString">SQL逄曆</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSql(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{				
				using (OracleCommand cmd = new OracleCommand(SQLString,connection))
				{
					try
					{		
						connection.Open();
						int rows=cmd.ExecuteNonQuery();
						return rows;
					}
					catch(System.Data.OracleClient.OracleException E)
					{					
						connection.Close();
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
		/// <summary>
		/// 硒俴嗣沭SQL逄曆ㄛ妗珋杅擂踱岈昢﹝
		/// </summary>
		/// <param name="SQLStringList">嗣沭SQL逄曆</param>		
		public static void ExecuteSqlTran(ArrayList SQLStringList)
		{
			using (OracleConnection conn = new OracleConnection(connectionString))
			{
				conn.Open();
				OracleCommand cmd = new OracleCommand();
				cmd.Connection=conn;				
				OracleTransaction tx=conn.BeginTransaction();			
				cmd.Transaction=tx;				
				try
				{   		
					for(int n=0;n<SQLStringList.Count;n++)
					{
						string strsql=SQLStringList[n].ToString();
						if (strsql.Trim().Length>1)
						{
							cmd.CommandText=strsql;
							cmd.ExecuteNonQuery();
						}
					}										
					tx.Commit();					
				}
				catch(System.Data.OracleClient.OracleException E)
				{		
					tx.Rollback();
					throw new Exception(E.Message);
				}
			}
		}
		/// <summary>
		/// 硒俴湍珨跺湔揣徹最統杅腔腔SQL逄曆﹝
		/// </summary>
		/// <param name="SQLString">SQL逄曆</param>
		/// <param name="content">統杅囀,掀珨跺趼僇岆跡宒葩娸腔恅梒ㄛ衄杻忷睫瘍ㄛ褫眕籵徹涴跺源宒氝樓</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSql(string SQLString,string content)
		{				
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand(SQLString,connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter("@content", OracleType.NVarChar);
				myParameter.Value = content ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.OracleClient.OracleException E)
				{				
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}	
			}
		}		
		/// <summary>
		/// 砃杅擂踱爵脣芞砉跡宒腔趼僇(睿奻醱錶濬侔腔鍚珨笱妗瞰)
		/// </summary>
		/// <param name="strSQL">SQL逄曆</param>
		/// <param name="fs">芞砉趼誹,杅擂踱腔趼僇濬倰峈image腔錶</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSqlInsertImg(string strSQL,byte[] fs)
		{		
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand(strSQL,connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter("@fs", OracleType.LongRaw);
				myParameter.Value = fs ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.OracleClient.OracleException E)
				{				
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}				
			}
		}
		
		/// <summary>
		/// 硒俴珨沭數呾脤戙賦彆逄曆ㄛ殿隙脤戙賦彆ㄗobjectㄘ﹝
		/// </summary>
		/// <param name="SQLString">數呾脤戙賦彆逄曆</param>
		/// <returns>脤戙賦彆ㄗobjectㄘ</returns>
		public static object GetSingle(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				using(OracleCommand cmd = new OracleCommand(SQLString,connection))
				{
					try
					{
						connection.Open();
						object obj = cmd.ExecuteScalar();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.OracleClient.OracleException e)
					{						
						connection.Close();
						throw new Exception(e.Message);
					}	
				}
			}
		}
		/// <summary>
        /// 硒俴脤戙逄曆ㄛ殿隙OracleDataReader ( 蛁砩ㄩ覃蚚蜆源楊綴ㄛ珨隅猁勤SqlDataReader輛俴Close )
		/// </summary>
		/// <param name="strSQL">脤戙逄曆</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader ExecuteReader(string strSQL)
		{
			OracleConnection connection = new OracleConnection(connectionString);			
			OracleCommand cmd = new OracleCommand(strSQL,connection);				
			try
			{
				connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException e)
			{								
				throw new Exception(e.Message);
			}			
			
		}		
		/// <summary>
		/// 硒俴脤戙逄曆ㄛ殿隙DataSet
		/// </summary>
		/// <param name="SQLString">脤戙逄曆</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				DataSet ds = new DataSet();
				try
				{
					connection.Open();
					OracleDataAdapter command = new OracleDataAdapter(SQLString,connection);				
					command.Fill(ds,"ds");
				}
				catch(System.Data.OracleClient.OracleException ex)
				{				
					throw new Exception(ex.Message);
				}			
				return ds;
			}			
		}


		#endregion

		#region 硒俴湍統杅腔SQL逄曆

		/// <summary>
		/// 硒俴SQL逄曆ㄛ殿隙荌砒腔暮翹杅
		/// </summary>
		/// <param name="SQLString">SQL逄曆</param>
		/// <returns>荌砒腔暮翹杅</returns>
		public static int ExecuteSql(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{				
				using (OracleCommand cmd = new OracleCommand())
				{
					try
					{		
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						int rows=cmd.ExecuteNonQuery();
						cmd.Parameters.Clear();
						return rows;
					}
					catch(System.Data.OracleClient.OracleException E)
					{				
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
			
		/// <summary>
		/// 硒俴嗣沭SQL逄曆ㄛ妗珋杅擂踱岈昢﹝
		/// </summary>
		/// <param name="SQLStringList">SQL逄曆腔慇洷桶ㄗkey峈sql逄曆ㄛvalue岆蜆逄曆腔OracleParameter[]ㄘ</param>
		public static void ExecuteSqlTran(Hashtable SQLStringList)
		{			
			using (OracleConnection conn = new OracleConnection(connectionString))
			{
				conn.Open();
				using (OracleTransaction trans = conn.BeginTransaction()) 
				{
					OracleCommand cmd = new OracleCommand();
					try 
					{
						//悜遠
						foreach (DictionaryEntry myDE in SQLStringList)
						{	
							string 	cmdText=myDE.Key.ToString();
							OracleParameter[] cmdParms=(OracleParameter[])myDE.Value;
							PrepareCommand(cmd,conn,trans,cmdText, cmdParms);
							int val = cmd.ExecuteNonQuery();
							cmd.Parameters.Clear();

							trans.Commit();
						}					
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}				
			}
		}
	
				
		/// <summary>
		/// 硒俴珨沭數呾脤戙賦彆逄曆ㄛ殿隙脤戙賦彆ㄗobjectㄘ﹝
		/// </summary>
		/// <param name="SQLString">數呾脤戙賦彆逄曆</param>
		/// <returns>脤戙賦彆ㄗobjectㄘ</returns>
		public static object GetSingle(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				using (OracleCommand cmd = new OracleCommand())
				{
					try
					{
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						object obj = cmd.ExecuteScalar();
						cmd.Parameters.Clear();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.OracleClient.OracleException e)
					{				
						throw new Exception(e.Message);
					}					
				}
			}
		}
		
		/// <summary>
        /// 硒俴脤戙逄曆ㄛ殿隙OracleDataReader ( 蛁砩ㄩ覃蚚蜆源楊綴ㄛ珨隅猁勤SqlDataReader輛俴Close )
		/// </summary>
		/// <param name="strSQL">脤戙逄曆</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader ExecuteReader(string SQLString,params OracleParameter[] cmdParms)
		{		
			OracleConnection connection = new OracleConnection(connectionString);
			OracleCommand cmd = new OracleCommand();				
			try
			{
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException e)
			{								
				throw new Exception(e.Message);
			}					
			
		}		
		
		/// <summary>
		/// 硒俴脤戙逄曆ㄛ殿隙DataSet
		/// </summary>
		/// <param name="SQLString">脤戙逄曆</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand();
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
				using( OracleDataAdapter da = new OracleDataAdapter(cmd) )
				{
					DataSet ds = new DataSet();	
					try
					{												
						da.Fill(ds,"ds");
						cmd.Parameters.Clear();
					}
					catch(System.Data.OracleClient.OracleException ex)
					{				
						throw new Exception(ex.Message);
					}			
					return ds;
				}				
			}			
		}


		private static void PrepareCommand(OracleCommand cmd,OracleConnection conn,OracleTransaction trans, string cmdText, OracleParameter[] cmdParms) 
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
				foreach (OracleParameter parm in cmdParms)
					cmd.Parameters.Add(parm);
			}
		}

		#endregion

		#region 湔揣徹最紱釬

		/// <summary>
        /// 硒俴湔揣徹最 殿隙SqlDataReader ( 蛁砩ㄩ覃蚚蜆源楊綴ㄛ珨隅猁勤SqlDataReader輛俴Close )
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
			OracleConnection connection = new OracleConnection(connectionString);
			OracleDataReader returnReader;
			connection.Open();
			OracleCommand command = BuildQueryCommand( connection,storedProcName, parameters );
			command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);				
			return returnReader;			
		}
		
		
		/// <summary>
		/// 硒俴湔揣徹最
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <param name="tableName">DataSet賦彆笢腔桶靡</param>
		/// <returns>DataSet</returns>
		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				DataSet dataSet = new DataSet();
				connection.Open();
				OracleDataAdapter sqlDA = new OracleDataAdapter();
				sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters );
				sqlDA.Fill( dataSet, tableName );
				connection.Close();
				return dataSet;
			}
		}

		
		/// <summary>
		/// 凳膘 OracleCommand 勤砓(蚚懂殿隙珨跺賦彆摩ㄛ奧祥岆珨跺淕杅硉)
		/// </summary>
		/// <param name="connection">杅擂踱蟀諉</param>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <returns>OracleCommand</returns>
		private static OracleCommand BuildQueryCommand(OracleConnection connection,string storedProcName, IDataParameter[] parameters)
		{			
			OracleCommand command = new OracleCommand( storedProcName, connection );
			command.CommandType = CommandType.StoredProcedure;
			foreach (OracleParameter parameter in parameters)
			{
				command.Parameters.Add( parameter );
			}
			return command;			
		}
		
		/// <summary>
		/// 硒俴湔揣徹最ㄛ殿隙荌砒腔俴杅		
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <param name="rowsAffected">荌砒腔俴杅</param>
		/// <returns></returns>
		public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected )
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				int result;
				connection.Open();
				OracleCommand command = BuildIntCommand(connection,storedProcName, parameters );
				rowsAffected = command.ExecuteNonQuery();
				result = (int)command.Parameters["ReturnValue"].Value;
				//Connection.Close();
				return result;
			}
		}
		
		/// <summary>
		/// 斐膘 OracleCommand 勤砓妗瞰(蚚懂殿隙珨跺淕杅硉)	
		/// </summary>
		/// <param name="storedProcName">湔揣徹最靡</param>
		/// <param name="parameters">湔揣徹最統杅</param>
		/// <returns>OracleCommand 勤砓妗瞰</returns>
		private static OracleCommand BuildIntCommand(OracleConnection connection,string storedProcName, IDataParameter[] parameters)
		{
			OracleCommand command = BuildQueryCommand(connection,storedProcName, parameters );
			command.Parameters.Add( new OracleParameter ( "ReturnValue",
                OracleType.Int32, 4, ParameterDirection.ReturnValue,
				false,0,0,string.Empty,DataRowVersion.Default,null ));
			return command;
		}
		#endregion	

	}
}
