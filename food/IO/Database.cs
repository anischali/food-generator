using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace food.IO
{
    static class Database
    {
        private const string contents_fileName = "contents.json";
        private const string recipe_fileName = "recipes.json";
        private const string history_fileName = "history.json";
        private static string path = $"{Environment.GetEnvironmentVariable("APPDATA")}\\FoodGenerator\\Databases\\";
        internal static List<Content> contents;
        internal static List<Recipe> AllMenus;
        internal static List<HistoryRecipe> HistoryMenus;
        


        internal static void AddContentToDatabase(Content content)
        {
            contents.Add(content);
            Tools.SaveToJSON<List<Content>>(contents, path, contents_fileName);
        }

        internal static void AddRecipeToDatabase(Recipe recipe)
        {
            AllMenus.Add(recipe);
            Tools.SaveToJSON<List<Recipe>>(AllMenus, path, recipe_fileName);
        }

        internal static void AddRecipeListToHistoryDatabase(HistoryRecipe historyRecipe)
        {
            HistoryMenus.Add(historyRecipe);
            Tools.SaveToJSON<List<HistoryRecipe>>(HistoryMenus, path, history_fileName);
        }

        internal static void SaveAllDatabases()
        {
            Tools.SaveToJSON<List<Recipe>>(AllMenus, path, recipe_fileName);
            Tools.SaveToJSON<List<HistoryRecipe>>(HistoryMenus, path, history_fileName);
            Tools.SaveToJSON<List<Content>>(contents, path, contents_fileName);
        }

        internal static void LoadAllDatabases()
        {
            contents = Tools.LoadFromJSON<List<Content>>(Path.Combine(path, contents_fileName));
            if (contents == null)
                contents = new List<Content>();
            AllMenus = Tools.LoadFromJSON<List<Recipe>>(Path.Combine(path, recipe_fileName));
            if (AllMenus == null)
                AllMenus = new List<Recipe>();
            HistoryMenus = Tools.LoadFromJSON<List<HistoryRecipe>>(Path.Combine(path, history_fileName));
            if (HistoryMenus == null)
            {
                HistoryMenus = new List<HistoryRecipe>();
            }
        }



    }
}
