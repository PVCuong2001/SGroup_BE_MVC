using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Test1.Extention.StreamUpload;
using Test1.Service.Service_Interface;
using Test1.ViewModel;

namespace Test1.Pages.User
{
    public class Create : PageModel
    {

        
        public IActionResult OnGet()
        {
            return Page();
        }
        
        
    }
}