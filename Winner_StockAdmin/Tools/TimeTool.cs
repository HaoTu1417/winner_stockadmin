// Decompiled with JetBrains decompiler
// Type: stockadmin.Tool.TimeTool
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable enable
namespace stockadmin.Tool
{
  public class TimeTool
  {
    public static DateTime ConvertLocalToUtc(DateTime localTime)
    {
      return TimeZoneInfo.ConvertTimeToUtc(localTime, TimeZoneInfo.Local);
    }

    public static void ConvertTimeZone<T>(List<T> model, TimeZoneInfo tz)
    {
      foreach (T model1 in model)
        TimeTool.ConvertTimeZone<T>(model1, tz);
    }

    public static void ConvertTimeZone<T>(T model, TimeZoneInfo tz)
    {
      if ((object) model == null)
        return;
      foreach (PropertyInfo property in model.GetType().GetProperties())
      {
        object obj1 = property.GetValue((object) model, (object[]) null);
        if ((!(property.PropertyType != typeof (bool)) || obj1 != null && !string.IsNullOrEmpty(obj1.ToString().Trim())) && obj1.GetType() == typeof (DateTime))
        {
          object obj2 = (object) TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(obj1), tz);
          property.SetValue((object) model, obj2);
        }
      }
    }
  }
}
