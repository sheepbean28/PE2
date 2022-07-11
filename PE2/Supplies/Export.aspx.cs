using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Supplies
{
    public partial class Export : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> LstColnums = new List<string>();
            foreach (ListItem oItem in cbLColnums.Items)
            {
                //判斷oItem是否有被選擇 
                if (oItem.Selected == true)
                {
                    LstColnums.Add(oItem.Value);
                }
            }
            if(cbLColnums.Items[0].Selected == true)
               LstColnums.Add("Supplies_sn");
            ExportData(LstColnums);
        }
        public void ExportData(List<string> LstColnums) 
        {
            SearchModel.Supplies model = new SearchModel.Supplies();
            DataTable dt = bllSupplies.GetSuppliesList(model.Model);
            if (model.Model.StockStatus == 1)
            {
                dt.DefaultView.RowFilter = " Supplies_Stock > Supplies_Warm ";

            }
            else if (model.Model.StockStatus == 2)
            {
                dt.DefaultView.RowFilter = "  Supplies_Stock <= Supplies_Warm and  Supplies_Stock > Supplies_Limit ";

            }
            else if (model.Model.StockStatus == 3)
            {
                dt.DefaultView.RowFilter = " Supplies_Stock <= Supplies_Limit ";

            }
            if (model.Model.Valid != -1)
            {
                dt.DefaultView.RowFilter = " Valid = " + model.Model.Valid;
            }
           // ExcelOutport.OutportToClient(ExcelOutport.RenderDataTableByOpenXML(dt.DefaultView.ToTable(), LstColnums), "耗材列表.xls");
        }
    }
}