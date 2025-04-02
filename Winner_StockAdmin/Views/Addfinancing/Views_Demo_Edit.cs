// Decompiled with JetBrains decompiler
// Type: AspNetCoreGeneratedDocument.Views_Demo_Edit
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using stockadmin.ViewModels.Demo;
using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

#nullable enable
namespace AspNetCoreGeneratedDocument
{
  [RazorSourceChecksum("Sha256", "eedd1536447f17cdb8e5b8a36b3c8d90d1683889807110a1388d6f15bd7348dd", "/Views/Demo/Edit.cshtml")]
  [RazorSourceChecksum("Sha256", "c8c2f33cba7ac9139945780650693bb09fbebb1e836a6af83f6d8f3f9c6a0879", "/Views/_ViewImports.cshtml")]
  [RazorCompiledItemMetadata("Identifier", "/Views/Demo/Edit.cshtml")]
  [CreateNewOnMetadataUpdate]
  internal sealed class Views_Demo_Edit : RazorPage<DemoMemberVm>
  {
    private static readonly 
    #nullable disable
    TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", (object) new HtmlString("text-danger"), (HtmlAttributeValueStyle) 0);
    private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("class", (object) new HtmlString("control-label"), (HtmlAttributeValueStyle) 0);
    private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("class", (object) new HtmlString("form-control"), (HtmlAttributeValueStyle) 0);
    private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", (object) new HtmlString("form-check-input"), (HtmlAttributeValueStyle) 0);
    private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("asp-action", (object) "PostEdit", (HtmlAttributeValueStyle) 0);
    private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("asp-action", (object) "Index", (HtmlAttributeValueStyle) 0);
    private TagHelperExecutionContext __tagHelperExecutionContext;
    private TagHelperRunner __tagHelperRunner = new TagHelperRunner();
    private string __tagHelperStringValueBuffer;
    private TagHelperScopeManager __backed__tagHelperScopeManager;
    private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
    private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
    private ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
    private LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
    private InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
    private ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
    private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;

    private TagHelperScopeManager __tagHelperScopeManager
    {
      get
      {
        if (this.__backed__tagHelperScopeManager == null)
          this.__backed__tagHelperScopeManager = new TagHelperScopeManager(new Action<HtmlEncoder>(((RazorPageBase) this).StartTagHelperWritingScope), new Func<TagHelperContent>(((RazorPageBase) this).EndTagHelperWritingScope));
        return this.__backed__tagHelperScopeManager;
      }
    }

    public virtual async Task ExecuteAsync()
    {
      Views_Demo_Edit viewsDemoEdit = this;
      ((RazorPageBase) viewsDemoEdit).WriteLiteral("\n<h4>編輯</h4>\n<hr />\n<div class=\"row\">\n    <div class=\"col-md-4\">\n        ");
      // ISSUE: reference to a compiler-generated method
      viewsDemoEdit.__tagHelperExecutionContext = viewsDemoEdit.__tagHelperScopeManager.Begin("form", (TagMode) 0, "eedd1536447f17cdb8e5b8a36b3c8d90d1683889807110a1388d6f15bd7348dd6804", new Func<Task>(viewsDemoEdit.\u003CExecuteAsync\u003Eb__19_0));
      viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = ((RazorPageBase) viewsDemoEdit).CreateTagHelper<FormTagHelper>();
      viewsDemoEdit.__tagHelperExecutionContext.Add((ITagHelper) viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
      viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = ((RazorPageBase) viewsDemoEdit).CreateTagHelper<RenderAtEndOfFormTagHelper>();
      viewsDemoEdit.__tagHelperExecutionContext.Add((ITagHelper) viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
      viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string) Views_Demo_Edit.__tagHelperAttribute_4.Value;
      viewsDemoEdit.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Demo_Edit.__tagHelperAttribute_4);
      await viewsDemoEdit.__tagHelperRunner.RunAsync(viewsDemoEdit.__tagHelperExecutionContext);
      if (!viewsDemoEdit.__tagHelperExecutionContext.Output.IsContentModified)
        await viewsDemoEdit.__tagHelperExecutionContext.SetOutputContentAsync();
      ((RazorPageBase) viewsDemoEdit).Write((object) viewsDemoEdit.__tagHelperExecutionContext.Output);
      viewsDemoEdit.__tagHelperExecutionContext = viewsDemoEdit.__tagHelperScopeManager.End();
      ((RazorPageBase) viewsDemoEdit).WriteLiteral("\n    </div>\n</div>\n\n<div>\n    ");
      // ISSUE: reference to a compiler-generated method
      viewsDemoEdit.__tagHelperExecutionContext = viewsDemoEdit.__tagHelperScopeManager.Begin("a", (TagMode) 0, "eedd1536447f17cdb8e5b8a36b3c8d90d1683889807110a1388d6f15bd7348dd38725", new Func<Task>(viewsDemoEdit.\u003CExecuteAsync\u003Eb__19_1));
      viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = ((RazorPageBase) viewsDemoEdit).CreateTagHelper<AnchorTagHelper>();
      viewsDemoEdit.__tagHelperExecutionContext.Add((ITagHelper) viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
      viewsDemoEdit.__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string) Views_Demo_Edit.__tagHelperAttribute_5.Value;
      viewsDemoEdit.__tagHelperExecutionContext.AddTagHelperAttribute(Views_Demo_Edit.__tagHelperAttribute_5);
      await viewsDemoEdit.__tagHelperRunner.RunAsync(viewsDemoEdit.__tagHelperExecutionContext);
      if (!viewsDemoEdit.__tagHelperExecutionContext.Output.IsContentModified)
        await viewsDemoEdit.__tagHelperExecutionContext.SetOutputContentAsync();
      ((RazorPageBase) viewsDemoEdit).Write((object) viewsDemoEdit.__tagHelperExecutionContext.Output);
      viewsDemoEdit.__tagHelperExecutionContext = viewsDemoEdit.__tagHelperScopeManager.End();
      ((RazorPageBase) viewsDemoEdit).WriteLiteral("\n</div>\n\n");
    }

    [RazorInject]
    public 
    #nullable enable
    IModelExpressionProvider ModelExpressionProvider { get; private set; }

    [RazorInject]
    public IUrlHelper Url { get; private set; }

    [RazorInject]
    public IViewComponentHelper Component { get; private set; }

    [RazorInject]
    public IJsonHelper Json { get; private set; }

    [RazorInject]
    public IHtmlHelper<DemoMemberVm> Html { get; private set; }
  }
}
