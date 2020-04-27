using System.Collections.Generic;

namespace food
{
    internal static class Generator
    {
        internal static readonly string[] tags = { "Hiver", "Eté", "Fête", "Dessert", "Snack", "Viande", "Poulet", "Oeuf", "Poisson", "Légumes", "Riz/Pâtes", "Léguméneuse", "Autres" };
        internal static readonly string[] units = { "Gramme", "Milligramme", "Kilogramme", "Millilitre", "Litre", "Centilitre", "Tasse", "Pincé", "Cuillerée à soupe", "cuillerée à café", "Pièce", "Inconue" };
        internal static List<Tag> TagsToUseInSearch = new List<Tag>();



    }
}
