// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletRecordBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.WalletRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class WalletRecordBiz
  {
    public static List<WalletRecordList> GetWalletRecordList(int id, int page, int pageSize)
    {
      List<WalletRecordList> walletRecordList = WalletRecordService.FindWalletRecordList(id, page, pageSize);
      return walletRecordList == null ? (List<WalletRecordList>) null : walletRecordList.Select<WalletRecordList, WalletRecordList>((Func<WalletRecordList, WalletRecordList>) (walletRecord => PublicTool.convertUtcToLocalTime<WalletRecordList>(walletRecord))).ToList<WalletRecordList>();
    }

    public static List<WalletRecordList> GetWalletRecordListByAdminDefaultLang(
      int id,
      int page,
      int pageSize)
    {
      MutilangSubjectDto adminDefault = MutilangSubjectBiz.GetAdminDefault();
      List<WalletRecordList> walletRecordList1 = WalletRecordService.FindWalletRecordList(id, page, pageSize, adminDefault.lang);
      return walletRecordList1 != null ? walletRecordList1.Select<WalletRecordList, WalletRecordList>((Func<WalletRecordList, WalletRecordList>) (walletRecord =>
      {
        PublicTool.convertUtcToLocalTime<WalletRecordList>(walletRecord);
        string[] strArray = walletRecord.param?.Split('|', StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index = 0; index < strArray.Length; ++index)
          {
            WalletRecordList walletRecordList2 = walletRecord;
            string template = walletRecord.template;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
            interpolatedStringHandler.AppendLiteral("#");
            interpolatedStringHandler.AppendFormatted<int>(index);
            interpolatedStringHandler.AppendLiteral("#");
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            string newValue = strArray[index]?.ToString();
            string str = template.Replace(stringAndClear, newValue);
            walletRecordList2.template = str;
          }
          walletRecord.info = walletRecord.template;
        }
        return walletRecord;
      })).ToList<WalletRecordList>() : (List<WalletRecordList>) null;
    }

    public static WalletRecordDto Get(int pk) => WalletRecordService.Find(pk);

    public static void PostCreate(WalletRecordDto req)
    {
      if (WalletRecordService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(WalletRecordDto req)
    {
      if (WalletRecordService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => WalletRecordService.Remove(pk);
  }
}
