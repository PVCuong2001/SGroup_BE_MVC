#pragma checksum "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fecb33a42291e59b97ba91415d937ba1076ed5ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SocialLinks), @"mvc.1.0.view", @"/Views/Shared/Components/SocialLinks.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/home/cuong/NET CORE/Folder1/Test1/Views/_ViewImports.cshtml"
using Test1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/cuong/NET CORE/Folder1/Test1/Views/_ViewImports.cshtml"
using Test1.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fecb33a42291e59b97ba91415d937ba1076ed5ae", @"/Views/Shared/Components/SocialLinks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9721d3cced50c239d501c8bd0e54213607feadfd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SocialLinks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Collections.Generic.List<Test1.ViewModel.SocialIcon>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<style>    \n    .main-div {    \n        margin-bottom: 20px;    \n        padding-bottom: 20px;    \n    }    \n</style>  \n<div class=\"col-md-12\" style=\"padding-left:10px;\">    \n");
#nullable restore
#line 9 "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml"
     foreach (var icon in Model)    
    {    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("style", " style=\"", 299, "\"", 376, 7);
            WriteAttributeValue("", 307, "background:", 307, 11, true);
#nullable restore
#line 11 "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml"
WriteAttributeValue("", 318, icon.IconBgColor, 318, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 335, ";", 336, 2, true);
            WriteAttributeValue(" ", 337, "padding:", 338, 9, true);
            WriteAttributeValue(" ", 346, "5px;margin:", 347, 12, true);
            WriteAttributeValue(" ", 358, "5px;color:", 359, 11, true);
            WriteAttributeValue(" ", 369, "white;", 370, 7, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 377, "\"", 403, 1);
#nullable restore
#line 11 "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml"
WriteAttributeValue("", 384, icon.IconTargetUrl, 384, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">    \n            <i");
            BeginWriteAttribute("class", " class=\"", 424, "\"", 447, 1);
#nullable restore
#line 12 "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml"
WriteAttributeValue("", 432, icon.IconClass, 432, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>    \n            ");
#nullable restore
#line 13 "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml"
       Write(icon.IconName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n        </a>    \n");
#nullable restore
#line 15 "/home/cuong/NET CORE/Folder1/Test1/Views/Shared/Components/SocialLinks.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>     ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Collections.Generic.List<Test1.ViewModel.SocialIcon>> Html { get; private set; }
    }
}
#pragma warning restore 1591