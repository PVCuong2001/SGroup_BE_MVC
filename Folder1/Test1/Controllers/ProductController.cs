using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test1.Extention;
using Test1.Model;
using Test1.Service;
using Test1.ViewModel;

namespace Test1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;
        public ProductController (ProductService productService , IMapper mapper){
            _productService = productService;
            _mapper = mapper;
        }
        
        // [HttpGet]
        // [Route("/Search.html", Name = "SearchForm")]
        // public ActionResult Index(string keyWord){
        //     return View(_customerService.Get(keyWord));
        // }

        [HttpGet]
        public ActionResult Index()
        {
            var listVM = _productService.Get("", "");
            return View(listVM);
        }
        [HttpGet]
        [Route("/Product/AddOrEdit/{id?}")]
        public IActionResult AddOrEdit(string id ="")
        {
            if (id == "")
            {
                return View(new ProductVM());
            }
            else
            {
                Product product =  _productService.FindById(id);
                if (product == null) return NotFound();
                ProductVM productVm = _mapper.Map<ProductVM>(product);
                return View (productVm);
            }
        }
        
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(ProductVM productVm)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                _mapper.Map(productVm, product);
                Console.WriteLine("before update or create");
                if (productVm.Id == "")
                {
                    _productService.Create(product);
                }
                else
                {
                    _productService.Update(product);
                }
                Console.WriteLine("after update or create");
                return Json(new {isValid =true , html = RazorHelper.RenderRazorViewToString(this,"_ViewAll",_productService.Get("",""))});
            }
           return Json(new {isValid =false , html = RazorHelper.RenderRazorViewToString(this,"AddOrEdit",productVm)});
        }
        
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM customerVM)
        {
            Customer customer = new Customer();
            _mapper.Map(customerVM, customer);
            if (ModelState.IsValid)
            {
                _customerService.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerVM);
        }
        
        [HttpGet]
        [Route("/Customer/{alias}-c.{id}")]
        public IActionResult Detail(string id){
            Console.WriteLine("sadasdasdas");
            Console.WriteLine(id);
            Customer customer =  _customerService.FindById(id);
            CustomerVM customerVm = _mapper.Map<CustomerVM>(customer);
            return View (customerVm);
        }
        

         [HttpGet]
         [Route("/Customer/Edit/{id?}")]
         public IActionResult Edit(string id){
             Customer customer =  _customerService.FindById(id);
            CustomerVM customerVm = _mapper.Map<CustomerVM>(customer);
             return View (customerVm);
         }


        [HttpPost]  
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                _mapper.Map(customerVM, customer);
                _customerService.Update(customer);
                return Redirect("/Customer/Search");
            }
            return View(customerVM);
         
        }

        [HttpGet]
        public IActionResult Delete(string id){
            _customerService.Remove(id);
              return RedirectToAction(actionName: "Index", controllerName: "Customer");
        }
        */

        
    }
    }
