using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PE2.Assets
{
    public partial class AssetsGroupChange : System.Web.UI.Page
    {
        BLL.Assets bllAssets = new BLL.Assets();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
                model.ClearList();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
            List<Model.Assets> lstAssets = bllAssets.GetModelList(" Assts_no = " + txtAsset_no_Detail.Text);
            if (lstAssets.Count > 0)
            {
                if (!model.isFind(lstAssets[0]))
                {
                    model.Add(lstAssets[0]);
                }
                else
                {
                    ServerJavascrpit.Alert.Warn(this.Page, "已在綁定項目");
                }
            }
            else
            {
                ServerJavascrpit.Alert.Warn(this.Page, "無此資產項目");
            }
            ServerJavascrpit.Textbox.Focus(this.Page, "txtAsset_no_Detail");
            LoadData();
        }
        public void LoadData() 
        {
            SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
            gvAssets.DataSource = model.List;
            gvAssets.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
            if (model.List.Count > 0)
            {
                for (int i = 0; i < model.List.Count; i++)
                {
                    Model.Assets modAssets = bllAssets.GetModel(model.List[i].Assets_sn);
                    modAssets.Note = ((gvAssets.Rows[i].FindControl("tbNote")) as TextBox).Text;
                    modAssets.SysNote = ((gvAssets.Rows[i].FindControl("tbSysNote")) as TextBox).Text;
                    modAssets.Place_Assets_sn = txtAssets_no.Text;
                    bllAssets.Update(modAssets);
                    //小地方也綁定
                    List<Model.Assets> lstAssetsDetail = bllAssets.GetModelList(" Place_Assets_Detail_sn = '" + modAssets.Assts_no + "'");
                    if (lstAssetsDetail.Count > 0)
                    {
                        foreach (Model.Assets assDetail in lstAssetsDetail)
                        {
                            assDetail.Place_Assets_sn = modAssets.Place_Assets_sn;
                            bllAssets.Update(assDetail);
                        }
                    }
                }
                ServerJavascrpit.Alert.Success(this.Page, "群組綁定成功");
            }
            else 
            {
                ServerJavascrpit.Alert.Warn(this.Page, "未有任何綁定資料");
            }
            
        }

        protected void txtAssets_no_TextChanged(object sender, EventArgs e)
        {

            gvTable.DataSource = bllAssets.GetModelList(" Assts_no = " + txtAssets_no.Text);
            gvTable.DataBind();

            
         }

        protected void gvAssets_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvAssets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowUpdate")
            {

            }
            if (e.CommandName.ToString() == "RowDelete")
            {
                SearchModel.AssetsGroup model = new SearchModel.AssetsGroup();
                model.Delete(e.CommandArgument.ToString());
                LoadData();
            }
        }

        
    }
}