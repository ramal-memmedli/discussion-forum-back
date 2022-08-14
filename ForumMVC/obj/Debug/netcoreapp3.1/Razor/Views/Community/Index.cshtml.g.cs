#pragma checksum "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5427ea7286a3658ab736eb9d91b2117dcd5205d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_Index), @"mvc.1.0.view", @"/Views/Community/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5427ea7286a3658ab736eb9d91b2117dcd5205d9", @"/Views/Community/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddfe9cbab9f9d384b783316ec87c49242b8948c5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Community_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetCommunityVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "user", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("topic-author"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "topic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"community-header\">\r\n        <div class=\"community-name\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 142, "\"", 167, 1);
#nullable restore
#line 7 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
WriteAttributeValue("", 148, Model.ProfileImage, 148, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 168, "\"", 174, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <a>");
#nullable restore
#line 8 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
        </div>
        <div class=""community-actions"">
            <ul>
                <li><a href=""#""><i class=""fa-solid fa-message""></i> Topics</a></li>
                <li><a href=""#""><i class=""fa-solid fa-users""></i> Members</a></li>
                <li><a href=""#""><i class=""fa-solid fa-at""></i> About</a></li>
                <li><a href=""#""><i class=""fa-solid fa-pen-to-square""></i> Edit</a></li>
            </ul>
        </div>
    </div>
    <div class=""row my-4"">
        <div class=""col-lg-8"">
            <div class=""main-flow"">
                <div class=""topic"">
                    <div class=""topic-header mb-0 ask-question-card"">
                        <a href=""#"" class=""topic-author"">
                            <img class=""author-image"" src=""./assets/images/logo.svg""");
            BeginWriteAttribute("alt", " alt=\"", 1017, "\"", 1023, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            Ramal Memmedli
                            <span class=""author-level"">10</span>
                        </a>
                        <a class=""ask-a-question-main"" href=""#"">Ask a question</a>
                    </div>
                </div>
");
#nullable restore
#line 32 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                 if(Model.Topics is null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4>This community doesn\'t has topic yet</h4>\r\n");
#nullable restore
#line 34 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                }else {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                     foreach (GetTopicVM topic in Model.Topics)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"topic\">\r\n                            <div class=\"topic-header\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5427ea7286a3658ab736eb9d91b2117dcd5205d98487", async() => {
                WriteLiteral("\r\n                                    <img class=\"author-image\" src=\"./assets/images/logo.svg\"");
                BeginWriteAttribute("alt", " alt=\"", 1857, "\"", 1863, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    ");
#nullable restore
#line 41 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                               Write(topic.AuthorFullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    <span class=\"author-level\">10</span>\r\n                                ");
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
#line 39 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                                                              WriteLiteral(topic.AuthorUsername);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <p class=\"topic-create-date\">\r\n");
#nullable restore
#line 45 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                     if (topic.UpdateDate != null)
                                    {
                                    Edited:
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"date\">");
#nullable restore
#line 48 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                                      Write(topic.UpdateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 49 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                    }
                                    else
                                    {
                                    Asked:
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"date\">");
#nullable restore
#line 53 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                                      Write(topic.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 54 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n                            <div class=\"topic-body\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5427ea7286a3658ab736eb9d91b2117dcd5205d913425", async() => {
#nullable restore
#line 59 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                                                                                 Write(topic.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
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
#line 61 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                               Write(topic.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </p>
                                <ul>
                                    <li><a href=""#"">Technology</a></li>
                                    <li><a href=""#"">GPU</a></li>
                                    <li><a href=""#"">Software</a></li>
                                    <li><a href=""#"">Technology</a></li>
                                    <li><a href=""#"">GPU</a></li>
                                    <li><a href=""#"">Software</a></li>
                                </ul>
                            </div>
                            <div class=""topic-footer"">
                                <div class=""topic-footer-left"">
                                    <div class=""topic-view-count"">
                                        <i class=""fa-solid fa-eye""></i> <span class=""view-count""> ");
#nullable restore
#line 75 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                                                                                             Write(topic.ViewCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Views</span>
                                    </div>

                                    <div class=""topic-answer-count"">
                                        <i class=""fa-solid fa-message""></i> <span class=""answer-count""> 7 Answers</span>
                                    </div>
                                </div>
                                <div class=""topic-footer-right"">
                                    <a href=""#""><i class=""fa-solid fa-bookmark""></i></a>
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 87 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\Ramal\Desktop\ForumMVC\ForumMVC\Views\Community\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                
            </div>
            <div class=""d-flex justify-content-center align-items-center"">
                <a class=""load-more"" href=""#""><i class=""fa-solid fa-arrow-rotate-right""></i> Load more</a>
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
                            <li><a href=""#""><i class=""fa-solid fa-angl");
            WriteLiteral(@"e-right""></i> Technology</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Internet</a></li>
                            <li><a href=""#""><i class=""fa-solid fa-angle-right""></i> Cars</a></li>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetCommunityVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
