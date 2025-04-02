// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.UploadImageLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Http;
using Models;
using Models.Dto;
using RestSharp;
using stockadmin.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Libs
{
  public class UploadImageLib
  {
    public static async Task<List<int>> UploadImages(
      FileManagementLib.Folder img_folder,
      string table_name,
      int pk,
      bool change_name,
      List<IFormFile> images,
      string watermark = "",
      int watermark_size = 0,
      int watermark_color = 0)
    {
      List<int> intList;
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiImg/uploadimages");
        request.AddParameter(nameof (img_folder), img_folder.ToString());
        request.AddParameter<bool>(nameof (change_name), change_name);
        if (watermark != null && watermark != "")
        {
          request.AddParameter(nameof (watermark), watermark);
          request.AddParameter(nameof (watermark_size), watermark_size.ToString());
          request.AddParameter(nameof (watermark_color), watermark_color.ToString());
        }
        List<int> pks = new List<int>();
        foreach (IFormFile image in images)
        {
          MemoryStream memoryStream = new MemoryStream();
          image.CopyTo((Stream) memoryStream);
          request.AddFile(nameof (images), memoryStream.ToArray(), image.FileName, (ContentType) image.ContentType);
        }
        APIResponse<UploadImagesResponse> apiResponse = await client.PostAsync<APIResponse<UploadImagesResponse>>(request);
        if (apiResponse != null)
        {
          foreach (string imgUrl in apiResponse.data.img_urls)
            pks.Add(CmsFilesService.FindPkAfterInsert(new CmsFilesDto()
            {
              url = imgUrl,
              file_type = 1,
              table = table_name,
              key = pk
            }));
        }
        intList = pks;
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
      return intList;
    }

    public static async Task<List<int>> UploadImage(
      FileManagementLib.Folder img_folder,
      string table_name,
      int pk,
      bool change_name,
      IFormFile image,
      string watermark = "",
      int watermark_size = 0,
      int watermark_color = 0)
    {
      return await UploadImageLib.UploadImages(img_folder, table_name, pk, change_name, new List<IFormFile>()
      {
        image
      }, watermark, watermark_size, watermark_color);
    }

    public static async Task UpdateUploadImage(
      FileManagementLib.Folder img_folder,
      string table_name,
      int pk,
      bool change_name,
      IFormFile image)
    {
      await UploadImageLib.UpdateUploadImages(img_folder, table_name, pk, change_name, new List<IFormFile>()
      {
        image
      });
    }

    public static async Task UpdateUploadImages(
      FileManagementLib.Folder img_folder,
      string table_name,
      int pk,
      bool change_name,
      List<IFormFile> images)
    {
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiImg/uploadimages");
        request.AddParameter(nameof (img_folder), img_folder.ToString());
        request.AddParameter<bool>(nameof (change_name), change_name);
        List<int> intList = new List<int>();
        foreach (IFormFile image in images)
        {
          MemoryStream memoryStream = new MemoryStream();
          image.CopyTo((Stream) memoryStream);
          request.AddFile(nameof (images), memoryStream.ToArray(), image.FileName, (ContentType) image.ContentType);
        }
        APIResponse<UploadImagesResponse> apiResponse = await client.PostAsync<APIResponse<UploadImagesResponse>>(request);
        if (apiResponse == null)
          return;
        foreach (string imgUrl in apiResponse.data.img_urls)
          CmsFilesService.Update(new CmsFilesDto()
          {
            url = imgUrl,
            file_type = 1,
            table = table_name,
            pk = pk
          });
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }

    public static async Task<string> UploadImage(
      FileManagementLib.Folder img_folder,
      IFormFile image,
      string watermark = "",
      int watermark_size = 0,
      int watermark_color = 0)
    {
      string imgUrl1;
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiImg/uploadimages");
        request.AddParameter(nameof (img_folder), img_folder.ToString());
        request.AddParameter<bool>("change_name", true);
        if (watermark != null && watermark != "")
        {
          request.AddParameter(nameof (watermark), watermark);
          request.AddParameter(nameof (watermark_size), watermark_size.ToString());
          request.AddParameter(nameof (watermark_color), watermark_color.ToString());
        }
        List<int> intList = new List<int>();
        MemoryStream memoryStream = new MemoryStream();
        image.CopyTo((Stream) memoryStream);
        request.AddFile("images", memoryStream.ToArray(), image.FileName, (ContentType) image.ContentType);
        APIResponse<UploadImagesResponse> apiResponse = await client.PostAsync<APIResponse<UploadImagesResponse>>(request);
        if (apiResponse == null)
          throw new AppException(2100, "upload_service_exception");
        foreach (string imgUrl2 in apiResponse.data.img_urls)
          CmsFilesService.FindPkAfterInsert(new CmsFilesDto()
          {
            url = imgUrl2,
            file_type = 1,
            table = "",
            key = 0
          });
        imgUrl1 = apiResponse.data.img_urls[0];
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
      return imgUrl1;
    }

    public static string RemoveHostName(string content)
    {
      try
      {
        string oldValue = ConfigLib.Get("filesite");
        return content.Replace(oldValue, "#0#");
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }

    public static string AddHostName(string content)
    {
      try
      {
        string newValue = ConfigLib.Get("filesite");
        return content.Replace("#0#", newValue);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }
  }
}
