using System;
using System.Collections.Generic;
using System.Linq;

namespace Teht2
{

    public class Item
    {
        public Guid Id { get; set; }
        public int Level { get; set; }

        public Item(Guid Id, int level)
        {
            this.Id = Id;
            this.Level = level;
        }

    }
}