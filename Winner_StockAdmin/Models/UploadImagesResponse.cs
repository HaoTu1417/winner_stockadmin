// Decompiled with JetBrains decompiler
// Type: Models.UploadImagesResponse
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System.Text.Json.Serialization;

#nullable enable
namespace Models
{
  public class UploadImagesResponse
  {
    [JsonPropertyName("server_url")]
    public string server_url { get; set; }

    [JsonPropertyName("img_urls")]
    public string[] img_urls { get; set; }
  }
}
