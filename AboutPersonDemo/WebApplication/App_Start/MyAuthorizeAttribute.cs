using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace WebApplication.App_Start
{
    /// <summary>
    /// 基于框架的当前用户和用户的角色的验证授权
    /// </summary>
    public class MyAuthorizeAttribute:AuthorizeAttribute
    {
        private static string UserName = "admin";
        private static string Password = "admin";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;
                var ticket = FormsAuthentication.Decrypt(encryptTicket);
                if (ticket.Expired)
                {
                    //如何返回自定义报文信息
                }
                if (ValidateTicket(ticket.UserData))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }

        private bool ValidateTicket(string userid)
        {
           if(userid.Contains(UserName))
            {
                return true;
            }
            return false;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}