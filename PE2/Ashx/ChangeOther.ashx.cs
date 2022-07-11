using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.Ashx
{
    /// <summary>
    ///ChangeOther 的摘要描述
    /// </summary>
    public class ChangeOther : IHttpHandler
    {
        BLL.Fixture bllFixture = new BLL.Fixture();
        Model.Fixture modFixture = new Model.Fixture();

        public void ProcessRequest(HttpContext context)
        {
            string Fixture_sn = context.Request.QueryString["Fixture_sn"];
            string Note = context.Request.QueryString["Note"];
            modFixture = bllFixture.GetModel(Convert.ToInt32(Fixture_sn));
            if (modFixture != null)
            {
                modFixture.Status = Convert.ToInt32(Status.轉出);
                modFixture.Note = Note;
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