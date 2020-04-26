using System;
using System.Runtime.Serialization;

namespace food
{
    [DataContract]
    internal class Content
    {
        [DataMember]
        internal string uid { get; set; }
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Tag type { get; set; }
        [DataMember]
        internal double Quantity { get; set; }
        [DataMember]
        internal Unit QuantityUnit { get; set; } 


        internal Content(String name, Tag tag, double quantity, Unit unit)
        {
            uid = Guid.NewGuid().ToString();
            Name = name;
            type = tag;
            Quantity = quantity;
            QuantityUnit = unit;
        }

        internal Content()
        {
            uid = Guid.NewGuid().ToString();
            Name = "Undefined";
            type = Tag.Undefined;
            Quantity = -1;
            QuantityUnit = Unit.Undefined;
        }
    }
}
