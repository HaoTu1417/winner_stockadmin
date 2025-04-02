// Decompiled with JetBrains decompiler
// Type: stockadmin.Internal.APIResponse`1
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

#nullable enable
namespace stockadmin.Internal
{
  public class APIResponse<T>
  {
    public int status { get; set; }

    public string message { get; set; }

    public T data { get; set; }

    public static APIResponse<T> Error(int status, string message)
    {
      return new APIResponse<T>()
      {
        status = status,
        message = message
      };
    }

    public static APIResponse<T> Ok(T obj, string message = "")
    {
      return new APIResponse<T>()
      {
        status = 200,
        message = message,
        data = obj
      };
    }
  }
}
