using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Test1.Extention.Enum;
using Test1.Extention.StreamUpload;
using Test1.Model;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static readonly FormOptions _defaultFormOptions = new FormOptions();
        
        /// <summary>
        /// Cloudinary
        /// </summary>
        private readonly Cloudinary _cloudinary;
        public DirectUploadType DirectUploadType { get; set; }
        private readonly IMapper _mapper;
        public UserController(IUserService userService , IWebHostEnvironment webHostEnvironment ,Cloudinary cloudinary,IMapper mapper)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _cloudinary = cloudinary;
            _mapper = mapper;
        }
        // GET
        /*public IActionResult Index()
        {
            return View();
        }*/
            
        [HttpGet]
        public async Task<IActionResult> CreateCloudinary(DirectUploadType type)
        {
            ViewData["ImageCheck"] = false;
            if (type == DirectUploadType.Unsigned)
            {
                ViewData["Type"] = DirectUploadType.Unsigned;
                return View();
            }else   ViewData["Type"] = DirectUploadType.Signed;
            ViewData["Preset"] = $"sample_{_cloudinary.Api.SignParameters(new SortedDictionary<string, object> { { "api_key", _cloudinary.Api.Account.ApiKey } }).Substring(0, 10)}";
            await _cloudinary.CreateUploadPresetAsync(new UploadPresetParams
            {
                Name = (string)ViewData["Preset"],
                Unsigned = true,
                Folder = "Images"
            }).ConfigureAwait(false);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                _mapper.Map(userVM, user);
                user.AboutYourSelf = "none";
                if (userVM.Id == "" || userVM.Id ==null)
                {
                    await _userService.addUser(user);
                }
                else
                {
                    await _userService.updateUser(user);
                }
                return Json(new { success = true, responseText= "Your message successfuly sent!"});
            }

            return Json(new { success = false, responseText= "Your Data aren't valid"});

        }
        
      

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
                return BadRequest(ModelState);
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            var formAccumelator = new KeyValueAccumulator();
            Console.WriteLine("oke");
            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    /*if (!MultipartRequestHelper
                        .HasFileContentDisposition(contentDisposition))
                    {
                        ModelState.AddModelError("File",
                            $"The request couldn't be processed (Error 2).");
                        // Log error
                        return BadRequest(ModelState);
                    }
                    else*/
                    {
                        if (contentDisposition.DispositionType.Equals("form-data") &&
                            (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
                             !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
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
                        }
                        else
                        {
                            var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name).Value;
                            using (var streamReader = new StreamReader(section.Body,
                                encoding: Encoding.UTF8,
                                detectEncodingFromByteOrderMarks: true,
                                bufferSize: 1024,
                                leaveOpen: true))
                            {
                                var value = await streamReader.ReadToEndAsync();
                                if (string.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase))
                                {
                                    value = string.Empty;
                                }
                                formAccumelator.Append(key, value);
                            }
                        }
                    }
                }
                section = await reader.ReadNextSectionAsync();
            }

            var profile = new TestStream();
                var formValueProvidere = new FormValueProvider(
                    BindingSource.Form,
                    new FormCollection(formAccumelator.GetResults()),
                    CultureInfo.CurrentCulture
                );
                var bindindSuccessfully = await TryUpdateModelAsync(profile, "", formValueProvidere);
                if (ModelState.IsValid)
                {
                }
                return Content("Uploaded successfully");
        }
    }
}