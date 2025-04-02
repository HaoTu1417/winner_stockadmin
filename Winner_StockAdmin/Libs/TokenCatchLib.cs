// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.TokenCatchLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using stockadmin.Cache;
using stockadmin.Models;
using System;

#nullable enable
namespace stockadmin.Libs
{
    public class TokenCatchLib
    {
        public static TokenModel? GetToken(string key)
        {
            CacheQuery.SelectDB(CacheEnum.token);
            return CacheQuery.StringGet<TokenModel>(key);
        }

        public static void SetToken(string token, TokenModel data)
        {
            CacheQuery.SelectDB(CacheEnum.token);
            CacheQuery.StringSet<TokenModel>(token, data, new TimeSpan?(TimeSpan.FromMinutes(30.0)));
        }

        public static bool IsTokenExist(string token)
        {
            CacheQuery.SelectDB(CacheEnum.token);
            return CacheQuery.KeyExpire(token, new TimeSpan?(TimeSpan.FromMinutes(30.0)));
        }

        public static void RemoveToken(string token)
        {
            CacheQuery.SelectDB(CacheEnum.token);
            CacheQuery.KeyDelete(token);
        }
    }
}