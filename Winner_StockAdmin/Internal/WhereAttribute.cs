// Decompiled with JetBrains decompiler
// Type: stockadmin.Internal.WhereAttribute
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.Internal
{
  public class WhereAttribute : Attribute
  {
    public string comparative;
    public string field;

    public WhereAttribute(string _comparative, string _dbfield)
    {
      this.comparative = _comparative.ToLower();
      this.field = _dbfield.IndexOf('.') == -1 ? "`" + _dbfield + "`" : _dbfield;
    }
  }
}
