// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RecommendRegisterBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.RecommendRegister;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class RecommendRegisterBiz
  {
    public static DataCountBase<RecommendRegisterList> GetRecommendRegisterList(
      RecommendRegisterFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<RecommendRegisterFilter>(filter).Must("member.is_test_account = 0 and member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<RecommendRegisterList> recommendRegisterList = RecommendRegisterService.FindRecommendRegisterList(page, pageSize, str);
      return new DataCountBase<RecommendRegisterList>(recommendRegisterList.count, recommendRegisterList.data.Select<RecommendRegisterList, RecommendRegisterList>((Func<RecommendRegisterList, RecommendRegisterList>) (recommned => PublicTool.convertUtcToLocalTime<RecommendRegisterList>(recommned))));
    }

    public static RecommendRegisterDto Get(int member_fk)
    {
      return RecommendRegisterService.Find(member_fk);
    }

    public static void PostCreate(RecommendRegisterDto req)
    {
      if (RecommendRegisterService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(RecommendRegisterDto req)
    {
      if (RecommendRegisterService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int member_fk) => RecommendRegisterService.Remove(member_fk);

    public static RecommendRegisterList GetDetailVm(int beinvite)
    {
      return RecommendRegisterService.FindRecommendRegister(beinvite);
    }
  }
}
