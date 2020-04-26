using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace food
{
    [DataContract]
    internal class Recipe
    {
        [DataMember]
        internal string uid { get; private set; }
        [DataMember]
        internal List<Tag> Tags { get; set; }
        [DataMember]
        internal List<Content> Contents { get; set; }
        [DataMember]
        internal string Description { get; set; }
        [DataMember]
        internal int PeopleNumber { get; set; }

        internal Recipe()
        {
            uid = Guid.NewGuid().ToString();
            Tags = new List<Tag>();
            Contents = new List<Content>();
            Description = "";
            PeopleNumber = -1;
        }
    }
}
