using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class JsonFormat
    {
        public static string GetSerializerJson<T>(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }


        public static T DeSerializerFromJson<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
