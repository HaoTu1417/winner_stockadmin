// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Menu.MainMenuVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System.Collections.Generic;

#nullable enable
namespace stockadmin.ViewModels.Menu
{
    public class MainMenuVm
    {
        public int Id { get; set; }

        public int Parent { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Active { get; set; }

        public string IconClass { get; set; } = string.Empty;

        public string Css { get; set; } = string.Empty;

        public List<MainMenuVm>? Child { get; set; }
    }
}