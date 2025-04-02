// Decompiled with JetBrains decompiler
// Type: AspNetCoreGeneratedDocument.Views_Shared__ValidationScriptsPartial
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

#nullable enable
namespace AspNetCoreGeneratedDocument
{
  [RazorSourceChecksum("Sha256", "fb1778070041325577c8463415f2d445aad6ccf35685bd71cddea0a0bb02b9c6", "/Views/Shared/_ValidationScriptsPartial.cshtml")]
  [RazorSourceChecksum("Sha256", "c8c2f33cba7ac9139945780650693bb09fbebb1e836a6af83f6d8f3f9c6a0879", "/Views/_ViewImports.cshtml")]
  [RazorCompiledItemMetadata("Identifier", "/Views/Shared/_ValidationScriptsPartial.cshtml")]
  [CreateNewOnMetadataUpdate]
  internal sealed class Views_Shared__ValidationScriptsPartial : RazorPage<object>
  {
    private static readonly 
    #nullable disable
    TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("src", (object) new HtmlString("~/lib/jquery-validation/dist/jquery.validate.min.js"), (HtmlAttributeValueStyle) 0);
    private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", (object) new HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"), (HtmlAttributeValueStyle) 0);
    private TagHelperExecutionContext __tagHelperExecutionContext;
    private TagHelperRunner __tagHelperRunner = new TagHelperRunner();
    private string __tagHelperStringValueBuffer;
    private TagHelperScopeManager __backed__tagHelperScopeManager;
    private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

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
      Views_Shared__ValidationScriptsPartial validationScriptsPartial = this;
      validationScriptsPartial.__tagHelperExecutionContext = validationScriptsPartial.__tagHelperScopeManager.Begin("script", (TagMode) 0, "fb1778070041325577c8463415f2d445aad6ccf35685bd71cddea0a0bb02b9c64755", (Func<Task>) (async () => { }));
      validationScriptsPartial.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = ((RazorPageBase) validationScriptsPartial).CreateTagHelper<UrlResolutionTagHelper>();
      validationScriptsPartial.__tagHelperExecutionContext.Add((ITagHelper) validationScriptsPartial.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
      validationScriptsPartial.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_0);
      await validationScriptsPartial.__tagHelperRunner.RunAsync(validationScriptsPartial.__tagHelperExecutionContext);
      if (!validationScriptsPartial.__tagHelperExecutionContext.Output.IsContentModified)
        await validationScriptsPartial.__tagHelperExecutionContext.SetOutputContentAsync();
      ((RazorPageBase) validationScriptsPartial).Write((object) validationScriptsPartial.__tagHelperExecutionContext.Output);
      validationScriptsPartial.__tagHelperExecutionContext = validationScriptsPartial.__tagHelperScopeManager.End();
      ((RazorPageBase) validationScriptsPartial).WriteLiteral("\n");
      validationScriptsPartial.__tagHelperExecutionContext = validationScriptsPartial.__tagHelperScopeManager.Begin("script", (TagMode) 0, "fb1778070041325577c8463415f2d445aad6ccf35685bd71cddea0a0bb02b9c65816", (Func<Task>) (async () => { }));
      validationScriptsPartial.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = ((RazorPageBase) validationScriptsPartial).CreateTagHelper<UrlResolutionTagHelper>();
      validationScriptsPartial.__tagHelperExecutionContext.Add((ITagHelper) validationScriptsPartial.__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
      validationScriptsPartial.__tagHelperExecutionContext.AddHtmlAttribute(Views_Shared__ValidationScriptsPartial.__tagHelperAttribute_1);
      await validationScriptsPartial.__tagHelperRunner.RunAsync(validationScriptsPartial.__tagHelperExecutionContext);
      if (!validationScriptsPartial.__tagHelperExecutionContext.Output.IsContentModified)
        await validationScriptsPartial.__tagHelperExecutionContext.SetOutputContentAsync();
      ((RazorPageBase) validationScriptsPartial).Write((object) validationScriptsPartial.__tagHelperExecutionContext.Output);
      validationScriptsPartial.__tagHelperExecutionContext = validationScriptsPartial.__tagHelperScopeManager.End();
      ((RazorPageBase) validationScriptsPartial).WriteLiteral("\n");
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
    public IHtmlHelper<object> Html { get; private set; }
  }
}
