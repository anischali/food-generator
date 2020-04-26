using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace food
{
    [DataContract]
    internal class RecipeContent
    {
        [DataMember]
        internal string uid { get; set; }
        [DataMember]
        internal double Quantity { get; set; }
        [DataMember]
        internal Unit QuantityUnit { get; set; }

        internal RecipeContent()
        {
            uid = "Undefined";
            Quantity = -1;
            QuantityUnit = Unit.Undefined;
        }
    }

}
