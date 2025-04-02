// Decompiled with JetBrains decompiler
// Type: stockadmin.Init
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/www/service/stockadmin/stockadmin.dll

// using stockadmin.Business;
// using stockadmin.Libs;

#nullable disable
using stockadmin.Business;
using stockadmin.Libs;

namespace stockadmin
{
    public class Init
    {
        public static void Run()
        {
            AdminMenuBiz.BuildMenu();
             LanguageLib.InitErrorMsgCache();
             ConfigLib.Reset();
        }
    }
}