// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.Exportlib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

#nullable enable
namespace stockadmin.Libs
{
  public class Exportlib
  {
    public static byte[]? ExportExcel<T>(IEnumerable<T> list)
    {
      // ExcelPackage.LicenseContext = new LicenseContext?(LicenseContext.NonCommercial);
      ExcelPackage.LicenseContext = new OfficeOpenXml.LicenseContext?(OfficeOpenXml.LicenseContext.NonCommercial);
      using (ExcelPackage excelPackage = new ExcelPackage())
      {
        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
        int Row1 = 1;
        IEnumerable<PropertyInfo> propertyInfos = ((IEnumerable<PropertyInfo>) typeof (T).GetProperties()).Where<PropertyInfo>((Func<PropertyInfo, bool>) (prop => Attribute.IsDefined((MemberInfo) prop, typeof (DisplayNameAttribute))));
        int Col1 = 1;
        foreach (MemberInfo element in propertyInfos)
        {
          DisplayNameAttribute customAttribute = (DisplayNameAttribute) Attribute.GetCustomAttribute(element, typeof (DisplayNameAttribute));
          excelWorksheet.Cells[Row1, Col1].Value = (object) customAttribute.DisplayName;
          ++Col1;
        }
        int Row2 = Row1 + 1;
        excelWorksheet.Cells.Style.Numberformat.Format = "0";
        foreach (T obj in list)
        {
          int Col2 = 1;
          foreach (PropertyInfo propertyInfo in propertyInfos)
          {
            if (propertyInfo.PropertyType == typeof (DateTime?))
            {
              DateTime? nullable = (DateTime?) propertyInfo.GetValue((object) obj);
              if (nullable.HasValue)
              {
                excelWorksheet.Cells[Row2, Col2].Style.Numberformat.Format = "yyyy/M/d h:mm:ss";
                ExcelRange cell = excelWorksheet.Cells[Row2, Col2];
                nullable = (DateTime?) propertyInfo.GetValue((object) obj);
                // ISSUE: variable of a boxed type
                __Boxed<DateTime> local = (ValueType) nullable.Value;
                cell.Value = (object) local;
                ++Col2;
                continue;
              }
            }
            if (propertyInfo.PropertyType == typeof (DateTime))
              excelWorksheet.Cells[Row2, Col2].Style.Numberformat.Format = "yyyy/M/d h:mm:ss";
            if (propertyInfo.PropertyType == typeof (Decimal) || propertyInfo.PropertyType == typeof (double) || propertyInfo.PropertyType == typeof (float))
              excelWorksheet.Cells[Row2, Col2].Style.Numberformat.Format = "0.00_";
            excelWorksheet.Cells[Row2, Col2].Value = propertyInfo.GetValue((object) obj);
            ++Col2;
          }
          ++Row2;
        }
        return excelPackage.GetAsByteArray();
      }
    }
  }
}
