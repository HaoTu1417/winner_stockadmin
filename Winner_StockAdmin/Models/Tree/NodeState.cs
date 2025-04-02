// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.Tree.NodeState
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

#nullable disable
namespace stockadmin.Models.Tree
{
    public class NodeState
    {
        public bool opened { get; set; }

        public bool disabled { get; set; }

        public bool selected { get; set; }

        public NodeState()
        {
            this.opened = true;
            this.disabled = false;
            this.selected = false;
        }

        public NodeState(bool isSelect)
        {
            this.opened = true;
            this.disabled = false;
            this.selected = isSelect;
        }
    }
}