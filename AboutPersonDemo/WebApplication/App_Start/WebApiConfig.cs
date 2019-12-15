using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ////路由规则优先匹配第一条配置，以下配置不会被捕获
            //config.Routes.Add("DefaultApiOfParamName", new HttpRoute("api/{controller}/{username}", new HttpRouteValueDictionary(new { username = RouteParameter.Optional })));
        }
    }
}
