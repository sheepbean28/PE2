using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace PE2.DAL
{
    public partial class Fixture
    {
        
        /// <summary>
        /// Select [Fixture_usefor] from [Fixture] group by [Fixture_usefor]
        /// 取得所有Fixture_usefor資料
        /// </summary>
        public DataTable GetUsefor() 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select [Fixture_usefor] from [Fixture] group by [Fixture_usefor] ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        //// SearchModel.Fixture model = new SearchModel.Fixture();
        //    model.Model.Fixture_name = txtFixture_name.Text;
        //    model.Model.Fixture_no = txtFixture_no.Text;
        //    model.Model.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        //    model.Model.Fixture_usefor = ddlFixture_usefor.SelectedValue;
        public DataTable GetFixtureList(Model.Fixture model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_FixtureAll] WHERE 1 = 1 ");
            
            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Fixture_name", SqlDbType.NVarChar),
                    new SqlParameter("@Fixture_no", SqlDbType.NVarChar),
                    new SqlParameter("@Fixture_usefor", SqlDbType.NVarChar),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@Limit_date", SqlDbType.DateTime),
                
            };
            if (model.Fixture_name != string.Empty &&  model.Fixture_name != null)
            {
                strSql.Append(" And Fixture_name like '%' + @Fixture_name + '%' ");
                parameters[0].Value = model.Fixture_name;
            }
            if (model.Fixture_no != string.Empty && model.Fixture_no != null)
            {
                strSql.Append(" And Fixture_no  like '%' + @Fixture_no + '%' ");
                parameters[1].Value = model.Fixture_no;
            }
            if (model.Fixture_usefor != "-1" && model.Fixture_usefor != null)
            {
                strSql.Append(" And Fixture_usefor  =  @Fixture_usefor ");
                parameters[2].Value = model.Fixture_usefor;
            }
            if (model.Status != -1 && model.Status != null)
            {
                strSql.Append(" And Status = @Status ");
                parameters[3].Value = model.Status;
            }
            //if (model.Limit_date != null)
            //{
            //    strSql.Append(" And Limit_date <= @Limit_date ");
            //    parameters[4].Value = model.Limit_date;
            //}
            if (model.Limit_date != null)
            {
                strSql.Append(" And Limit_date <= @Limit_date ");
                parameters[4].Value = model.Limit_date;
            }
            strSql.Append(" order by LastOut_date desc ");
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

        public DataTable GetFixtureList(Model.Fixture model,int User_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_OutFixture] WHERE 1 = 1 ");

            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Fixture_name", SqlDbType.NVarChar),
                    new SqlParameter("@Fixture_no", SqlDbType.NVarChar),
                    new SqlParameter("@Fixture_usefor", SqlDbType.NVarChar),
                    new SqlParameter("@Status", SqlDbType.Int)
            };
            if (model.Fixture_name != string.Empty && model.Fixture_name != null)
            {
                strSql.Append(" And Fixture_name like '%' + @Fixture_name + '%' ");
                parameters[0].Value = model.Fixture_name;
            }
            if (model.Fixture_no != string.Empty && model.Fixture_no != null)
            {
                strSql.Append(" And Fixture_no  like '%' + @Fixture_no + '%' ");
                parameters[1].Value = model.Fixture_no;
            }
            if (model.Fixture_usefor != "-1" && model.Fixture_usefor != null)
            {
                strSql.Append(" And Fixture_usefor  =  @Fixture_usefor ");
                parameters[2].Value = model.Fixture_usefor;
            }
            if (model.Status != -1 && model.Status != null)
            {
                strSql.Append(" And Status = @Status ");
                parameters[3].Value = model.Status;
            }
            if (User_sn != 0)
            {
                strSql.Append(" And User_sn = " + User_sn);
            }
          
            strSql.Append(" order by Out_date ");
            if (model.sort != string.Empty && model.sort != null)
            {
                strSql.Append(model.sort);
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

        public DataSet GetFixtureListDataSet(Model.Fixture model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_FixtureAll] WHERE 1 = 1 ");

            SqlParameter[] parameters = 
            {
                    new SqlParameter("@Fixture_name", SqlDbType.NVarChar),
                    new SqlParameter("@Fixture_no", SqlDbType.NVarChar),
                    new SqlParameter("@Fixture_usefor", SqlDbType.NVarChar),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@Limit_date", SqlDbType.DateTime)
                    
            };
            if (model.Fixture_name != string.Empty && model.Fixture_name != null)
            {
                strSql.Append(" And Fixture_name like '%' + @Fixture_name + '%' ");
                parameters[0].Value = model.Fixture_name;
            }
            if (model.Fixture_no != string.Empty && model.Fixture_no != null)
            {
                strSql.Append(" And Fixture_no  like '%' + @Fixture_no + '%' ");
                parameters[1].Value = model.Fixture_no;
            }
            if (model.Fixture_usefor != "-1" && model.Fixture_usefor != null)
            {
                strSql.Append(" And Fixture_usefor  =  @Fixture_usefor ");
                parameters[2].Value = model.Fixture_usefor;
            }
            if (model.Status != -1 && model.Status != null)
            {
                strSql.Append(" And Status = @Status ");
                parameters[3].Value = model.Status;
            }
            //if (model.Limit_date != null)
            //{
            //    strSql.Append(" And Limit_date <= @Limit_date ");
            //    parameters[4].Value = model.Limit_date;
            //}
            if (model.Limit_date != null)
            {
                strSql.Append(" And Limit_date <= @Limit_date ");
                parameters[4].Value = model.Limit_date;
            }
           
            strSql.Append(" order by LastOut_date desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

    }

    public partial class InFixture
    {
        public DataTable GetViewList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_InFixture] WHERE 1 = 1 ");
            strSql.Append(" order by In_date desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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

    public partial class OutFixture
    {
        public DataTable GetViewList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * from [v_OutFixture] WHERE 1 = 1 ");
            strSql.Append(" order by Out_date desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
