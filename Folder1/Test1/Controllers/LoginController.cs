using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1.Extention;
using Test1.Model;
using Test1.Service;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public LoginController(IUserService userService, IMapper imapper , ISessionService sessionService)
        {
            _userService = userService;
            _mapper = _mapper;
            _sessionService = sessionService;
        }
        
        private async Task<string> CreateCookie(User user)
        {
            var userClaims = new List<Claim>()  
            {  
                new Claim(ClaimTypes.Name, user.Name),  
                new Claim(ClaimTypes.Email, user.Gmail),
                new Claim(ClaimTypes.Thumbprint , user.Id),
                new Claim(ClaimTypes.Uri,user.ImageUrl)
            };  
  
            //     var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");  
  
            var grandmaIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);  
            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
            /*
            var authenProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddSeconds(5)
            };
            */
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,userPrincipal);
            var listCookie = HttpContext.Response.GetTypedHeaders().SetCookie;
            var result = listCookie.Last(x => x.Name == "UserLoginCookie").Value.ToString();
            return result;
        }
        
        [HttpGet]
        public IActionResult CheckLogin()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> CheckLogin(LoginVM loginVm)
        {
            if (ModelState.IsValid)
            {
                Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("Gmail",loginVm.Gmail);
                properties.Add("Password", loginVm.Password);
                var query =await _userService.findByProperty(properties);
                var list = query;
                if (list != null && list.Count!=0)
                {
                    Dictionary<string, string> propertiesSession = new Dictionary<string, string>();
                    propertiesSession.Add("idUser",list[0].Id);
                    propertiesSession.Add("status","Active");
                    var query1 =await _sessionService.Get(propertiesSession);
                    var listSession = query1;
                    if (listSession.Count != 0)
                    {
                        if ( listSession[0].ExpiredTime>DateTime.UtcNow && listSession[0].LastAccessTime.Add(ConstParameter.requiredActiveTime) > DateTime.UtcNow )
                        {
                            ViewData["Message"] = "Are you kidding me \\n This account has already logined";
                            return View(loginVm);
                        }
                        else
                        {
                            listSession[0].ActiveFlag = false;
                             _sessionService.Update(listSession[0]).Wait();
                        }
                    }
                    var cookie = CreateCookie(list[0]);
                        Session session = new Session()
                        {
                            UserId = list[0].Id,
                            LoginTime = DateTime.UtcNow,
                            ExpiredTime =DateTime.UtcNow.Add(ConstParameter.duration),
                            LastAccessTime = DateTime.UtcNow,
                            ActiveFlag = true
                        };
                        cookie.Wait();
                        session.Cookie = cookie.Result;
                        _sessionService.Create(session).Wait();
                        return Redirect("/Home/Index");
                }
                else
                {
                    ViewData["Message"] = "Account is not existed \\n Poor You";
                }
            }
            return View(loginVm);
        }

        /*[HttpGet]
        public IActionResult JustTest(string gmail, string password)
        {
            string check = "";
            if (gmail == "" || password == "") check = "F*ck you !!! Fill in the form NOW";
            Console.WriteLine(gmail +" "+password);
            Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("Gmail",gmail);
                properties.Add("Password", password);
                List<User>list = _userService.findByProperty(properties);
                if (list.Count==0)
                {
                    check = "Account not existed \\n Poor you!!!";
                }
                else
                {
                    if (list[0].ActiveFlag == true)
                    {
                        check = "Are you kidding me !!! This account has already logined";
                    }
                    else
                    {
                    var userClaims = new List<Claim>()  
                    {  
                        new Claim(ClaimTypes.Name, list[0].Name),  
                        new Claim(ClaimTypes.Email, list[0].Gmail),
                        new Claim(ClaimTypes.Thumbprint , list[0].Id),
                        new Claim(ClaimTypes.Uri,list[0].ImageUrl)
                    };  
  
               //     var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");  
  
                    var grandmaIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);  
                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    /*
                    var authenProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddSeconds(5)
                    };
                    #1#
                    var temp =HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,userPrincipal);
                    list[0].ActiveFlag = true;
                    _userService.updateUser(list[0]);
                    }
                }
                return Json(new
                {
                    check = check 
                });
        }*/

        /*[HttpGet]
        public IActionResult Logout()
        {
         //   Response.Cookies.Delete("UserLoginCookie"
         var cookieValue = HttpContext.Request.Cookies["UserLoginCookie"];
         ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
         string idUser = principal.FindFirst(ClaimTypes.Thumbprint).Value;
         var user = _userService.findById(idUser);
         user.ActiveFlag = false;
         _userService.updateUser(user);
         HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
         return Redirect("/Home/Index");
        }*/
        
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var cookieValue = HttpContext.Request.Cookies["UserLoginCookie"];
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Dictionary<string, string> propertiesSession = new Dictionary<string, string>();
            propertiesSession.Add("cookie",cookieValue);
            List<Session> listSession =await _sessionService.Get(propertiesSession);
            if (listSession.Count != 0)
            {
                listSession[0].ActiveFlag = false;
                _sessionService.Update(listSession[0]);
            }
   
            /*return Ok(1);*/
            return Redirect("/Home/Index");
        }

       
    }
}