// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.MD5Service
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;
using System.Security.Cryptography;
using System.Text;

#nullable enable
namespace stockadmin.Libs
{
  public class MD5Service
  {
    public static string GetMD5String(string str, MD5Service.EncodingType encodingType = MD5Service.EncodingType.ASCII)
    {
      MD5 md5 = MD5.Create();
      byte[] bytes;
      switch (encodingType)
      {
        case MD5Service.EncodingType.UTF8:
          bytes = Encoding.UTF8.GetBytes(str);
          break;
        case MD5Service.EncodingType.ASCII:
          bytes = Encoding.ASCII.GetBytes(str);
          break;
        default:
          return "";
      }
      byte[] hash = md5.ComputeHash(bytes);
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("X2"));
      return stringBuilder.ToString();
    }

    public static string MD5Password(string password)
    {
      string empty = string.Empty;
      byte[] hash1 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash1.Length; ++index)
        stringBuilder.Append(hash1[index].ToString("X2"));
      byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
      byte[] hash2;
      using (SHA256 shA256 = SHA256.Create())
        hash2 = shA256.ComputeHash(bytes);
      return BitConverter.ToString(hash2).Replace("-", "").ToLower();
    }

    public static string Addmd5(string key)
    {
      byte[] hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(key));
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("X2"));
      return stringBuilder.ToString();
    }

    public enum EncodingType
    {
      UTF8,
      ASCII,
    }
  }
}
