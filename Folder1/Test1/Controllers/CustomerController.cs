using System;
using Microsoft.AspNetCore.Mvc;
using Test1.Model;
using Test1.Service;

namespace Test1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomerController (CustomerService customerService){
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult Index(){
            return View(_customerService.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(string id){
           Customer customer =  _customerService.Get(id);
            return View (customer);
        }


        [HttpPost]  
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(string id){
            _customerService.Remove(id);
              return RedirectToAction(actionName: "Index", controllerName: "Customer");
        }
    }
}