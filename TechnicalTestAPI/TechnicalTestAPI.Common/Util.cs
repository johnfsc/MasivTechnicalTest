using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TechnicalTestAPI.Common
{
    public static class Util
    {
        public static string ConvertToJson(object item)
        {
            return  JsonSerializer.Serialize(item);
        }

        public static object ConvertJsonToObjec(string item)
        {
            return JsonSerializer.Deserialize(item,null);
        }

        public static int GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next() * (maximum - minimum) + minimum;
        }
    }
}
