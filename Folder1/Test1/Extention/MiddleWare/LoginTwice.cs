using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Test1.Model;

namespace Test1.Extention.MiddleWare
{
    public class LoginTwice
    {
        private readonly RequestDelegate _next;
        public LoginTwice(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext httpContext )
        {
            if (httpContext.Request.Path == "/Login/CheckLogin" && httpContext.Request.Cookies["UserLoginCookie"] !=null)
            {
                await Task.Run(
                    async () =>
                    {
                         httpContext.Response.Redirect("/Home/Index");
                     //   await _next (httpContext);
                    }
                );

            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}