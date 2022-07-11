using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.Ashx
{
    /// <summary>
    ///SuppliesAdd 的摘要描述
    /// </summary>
    public class SuppliesAdd : IHttpHandler
    {
        BLL.Supplies bllSupplies = new BLL.Supplies();
        BLL.SuppliesLog bllSuppliesLog = new BLL.SuppliesLog();
        Model.Supplies modSupplies = new Model.Supplies();
        Model.SuppliesLog modSuppliesLog = new Model.SuppliesLog();
        public void ProcessRequest(HttpContext context)
        {
            string Supplies_sn = context.Request.QueryString["Supplies_sn"];
            string Note = context.Request.QueryString["Note"];
            if (Note != string.Empty)
            {
                modSupplies = bllSupplies.GetModel(Convert.ToInt32(Supplies_sn));
                if (modSupplies != null)
                {
                    modSupplies.Supplies_Stock += Convert.ToInt32(Note);
                    modSupplies.Supplies_Add += Convert.ToInt32(Note);
                    bllSupplies.Update(modSupplies);
                    modSuppliesLog.Supplies_sn = Convert.ToInt32(Supplies_sn);
                    modSuppliesLog.Quantity = Convert.ToInt32(Note);
                    modSuppliesLog.Type = 0;
                    modSuppliesLog.User_sn = 0;
                    bllSuppliesLog.Add(modSuppliesLog);
                }
            }
            
 

            //將objResult物件序列化成JSON格式再回傳
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Supplies_sn));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}