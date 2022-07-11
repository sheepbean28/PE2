using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace PE2.Supplies
{
    public partial class GetSuppliesList : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Settings();
                SearchModel.Supplies model = new SearchModel.Supplies();
                model.ClearList();
            }
                //model.ClearList();
            //LoadData(false);
        }

        public void LoadData() 
        {
            SearchModel.Supplies model = new SearchModel.Supplies();
            //DataTable dt = bllSupplies.GetSuppliesList(model.Model);
            gvList.DataSource = model.List;
            gvList.DataBind();
            if (model.List.Count > 0)
                lbCount.Text = model.List.Count.ToString();
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbWarm = (Label)e.Row.FindControl("lbWarm");
                Label lbLimit = (Label)e.Row.FindControl("lbLimit");
                Label lbStock = (Label)e.Row.FindControl("lbStock");
                Label lbResult = (Label)e.Row.FindControl("lbResult");
                lbResult.ForeColor = Color.Green;
                //lbResult
                if (Convert.ToInt32(lbStock.Text) < Convert.ToInt32(lbLimit.Text))
                {
                    lbResult.Text = "庫存不足";
                    lbResult.ForeColor = Color.Red;
                }
                else if (Convert.ToInt32(lbStock.Text) < Convert.ToInt32(lbWarm.Text))
                {
                    lbResult.Text = "庫存即將不足";
                    lbResult.ForeColor = Color.YellowGreen;
                }
            }
        }

        public Model.Supplies GetSupplies() 
        {
            Model.Supplies model = new Model.Supplies();

            List<Model.Supplies> Lst = bllSupplies.GetModelList(" Supplies_no = '" + txtSupplies_no.Text + "' and Place_code_sn = " + ddlPlace_sn.SelectedValue);
            if (Lst.Count > 0)
            {
                model = Lst[0];
                model.GetQuantity = Convert.ToInt32(txtStockStart.Text);
                model.GetNote = txtNote.Text;
                model.GetStatus = Convert.ToInt32(ddlStatus.SelectedValue);

            }
            else 
            {
                     ServerJavascrpit.Alert.Warn(this.Page, "查無此耗材");
        
            }
            return model;
        }

        public void ShowSupplies() 
        {
            Model.Supplies model = GetSupplies();
            SearchModel.Supplies modList = new SearchModel.Supplies();

            lbSupplies_Name.Text = model.Supplies_Name;
            //lbStock.Text = (model.Supplies_Stock - modList.List.FindAll(x =>x.Supplies_no == model.Supplies_no).Sum(x => x.GetQuantity)).ToString();
            lbStock.Text = model.Supplies_Stock.ToString();
            ddlSupplies_Class.SelectedValue = model.Supplies_Class;
        }

        public void Settings()
        {
            BLL.Code bllCode = new BLL.Code();
            ddlPlace_sn.Items.Clear();
            //第一段位置
            ddlPlace_sn.DataSource = bllCode.GetModelList(" Class_sn = 6");
            ddlPlace_sn.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
          
        }

        protected void txtSupplies_no_TextChanged(object sender, EventArgs e)
        {
            ShowSupplies();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowSupplies();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtStockStart.Text) > 0)
            {
                SearchModel.Supplies model = new SearchModel.Supplies();
                BLL.SuppliesLog bllSuppliesLog = new BLL.SuppliesLog();

                if (Convert.ToInt32(txtStockStart.Text) <= Convert.ToInt32(lbStock.Text))
                {

                    model.Add(GetSupplies());
                    LoadData();
                }
                else
                {
                    ServerJavascrpit.Alert.Warn(this.Page, "耗材庫存數量不足");
                }
                ShowSupplies();

                //領用耗材
                Model.SuppliesLog modelDetail = new Model.SuppliesLog();
                SearchModel.User modUser = new SearchModel.User(this.Page);
                modelDetail.Note = GetSupplies().GetNote;
                modelDetail.Quantity = GetSupplies().GetQuantity;
                modelDetail.Type = GetSupplies().GetStatus;
                modelDetail.Supplies_sn = GetSupplies().Supplies_sn;
                modelDetail.User_sn = modUser.Model.User_sn;
                modelDetail.StockBefore = Convert.ToInt32(lbStock.Text);
                bllSuppliesLog.Add(modelDetail);


                Model.Supplies modSupplies = new Model.Supplies();
                modSupplies = GetSupplies();
                if (modSupplies.GetStatus == 1)
                {
                    //"耗材領用";
                    modSupplies.Supplies_Out += modSupplies.GetQuantity;
                    modSupplies.Supplies_Stock -= modSupplies.GetQuantity;
                }
                if (GetSupplies().GetStatus == 2)
                {
                    // "耗材退庫";
                    modSupplies.Supplies_In += modSupplies.GetQuantity;
                    modSupplies.Supplies_Stock += modSupplies.GetQuantity;
                }
                if (GetSupplies().GetStatus == 3)
                {
                    // "外單位借出";
                    modSupplies.Supplies_R_OUT += modSupplies.GetQuantity;
                    modSupplies.Supplies_Stock -= modSupplies.GetQuantity;
                }
                if (GetSupplies().GetStatus == 4)
                {
                    // "外單位歸還";
                    modSupplies.Supplies_R_IN += modSupplies.GetQuantity;
                    modSupplies.Supplies_Stock += modSupplies.GetQuantity;
                }
                bllSupplies.Update(modSupplies);

                // LoadData();
                ServerJavascrpit.Alert.Success(this.Page, "耗材領取成功");
            }
            else
            {
                ServerJavascrpit.Alert.Warn(this.Page, "請輸入正確的庫存數量");
            }

            
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowDelete")
            {
                SearchModel.Supplies model = new SearchModel.Supplies();
                model.Delete(e.CommandArgument.ToString());
                LoadData();
                ShowSupplies();
            }
            if (e.CommandName == "RowUpdate")
            {
                SearchModel.Supplies model = new SearchModel.Supplies();
                txtSupplies_no.Text = e.CommandArgument.ToString();
                txtStockStart.Text = model.List.Find(x => x.Supplies_no == txtSupplies_no.Text).GetQuantity.ToString();
                txtNote.Text = model.List.Find(x => x.Supplies_no == txtSupplies_no.Text).GetNote;
                LoadData();
                ShowSupplies();
            }
        }

        protected void ddlPlace_sn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSupplies();
        }
    }
}