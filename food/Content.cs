using System;

namespace food
{
    internal class Content
    {
        internal string Name { get; set; }
        internal Tag type { get; set; }
        internal double Quantity { get; set; }
        internal string uid { get; private set; }

        internal Content(String name, Tag tag, double quantity)
        {
            uid = Guid.NewGuid().ToString();
            Name = name;
            type = tag;
            Quantity = quantity;
        }

        internal Content()
        {
            Name = "Undefined";
            type = Tag.Undefined;
            Quantity = -1;
        }
    }
}
