// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Question.QuestionFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.Question
{
  public class QuestionFilter
  {
    [Where("=", "question_category_fk")]
    public int? question_category_fk { get; set; }

    [Where("=", "cq.lang")]
    public string? lang { get; set; }

    [Where("LIKE", "question")]
    public string? question { get; set; }
  }
}
