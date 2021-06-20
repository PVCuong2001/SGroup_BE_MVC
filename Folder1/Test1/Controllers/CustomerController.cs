using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Test1.Model;
using Test1.Service;
using Test1.Service.Service_Interface;
using Test1.ViewModel;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Test1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _customerService = customerService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        // [HttpGet]
        // [Route("/Search.html", Name = "SearchForm")]
        // public ActionResult Index(string keyWord){
        //     return View(_customerService.Get(keyWord));
        // }

        [HttpGet]
        [Route("/Customer/Search", Name = "SearchForm")]
        public async Task<ActionResult> Index(string searchName, string orderBy)
        {
            List<CustomerVM> listVM = new List<CustomerVM>();
            foreach (Customer customer in await _customerService.Get(searchName, orderBy))
            {
                CustomerVM customerVm = _mapper.Map<CustomerVM>(customer);
                listVM.Add(customerVm);
            }

            return View(listVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                List<Customer> list = await _customerService.Get(customerVM.Name, "");
                if (list.Count == 0)
                {
                    string imgUrl = UploadedFile(customerVM);
                    Customer customer = new Customer();
                    _mapper.Map(customerVM, customer);
                    customer.ImageUrl = imgUrl;
                    await _customerService.Create(customer);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Name", "This name has already been existed");
                }
            }

            return View(customerVM);
        }

        [HttpGet]
        [Route("/Customer/{alias}-c.{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            Customer customer = await _customerService.FindById(id);
            CustomerVM customerVm = _mapper.Map<CustomerVM>(customer);
            return View(customerVm);
        }


        [HttpGet]
        [Route("/Customer/Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            Customer customer = await _customerService.FindById(id);
            CustomerVM customerVm = _mapper.Map<CustomerVM>(customer);
            return View(customerVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                var list = await _customerService.Get(customerVM.Name, "");
                list.RemoveAll(x => x.Id == customerVM.Id);
                if (list.Count == 0)
                {
                    string imgUrl = UploadedFile(customerVM);
                    Customer customer = new Customer();
                    _mapper.Map(customerVM, customer);
                    customer.ImageUrl = imgUrl;
                    await _customerService.Update(customer);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Name", "This name has already been existed");
                }
            }

            return View(customerVM);
        }

        /*[HttpGet]
        public IActionResult Delete(string id){
            _customerService.Remove(id);
              return RedirectToAction(actionName: "Index", controllerName: "Customer");
        }*/

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] JsonElement data)
        {
            string id = JsonConvert.DeserializeObject<string>(data.GetRawText());

            await _customerService.RemoveById(id);
            return Ok(1);
        }

        private string UploadedFile(CustomerVM customerVM)
        {
            string uniqueFileName = null;

            if (customerVM.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + customerVM.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    customerVM.ProfileImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}