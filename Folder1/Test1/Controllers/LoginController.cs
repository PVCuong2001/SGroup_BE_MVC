using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Test1.Model;
using Test1.Service;
using Test1.ViewModel;

namespace Test1.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public LoginController(UserService userService, IMapper imapper)
        {
            _userService = userService;
            _mapper = _mapper;
        }
        
        // GET
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
        
        [HttpGet]
        public IActionResult CheckLogin()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckLogin(UserVM userVm)
        {
            
            if (ModelState.IsValid)
            {
                Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("Gmail",userVm.Gmail);
                properties.Add("Password", userVm.Password);
                List<User>list = _userService.findByProperty(properties);
                if (list != null && list.Count!=0)
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
                    */
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,userPrincipal); 
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewData["Message"] = "Account is not existed \\n Poor You";
                }
            }
            return View(userVm);
        }

        [HttpGet]
        public IActionResult Logout()
        {
         //   Response.Cookies.Delete("UserLoginCookie");
         HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home/Index");
        }
    }
}