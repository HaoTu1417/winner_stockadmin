// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AppLogoController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.AppLogo;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AppLogo")]
  public class AppLogoController : BaseController
  {
    public void SetSelect(string lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
      // ISSUE: reference to a compiler-generated field
      if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, new List<SelectListItem>());
      if (lang.ToUpper() == "VN")
      {
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__4 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target1 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__4.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p4 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__4;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__3, this.ViewBag);
        target1((CallSite) p4, obj4, new SelectListItem()
        {
          Text = "Vui lòng chọn một loại",
          Value = "0",
          Selected = true
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__6 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target2 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p6 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__5.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__5, this.ViewBag);
        target2((CallSite) p6, obj5, new SelectListItem()
        {
          Text = "Logo trang đăng nhập(131x180)",
          Value = "1",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__8 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target3 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__8.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p8 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__8;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj6 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__7.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__7, this.ViewBag);
        target3((CallSite) p8, obj6, new SelectListItem()
        {
          Text = "Logo trang tải xuống (245x104)",
          Value = "2",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__10 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target4 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__10.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p10 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__10;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj7 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__9.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__9, this.ViewBag);
        target4((CallSite) p10, obj7, new SelectListItem()
        {
          Text = "Tải ảnh nền trang xuống (750x1000)",
          Value = "3",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__12 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__12 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target5 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__12.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p12 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__12;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__11.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__11, this.ViewBag);
        target5((CallSite) p12, obj8, new SelectListItem()
        {
          Text = "Logo chung phải trên nền trắng (187x38)",
          Value = "4",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__14 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target6 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p14 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj9 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__13.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__13, this.ViewBag);
        target6((CallSite) p14, obj9, new SelectListItem()
        {
          Text = "Bản đồ cơ sở khuyến mãi (750x978)",
          Value = "5",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__16 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target7 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__16.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p16 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__16;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj10 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__15.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__15, this.ViewBag);
        target7((CallSite) p16, obj10, new SelectListItem()
        {
          Text = "Hướng dẫn tải iOS (600x800)",
          Value = "6",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__18 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target8 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__18.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p18 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__18;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj11 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__17.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__17, this.ViewBag);
        target8((CallSite) p18, obj11, new SelectListItem()
        {
          Text = "Hình ảnh chỉ báo tải xuống Android (600x800)",
          Value = "7",
          Selected = false
        });
      }
      else if (lang.ToUpper() == "CN")
      {
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__20 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target9 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__20.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p20 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__20;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj12 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__19.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__19, this.ViewBag);
        target9((CallSite) p20, obj12, new SelectListItem()
        {
          Text = "請選擇種類",
          Value = "0",
          Selected = true
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__22 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__22 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target10 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__22.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p22 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__22;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj13 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__21.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__21, this.ViewBag);
        target10((CallSite) p22, obj13, new SelectListItem()
        {
          Text = "登入頁面logo(131x180)",
          Value = "1",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__24 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__24 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target11 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__24.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p24 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__24;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj14 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__23.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__23, this.ViewBag);
        target11((CallSite) p24, obj14, new SelectListItem()
        {
          Text = "下載頁面logo(245x104)",
          Value = "2",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__26 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__26 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target12 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__26.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p26 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__26;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj15 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__25.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__25, this.ViewBag);
        target12((CallSite) p26, obj15, new SelectListItem()
        {
          Text = "下載頁面背景圖(750x1000)",
          Value = "3",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__28 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__28 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target13 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__28.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p28 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__28;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__27 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj16 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__27.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__27, this.ViewBag);
        target13((CallSite) p28, obj16, new SelectListItem()
        {
          Text = "通用logo 須為白底(187x38)",
          Value = "4",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__30 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__30 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target14 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__30.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p30 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__30;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__29 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj17 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__29.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__29, this.ViewBag);
        target14((CallSite) p30, obj17, new SelectListItem()
        {
          Text = "推廣底圖(750x978)",
          Value = "5",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__32 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__32 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target15 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__32.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p32 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__32;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__31 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__31 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj18 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__31.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__31, this.ViewBag);
        target15((CallSite) p32, obj18, new SelectListItem()
        {
          Text = "IOS下載指示圖(600x800)",
          Value = "6",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__34 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__34 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target16 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__34.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p34 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__34;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__33 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__33 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj19 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__33.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__33, this.ViewBag);
        target16((CallSite) p34, obj19, new SelectListItem()
        {
          Text = "Android下載指示圖(600x800)",
          Value = "7",
          Selected = false
        });
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__36 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__36 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target17 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__36.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p36 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__36;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__35 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__35 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj20 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__35.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__35, this.ViewBag);
        target17((CallSite) p36, obj20, new SelectListItem()
        {
          Text = "Select type",
          Value = "0",
          Selected = true
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__38 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__38 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target18 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__38.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p38 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__38;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__37 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__37 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj21 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__37.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__37, this.ViewBag);
        target18((CallSite) p38, obj21, new SelectListItem()
        {
          Text = "Logo in login page(131x180)",
          Value = "1",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__40 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__40 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target19 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__40.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p40 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__40;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__39 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__39 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj22 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__39.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__39, this.ViewBag);
        target19((CallSite) p40, obj22, new SelectListItem()
        {
          Text = "Logo in Download page(245x104)",
          Value = "2",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__42 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__42 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target20 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__42.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p42 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__42;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__41 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__41 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj23 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__41.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__41, this.ViewBag);
        target20((CallSite) p42, obj23, new SelectListItem()
        {
          Text = "Background in Download page(750x1000)",
          Value = "3",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__44 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__44 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target21 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__44.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p44 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__44;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__43 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__43 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj24 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__43.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__43, this.ViewBag);
        target21((CallSite) p44, obj24, new SelectListItem()
        {
          Text = "General logo must be white background(187x38)",
          Value = "4",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__46 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__46 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target22 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__46.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p46 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__46;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__45 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__45 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj25 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__45.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__45, this.ViewBag);
        target22((CallSite) p46, obj25, new SelectListItem()
        {
          Text = "Background in recommend page(750x978)",
          Value = "5",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__48 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__48 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target23 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__48.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p48 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__48;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__47 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__47 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj26 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__47.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__47, this.ViewBag);
        target23((CallSite) p48, obj26, new SelectListItem()
        {
          Text = "IOS download instructions(600x800)",
          Value = "6",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__50 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__50 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target24 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__50.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p50 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__50;
        // ISSUE: reference to a compiler-generated field
        if (AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__49 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__49 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "types", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj27 = AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__49.Target((CallSite) AppLogoController.\u003C\u003Eo__0.\u003C\u003Ep__49, this.ViewBag);
        target24((CallSite) p50, obj27, new SelectListItem()
        {
          Text = "Android download instructions(600x800)",
          Value = "7",
          Selected = false
        });
      }
    }

    [MenuFilter(91, 9)]
    public IActionResult Index(int page = 1, int pageSize = 20)
    {
      this.SetSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (AppLogoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) AppLogoController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      AppLogoVm appLogoVm = new AppLogoVm();
      try
      {
        List<AppLogoList> appLogoList = AppLogoBiz.GetAppLogoList(this.GetUser().lang);
        appLogoVm.list = appLogoList.ToPagedList<AppLogoList>(page, pageSize);
        return (IActionResult) this.View((object) appLogoVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) appLogoVm);
      }
    }

    [UseFilter(91, 9)]
    public IActionResult Edit(int cms_files_fk)
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AppLogoDto>(AppLogoBiz.Get(cms_files_fk)));
    }

    public async Task<IActionResult> PostEdit(AppLogoDto req)
    {
      AppLogoController appLogoController = this;
      appLogoController.SetSelect(appLogoController.GetUser().lang);
      try
      {
        await AppLogoBiz.PostEdit(req, appLogoController.GetUser());
        return (IActionResult) ((ControllerBase) appLogoController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        appLogoController.ShowError(ex.Message);
        return (IActionResult) appLogoController.View("Edit", (object) req);
      }
    }

    [UseFilter(91, 9)]
    public IActionResult Create()
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) new AppLogoDto());
    }

    public async Task<IActionResult> PostCreate(AppLogoDto req)
    {
      AppLogoController appLogoController = this;
      appLogoController.SetSelect(appLogoController.GetUser().lang);
      try
      {
        await AppLogoBiz.PostCreate(req, appLogoController.GetUser());
        return (IActionResult) ((ControllerBase) appLogoController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        appLogoController.ShowError(ex.Message);
        return (IActionResult) appLogoController.View("Create", (object) req);
      }
    }

    [UseFilter(91, 9)]
    public async Task<IActionResult> Delete(int cms_files_fk)
    {
      AppLogoController appLogoController = this;
      try
      {
        await AppLogoBiz.Delete(cms_files_fk, appLogoController.GetUser());
        return (IActionResult) ((ControllerBase) appLogoController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        appLogoController.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) appLogoController).RedirectToAction("Index");
      }
    }
  }
}
