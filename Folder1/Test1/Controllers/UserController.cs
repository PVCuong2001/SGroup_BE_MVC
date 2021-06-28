using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        public const string Tags = "direct_PhotoAlbum";
         private const string FolderName = "preset_folder";
        public DirectUploadType DirectUploadType { get; set; }
        public string Preset { get; set; }
        public UserController(IUserService userService , IWebHostEnvironment webHostEnvironment ,Cloudinary cloudinary)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _cloudinary = cloudinary;
        }
        // GET
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public async Task<IActionResult> CreateCloudinary(DirectUploadType type)
        {
            /*DirectUploadType = type;

            if (DirectUploadType == DirectUploadType.Signed) return View();*/
            if (type == DirectUploadType.Signed)
            {
                ViewData["Type"] = DirectUploadType.Signed;
                return View();
            }else   ViewData["Type"] = DirectUploadType.Unsigned;

           // Preset = $"sample_{_cloudinary.Api.SignParameters(new SortedDictionary<string, object> { { "api_key", _cloudinary.Api.Account.ApiKey } }).Substring(0, 10)}";
            ViewData["Preset"] = $"sample_{_cloudinary.Api.SignParameters(new SortedDictionary<string, object> { { "api_key", _cloudinary.Api.Account.ApiKey } }).Substring(0, 10)}";
            await _cloudinary.CreateUploadPresetAsync(new UploadPresetParams
            {
                Name = Preset,
                Unsigned = true,
                Folder = FolderName
            }).ConfigureAwait(false);
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult>CreateCloudinary(){
            string content = null;
            using (var reader = new StreamReader(HttpContext.Request.Body))
            {
                content = await reader.ReadToEndAsync().ConfigureAwait(false);
            }

            if (string.IsNullOrEmpty(content)) return View();

            var parsedResult = JsonConvert.DeserializeObject<ImageUploadResult>(content);
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
            var testHello = new TestHello
            {
                CreatedAt = parsedResult.CreatedAt.ToString(),
                Format = parsedResult.Format,
                Height = parsedResult.Height.ToString(),
                PublicId = parsedResult.PublicId,
                ResourceType = parsedResult.ResourceType,
                SecureUrl = parsedResult.SecureUrl.ToString(),
                Signature = parsedResult.Signature,
                Type = parsedResult.Type,
                Url = parsedResult.Url.ToString(),
                Version = int.Parse(parsedResult.Version, provider),
                Width = parsedResult.Width.ToString()
            };
            Console.WriteLine(testHello.ToString());
            return Redirect("/");
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

            var profile = new TestHello();
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