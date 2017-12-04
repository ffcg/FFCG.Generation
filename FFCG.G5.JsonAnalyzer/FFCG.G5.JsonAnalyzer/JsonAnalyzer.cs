using System.Linq;
using Newtonsoft.Json.Linq;

namespace FFCG.G5.JsonAnalyzer
{
    public class JsonAnalyzer
    {
        public int GetSumOfAllNumbers(string json, string valueToExclude = null)
        {
            return json
                    .Parse()
                    .Descendants()
                    .Where(x => x.Type == JTokenType.Integer)
                    .Select(x => ValueFromNodeWithoutValue(x, valueToExclude))
                    .Sum();
        }

        private static int ValueFromNodeWithoutValue(JToken node, string value)
        {
            return node
                    .Ancestors()
                    .Where(x => x.Type == JTokenType.Object)
                    .Any(x => x.ContainsValue(value))
                    ? 0 : node.Value<int>();
        }
    }

    public static class JsonExtensions
    {
        public static JContainer Parse(this string json)
        {
            return json.StartsWith("{") ? (JContainer)JObject.Parse(json) : JArray.Parse(json);
        }

        public static bool ContainsValue(this JToken jtoken, string value)
        {
            return jtoken
                    .Select(x => x as JProperty)
                    .Select(x => x.Value)
                    .ToList()
                    .Where(x => x.Type == JTokenType.String)
                    .Any(x => x.Value<string>() == value);
        }
    }
}
