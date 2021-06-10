using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Test1.Service;

namespace Test1.Extention.MiddleWare
{
    public class RemoveCookieIfNotNeeded
    {
        private readonly RequestDelegate _next;
        public RemoveCookieIfNotNeeded(RequestDelegate next)
        {
            _next = next;
     
        }
        public async Task Invoke(HttpContext httpContext , SessionService _sessionService)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                bool redirect=false;
                var cookie = httpContext.Request.Cookies["UserLoginCookie"];
                Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("cookie", cookie);
                properties.Add("status", "Active");
                var list = _sessionService.Get(properties);
                if (list.Count != 0)
                {
                    if (list[0].LastAccessTime.Add(ConstParameter.requiredActiveTime) < DateTime.UtcNow)
                    {
                        list[0].ActiveFlag = false;
                        redirect = true;
                    }
                    else
                    {
                        list[0].LastAccessTime = DateTime.UtcNow;
                    }
                    _sessionService.Update(list[0]);
                }
                else
                {
                    redirect = true;
                }
                if (redirect)
                {
                    await Task.Run(
                        async () =>
                        {
                            httpContext.Response.Redirect("/Login/Logout");
                            //   await _next (httpContext);
                        }
                    );
                }
                else
                {
                    await _next(httpContext);
                }
               
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
    }
