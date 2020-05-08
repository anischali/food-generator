using System.Collections.Generic;

namespace food
{
    internal static class Generator
    {
        internal static readonly string[] tags = { "Hiver", "Eté", "Fête", "Dessert", "Tartes/Tartines", "Viande", "Poulet", "Oeuf", "Poisson", "Légumes", "Riz/Pâtes", "Légumineuse","Ramadan soir", "Ramadan matin", "Soupe", "Boisson","Picnic", "Autres","Petit déjeuner", "Goûter", "Collation salée" };
        internal static readonly string[] contentTags = { "Protein", "Légumes", "Légumineuse", "Produits Laitier", "Féculents", "Produits ménager", "Boisson", "Dessert","Fruits frais" ,"Fruits secs","Fruis oléagineux", "Epices","Autres" };
        internal static readonly string[] units = { "Gramme", "Milligramme", "Kilogramme", "Millilitre", "Litre", "Centilitre", "Tasse", "Pincé", "Cuillère à soupe", "cuillère à café", "Pièce", "Inconue" };
        internal static List<Tag> TagsToUseInSearch = new List<Tag>();



    }
}
