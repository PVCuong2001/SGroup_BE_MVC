using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Test1.Service;
using Test1.Service.Service_Interface;

namespace Test1.Extention.MiddleWare
{
    public class RemoveCookieIfNotNeeded
    {
        private readonly RequestDelegate _next;
        public RemoveCookieIfNotNeeded(RequestDelegate next)
        {
            _next = next;
     
        }
        public async Task Invoke(HttpContext httpContext , ISessionService _sessionService)
        {
            if (httpContext.Request.Path != "/Login/Logout" && httpContext.Request.Path != "/Login/CheckLogin"  && httpContext.User.Identity.IsAuthenticated)
            {
                bool redirect=false;
                var cookie = httpContext.Request.Cookies["UserLoginCookie"];
                Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("cookie", cookie);
                properties.Add("status", "Active");
                var list =await _sessionService.Get(properties);
                if (list.Count != 0)
                {
                    if (list[0].LastAccessTime.Add(ConstParameter.requiredActiveTime) < DateTime.UtcNow)
                    {
                        redirect = true;
                    }
                    else
                    {
                        list[0].LastAccessTime = DateTime.UtcNow;
                        await _sessionService.Update(list[0]);
                    }
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
