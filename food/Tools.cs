using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace food
{
    static class Tools
    {
        static internal string StringBonify(string old)
        {
            Regex rx = new Regex("[\\/:\"*?<>|]+");
            return rx.Replace(old, "");
        }

        internal static Type LoadFromJSON<Type>(string file_Name)
        {

            if (!File.Exists(file_Name))
            {
                return default(Type);
            }
            string json_file = File.ReadAllText(file_Name);
            return JsonConvert.DeserializeObject<Type>(json_file);
        }

        internal static void SaveToJSON<Type>(Type data, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string contents_json = JsonConvert.SerializeObject(data);
            File.WriteAllText(Path.Combine(path, fileName), contents_json);
        }


        internal static string ContentToStringConverter(Content content)
        {
            return content.Name;
        }

        internal static string FindContentNameByUid(string uid)
        {
            foreach (Content c in IO.Database.contents)
            {
                if (c.uid == uid)
                    return c.Name;
            }
            return "Unknown";
        }

        internal static Content FindContentByName(string name)
        {
            foreach (Content c in IO.Database.contents)
            {
                if (c.Name == name)
                    return c;
            }
            return null;
        }

        internal static RecipeContent FindRecipeContentByName(List<RecipeContent> contents, string name)
        {
            Content content = FindContentByName(name);
            if (content == null)
                return null;
            foreach (RecipeContent rc in contents)
            {
                if (rc.uid == content.uid)
                    return rc;
            }
            return null;
        }
    }
}
