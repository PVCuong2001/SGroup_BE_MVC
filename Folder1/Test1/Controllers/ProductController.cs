using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test1.Extention;
using Test1.Model;
using Test1.Service;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController (IProductService productService , IMapper mapper){
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
                if (productVm.Id == "" || productVm.Id ==null)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _productService.RemoveById(id);
            return Json(new
                {html = RazorHelper.RenderRazorViewToString(this, "_ViewAll", _productService.Get("", ""))});
        }
    }
    }
