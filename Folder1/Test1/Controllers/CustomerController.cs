using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using MongoDB.Bson.IO;
using Test1.Extention;
using Test1.Extention.StreamUpload;
using Test1.Model;
using Test1.Service;
using Test1.Service.Service_Interface;
using Test1.ViewModel;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Test1.Controllers
{
    /*[Authorize]*/
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private static readonly FormOptions _defaultFormOptions = new FormOptions();
        public CustomerController(ICustomerService customerService, IMapper mapper,
            IWebHostEnvironment webHostEnvironment )
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
        [RequestSizeLimit(6000000000)]
        [RequestFormLimits(MultipartBodyLengthLimit = 6000000000)]
        public async Task<IActionResult> Create(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                List<Customer> list = await _customerService.Get(customerVM.Name, "");
                if (list.Count == 0)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    List<string> listImgUrl = await IO_Management.UploadedFile(customerVM, folderPath);
                    if (listImgUrl == null)
                    {
                        ModelState.AddModelError("ProfileImage", "Fail to save image ,please save again");
                        return View(customerVM);
                    }
                    Customer customer = new Customer();
                    _mapper.Map(customerVM, customer);
                    foreach (var value in listImgUrl)
                    {
                        customer.ListImage.Add(value);
                    }

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
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string imgUrl = "";
                    IO_Management.UploadedFile(customerVM, folderPath);
                    if (imgUrl == "fail")
                    {
                        ModelState.AddModelError("ProfileImage", "Fail to save image ,please save again");
                        return View(customerVM);
                    }

                    Customer customer = new Customer();
                    _mapper.Map(customerVM, customer);
                    /*customer.ListImage = imgUrl;*/
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
            var customer = await _customerService.FindById(id);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            List<string> listFullPath = new List<string>();
            foreach (var value in customer.ListImage)
            {
                listFullPath.Add(Path.Combine(uploadsFolder, value));
            }

            await IO_Management.deleteFile(listFullPath);
            await _customerService.RemoveById(id);
            return Ok(1);
        }

        /*[HttpGet]
        public IActionResult TestUpload()
        {
            return View();
        }*/

        [HttpPost]
        [DisableFormValueModelBinding]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(6000000000)]
        [RequestFormLimits(MultipartBodyLengthLimit = 6000000000)]
        public async Task<IActionResult> UploadPhysical()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed (Error 1).");
                // Log error

                return BadRequest(ModelState);
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            Console.WriteLine("oke");
            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (!MultipartRequestHelper
                        .HasFileContentDisposition(contentDisposition))
                    {
                        ModelState.AddModelError("File",
                            $"The request couldn't be processed (Error 2).");
                        // Log error
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                            contentDisposition.FileName.Value);
                        var fileName = Path.GetRandomFileName();
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        var saveToPath = Path.Combine(uploadsFolder, fileName);
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        using (var targetStream = System.IO.File.Create(
                            saveToPath))
                        {
                            await section.Body.CopyToAsync(targetStream);
                        }
                        
                        return Ok();
                    }
                }

                // Drain any remaining section body that hasn't been consumed and
                // read the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            return BadRequest("No files data in the request.");
        }
    }
}