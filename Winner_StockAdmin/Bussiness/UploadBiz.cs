// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.UploadBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Business
{
  public class UploadBiz
  {
    public static async Task<string> UploadImage([FromForm] IFormFile image, FileManagementLib.Folder folder)
    {
      string str;
      try
      {
        string host = ConfigLib.Get("filesite");
        str = host + await UploadImageLib.UploadImage(folder, image);
      }
      catch (Exception ex)
      {
        throw new AppException("資料建立失敗");
      }
      return str;
    }
  }
}
