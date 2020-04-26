using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace food.IO
{
    static class Database 
    {
        private const string contents_fileName = "contents.json";
        private const string recipe_fileName = "recipes.json";
        private const string history_fileName = "history.json";
        private static string path = $"{Environment.GetEnvironmentVariable("APPDATA")}\\FoodGenerator\\Databases\\";
        internal static List<Content> contents = new List<Content>();
        private static bool isContentsListChanged = false;
        internal static List<Recipe> AllMenus;
        
        internal static void SaveContents()
        {
            if (isContentsListChanged)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string contents_json = JsonConvert.SerializeObject(contents);
                File.WriteAllText(Path.Combine(path, contents_fileName), contents_json);
                isContentsListChanged = false;
            }
        }

        internal static void AddContentToDatabase(Content content)
        {
            contents.Add(content);
            isContentsListChanged = true;
            SaveContents();
        }


    }
}
