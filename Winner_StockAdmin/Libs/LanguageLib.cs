// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.LanguageLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using Newtonsoft.Json.Linq;
using stockadmin.Cache;

#nullable enable
namespace stockadmin.Libs
{
    public class LanguageLib
    {
        public static string GetWarningMsg(string lang)
        {
            MutilangCacheDto mutilangCacheDto = MutilangCacheService.Find("warning", lang.ToLower());
            return mutilangCacheDto != null ? mutilangCacheDto.value : MutilangService.Find("warning").template;
        }

        public static void InitErrorMsgCache()
        {
            CacheQuery.SelectDB(CacheEnum.language);
            foreach (MutilangSubjectDto mutilangSubjectDto in MutilangSubjectService.FindAll())
                LanguageLib.InitLangErrorMsgCache(mutilangSubjectDto.lang.ToLower());
        }

        public static void InitLangErrorMsgCache(string lang)
        {
            CacheQuery.SelectDB(CacheEnum.language);
            foreach (JProperty property in JObject.Parse(LanguageLib.GetWarningMsg(lang)).Properties())
            {
                string name = property.Name;
                string str = property.Value.ToString();
                CacheQuery.HashSet(lang.ToLower() + "_error", name, str);
            }
        }

        public static string GetErrorTranslate(string lang, string key)
        {
            if (key == "redis_exception")
                return "翻译檔不存在";
            lang = lang.ToLower();
            CacheQuery.SelectDB(CacheEnum.language);
            string redisKey = lang + "_error";
            return !CacheQuery.HashExists(redisKey, key) ? key + "(找不到翻译档)" : (string) CacheQuery.HashGet(redisKey, key);
        }
    }
}