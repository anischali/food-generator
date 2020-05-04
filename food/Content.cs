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
        internal ContentTag type { get; set; }



        internal Content(String name, ContentTag tag, double quantity, Unit unit)
        {
            uid = Guid.NewGuid().ToString();
            Name = name;
            type = tag;
        }

        internal Content()
        {
            uid = Guid.NewGuid().ToString();
            Name = "Undefined";
            type = ContentTag.Undefined;
        }
    }
}
