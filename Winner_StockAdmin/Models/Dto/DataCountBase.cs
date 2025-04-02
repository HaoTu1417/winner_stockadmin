// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.Dto.DataCountBase`1
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Models.Dto
{
    public class DataCountBase<T>
    {
        public DataCountBase()
        {
        }

        public DataCountBase(int count, IEnumerable<T> data)
        {
            this.count = count;
            this.data = data;
        }

        public int count { get; private set; }

        public IEnumerable<T> data { get; private set; } = Enumerable.Empty<T>();
    }
}