#pragma checksum "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Edit), @"mvc.1.0.view", @"/Views/Customer/Edit.cshtml")]
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
#line 2 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
using Test1.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb", @"/Views/Customer/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9721d3cced50c239d501c8bd0e54213607feadfd", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test1.ViewModel.CustomerVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Gender"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "SearchForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("formmethod", new global::Microsoft.AspNetCore.Html.HtmlString("get"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("        \n");
            WriteLiteral("    <div class=\"col-md-12\">    \n        <h2>Customer Management</h2>    \n    </div>    \n\n    <!-- Input and Submit elements -->\n        <div class=\"form-horizontal\">    \n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb6383", async() => {
                WriteLiteral("  \n                <hr />   \n                <div class =\"form-group\">\n                    ");
#nullable restore
#line 17 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
               Write(Html.HiddenFor(model=> model.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div> \n                <div class=\"form-group\">    \n                    ");
#nullable restore
#line 20 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
               Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    <div class=\"col-md-10\">    \n                        ");
#nullable restore
#line 22 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                        ");
#nullable restore
#line 23 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    </div>    \n                </div>    \n        \n                <div class=\"form-group\">    \n                    ");
#nullable restore
#line 28 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
               Write(Html.LabelFor(model => model.Address, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    <div class=\"col-md-10\">    \n                        ");
#nullable restore
#line 30 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.EditorFor(model => model.Address, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                        ");
#nullable restore
#line 31 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Address, "", new { @class = "tet-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    </div>    \n                </div>    \n        \n                <div class=\"form-group\">    \n                    ");
#nullable restore
#line 36 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
               Write(Html.LabelFor(model => model.DTB, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    <div class=\"col-md-10\">    \n                        ");
#nullable restore
#line 38 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.EditorFor(model => model.DTB, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                        ");
#nullable restore
#line 39 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.DTB, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    </div>    \n                </div>    \n                <div class=\"form-group\">    \n                    ");
#nullable restore
#line 43 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
               Write(Html.LabelFor(model => model.Gender, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    <div class=\"col-md-10\">    \n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb10767", async() => {
                    WriteLiteral("\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb11060", async() => {
                        WriteLiteral("Select type ...");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 45 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Gender);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 47 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<CustomerVM.GenderEnum>();

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
#nullable restore
#line 50 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Gender, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    </div>    \n                </div>    \n        \n                <div class=\"form-group\">    \n                    ");
#nullable restore
#line 55 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
               Write(Html.LabelFor(model => model.ImageUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                    <div class=\"col-md-10\">    \n                        ");
#nullable restore
#line 57 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.EditorFor(model => model.ImageUrl, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("    \n                        ");
#nullable restore
#line 58 "/home/cuong/NET CORE/Folder1/Test1/Views/Customer/Edit.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ImageUrl, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    
                    </div>    
                </div>    
        
          
        
                <div class=""form-group"">    
                    <div class=""col-md-offset-2 col-md-10"">    
                        <input type=""submit"" value=""Update"" class=""btn btn-primary"" />    
                    </div>    
                </div>    
            
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n             <div class=\"form-group\">\n                            <div class=\"col-md-offset-2 col-md-10\">\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb17545", async() => {
                WriteLiteral("\n                                      ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c53eb4fe675e8034703c9a2ac1d61b33e1d3fdb17838", async() => {
                    WriteLiteral("Cancel");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Route = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
                WriteLiteral("                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            </div>\n                              </div> \n        </div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Test1.ViewModel.CustomerVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
