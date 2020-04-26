using Newtonsoft.Json;
using System;
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
    }
}
