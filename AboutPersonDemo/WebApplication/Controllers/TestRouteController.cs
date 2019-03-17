using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

/// <summary>
/// 探究关于路由机制特性使用
/// </summary>
namespace WebApplication.Controllers
{
    public class TestRouteController : ApiController
    {
        public string GetResult()
        {
            return DateTime.Now.ToString();
        }

        public string GetResult1()
        {
            return DateTime.Now.ToString();
        }
    }
}
