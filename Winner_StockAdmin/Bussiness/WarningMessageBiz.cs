// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WarningMessageBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using Newtonsoft.Json;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.WarningMessage;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class WarningMessageBiz
  {
    public static List<SelectListItem> FindSelectList()
    {
      List<SelectListItem> selectList = new List<SelectListItem>();
      foreach (MutilangSubjectDto mutilangSubjectDto in MutilangSubjectService.FindAll())
        selectList.Add(new SelectListItem()
        {
          Value = mutilangSubjectDto.lang,
          Text = mutilangSubjectDto.title + "(" + mutilangSubjectDto.lang + ")"
        });
      return selectList;
    }

    public static DataCountBase<WarningMessageList> GetWarningMessageList(
      WarningMessageFilter filter,
      int page,
      int pageSize)
    {
      SqlTool.Build<WarningMessageFilter>(filter);
      IEnumerable<WarningMessageList> source = PublicTool.FromJson<Dictionary<string, string>>(MutilangService.Find("warning").template).Join<KeyValuePair<string, string>, KeyValuePair<string, string>, string, WarningMessageList>((IEnumerable<KeyValuePair<string, string>>) PublicTool.FromJson<Dictionary<string, string>>(MutilangCacheService.FindJson("warning", filter.lang)), (Func<KeyValuePair<string, string>, string>) (templateItem => templateItem.Key), (Func<KeyValuePair<string, string>, string>) (langCacheItem => langCacheItem.Key), (Func<KeyValuePair<string, string>, KeyValuePair<string, string>, WarningMessageList>) ((templateItem, langCacheItem) => new WarningMessageList()
      {
        key = templateItem.Key,
        description = templateItem.Value,
        translation = langCacheItem.Value
      }));
      if (!string.IsNullOrEmpty(filter.search_text))
        source = source.Where<WarningMessageList>((Func<WarningMessageList, bool>) (o => o.key.Contains(filter.search_text) || o.description.Contains(filter.search_text) || o.translation.Contains(filter.search_text)));
      return new DataCountBase<WarningMessageList>(source.Count<WarningMessageList>(), (IEnumerable<WarningMessageList>) source.Skip<WarningMessageList>((page - 1) * pageSize).Take<WarningMessageList>(pageSize).ToList<WarningMessageList>());
    }

    public static WarningMessageDto GetTranslateByKey(string lang, string messageKey)
    {
      return PublicTool.FromJson<Dictionary<string, string>>(MutilangService.Find("warning").template).Join<KeyValuePair<string, string>, KeyValuePair<string, string>, string, WarningMessageDto>((IEnumerable<KeyValuePair<string, string>>) PublicTool.FromJson<Dictionary<string, string>>(MutilangCacheService.FindJson("warning", lang)), (Func<KeyValuePair<string, string>, string>) (templateItem => templateItem.Key), (Func<KeyValuePair<string, string>, string>) (langCacheItem => langCacheItem.Key), (Func<KeyValuePair<string, string>, KeyValuePair<string, string>, WarningMessageDto>) ((templateItem, langCacheItem) => new WarningMessageDto()
      {
        lang = lang,
        key = templateItem.Key,
        desc = templateItem.Value,
        translation = langCacheItem.Value
      })).FirstOrDefault<WarningMessageDto>((Func<WarningMessageDto, bool>) (kv => kv.key == messageKey));
    }

    public static void PostEdit(WarningMessageDto req, AdminSession adminUser)
    {
      MutilangCacheDto model = MutilangCacheService.Find("warning", req.lang);
      Dictionary<string, string> dictionary1 = PublicTool.FromJson<Dictionary<string, string>>(model.value);
      Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
      foreach (KeyValuePair<string, string> keyValuePair in dictionary1)
      {
        if (keyValuePair.Key == req.key)
          dictionary2.Add(keyValuePair.Key, req.translation);
        else
          dictionary2.Add(keyValuePair.Key, keyValuePair.Value);
      }
      model.value = JsonConvert.SerializeObject((object) dictionary2);
      if (MutilangCacheService.Update(model) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.key
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 439,
        list = objArray
      });
    }
  }
}
