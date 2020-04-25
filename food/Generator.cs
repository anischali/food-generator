using System.Collections.Generic;

namespace food
{
    internal static class Generator
    {
        internal static readonly string[] tags = { "Hiver","Eté","Fête","Dessert","Snack","Viande","Poulet","Oeuf","Poisson","Légumes","Riz/Pâtes", "Léguméneuse", "Autres" };
        internal static List<Tag> TagsToUseInSearch = new List<Tag>();
    }
}
