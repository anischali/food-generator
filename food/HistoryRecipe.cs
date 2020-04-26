using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace food
{
    [DataContract]
    class HistoryRecipe
    {
        [DataMember]
        internal List<Recipe> GroceriesList { get; set; }
        [DataMember]
        internal DateTime date { get; set; }
        [DataMember]
        internal string uid { get; private set; }

        internal HistoryRecipe()
        {
            uid = Guid.NewGuid().ToString();
            date = DateTime.UtcNow;
            GroceriesList = new List<Recipe>();
        }
    }
}
