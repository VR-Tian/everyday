using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace WebApplication.App_Start
{
    /// <summary>
    /// 自定义身份验证模块（继承HttpModule，此做法不适宜于WEB API2，应采用自定义身份验证筛选器）
    /// </summary>
    public class MyHttpModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
        }

        private void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                //var encoding = Encoding.GetEncoding("iso-8859-1");
                //credentials = encoding.GetString(Convert.FromBase64String(credentials));

                //int separator = credentials.IndexOf(':');
                //string name = credentials.Substring(0, separator);
                //string password = credentials.Substring(separator + 1);

                //if (CheckPassword(name, password))
                //{
                //    var identity = new GenericIdentity(name);
                //    SetPrincipal(new GenericPrincipal(identity, null));
                //}
                //else
                //{
                //    // Invalid username or password.
                //    HttpContext.Current.Response.StatusCode = 401;
                //}
            }
            catch (FormatException)
            {
                // Credentials were not formatted correctly.
                HttpContext.Current.Response.StatusCode = 401;
            }
        }
    }
}