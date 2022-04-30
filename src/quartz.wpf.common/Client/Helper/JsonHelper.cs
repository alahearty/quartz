using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client.Helper
{
    public static class JsonHelper
    {
        public static string SerializeObjectAsJsonString(this object objectToSerialize)
        {
            string jsonString = JsonConvert.SerializeObject(objectToSerialize, Newtonsoft.Json.Formatting.Indented
                                    , new JsonSerializerSettings
                                    {
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                    }
                                    );
            return jsonString;
        }

        public static void SaveAsJsonToFile(object objectToSerialize, string filePath)
        {
            string jsonString = SerializeObjectAsJsonString(objectToSerialize);
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                File.WriteAllText(filePath, jsonString);
            }
        }

        public static T DeserializeToClass<T>(this string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return default(T);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static T DeserializeFromFile<T>(string jsonfilePath)
        {
            string jsonString = File.ReadAllText(jsonfilePath);
            if (string.IsNullOrWhiteSpace(jsonString))
                return default(T);

            T @class = JsonConvert.DeserializeObject<T>(jsonString);
            return @class;
        }
    }
}
