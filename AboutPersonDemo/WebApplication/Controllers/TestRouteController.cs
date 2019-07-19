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
        #region RESETful API
        //RESET 资源状态扭转，通过不同请求方式的动作来解释资源获取途径，而不是通过函数的命名来区分资源（1）。
        //即是报文的method类型约定的方式进行操作资源，则每个请求类型最多只有两个接口资源（2）。

        //(1) 根据路由规则，若出现不同函数签名的子项，只匹配第一条(配置代码的顺序)
        //(2) 根据路由规则，在同一个请求类型，要么是匹配无参数的接口，要么匹配是带参数的接口

        //疑惑：要是参数不是基本类型或多个入参，是否违背了RESETful的遵循规则；
        
        #endregion

        public string Get()
        {
            return DateTime.Now.ToString();
        }

        public string Get(string username)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, username, DateTime.Now, DateTime.Now.AddMinutes(1), true, "{\"username\":1}", FormsAuthentication.FormsCookiePath);
            var loginObj = new { username, Ticket = FormsAuthentication.Encrypt(ticket) };
            var loginInfo = Newtonsoft.Json.JsonConvert.SerializeObject(loginObj);
            return loginInfo;
        }

        public string Get(int id)
        {
            return "success";
        }
    }
}
