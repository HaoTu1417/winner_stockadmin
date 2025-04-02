// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.EmailVerificationCodeBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using StackExchange.Redis;
using stockadmin.Cache;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.EmailVerificationCode;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class EmailVerificationCodeBiz
  {
    public static DataCountBase<EmailVerificationCodeList> GetList(
      EmailVerificationCodeFilter? filter,
      int page,
      int pageSize)
    {
      CacheQuery.SelectDB(CacheEnum.email_verification);
      IEnumerable<RedisKey> keys = CacheQuery.GetKeys(CacheEnum.email_verification);
      List<EmailVerificationCodeList> data = new List<EmailVerificationCodeList>();
      foreach (RedisKey redisKey in keys)
        data.Add(new EmailVerificationCodeList()
        {
          email = (string) redisKey,
          code = CacheQuery.StringGet((string) redisKey)
        });
      return new DataCountBase<EmailVerificationCodeList>(data.Count, (IEnumerable<EmailVerificationCodeList>) data);
    }
  }
}
