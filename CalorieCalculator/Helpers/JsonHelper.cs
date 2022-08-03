using CalorieCalculator.DTO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalorieCalculator.Helpers
{
    public static class JsonHelper
    {

        public static JObject LoadJson(string fileName) =>
            Disposable
                .Of(() => new StreamReader(fileName, Encoding.UTF8))
                .Use(r => JObject.Parse(r.ReadToEnd()));


        public static IEnumerable<ProductControl> ToProducts(this JObject js) =>
            js["products"]
                .SelectTokens()
                .Select(t => new ProductControl(t.ToProduct().Name, t.ToProduct()));


        private static Product ToProduct(this JToken jToken)
        {
            string name = (string)jToken["name"];
            float protein = float.Parse((string)jToken["protein"]);
            float fat = float.Parse((string)jToken["fat"]);
            float carbohydrates = float.Parse((string)jToken["carbohydrates"]);
            float calcium = float.Parse((string)jToken["calcium"] ?? "0");
            var kcal = protein * 4 + fat * 9 + carbohydrates * 4;
            return new Product(name, protein, fat, carbohydrates, kcal, calcium);
        }


        private static IEnumerable<JToken> SelectTokens(this JToken js)
        {
            foreach (JToken item in js)
            {
                yield return item;
            }
        }

    }
}
