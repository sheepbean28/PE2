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
        public DataTable GetSuppliesList(Model.Supplies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_Supplies] WHERE 1 = 1 ");

            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Supplies_no", SqlDbType.NVarChar),
                    new SqlParameter("@Supplies_Name", SqlDbType.NVarChar),
                    new SqlParameter("@Supplies_Class", SqlDbType.NVarChar),
                    new SqlParameter("@Note", SqlDbType.NVarChar)
            };
            if (model.Supplies_no != string.Empty && model.Supplies_no != null)
            {
                strSql.Append(" And Supplies_no like '%' + @Supplies_no + '%' ");
                parameters[0].Value = model.Supplies_no;
            }

            if (model.Supplies_Name != string.Empty && model.Supplies_Name != null)
            {
                strSql.Append(" And Supplies_Name like '%' + @Supplies_Name + '%' ");
                parameters[1].Value = model.Supplies_Name;
            }

            if (model.Supplies_Class != string.Empty && model.Supplies_Class != "-1" && model.Supplies_Class != null)
            {
                strSql.Append(" And Supplies_Class = @Supplies_Class");
                parameters[2].Value = model.Supplies_Class;
            }

            if (model.Note != string.Empty && model.Note != null)
            {
                strSql.Append(" And Note like '%' + @Note + '%' ");
                parameters[3].Value = model.Note;
            }
            if (model.StockStart != -1 && model.StockStart != null)
            {
                strSql.Append(" And Supplies_Stock >= " + model.StockStart);

            }
            if (model.StockEnd != -1 && model.StockEnd != null)
            {
                strSql.Append(" And Supplies_Stock <= " + model.StockEnd);

            }
            if (model.Place_code_sn != -1 && model.Place_code_sn != null)
            {
                strSql.Append(" And Place_code_sn = " + model.Place_code_sn);

            }
            strSql.Append(" order by Supplies_no ");

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
        public DataTable GetSuppliesList(Model.Supplies model,bool isUse)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [Supplies] WHERE 1 = 1 ");

            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Supplies_no", SqlDbType.NVarChar),
                    new SqlParameter("@Supplies_Name", SqlDbType.NVarChar),
                    new SqlParameter("@Supplies_Class", SqlDbType.NVarChar),
                    new SqlParameter("@Note", SqlDbType.NVarChar)
            };
            if (model.Supplies_no != string.Empty && model.Supplies_no != null)
            {
                strSql.Append(" And Supplies_no =  @Supplies_no ");
                parameters[0].Value = model.Supplies_no;
            }

            if (model.Supplies_Name != string.Empty && model.Supplies_Name != null)
            {
                strSql.Append(" And Supplies_Name like '%' + @Supplies_Name + '%' ");
                parameters[1].Value = model.Supplies_Name;
            }

            if (model.Supplies_Class != string.Empty && model.Supplies_Class != "-1" && model.Supplies_Class != null)
            {
                strSql.Append(" And Supplies_Class = @Supplies_Class");
                parameters[2].Value = model.Supplies_Class;
            }

            if (model.Note != string.Empty && model.Note != null)
            {
                strSql.Append(" And Note like '%' + @Note + '%' ");
                parameters[3].Value = model.Note;
            }
            if (model.StockStart != -1 && model.StockStart != null)
            {
                strSql.Append(" And Supplies_Stock >= " + model.StockStart);

            }
            if (model.StockEnd != -1 && model.StockEnd != null)
            {
                strSql.Append(" And Supplies_Stock <= " + model.StockEnd);

            }


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
        public string GetSupplies_no(string Supplies_Class)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" SELECT RIGHT(REPLICATE('0', 4) + CAST(MAX([Supplies_C_No]) + 1 as NVARCHAR), 4)  as New_no
                             FROM [PE2].[dbo].[Supplies] WHERE [Supplies_Class] = " + Supplies_Class);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["New_no"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

