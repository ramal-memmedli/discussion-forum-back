#pragma checksum "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bc6416e0bd69fcee0a9001ed17f9c0f7111a4fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopCommunitiesPartial), @"mvc.1.0.view", @"/Views/Shared/_TopCommunitiesPartial.cshtml")]
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
#line 4 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.AccountVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.UserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.TopicVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.CommunityVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using BusinessLayer.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using DataAccessLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.HomeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.AnswerVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.CommentVMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bc6416e0bd69fcee0a9001ed17f9c0f7111a4fd", @"/Views/Shared/_TopCommunitiesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3edc54152532c61df04d654944895cf128249e52", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__TopCommunitiesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetCommunityCardVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "community", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"top-communities\">\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
     if (Model is null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>There are no community</h2>\r\n");
#nullable restore
#line 8 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
         foreach (GetCommunityCardVM communityCard in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"sidebar-community\"");
            BeginWriteAttribute("style", " style=\"", 280, "\"", 340, 4);
            WriteAttributeValue("", 288, "background-image:", 288, 17, true);
            WriteAttributeValue(" ", 305, "url(\'", 306, 6, true);
#nullable restore
#line 13 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
WriteAttributeValue("", 311, communityCard.BannerImage, 311, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 337, "\');", 337, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bc6416e0bd69fcee0a9001ed17f9c0f7111a4fd6815", async() => {
                WriteLiteral("<div><img");
                BeginWriteAttribute("src", " src=\"", 453, "\"", 486, 1);
#nullable restore
#line 15 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
WriteAttributeValue("", 459, communityCard.ProfileImage, 459, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 487, "\"", 493, 0);
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 15 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
                                                                                                                                                 Write(communityCard.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div><p>");
#nullable restore
#line 15 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
                                                                                                                                                                             Write(communityCard.MemberCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(" member</p>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
                                                                   WriteLiteral(communityCard.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 17 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Ramal\Desktop\final\ForumMVC\ForumMVC\Views\Shared\_TopCommunitiesPartial.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GetCommunityCardVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
