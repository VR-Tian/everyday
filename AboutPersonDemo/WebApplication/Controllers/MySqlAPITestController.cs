using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class MySqlAPITestController : ApiController
    {
        public string Test(string name)
        {
            var connectionString=ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            return MySqlHelper.ExecuteNonQuery(connectionString, "insert into userinfo values(0," + name + ")").ToString();
        }
    }
}
