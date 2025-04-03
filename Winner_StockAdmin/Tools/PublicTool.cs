// Decompiled with JetBrains decompiler
// Type: stockadmin.Tool.PublicTool
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Responses;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Tool
{
  public class PublicTool
  {
    private static List<string> excludeIp = new List<string>()
    {
      "127.0.0.1",
      "localhost",
      "::1"
    };

    public static string Text(object? obj) => (obj ?? (object) "").ToString() ?? "";

    public static string ToJson(object obj) => JsonConvert.SerializeObject(obj);

    public static T FromJson<T>(string json)
    {
      try
      {
        return JsonConvert.DeserializeObject<T>(json);
      }
      catch (Exception ex)
      {
        LogLib.Log(ex.Message);
        return default (T);
      }
    }

    public static bool ToBool(string number)
    {
      return !(number == "0") && !(number.ToLower() == "false") && !(number.ToLower() == "f");
    }

    public static string BoolStringToNumberString(string b) => PublicTool.ToBool(b) ? "1" : "0";

    public static string GetRandomNum(int length)
    {
      Random random = new Random();
      string randomNum = "";
      for (int index = 0; index < length; ++index)
      {
        int num = random.Next(0, 10);
        randomNum += num.ToString();
      }
      return randomNum;
    }

    public static string GenerateRandomName(int length)
    {
      return new string(Enumerable.Repeat<string>("abcdefghijklmnopqrstuvwxyz0123456789", length).Select<string, char>((Func<string, char>) (s => s[new Random().Next(s.Length)])).ToArray<char>());
    }

    public static T convertUtcToLocalTime<T>(T obj)
    {
      PropertyInfo[] properties = obj.GetType().GetProperties();
      int int32 = Convert.ToInt32(ConfigLib.Get("time_zone_difference"));
      foreach (PropertyInfo propertyInfo in properties)
      {
        if ((propertyInfo.PropertyType == typeof (DateTime) || propertyInfo.PropertyType == typeof (DateTime?)) && propertyInfo.GetValue((object) obj) != null)
        {
          DateTime dateTime = (DateTime) propertyInfo.GetValue((object) obj);
          propertyInfo.SetValue((object) obj, (object) dateTime.AddHours((double) int32));
        }
      }
      return obj;
    }

    public static T convertLocalToUtcTime<T>(T obj)
    {
      PropertyInfo[] properties = obj.GetType().GetProperties();
      int int32 = Convert.ToInt32(ConfigLib.Get("time_zone_difference"));
      foreach (PropertyInfo propertyInfo in properties)
      {
        if (propertyInfo.PropertyType == typeof (DateTime))
        {
          DateTime dateTime = (DateTime) propertyInfo.GetValue((object) obj);
          propertyInfo.SetValue((object) obj, (object) dateTime.AddHours((double) -int32));
        }
      }
      return obj;
    }

    public static string GetCountryByIp(string ip)
    {
      try
      {
        if (PublicTool.excludeIp.Contains(ip))
          return (string) null;
        using (DatabaseReader databaseReader = new DatabaseReader("GeoLite2-Country.mmdb"))
        {
          if (string.IsNullOrEmpty(ip))
            return "未知";
          if (ip == "::1")
            return "本地";
          CountryResponse countryResponse = databaseReader.Country(ip);
          return countryResponse == null ? "未知" : countryResponse.Country.Names["en"];
        }
      }
      catch (AppException ex)
      {
        throw new AppException("請求:" + ip + "，錯誤:" + ex.Message);
      }
    }

    public static string AddNumberSeparation(Decimal? num, string currency)
    {
      if (!num.HasValue)
        return "";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
      interpolatedStringHandler.AppendFormatted<Decimal?>(num, "N2");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      string str1;
      switch (currency)
      {
        case "VND":
          string str2 = stringAndClear;
          str1 = str2.Substring(0, str2.Length - 3).Replace(",", ".");
          break;
        case "TWD":
          string str3 = stringAndClear;
          str1 = str3.Substring(0, str3.Length - 3);
          break;
        default:
          str1 = stringAndClear;
          break;
      }
      return str1;
    }

    public static RouteValueDictionary ArgsToRouteValueDictionary(Dictionary<string, object>? args)
    {
      RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
      if (args != null)
      {
        foreach (KeyValuePair<string, object> keyValuePair in args)
          routeValueDictionary.TryAdd(keyValuePair.Key, keyValuePair.Value);
      }
      return routeValueDictionary;
    }

    public static RouteValueDictionary ToRouteValueDictionary<T>(
      T obj,
      Dictionary<string, object>? args = null)
    {
      var datas = ((IEnumerable<PropertyInfo>) obj.GetType().GetProperties()).Where<PropertyInfo>((Func<PropertyInfo, bool>) (p => p.GetValue((object) (T) obj, (object[]) null) != null)).Select(p => new
      {
        Name = p.Name,
        Value = p.GetValue((object) (T) obj, (object[]) null)
      });
     

      RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
      foreach (var data in datas)
        routeValueDictionary.Add(data.Name, data.Value);
      if (args != null)
      {
        foreach (KeyValuePair<string, object> keyValuePair in args)
          routeValueDictionary.TryAdd(keyValuePair.Key, keyValuePair.Value);
      }
      return routeValueDictionary;
    }

    public static string ReplaceWithSpecialChar(
      string value,
      int startLen = 2,
      int endLen = 2,
      char specialChar = '*')
    {
      if (value == null)
        return "";
      switch (value.Length)
      {
        case 0:
        case 1:
        case 2:
          return "***";
        case 3:
          return value.Substring(0, 1) + "**";
        case 4:
          return value.Substring(0, 1) + "**" + value.Substring(3, 1);
        default:
          int startIndex = value.Length - 2;
          return value.Substring(0, 2) + "***" + value.Substring(startIndex, 2);
      }
    }

    public static void AddWatermark(
      string inputImagePath,
      string outputImagePath,
      string text,
      float offset_x,
      float offset_y,
      string fontFile,
      float fontSize,
      int r,
      int g,
      int b)
    {
      Image source = Image.Load(inputImagePath);
      int height = source.Height;
      int width = source.Width;
      Font font = new FontCollection().Add(fontFile).CreateFont(fontSize, FontStyle.Regular);
      TextOptions options = new TextOptions(font)
      {
        Dpi = 72f,
        KerningMode = KerningMode.Standard
      };
      TextMeasurer.MeasureSize(text, options);
      source.Mutate((Action<IImageProcessingContext>) (c => c.DrawText(text, font, new Color(new Rgba32((float) r, (float) g, (float) b)), new PointF((float) width - offset_x, (float) height - offset_y))));
      source.SaveAsJpeg(outputImagePath);
    }
  }
}
