// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.UploadFileLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Microsoft.AspNetCore.Http;
using Models;
using RestSharp;
using stockadmin.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Libs
{
  public class UploadFileLib
  {
    public static async Task DeleteFile(FileManagementLib.Folder dir_name, string file_name)
    {
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("apifile/deletefile");
        request.AddParameter(nameof (dir_name), dir_name.ToString());
        request.AddParameter(nameof (file_name), file_name);
        APIResponse<UploadImagesResponse> apiResponse = await client.PostAsync<APIResponse<UploadImagesResponse>>(request);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }

    public static async Task DeleteFile(string file_url)
    {
      try
      {
        APIResponse apiResponse = await new RestClient(ConfigLib.Get("fileserver")).PostAsync<APIResponse>(new RestRequest("api/apifile/deletefile?file_name=" + file_url + "&dir_name=\"\""));
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }

    public static async Task<APIResponse<UploadFileResponse>> UploadFile(
      FileManagementLib.Folder img_folder,
      IFormFile? file)
    {
      APIResponse<UploadFileResponse> apiResponse;
      try
      {
        if (file == null)
          throw new AppException(2100, "upload_service_exception");
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiFile/uploadfile");
        request.AddParameter(nameof (img_folder), img_folder.ToString());
        MemoryStream target = new MemoryStream();
        file.CopyTo((Stream) target);
        request.AddFile(nameof (file), target.ToArray(), file.FileName, (ContentType) file.ContentType);
        apiResponse = await client.PostAsync<APIResponse<UploadFileResponse>>(request);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
      return apiResponse;
    }
  }
}
