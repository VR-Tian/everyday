using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 权限控制模块
    /// </summary>
    public class AccountController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SignIn(LoginDto model)
        {
            //1验证身份
            //2发放票据

            //过程：
            //采用何种验证方式
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, model.UserName, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", model.UserName, model.Password),
                            FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            var oUser = new LoginDto {  UserName = model.UserName, Password = model.Password, Ticket = FormsAuthentication.Encrypt(ticket) };
            //将身份信息保存在session中，验证当前请求是否是有效请求
            //HttpContext.Current.Session[strUser] = oUser;
            var responseMsg = this.Request.CreateResponse(HttpStatusCode.OK);
            responseMsg.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(oUser));
            return responseMsg;
        }
    }
}
