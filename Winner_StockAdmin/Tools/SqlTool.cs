// Decompiled with JetBrains decompiler
// Type: stockadmin.Tool.SqlTool
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Reflection;

#nullable enable
namespace stockadmin.Tool
{
  public static class SqlTool
  {
    public static string Build<T>(T model, bool accurate = false)
    {
      string str1 = string.Empty;
      if ((object) model == null)
        return str1;
      foreach (PropertyInfo property in model.GetType().GetProperties())
      {
        object obj = property.GetValue((object) model, (object[]) null);
        if ((!(property.PropertyType != typeof (bool)) || obj != null && !string.IsNullOrEmpty(obj.ToString().Trim())) && ((MemberInfo) property).IsDefined(typeof (WhereAttribute), false))
        {
          WhereAttribute customAttribute = (WhereAttribute) CustomAttributeExtensions.GetCustomAttribute((MemberInfo) property, typeof (WhereAttribute), false);
          string field = customAttribute.field;
          string comparative = customAttribute.comparative;
          string str2 = str1.Length != 0 ? str1 + " AND " : " WHERE ";
          if (comparative.ToLower() == "like")
          {
            str1 = !accurate ? str2 + string.Format("{0} LIKE '%{1}%'", (object) field, (object) obj.ToString()) : str2 + string.Format("{0} = '{1}'", (object) field, (object) obj.ToString());
          }
          else
          {
            string str3 = obj.ToString();
            if (obj.GetType() == typeof (DateTime))
            {
              DateTime dateTime1 = Convert.ToDateTime(obj);
              DateTime dateTime2 = dateTime1;
              string str4 = ConfigLib.Get("time_zone_difference");
              if (str4 != null)
                dateTime2 = dateTime1.AddHours((double) -Convert.ToInt32(str4));
              str3 = dateTime2.ToString("yyyy-MM-dd HH:mm:ss");
            }
            str1 = str2 + string.Format("{0} {1} '{2}'", (object) field, (object) comparative, (object) str3);
          }
        }
      }
      return str1;
    }

    public static string Must(this string sourceStr, string sql)
    {
      return !string.IsNullOrEmpty(sourceStr) ? sourceStr.TrimEnd() + " AND " + sql : " WHERE " + sql;
    }
  }
}
