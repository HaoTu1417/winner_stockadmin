// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MultiLangBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using Newtonsoft.Json;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.MultiLang;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class MultiLangBiz
  {
    public static void MultilangSync(string key, AdminSession adminUser)
    {
      MutilangDto mutilangDto = MutilangService.Find(key);
      foreach (MutilangSubjectDto mutilangSubjectDto in MutilangSubjectService.FindAll().FindAll((Predicate<MutilangSubjectDto>) (x => x.enable == 1)))
      {
        Dictionary<string, string> first = PublicTool.FromJson<Dictionary<string, string>>(mutilangDto.template);
        MutilangCacheDto mutilangCacheDto = MutilangCacheService.Find(mutilangDto.key, mutilangSubjectDto.lang);
        if (mutilangCacheDto == null)
        {
          MutilangCacheService.Insert(new MutilangCacheDto()
          {
            key = mutilangDto.key,
            lang = mutilangSubjectDto.lang,
            value = JsonConvert.SerializeObject((object) first)
          });
        }
        else
        {
          Dictionary<string, string> second = PublicTool.FromJson<Dictionary<string, string>>(mutilangCacheDto.value);
          Dictionary<string, string> dictionary = first.Concat<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>) second).GroupBy<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>) (x => x.Key)).ToDictionary<IGrouping<string, KeyValuePair<string, string>>, string, string>((Func<IGrouping<string, KeyValuePair<string, string>>, string>) (x => x.Key), (Func<IGrouping<string, KeyValuePair<string, string>>, string>) (x => x.Last<KeyValuePair<string, string>>().Value));
          MutilangCacheService.Update(new MutilangCacheDto()
          {
            key = mutilangDto.key,
            lang = mutilangSubjectDto.lang,
            value = JsonConvert.SerializeObject((object) dictionary)
          });
        }
      }
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) key
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 9,
        list = objArray
      });
    }

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

    public static List<MultiLangLanghList> GetSearchList() => new List<MultiLangLanghList>();

    public static MutilangSubjectDto GetByLang(string lang) => MutilangSubjectService.Find(lang);

    public static int Edit(MultiLangLangVm vm)
    {
      return MutilangSubjectService.UpdateFull(new MutilangSubjectDto()
      {
        lang = vm.lang,
        title = vm.title,
        enable = vm.enable,
        admin_default = vm.admin_default,
        app_default = vm.app_default
      });
    }

    public static List<MultilangList> GetList(MultilangFilter filter)
    {
      return MutilangService.FindMutilangList(SqlTool.Build<MultilangFilter>(filter));
    }

    public static List<MultiLangCacheSearchList> GetMultiLangCacheList(
      MultiLangCacheSearchFilter filter)
    {
      string where = SqlTool.Build<MultiLangCacheSearchFilter>(filter);
      MutilangDto mutilangDto = MutilangService.Find(filter.key);
      List<MutilangCacheDto> multiLangCacheList1 = MutilangCacheService.GetMultiLangCacheList(where);
      Dictionary<string, string> dictionary = PublicTool.FromJson<Dictionary<string, string>>(mutilangDto.template);
      List<MultiLangCacheSearchList> multiLangCacheList2 = new List<MultiLangCacheSearchList>();
      foreach (KeyValuePair<string, string> keyValuePair in dictionary)
      {
        KeyValuePair<string, string> dic = keyValuePair;
        foreach (MutilangCacheDto mutilangCacheDto in multiLangCacheList1)
        {
          Dictionary<string, string> source = PublicTool.FromJson<Dictionary<string, string>>(mutilangCacheDto.value);
          multiLangCacheList2.Add(new MultiLangCacheSearchList()
          {
            lang = mutilangCacheDto.lang,
            key = dic.Key,
            description = dic.Value,
            translation = (source != null ? source.FirstOrDefault<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key == dic.Key)).Value : (string) null) ?? ""
          });
        }
      }
      return multiLangCacheList2;
    }

    public static MultiLangCacheEditVm GetTranslateByKey(string key, string lang, string valKey)
    {
      Dictionary<string, string> dictionary = PublicTool.FromJson<Dictionary<string, string>>(MutilangCacheService.Find(key, lang).value);
      string empty = string.Empty;
      foreach (KeyValuePair<string, string> keyValuePair in dictionary)
      {
        if (keyValuePair.Key == valKey)
          empty = keyValuePair.Value;
      }
      return new MultiLangCacheEditVm()
      {
        key = key,
        lang = lang,
        translationKey = valKey,
        translation = empty
      };
    }

    public static int EditMultilangTranslate(MultiLangCacheEditVm req, AdminSession adminUser)
    {
      MutilangCacheDto model = MutilangCacheService.Find(req.key, req.lang);
      Dictionary<string, string> dictionary1 = PublicTool.FromJson<Dictionary<string, string>>(model.value);
      Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
      foreach (KeyValuePair<string, string> keyValuePair in dictionary1)
      {
        if (keyValuePair.Key == req.translationKey)
          dictionary2.Add(keyValuePair.Key, req.translation);
        else
          dictionary2.Add(keyValuePair.Key, keyValuePair.Value);
      }
      model.value = JsonConvert.SerializeObject((object) dictionary2);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.key
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 8,
        list = objArray
      });
      return MutilangCacheService.Update(model);
    }
  }
}
