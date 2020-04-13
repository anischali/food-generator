using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food
{
    internal class Recipe
    {
        internal List<Tag> Tags { get; set; }
        internal List<Content> Contents { get; set; }
        internal string Description { get; set; }
        internal int PeopleNumber { get; set; }

        internal Recipe()
        {
            Tags = new List<Tag>();
            Contents = new List<Content>();
            Description = "";
            PeopleNumber = -1;
        }
    }
}
