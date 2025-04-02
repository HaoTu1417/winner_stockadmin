// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.BannerController
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
using stockadmin.ViewModels.Banner;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Banner")]
  public class BannerController : BaseController
  {
    public void SetSelect(string lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      if (lang == "EN")
      {
        selectListItemList.Add(new SelectListItem()
        {
          Text = "PC",
          Value = "0",
          Selected = false
        });
        selectListItemList.Add(new SelectListItem()
        {
          Text = "Phone",
          Value = "1",
          Selected = false
        });
      }
      else
      {
        selectListItemList.Add(new SelectListItem()
        {
          Text = "桌機",
          Value = "0",
          Selected = false
        });
        selectListItemList.Add(new SelectListItem()
        {
          Text = "手機",
          Value = "1",
          Selected = false
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sizes", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, selectListItemList);
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__3, this.ViewBag, new List<SelectListItem>());
      if (lang == "EN")
      {
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__5 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target1 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p5 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__4.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__4, this.ViewBag);
        target1((CallSite) p5, obj5, new SelectListItem()
        {
          Text = "Select color",
          Value = "0",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__7 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target2 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__7.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p7 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__7;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj6 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__6.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__6, this.ViewBag);
        target2((CallSite) p7, obj6, new SelectListItem()
        {
          Text = "Red",
          Value = "1",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__9 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target3 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__9.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p9 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__9;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj7 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__8.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__8, this.ViewBag);
        target3((CallSite) p9, obj7, new SelectListItem()
        {
          Text = "Blue",
          Value = "2",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__11 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target4 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__11.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p11 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__11;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__10.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__10, this.ViewBag);
        target4((CallSite) p11, obj8, new SelectListItem()
        {
          Text = "Green",
          Value = "3",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__13 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target5 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__13.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p13 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__13;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__12 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj9 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__12.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__12, this.ViewBag);
        target5((CallSite) p13, obj9, new SelectListItem()
        {
          Text = "White",
          Value = "4",
          Selected = false
        });
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__15 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target6 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__15.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p15 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__15;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj10 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__14.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__14, this.ViewBag);
        target6((CallSite) p15, obj10, new SelectListItem()
        {
          Text = "請選擇顏色",
          Value = "0",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__17 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target7 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__17.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p17 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__17;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj11 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__16.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__16, this.ViewBag);
        target7((CallSite) p17, obj11, new SelectListItem()
        {
          Text = "紅",
          Value = "1",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__19 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target8 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__19.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p19 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__19;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj12 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__18.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__18, this.ViewBag);
        target8((CallSite) p19, obj12, new SelectListItem()
        {
          Text = "藍",
          Value = "2",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__21 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target9 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__21.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p21 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__21;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj13 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__20.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__20, this.ViewBag);
        target9((CallSite) p21, obj13, new SelectListItem()
        {
          Text = "綠",
          Value = "3",
          Selected = false
        });
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__23 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target10 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__23.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p23 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__23;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__22 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_colors", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj14 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__22.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__22, this.ViewBag);
        target10((CallSite) p23, obj14, new SelectListItem()
        {
          Text = "白",
          Value = "4",
          Selected = false
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__24 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__0.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "watermark_sizes", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj15 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__24.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__24, this.ViewBag, new List<SelectListItem>());
      if (lang == "EN")
      {
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__26 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__26 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__26.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p26 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__26;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_sizes", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj16 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__25.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__25, this.ViewBag);
        target((CallSite) p26, obj16, new SelectListItem()
        {
          Text = "Select size",
          Value = "0",
          Selected = false
        });
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__28 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__28 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__28.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p28 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__28;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__27 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_sizes", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj17 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__27.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__27, this.ViewBag);
        target((CallSite) p28, obj17, new SelectListItem()
        {
          Text = "請選擇大小",
          Value = "0",
          Selected = false
        });
      }
      for (int index = 14; index <= 120; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__30 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__30 = CallSite<Action<CallSite, object, SelectListItem>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, object, SelectListItem> target = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__30.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, object, SelectListItem>> p30 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__30;
        // ISSUE: reference to a compiler-generated field
        if (BannerController.\u003C\u003Eo__0.\u003C\u003Ep__29 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BannerController.\u003C\u003Eo__0.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "watermark_sizes", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj18 = BannerController.\u003C\u003Eo__0.\u003C\u003Ep__29.Target((CallSite) BannerController.\u003C\u003Eo__0.\u003C\u003Ep__29, this.ViewBag);
        target((CallSite) p30, obj18, new SelectListItem()
        {
          Text = index.ToString(),
          Value = index.ToString(),
          Selected = false
        });
      }
    }

    [MenuFilter(220, 7)]
    public IActionResult Index(BannerFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = BannerController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) BannerController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (BannerController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BannerController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (BannerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = BannerController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) BannerController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      BannerVm bannerVm = new BannerVm()
      {
        filter = filter ?? new BannerFilter()
      };
      try
      {
        List<BannerList> bannerList = BannerBiz.GetBannerList(bannerVm.filter, this.GetUser().lang);
        bannerVm.list = bannerList.ToPagedList<BannerList>(page, pageSize);
        return (IActionResult) this.View((object) bannerVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) bannerVm);
      }
    }

    [UseFilter(220, 7)]
    public IActionResult Edit(int cms_files_fk)
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<CmsBannerDto>(BannerBiz.Get(cms_files_fk)));
    }

    public IActionResult PostEdit(CmsBannerDto req)
    {
      this.SetSelect(this.GetUser().lang);
      try
      {
        BannerBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(220, 7)]
    public IActionResult Create()
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) new CmsBannerDto());
    }

    public async Task<IActionResult> PostCreate(CmsBannerDto req)
    {
      BannerController bannerController = this;
      bannerController.SetSelect(bannerController.GetUser().lang);
      try
      {
        await BannerBiz.PostCreate(req, bannerController.GetUser());
        return (IActionResult) ((ControllerBase) bannerController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        bannerController.ShowError(ex.Message);
        return (IActionResult) bannerController.View("Create", (object) req);
      }
    }

    [UseFilter(220, 7)]
    public async Task<IActionResult> Delete(int cms_files_fk)
    {
      BannerController bannerController = this;
      try
      {
        await BannerBiz.Delete(cms_files_fk, bannerController.GetUser());
        return (IActionResult) ((ControllerBase) bannerController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        bannerController.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) bannerController).RedirectToAction("Index");
      }
    }
  }
}
