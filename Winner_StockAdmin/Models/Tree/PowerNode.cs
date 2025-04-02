// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.Tree.PowerNode
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System.Collections.Generic;

#nullable enable
namespace stockadmin.Models.Tree
{
    public class PowerNode
    {
        public int id { get; set; }

        public string text { get; set; }

        public string icon { get; set; }

        public NodeState state { get; set; }

        public List<PowerNode> children { get; set; }
    }
}