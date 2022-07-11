using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//using DocumentFormat.OpenXml.Drawing.Charts;

namespace PE2.Supplies
{
    public partial class SuppliesEdit : System.Web.UI.Page
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();
        Model.Supplies modSupplies = new Model.Supplies();
        protected void Page_Load(object sender, EventArgs e)
        {
            hfSupplies_sn.Value = Request.QueryString["Mode"];
            if (!IsPostBack)
            {
                Settings();
                if (hfSupplies_sn.Value != "0" && hfSupplies_sn.Value != string.Empty)
                {
                    modSupplies = bllSupplies.GetModel(Convert.ToInt32(hfSupplies_sn.Value));
                    SetEidt(modSupplies);
                    tbSupplies_Stock.Enabled = true;
                    tbSupplies_Add.Enabled = false;
                    ddlPlace_code_sn.Enabled = true;
                   
                }
                else 
                {
                    tbSupplies_C_No.Text = bllSupplies.GetSupplies_no(ddlSupplies_Class.SelectedValue);
                    tbSupplies_Stock.Enabled = false;
                    tbSupplies_Add.Enabled = true;
                    ddlPlace_code_sn.Enabled = false;
                }   
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
        
            if (hfSupplies_sn.Value != "0")
            {
                Model.Supplies model = bllSupplies.GetModel(Convert.ToInt32(hfSupplies_sn.Value));
                GetEidt(model);
                Update(model);
            }
            else
            {
                Model.Supplies model = new Model.Supplies();
                GetEidt(model);
                Add(model,true);
                GetEidtEmpty(model, 24);
                Add(model,false);
                GetEidtEmpty(model, 27);
                Add(model,false);
                GetEidtEmpty(model, 28);
                Add(model,false);
            }
        }

        public void Settings() 
        {
            BLL.Code bllCode = new BLL.Code();
            ddlPlace_code_sn.Items.Clear();
            //第一段位置
            ddlPlace_code_sn.DataSource = bllCode.GetModelList(" Class_sn = 6");
            ddlPlace_code_sn.DataBind();
        }

        public Model.Supplies GetEidt(Model.Supplies model)
        {
            model.Supplies_Class = ddlSupplies_Class.SelectedValue;
            model.Supplies_C_No = tbSupplies_C_No.Text;
            model.Supplies_no = model.Supplies_Class + model.Supplies_C_No;
            model.Supplies_Name = tbSupplies_Name.Text;
            model.Supplies_Price =Convert.ToInt32(tbSupplies_Price.Text);
            model.Supplies_Stock =Convert.ToInt32(tbSupplies_Stock.Text);
            model.Supplies_Add = Convert.ToInt32(tbSupplies_Add.Text);
            model.Supplies_Warm = Convert.ToInt32(tbSupplies_Warm.Text);
            model.Supplies_Limit = Convert.ToInt32(tbSupplies_Limit.Text);
            model.Supplies_File = hfFilePath.Value;
            model.Place_code_sn = Convert.ToInt32(ddlPlace_code_sn.SelectedValue);
            model.Valid = cbValid.Checked == true ? 1 : 0;
            model.Note = tbNote.Text;
           
            return model;
        }
        public Model.Supplies GetEidtEmpty(Model.Supplies model, int ddlPlace_code_sn)
        {
            //model.Supplies_Class = ddlSupplies_Class.SelectedValue;
            //model.Supplies_C_No = tbSupplies_C_No.Text;
            //model.Supplies_no = model.Supplies_Class + model.Supplies_C_No;
            //model.Supplies_Name = tbSupplies_Name.Text;
            //model.Supplies_Price = Convert.ToInt32(tbSupplies_Price.Text);
            model.Supplies_Stock = Convert.ToInt32(0);
            model.Supplies_Add = Convert.ToInt32(0);
            //model.Supplies_Warm = Convert.ToInt32(tbSupplies_Warm.Text);
            //model.Supplies_Limit = Convert.ToInt32(tbSupplies_Limit.Text);
            //model.Supplies_File = hfFilePath.Value;
            model.Place_code_sn = Convert.ToInt32(ddlPlace_code_sn);
            model.Valid = cbValid.Checked == true ? 1 : 0;
            //model.Note = tbNote.Text;

            return model;
        }

        public void SetEidt(Model.Supplies model)
        {

            ddlSupplies_Class.SelectedValue = model.Supplies_Class;
            hfSupplies_Class.Value = model.Supplies_Class;
            tbSupplies_C_No.Text = model.Supplies_C_No;
            hfSupplies_no.Value = model.Supplies_C_No;
            tbSupplies_Name.Text = model.Supplies_Name;
            tbSupplies_Price.Text = model.Supplies_Price.ToString();
            tbSupplies_Stock.Text = model.Supplies_Stock.ToString();
            tbSupplies_Add.Text = model.Supplies_Add.ToString();
            tbSupplies_Warm.Text = model.Supplies_Warm.ToString();
            tbSupplies_Limit.Text = model.Supplies_Limit.ToString();
            hfFilePath.Value = model.Supplies_File.ToString();
            ddlPlace_code_sn.SelectedValue = model.Place_code_sn.ToString();
            cbValid.Checked = model.Valid == 1 ? true : false;
            imgUpload.ImageUrl = model.Supplies_File.ToString();
            tbNote.Text = model.Note;
        }

        public void ClearEdit()
        {

            ddlSupplies_Class.SelectedValue = "01";
            tbSupplies_C_No.Text = bllSupplies.GetSupplies_no(ddlSupplies_Class.SelectedValue);

            tbSupplies_Name.Text = string.Empty;
            tbSupplies_Price.Text = "0";
            tbSupplies_Stock.Text = "0";
            tbSupplies_Add.Text = "0";
            tbSupplies_Warm.Text = "3";
            tbSupplies_Limit.Text = "2";
            cbValid.Checked = true;
            imgUpload.ImageUrl = "~/Images/Supplies/image_4.png";
            tbNote.Text = string.Empty;
        }

        public void Add(Model.Supplies model,bool isCheck)
        {
            model.Supplies_Out = 0;
            model.Supplies_R_IN = 0;
            model.Supplies_R_OUT = 0;
            model.Supplies_Stock = model.Supplies_Add;
            model.User_sn = 0;
            model.Input_date = DateTime.Now;
            model.Supplies_File = hfFilePath.Value;
            model.Valid = cbValid.Checked == true ? 1:0;
            if (isCheck)
            {
                if (bllSupplies.GetSuppliesbySupplies_no(model) != null)
                {
                    ServerJavascrpit.Alert.Warn(this.Page, model.Supplies_no + "已被使用");
                }
                else
                {
                    bllSupplies.Add(model);
                    ServerJavascrpit.Alert.Success(this.Page, "耗材新增完成");
                    ClearEdit();
                }
            }
            else 
            {
                bllSupplies.Add(model);
            }

        }

        public void Update(Model.Supplies model)
        {
            if (bllSupplies.GetSuppliesbySupplies_no(model) != null)
            {
                //if (hfSupplies_sn.Value == bllSupplies.GetSuppliesbySupplies_no(model).Supplies_sn.ToString())
                //{
                  
                //}
                //else
                //{
                //    ServerJavascrpit.Alert.Warn(this.Page, model.Supplies_no + "已被使用");
                //}
                bllSupplies.Update(model);
                ServerJavascrpit.Alert.Success(this.Page, "耗材修改完成");
                
            }
            else
            {
                bllSupplies.Update(model);
                ServerJavascrpit.Alert.Success(this.Page, "耗材修改完成");
            }

          
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string LocalFileName = Server.MapPath(@"~\Images\Supplies\") + fileUpload.FileName;
                string FilePath = @"~\Images\Supplies\" + fileUpload.FileName;
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                fileUpload.SaveAs(LocalFileName);
                hfFilePath.Value = FilePath;
                imgUpload.ImageUrl = FilePath;
            }
            
        }

        protected void ddlSupplies_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hfSupplies_sn.Value != "0" && hfSupplies_sn.Value != string.Empty)
            {
                if (ddlSupplies_Class.SelectedValue == hfSupplies_Class.Value)
                {
                    tbSupplies_C_No.Text = hfSupplies_no.Value; 
                }
                else 
                {
                    tbSupplies_C_No.Text = bllSupplies.GetSupplies_no(ddlSupplies_Class.SelectedValue); 
                }
            }
            else 
            {
                tbSupplies_C_No.Text = bllSupplies.GetSupplies_no(ddlSupplies_Class.SelectedValue); 
            }
           
        }
    }
}