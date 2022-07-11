using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PE2.Assets
{
    public partial class AssetsUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvAssets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvAssets_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploader.HasFile)
            {
                string LocalFileName = Server.MapPath(@"~\AssetsFile\") + fileUploader.FileName;
                string FilePath = @"~\AssetsFile\" + fileUploader.FileName;
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                fileUploader.SaveAs(LocalFileName);
                LoadData(LocalFileName);
            }
        }
        public void LoadData(string FileName)
        {
            string strQuery = "SELECT * FROM 資產明細 "; //<--這裡您的需要改一下 
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName;
            OleDbConnection Connection = new OleDbConnection(strConn);
            OleDbCommand Command = new OleDbCommand(strQuery, Connection);
            Connection.Open();
            OleDbDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dtReader);


            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["操作時間"] != DBNull.Value)
                    dt.Rows[i]["操作時間"] = Convert.ToDateTime(dt.Rows[i]["操作時間"]).ToString("yyyy-MM-dd HH:mm:ss");
                else
                    dt.Rows[i]["操作時間"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            gvAssets.DataSource = dt;
            gvAssets.DataBind();
            InsertDt(dt);
            CheckDt();
            lbCount.Text = dt.Rows.Count.ToString();

            dtReader.Close();

        }
        public void InsertDt(DataTable dt)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            conn.Open();
            //宣告SqlBulkCopy
            using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn))
            {
                //設定一個批次量寫入多少筆資料
                sqlBC.BatchSize = 1000;
                //設定逾時的秒數
                sqlBC.BulkCopyTimeout = 60;

                //設定 NotifyAfter 屬性，以便在每複製 10000 個資料列至資料表後，呼叫事件處理常式。
                sqlBC.NotifyAfter = 10000;
                //  sqlBC.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                //設定要寫入的資料庫
                sqlBC.DestinationTableName = "dbo.AssetInLog";

                //對應資料行
                sqlBC.ColumnMappings.Add("標籤代碼", "標籤代碼");
                sqlBC.ColumnMappings.Add("資產編號", "資產編號");
                sqlBC.ColumnMappings.Add("資產名稱", "資產名稱");
                sqlBC.ColumnMappings.Add("設備序號", "設備序號");
                sqlBC.ColumnMappings.Add("管制資產名稱", "管制資產名稱");
                sqlBC.ColumnMappings.Add("數量", "數量");
                sqlBC.ColumnMappings.Add("客戶", "客戶");
                sqlBC.ColumnMappings.Add("測試站功能", "測試站功能");
                sqlBC.ColumnMappings.Add("樓層", "樓層");
                sqlBC.ColumnMappings.Add("線別", "線別");
                sqlBC.ColumnMappings.Add("儲位代碼", "儲位代碼");
                sqlBC.ColumnMappings.Add("關聯儲位", "關聯儲位");
                sqlBC.ColumnMappings.Add("操作人員", "操作人員");
                sqlBC.ColumnMappings.Add("操作時間", "操作時間");
                sqlBC.ColumnMappings.Add("一般說明", "一般說明");
                sqlBC.ColumnMappings.Add("管理人員說明", "管理人員說明");
                sqlBC.ColumnMappings.Add("盤點人員", "盤點人員");
                sqlBC.ColumnMappings.Add("盤點時間", "盤點時間");
                sqlBC.ColumnMappings.Add("盤點結果", "盤點結果");
                sqlBC.ColumnMappings.Add("資產建檔時間", "資產建檔時間");
                sqlBC.ColumnMappings.Add("站體數量", "站體數量");


                //開始寫入
                sqlBC.WriteToServer(dt);
            }
            conn.Dispose();

        }
        public void CheckDt()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand Command = new SqlCommand("EXEC [dbo].[sp_AssetInCheck]", conn);
            conn.Open();
                Command.ExecuteNonQuery();
            conn.Dispose();
        }
        public void Delete()
        {

        }
    }
}