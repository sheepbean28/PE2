using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.Ashx
{
    /// <summary>
    ///ChangeLimitDate 的摘要描述
    /// </summary>
    public class ChangeLimitDate : IHttpHandler
    {

        BLL.Fixture bllFixture = new BLL.Fixture();
        Model.Fixture modFixture = new Model.Fixture();

        public void ProcessRequest(HttpContext context)
        {
            string Fixture_sn = context.Request.QueryString["Fixture_sn"];
            modFixture = bllFixture.GetModel(Convert.ToInt32(Fixture_sn));
            if (modFixture != null)
            {
                if (modFixture.Create_date != null)
                    modFixture.Create_date = Convert.ToDateTime(modFixture.Create_date).AddYears(3);
                else
                    modFixture.Create_date = Convert.ToDateTime(modFixture.Limit_date);

                modFixture.Limit_date = Convert.ToDateTime(modFixture.Limit_date).AddYears(3);
            }
            bllFixture.Update(modFixture);


            //將objResult物件序列化成JSON格式再回傳
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Fixture_sn));
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