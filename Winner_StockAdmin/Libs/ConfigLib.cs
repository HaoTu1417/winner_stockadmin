// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.ConfigLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Cache;
using stockadmin.Internal;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Libs
{
  public class ConfigLib
  {
    private static string ConfigCacheTable = "AdminConfig";

    public static void Reset()
    {
      CacheQuery.SelectDB(CacheEnum.admin);
      CacheQuery.KeyDelete(ConfigLib.ConfigCacheTable);
      List<AdminConfigDto> all = AdminConfigService.FindAll();
      if (all.Count <= 0)
        return;
      foreach (AdminConfigDto adminConfigDto in all)
        CacheQuery.HashSet(ConfigLib.ConfigCacheTable, adminConfigDto.name, adminConfigDto.value);
    }

    public static string Get(string key)
    {
      try
      {
        CacheQuery.SelectDB(CacheEnum.admin);
        if (!CacheQuery.KeyExists(ConfigLib.ConfigCacheTable))
        {
          List<AdminConfigDto> all = AdminConfigService.FindAll();
          if (all.Count <= 0)
            throw new AppException(790, "undefine_redis_key");
          foreach (AdminConfigDto adminConfigDto in all)
            CacheQuery.HashSet(ConfigLib.ConfigCacheTable, adminConfigDto.name, adminConfigDto.value);
        }
        if (!CacheQuery.HashExists(ConfigLib.ConfigCacheTable, key))
        {
          AdminConfigDto adminConfigDto = AdminConfigService.Find(key);
          if (adminConfigDto == null)
            throw new AppException(790, "undefine_redis_key");
          CacheQuery.HashSet(ConfigLib.ConfigCacheTable, adminConfigDto.name, adminConfigDto.value);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[ConfigLib][Get]" + ex.Message);
        throw new AppException(800, "illegal_read_redis_key");
      }
      return (string) CacheQuery.HashGet(ConfigLib.ConfigCacheTable, key);
    }
  }
}
