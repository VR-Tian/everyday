using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace WebApplication.Controllers
{
    public class UserController : ApiController
    {
        public string Login(string username, string passsword)
        {
            //1与密钥加密生成的密码校验用户合法性(登录次数、密码)
            //2 对用户信息生成会话数据(生成token：不采用URL的ticket方式)
            FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, username, DateTime.Now, DateTime.Now.AddMinutes(1), true, "{\"username\":1}", FormsAuthentication.FormsCookiePath);
            var loginObj = new { username, Ticket = FormsAuthentication.Encrypt(token) };
            var loginInfo = Newtonsoft.Json.JsonConvert.SerializeObject(loginObj);
            return loginInfo;
        }
    }
}
