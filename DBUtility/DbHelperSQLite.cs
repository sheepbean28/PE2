using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;

namespace Maticsoft.DBUtility
{
    /// <summary>
    /// Copyright (C) 2011 Maticsoft 
    /// 杅擂溼恀價插濬(價衾SQLite)
    /// 褫眕蚚誧褫眕党蜊雛逋赻撩砐醴腔剒猁﹝
    /// </summary>
    public abstract class DbHelperSQLite
    {
        //杅擂踱蟀諉趼睫揹(web.config懂饜离)ㄛ褫眕雄怓載蜊connectionString盓厥嗣杅擂踱.		
        public static string connectionString = PubConstant.ConnectionString;
        public DbHelperSQLite()
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
        public static bool Exists(string strSql, params SQLiteParameter[] cmdParms)
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

        //#region  硒俴潠等SQL逄曆

        ///// <summary>
        ///// 硒俴SQL逄曆ㄛ殿隙荌砒腔暮翹杅
        ///// </summary>
        ///// <param name="SQLString">SQL逄曆</param>
        ///// <returns>荌砒腔暮翹杅</returns>
        //public static int ExecuteSql(string SQLString)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        using (SQLiteCommand cmd = new SQLiteCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SQLite.SQLiteException E)
        //            {
        //                connection.Close();
        //                throw new Exception(E.Message);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 硒俴嗣沭SQL逄曆ㄛ妗珋杅擂踱岈昢﹝
        ///// </summary>
        ///// <param name="SQLStringList">嗣沭SQL逄曆</param>		
        //public static void ExecuteSqlTran(ArrayList SQLStringList)
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        //    {
        //        conn.Open();
        //        SQLiteCommand cmd = new SQLiteCommand();
        //        cmd.Connection = conn;
        //        SQLiteTransaction tx = conn.BeginTransaction();
        //        cmd.Transaction = tx;
        //        try
        //        {
        //            for (int n = 0; n < SQLStringList.Count; n++)
        //            {
        //                string strsql = SQLStringList[n].ToString();
        //                if (strsql.Trim().Length > 1)
        //                {
        //                    cmd.CommandText = strsql;
        //                    cmd.ExecuteNonQuery();
        //                }
        //            }
        //            tx.Commit();
        //        }
        //        catch (System.Data.SQLite.SQLiteException E)
        //        {
        //            tx.Rollback();
        //            throw new Exception(E.Message);
        //        }
        //    }
        //}
        ///// <summary>
        ///// 硒俴湍珨跺湔揣徹最統杅腔腔SQL逄曆﹝
        ///// </summary>
        ///// <param name="SQLString">SQL逄曆</param>
        ///// <param name="content">統杅囀,掀珨跺趼僇岆跡宒葩娸腔恅梒ㄛ衄杻忷睫瘍ㄛ褫眕籵徹涴跺源宒氝樓</param>
        ///// <returns>荌砒腔暮翹杅</returns>
        //public static int ExecuteSql(string SQLString, string content)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        SQLiteCommand cmd = new SQLiteCommand(SQLString, connection);
        //        SQLiteParameter myParameter = new SQLiteParameter("@content", DbType.String);
        //        myParameter.Value = content;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows;
        //        }
        //        catch (System.Data.SQLite.SQLiteException E)
        //        {
        //            throw new Exception(E.Message);
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 砃杅擂踱爵脣芞砉跡宒腔趼僇(睿奻醱錶濬侔腔鍚珨笱妗瞰)
        ///// </summary>
        ///// <param name="strSQL">SQL逄曆</param>
        ///// <param name="fs">芞砉趼誹,杅擂踱腔趼僇濬倰峈image腔錶</param>
        ///// <returns>荌砒腔暮翹杅</returns>
        //public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        SQLiteCommand cmd = new SQLiteCommand(strSQL, connection);
        //        SQLiteParameter myParameter = new SQLiteParameter("@fs", DbType.Binary);
        //        myParameter.Value = fs;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows;
        //        }
        //        catch (System.Data.SQLite.SQLiteException E)
        //        {
        //            throw new Exception(E.Message);
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 硒俴珨沭數呾脤戙賦彆逄曆ㄛ殿隙脤戙賦彆ㄗobjectㄘ﹝
        ///// </summary>
        ///// <param name="SQLString">數呾脤戙賦彆逄曆</param>
        ///// <returns>脤戙賦彆ㄗobjectㄘ</returns>
        //public static object GetSingle(string SQLString)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        using (SQLiteCommand cmd = new SQLiteCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                object obj = cmd.ExecuteScalar();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SQLite.SQLiteException e)
        //            {
        //                connection.Close();
        //                throw new Exception(e.Message);
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 硒俴脤戙逄曆ㄛ殿隙SQLiteDataReader
        ///// </summary>
        ///// <param name="strSQL">脤戙逄曆</param>
        ///// <returns>SQLiteDataReader</returns>
        //public static SQLiteDataReader ExecuteReader(string strSQL)
        //{
        //    SQLiteConnection connection = new SQLiteConnection(connectionString);
        //    SQLiteCommand cmd = new SQLiteCommand(strSQL, connection);
        //    try
        //    {
        //        connection.Open();
        //        SQLiteDataReader myReader = cmd.ExecuteReader();
        //        return myReader;
        //    }
        //    catch (System.Data.SQLite.SQLiteException e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //}
        ///// <summary>
        ///// 硒俴脤戙逄曆ㄛ殿隙DataSet
        ///// </summary>
        ///// <param name="SQLString">脤戙逄曆</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, connection);
        //            command.Fill(ds, "ds");
        //        }
        //        catch (System.Data.SQLite.SQLiteException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}


        //#endregion

        //#region 硒俴湍統杅腔SQL逄曆

        ///// <summary>
        ///// 硒俴SQL逄曆ㄛ殿隙荌砒腔暮翹杅
        ///// </summary>
        ///// <param name="SQLString">SQL逄曆</param>
        ///// <returns>荌砒腔暮翹杅</returns>
        //public static int ExecuteSql(string SQLString, params SQLiteParameter[] cmdParms)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        using (SQLiteCommand cmd = new SQLiteCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //                int rows = cmd.ExecuteNonQuery();
        //                cmd.Parameters.Clear();
        //                return rows;
        //            }
        //            catch (System.Data.SQLite.SQLiteException E)
        //            {
        //                throw new Exception(E.Message);
        //            }
        //        }
        //    }
        //}


        ///// <summary>
        ///// 硒俴嗣沭SQL逄曆ㄛ妗珋杅擂踱岈昢﹝
        ///// </summary>
        ///// <param name="SQLStringList">SQL逄曆腔慇洷桶ㄗkey峈sql逄曆ㄛvalue岆蜆逄曆腔SQLiteParameter[]ㄘ</param>
        //public static void ExecuteSqlTran(Hashtable SQLStringList)
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SQLiteTransaction trans = conn.BeginTransaction())
        //        {
        //            SQLiteCommand cmd = new SQLiteCommand();
        //            try
        //            {
        //                //悜遠
        //                foreach (DictionaryEntry myDE in SQLStringList)
        //                {
        //                    string cmdText = myDE.Key.ToString();
        //                    SQLiteParameter[] cmdParms = (SQLiteParameter[])myDE.Value;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();

        //                    trans.Commit();
        //                }
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}


        ///// <summary>
        ///// 硒俴珨沭數呾脤戙賦彆逄曆ㄛ殿隙脤戙賦彆ㄗobjectㄘ﹝
        ///// </summary>
        ///// <param name="SQLString">數呾脤戙賦彆逄曆</param>
        ///// <returns>脤戙賦彆ㄗobjectㄘ</returns>
        //public static object GetSingle(string SQLString, params SQLiteParameter[] cmdParms)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        using (SQLiteCommand cmd = new SQLiteCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //                object obj = cmd.ExecuteScalar();
        //                cmd.Parameters.Clear();
        //                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (System.Data.SQLite.SQLiteException e)
        //            {
        //                throw new Exception(e.Message);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 硒俴脤戙逄曆ㄛ殿隙SQLiteDataReader
        ///// </summary>
        ///// <param name="strSQL">脤戙逄曆</param>
        ///// <returns>SQLiteDataReader</returns>
        //public static SQLiteDataReader ExecuteReader(string SQLString, params SQLiteParameter[] cmdParms)
        //{
        //    SQLiteConnection connection = new SQLiteConnection(connectionString);
        //    SQLiteCommand cmd = new SQLiteCommand();
        //    try
        //    {
        //        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //        SQLiteDataReader myReader = cmd.ExecuteReader();
        //        cmd.Parameters.Clear();
        //        return myReader;
        //    }
        //    catch (System.Data.SQLite.SQLiteException e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //}

        ///// <summary>
        ///// 硒俴脤戙逄曆ㄛ殿隙DataSet
        ///// </summary>
        ///// <param name="SQLString">脤戙逄曆</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString, params SQLiteParameter[] cmdParms)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        SQLiteCommand cmd = new SQLiteCommand();
        //        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                da.Fill(ds, "ds");
        //                cmd.Parameters.Clear();
        //            }
        //            catch (System.Data.SQLite.SQLiteException ex)
        //            {
        //                throw new Exception(ex.Message);
        //            }
        //            return ds;
        //        }
        //    }
        //}


        //private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (trans != null)
        //        cmd.Transaction = trans;
        //    cmd.CommandType = CommandType.Text;//cmdType;
        //    if (cmdParms != null)
        //    {
        //        foreach (SQLiteParameter parm in cmdParms)
        //            cmd.Parameters.Add(parm);
        //    }
        //}

       // #endregion

    

    }
}
