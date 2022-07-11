using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace PE2.DAL
{
    public partial class v_Calibrate
    {
        public DataTable GetCalibrateList(Model.v_Calibrate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_Calibrate] WHERE 1 = 1 ");

            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Assts_no", SqlDbType.NVarChar),
                    new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.Int),
                    new SqlParameter("@Assts_Station", SqlDbType.NVarChar),
                    new SqlParameter("@Assts_Customer", SqlDbType.NVarChar),
                    new SqlParameter("@Assts_id", SqlDbType.NVarChar),
                    new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar),
                    new SqlParameter("@Assts_name", SqlDbType.NVarChar),
                    new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar),
                    new SqlParameter("@Assts_Quantity", SqlDbType.Int),
                    new SqlParameter("@Note", SqlDbType.NVarChar),
                    new SqlParameter("@SysNote", SqlDbType.NVarChar),
                    new SqlParameter("@Place_sn", SqlDbType.Int),
                    new SqlParameter("@Floor_sn", SqlDbType.Int),
                    new SqlParameter("@Place_Assets_sn", SqlDbType.NVarChar),
                    new SqlParameter("@Cp_Status", SqlDbType.Int)

            };
            if (model.Assts_no != string.Empty && model.Assts_no != null)
            {
                strSql.Append(" And Assts_no like '%' + @Assts_no + '%' ");
                parameters[0].Value = model.Assts_no;
            }
            //if (model.Place_Assets_Detail_sn != string.Empty && model.Place_Assets_Detail_sn != null)
            //{
            //    strSql.Append(" And Place_Assets_Detail_sn  =  @Place_Assets_Detail_sn ");
            //    parameters[1].Value = model.Place_Assets_Detail_sn;
            //}
            if (model.Place_Assets_Detail_sn != string.Empty && model.Place_Assets_Detail_sn != null)
            {
                strSql.Append(" And (Place_Assets_Detail_sn  =  @Place_Assets_Detail_sn or Assts_no =  @Place_Assets_Detail_sn ) ");
                parameters[1].Value = model.Place_Assets_Detail_sn;
            }
            if (model.Assts_Station != string.Empty && model.Assts_Station != null)
            {
                strSql.Append(" And Assts_Station like '%' + @Assts_Station + '%' ");
                parameters[2].Value = model.Assts_Station;
            }
            if (model.Assts_Customer != string.Empty && model.Assts_Customer != null)
            {
                strSql.Append(" And Assts_Customer like '%' + @Assts_Customer + '%' ");
                parameters[3].Value = model.Assts_Customer;
            }
            if (model.Assts_id != string.Empty && model.Assts_id != null)
            {
                strSql.Append(" And Assts_id like '%' + @Assts_id + '%' ");
                parameters[4].Value = model.Assts_id;
            }
            if (model.Assts_eq_id != string.Empty && model.Assts_eq_id != null)
            {
                strSql.Append(" And Assts_eq_id like '%' + @Assts_eq_id + '%' ");
                parameters[5].Value = model.Assts_eq_id;
            }
            if (model.Assts_name != string.Empty && model.Assts_name != null)
            {
                strSql.Append(" And Assts_name like '%' + @Assts_name + '%' ");
                parameters[6].Value = model.Assts_name;
            }
            if (model.Assts_eq_name != string.Empty && model.Assts_eq_name != null)
            {
                strSql.Append(" And Assts_eq_name like '%' + @Assts_eq_name + '%' ");
                parameters[7].Value = model.Assts_eq_name;
            }
            if (model.Assts_Quantity != 0 && model.Assts_Quantity != null)
            {
                strSql.Append(" And Assts_Quantity = @Assts_Quantity ");
                parameters[8].Value = model.Assts_Quantity;
            }

            if (model.Note != string.Empty && model.Note != null)
            {
                strSql.Append(" And Note like '%' + @Note + '%' ");
                parameters[9].Value = model.Note;
            }
            if (model.SysNote != string.Empty && model.SysNote != null)
            {
                strSql.Append(" And SysNote like '%' + @SysNote + '%' ");
                parameters[10].Value = model.SysNote;
            }
            if (model.Place_sn != 0 && model.Place_sn != null)
            {
                strSql.Append(" And Place_sn  =  @Place_sn ");
                parameters[11].Value = model.Place_sn;
            }
            if (model.Floor_sn != 0 && model.Floor_sn != null)
            {
                strSql.Append(" And Floor_sn  =  @Floor_sn ");
                parameters[12].Value = model.Floor_sn;
            }
            if (model.Place_Assets_sn != "" && model.Place_Assets_sn != null)
            {
                strSql.Append(" And Place_Assets_sn  =  @Place_Assets_sn ");
                parameters[13].Value = model.Place_Assets_sn;
            }
            if (model.Cp_Status != -1 && model.Cp_Status != null)
            {
                strSql.Append(" And Cp_Status  =  @Cp_Status ");
                parameters[14].Value = model.Cp_Status;
            }
            if (model.Last_Cp_Date_s != string.Empty && model.Last_Cp_Date_s != null)
            {
                strSql.Append(" And Last_Cp_Date  >= '" + model.Last_Cp_Date_s  + "'");
                
            }
            if (model.Last_Cp_Date_d != string.Empty && model.Last_Cp_Date_d != null)
            {
                strSql.Append(" And Last_Cp_Date  <= '" + model.Last_Cp_Date_d + "'");

            }
            if (model.Next_Cp_Date_s != string.Empty && model.Next_Cp_Date_s != null) 
            {
                strSql.Append(" And Next_Cp_Date  >= '" + model.Next_Cp_Date_s + "'");

            }
            if (model.Next_Cp_Date_d != string.Empty && model.Next_Cp_Date_d != null)
            {
                strSql.Append(" And Next_Cp_Date  <= '" + model.Next_Cp_Date_d + "'");

            }
            if (model.Non_In_Type != string.Empty && model.Non_In_Type != null)
            {
                strSql.Append(" And Cp_Type  not in (" + model.Non_In_Type + ")");

            }
            strSql.Append(" order by Next_Cp_Date  ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }


}
