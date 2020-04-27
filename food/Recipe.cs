using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Documents;

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
        internal List<RecipeContent> Contents { get; set; }
        [DataMember]
        internal string Description { get; set; }
        [DataMember]
        internal int PeopleNumber { get; set; }
        [DataMember]
        internal string title;
        internal Recipe()
        {
            uid = Guid.NewGuid().ToString();
            Tags = new List<Tag>();
            Contents = new List<RecipeContent>();
            Description = "";
            PeopleNumber = -1;
            title = "";
        }
    }
}
