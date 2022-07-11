using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Fixture
{
    public partial class FixtureList : System.Web.UI.Page
    {
        BLL.Fixture bllFixture = new BLL.Fixture();
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            
            if (!IsPostBack)
            {
                LoadData();
                SearchModel.Fixture model = new SearchModel.Fixture();
                model.ClearModel();
            }
            
            btnAdd.Visible = (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0);

          
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            SearchModel.Fixture model = new SearchModel.Fixture();
            model.Model.Status = -1;
            DataTable dt = bllFixture.GetFixtureList(model.Model);
            Excel.ObjExcel.OutportExcel(dt, "治具列表" + DateTime.Now.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 資料讀取
        /// </summary>
        public void LoadData()
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
            SearchModel.Fixture model = new SearchModel.Fixture();
            if (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0)
            {
                model.Model.Fixture_usefor = "-1";
            }
            DataTable dt = bllFixture.GetFixtureList(model.Model);
            gvFixture.DataSource = dt;
            gvFixture.DataBind();
            if(dt != null)
                lbCount.Text = dt.Rows.Count.ToString();
        }

        protected void gvFixture_PreRender(object sender, EventArgs e)
        {
            SearchModel.User modUser = new SearchModel.User(this.Page);
             gvFixture.Columns[0].Visible = (modUser.Power_sn(Convert.ToInt32(Power.治具管理)) == 0);
        }

        protected void gvFixture_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[11].Text == "1")
                {
                    e.Row.Cells[11].Text = "在庫";
                }
                if (e.Row.Cells[11].Text == "0")
                {
                    e.Row.Cells[11].Text = "已領出";
                }
                if (e.Row.Cells[11].Text == "2")
                {
                    e.Row.Cells[11].Text = "報廢";
                }
                if (e.Row.Cells[11].Text == "3")
                {
                    e.Row.Cells[11].Text = "轉出";
                }
            }
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFixture.PageIndex = e.NewPageIndex;
            LoadData();
        }

        
    }
}