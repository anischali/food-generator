using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food
{
    internal class Content
    {
        internal string Name { get; set; }
        internal Tag type { get; set; }
        internal double Quantity { get; set; }

        internal Content(String name, Tag tag, double quantity)
        {
            Name = name;
            type = tag;
            Quantity = quantity;
        }

    }
}
