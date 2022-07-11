using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2.Ashx
{
    /// <summary>
    ///GetAjax 的摘要描述
    /// </summary>
    public class GetAjax : IHttpHandler
    {
        BLL.OutFixture bllOutFixture = new BLL.OutFixture();
        BLL.InFixture bllInFixture = new BLL.InFixture();
        BLL.Fixture bllFixture = new BLL.Fixture();

        Model.OutFixture modOutFixture = new Model.OutFixture();
        Model.InFixture modInFixture = new Model.InFixture();
        Model.Fixture modFixture = new Model.Fixture();

        public void ProcessRequest(HttpContext context)
        {
            string Out = context.Request.QueryString["Out"];
            modOutFixture = bllOutFixture.GetModel(Convert.ToInt32(Out));

            //歸還
            modInFixture.Fixture_sn = modOutFixture.Fixture_sn;
            modInFixture.User_sn = modOutFixture.User_sn;
            modInFixture.Out_sn = modOutFixture.Out_sn;
            // modInFixture.Note = modOutFixture.User_sn;
            modInFixture.Create_date = DateTime.Now;
            modInFixture.In_date = DateTime.Now;
            modInFixture.Look = modOutFixture.User_sn;
            modInFixture.Clean = modOutFixture.User_sn;
            modInFixture.Valid = 1;
            modInFixture.Place_sn = modOutFixture.Place_sn;

            int In_sn = bllInFixture.Add(modInFixture);
            //續借
            modOutFixture.Out_sn = 0;
            modOutFixture.Out_date = DateTime.Now;
            int Out_sn = bllOutFixture.Add(modOutFixture);


            modFixture = bllFixture.GetModel(modOutFixture.Fixture_sn);
            modFixture.LastOut_sn = Out_sn;
            modFixture.LastOut_date = DateTime.Now;
            modFixture.LastIn_sn = In_sn;
            modFixture.LastIn_date = DateTime.Now;

            bllFixture.Update(modFixture);
            //將objResult物件序列化成JSON格式再回傳
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Out));
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