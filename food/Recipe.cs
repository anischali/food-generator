using System;
using System.Collections.Generic;

namespace food
{
    internal class Recipe
    {
        internal List<Tag> Tags { get; set; }
        internal List<Content> Contents { get; set; }
        internal string Description { get; set; }
        internal int PeopleNumber { get; set; }
        internal string uid { get; private set; }

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
