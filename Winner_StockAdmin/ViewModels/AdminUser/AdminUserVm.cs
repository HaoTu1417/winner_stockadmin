// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.AdminUser.AdminUserVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.AdminUser
{
  public class AdminUserVm
  {
    public AdminUserFilter filter { get; set; }

    public IPagedList<AdminUserList> list { get; set; }

    public List<SelectListItem> roleDropdown { get; set; }
  }
}
