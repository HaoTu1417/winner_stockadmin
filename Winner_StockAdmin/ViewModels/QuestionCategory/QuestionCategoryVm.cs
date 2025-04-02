// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.QuestionCategory.QuestionCategoryVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.QuestionCategory
{
  public class QuestionCategoryVm
  {
    public QuestionCategoryFilter filter { get; set; }

    public IPagedList<QuestionCategoryList> list { get; set; }
  }
}
