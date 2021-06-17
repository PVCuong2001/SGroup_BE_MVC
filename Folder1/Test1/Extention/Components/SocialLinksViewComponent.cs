using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.ViewModel;

namespace Test1.Extention.Components
{
    public class SocialLinksViewComponent : ViewComponent
    {
        List<SocialIcon> socialIcons = new List<SocialIcon>();  
        public SocialLinksViewComponent()  
        {  
            socialIcons = SocialIcon.AppSocialIcons();  
        }  
  
        public async Task<IViewComponentResult> InvokeAsync()  
        {  
            var model = socialIcons;  
            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/SocialLinks.cshtml", model));  
        }  
    }
}