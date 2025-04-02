// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminConfig.AdminConfigVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.AdminConfig
{
    public class AdminConfigVm
    {
        public AdminConfigFilter filter { get; set; }

        public IPagedList<AdminConfigList> list { get; set; }
    }
}