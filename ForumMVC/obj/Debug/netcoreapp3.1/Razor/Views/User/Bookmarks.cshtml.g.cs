#pragma checksum "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "426d6d62900f1a9cc3859afbe70b7d9936ad3eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Bookmarks), @"mvc.1.0.view", @"/Views/User/Bookmarks.cshtml")]
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
#line 4 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.AccountVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.UserVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.TopicVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.CommunityVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using BusinessLayer.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using DataAccessLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.HomeVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.AnswerVMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\_ViewImports.cshtml"
using ForumMVC.ViewModels.CommentVMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"426d6d62900f1a9cc3859afbe70b7d9936ad3eca", @"/Views/User/Bookmarks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3edc54152532c61df04d654944895cf128249e52", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_Bookmarks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserProfileVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "user", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "about", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("author-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("topic-author"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "topic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"user-header\"");
            BeginWriteAttribute("style", " style=\"", 77, "\"", 228, 10);
            WriteAttributeValue("", 85, "background-image:", 85, 17, true);
            WriteAttributeValue(" ", 102, "url(\'", 103, 6, true);
#nullable restore
#line 4 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
WriteAttributeValue("", 108, Model.User.BannerImage, 108, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 131, "\');", 131, 3, true);
            WriteAttributeValue("\r\n    ", 134, "background-position:", 140, 26, true);
            WriteAttributeValue(" ", 160, "center;", 161, 8, true);
            WriteAttributeValue("\r\n    ", 168, "background-size:", 174, 22, true);
            WriteAttributeValue(" ", 190, "cover;", 191, 7, true);
            WriteAttributeValue("\r\n    ", 197, "background-color:", 203, 23, true);
            WriteAttributeValue(" ", 220, "#161b22", 221, 8, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"user\">\r\n            <div class=\"user-name\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca8800", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 323, "~/uploads/images/user/", 323, 22, true);
#nullable restore
#line 10 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
AddHtmlAttributeValue("", 345, Model.User.ProfileImage, 345, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <a>");
#nullable restore
#line 11 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
              Write(Model.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                               Write(Model.User.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                <span class=\"user-level\">");
#nullable restore
#line 12 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                    Write(Model.User.Level);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div class=\"user-actions\">\r\n            <ul>\r\n                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca11288", async() => {
                WriteLiteral("<i class=\"fa-solid fa-message\"></i> Topics");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                  WriteLiteral(Model.User.Username);

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
            WriteLiteral("</li>\r\n                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca13735", async() => {
                WriteLiteral("<i class=\"fa-solid fa-at\"></i> About");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                  WriteLiteral(Model.User.Username);

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
            WriteLiteral("</li>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                 if (Model.User.Username == User.Identity.Name)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca16449", async() => {
                WriteLiteral("<i class=\"fa-solid fa-pen-to-square\"></i> Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                     WriteLiteral(Model.User.Username);

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
            WriteLiteral("</li>\r\n");
#nullable restore
#line 25 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n    <div class=\"row my-4\">\r\n        <div class=\"col-lg-8\">\r\n            <div class=\"main-flow\">\r\n");
#nullable restore
#line 32 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                 if (Model.Topics.Count != 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                     foreach (GetTopicVM topic in @Model.Topics)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"topic\">\r\n                            <div class=\"topic-header\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca19894", async() => {
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca20186", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1770, "~/uploads/images/user/", 1770, 22, true);
#nullable restore
#line 39 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
AddHtmlAttributeValue("", 1792, topic.AuthorImage, 1792, 18, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 40 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                               Write(topic.AuthorFullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    <span class=\"author-level\">");
#nullable restore
#line 41 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                          Write(topic.AuthorLevel);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                              WriteLiteral(topic.AuthorUsername);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <p class=\"topic-create-date\">\r\n                                    Asked: <span class=\"date\">");
#nullable restore
#line 44 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                         Write(topic.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </p>\r\n                            </div>\r\n                            <div class=\"topic-body\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca25375", async() => {
#nullable restore
#line 48 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                                                 Write(topic.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                               WriteLiteral(topic.Id);

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
            WriteLiteral("\r\n                                <p>\r\n                                    ");
#nullable restore
#line 50 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                               Write(Html.Raw(topic.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                                <ul>\r\n                                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426d6d62900f1a9cc3859afbe70b7d9936ad3eca28432", async() => {
#nullable restore
#line 53 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                                                                          Write(topic.TopicCategory.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                                          WriteLiteral(topic.TopicCategory.Id);

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
            WriteLiteral(@"</li>
                                </ul>
                            </div>
                            <div class=""topic-footer"">
                                <div class=""topic-footer-left"">
                                    <div class=""topic-view-count"">
                                        <i class=""fa-solid fa-eye""></i> <span class=""view-count""> ");
#nullable restore
#line 59 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                                             Write(topic.ViewCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Views</span>\r\n                                    </div>\r\n\r\n                                    <div class=\"topic-answer-count\">\r\n                                        <i class=\"fa-solid fa-message\"></i> <span class=\"answer-count\"> ");
#nullable restore
#line 63 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                                                                                                   Write(topic.AnswerCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Answers</span>
                                    </div>
                                </div>
                                <div class=""topic-footer-right"">
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 70 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h3>There are no saved bookmark.</h3>\r\n");
#nullable restore
#line 75 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\User\Bookmarks.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>

        <div class=""col-lg-4"">
            <footer>
                <div class=""row"">
                    <div class=""col-6"">
                        <p>Useful links</p>
                        <ul>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Communities</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Members</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Rules</a></li>
                        </ul>
                    </div>
                    <div class=""col-6"">
                        <p>Popular categories</p>
                        <ul>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Technology</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Internet</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i");
            WriteLiteral(@"> Cars</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Operation systems</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-12"">
                        <p class=""copyright"">
                            Forum Inc © 2022. All rights reserved
                        </p>
                    </div>
                </div>
            </footer>
        </div>


    </div>

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserProfileVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591