using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebApplication.App_Start;

/// <summary>
/// 探究关于路由机制特性使用
/// </summary>
namespace WebApplication.Controllers
{
    public class TestRouteController : ApiController
    {
        public string GetResult(string username)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, username, DateTime.Now, DateTime.Now.AddMinutes(1), true, "{\"username\":1}",FormsAuthentication.FormsCookiePath);
            var loginObj = new { username, Ticket = FormsAuthentication.Encrypt(ticket) };
            var loginInfo = Newtonsoft.Json.JsonConvert.SerializeObject(loginObj);
            return loginInfo;
        }

        [RequestAuthorizeAttribute]
        [HttpPost]
        public string GetResult1()
        {
            return "success";
        }
    }
}
