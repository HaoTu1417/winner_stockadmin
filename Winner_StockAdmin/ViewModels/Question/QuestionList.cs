// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Question.QuestionList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.ViewModels.Question
{
  public class QuestionList
  {
    public int question_category_fk { get; set; }

    public string question_category_text { get; set; }

    public int pk { get; set; }

    public string lang { get; set; }

    public string question { get; set; }

    public bool enable { get; set; }

    public bool commonly_used { get; set; }

    public int sort { get; set; }
  }
}
