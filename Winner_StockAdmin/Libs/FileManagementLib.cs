// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.FileManagementLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Models;
using RestSharp;
using stockadmin.Internal;
using System;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Libs
{
  public class FileManagementLib
  {
    public static async Task<GetFilesResponse> GetFilesInDirectory(FileManagementLib.Folder dir_name)
    {
      GetFilesResponse filesInDirectory;
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiFile/getfilesindirectory");
        request.AddParameter(nameof (dir_name), dir_name.ToString());
        APIResponse<GetFilesResponse> apiResponse = await client.PostAsync<APIResponse<GetFilesResponse>>(request);
        filesInDirectory = apiResponse != null ? apiResponse.data : throw new AppException(apiResponse.status, apiResponse.message);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
      return filesInDirectory;
    }

    public static async Task<GetFilesResponse> GetAllFiles()
    {
      GetFilesResponse allFiles;
      try
      {
        APIResponse<GetFilesResponse> apiResponse = await new RestClient(ConfigLib.Get("fileserver") + "/api/").PostAsync<APIResponse<GetFilesResponse>>(new RestRequest("ApiFile/getallfiles"));
        allFiles = apiResponse != null ? apiResponse.data : throw new AppException(apiResponse.status, apiResponse.message);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
      return allFiles;
    }

    public static async Task CreateDirectory(FileManagementLib.Folder dir_name)
    {
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiFile/createdirectory");
        request.AddParameter(nameof (dir_name), dir_name.ToString());
        APIResponse apiResponse = await client.PostAsync<APIResponse>(request);
        if ((apiResponse != null ? (apiResponse.status != 200 ? 1 : 0) : 1) != 0)
          throw new AppException(apiResponse.status, apiResponse.message);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }

    public static async Task DeleteFile(FileManagementLib.Folder dir_name, string file_name)
    {
      try
      {
        RestClient client = new RestClient(ConfigLib.Get("fileserver") + "/api/");
        RestRequest request = new RestRequest("ApiFile/deletefile");
        request.AddParameter(nameof (dir_name), dir_name.ToString());
        request.AddParameter(nameof (file_name), file_name);
        APIResponse apiResponse = await client.PostAsync<APIResponse>(request);
        if ((apiResponse != null ? (apiResponse.status != 200 ? 1 : 0) : 1) != 0)
          throw new AppException(apiResponse.status, apiResponse.message);
      }
      catch (Exception ex)
      {
        throw new AppException(2100, "upload_service_exception");
      }
    }

    public enum Folder
    {
      flag = 1,
      id = 2,
      banner = 3,
      article = 4,
      message = 5,
      bank_book = 6,
      app_file = 7,
      advertise = 8,
      app_logo = 9,
    }
  }
}
