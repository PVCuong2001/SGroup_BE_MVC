using System.Collections.Generic;
using AutoMapper;
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
                if (_userService.checkLogin(userVm.Gmail, userVm.Password))
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewData["Message"] = "Account is not existed";
                }
            }
            return View(userVm);
        }
    }
}