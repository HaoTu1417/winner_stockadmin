// Decompiled with JetBrains decompiler
// Type: AspNetCoreGeneratedDocument.Views__ViewImports
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace AspNetCoreGeneratedDocument
{
  [RazorSourceChecksum("Sha256", "c8c2f33cba7ac9139945780650693bb09fbebb1e836a6af83f6d8f3f9c6a0879", "/Views/_ViewImports.cshtml")]
  [RazorCompiledItemMetadata("Identifier", "/Views/_ViewImports.cshtml")]
  [CreateNewOnMetadataUpdate]
  internal sealed class Views__ViewImports : RazorPage<object>
  {
    public virtual async 
    #nullable disable
    Task ExecuteAsync() => ((RazorPageBase) this).WriteLiteral("\n");

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
