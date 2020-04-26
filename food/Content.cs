using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace food
{
    [DataContract]
    internal class Content 
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Tag type { get; set; }
        [DataMember]
        internal double Quantity { get; set; }
        [DataMember]
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
            uid = Guid.NewGuid().ToString();
            Name = "Undefined";
            type = Tag.Undefined;
            Quantity = -1;
        }
/*
        protected Content(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            uid = info.GetString("uid");
            Name = info.GetString("Name");
            type = (Tag)info.GetInt32("type");
            Quantity = info.GetDouble("Quantity");
        }
  
    public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("uid", uid);
            info.AddValue("Name", Name);
            info.AddValue("type", $"{(int)type}");
            info.AddValue("Quantity", $"{Quantity}");
        }
    */
    }
}
