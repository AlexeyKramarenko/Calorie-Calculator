using CalorieCalculator.DTO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalorieCalculator.Helpers
{
    public static class JsonHelper
    {
        public static List<ProductControl> ToProducts(this JObject js)
        {
            var dictionary = new List<ProductControl>();

            foreach (JToken item in js["products"])
            {
                var prod = ToProduct(item);

                dictionary.Add(new ProductControl(prod.Name, prod));
            }

            return dictionary;
        }

        public static Product ToProduct(JToken jToken)
        {
            string name = (string)jToken["name"];
            float protein = float.Parse((string)jToken["protein"]);
            float fat = float.Parse((string)jToken["fat"]);
            float carbohydrates = float.Parse((string)jToken["carbohydrates"]);
            float calcium = float.Parse((string)jToken["calcium"] ?? "0");
            var kcal = protein * 4 + fat * 9 + carbohydrates * 4;
            return new Product(name, protein, fat, carbohydrates, kcal, calcium);
        }

        public static JObject LoadJson()
        {
            using (StreamReader r = new StreamReader("products.json", Encoding.UTF8))
            {
                string jsonText = r.ReadToEnd();

                return JObject.Parse(jsonText);
            }
        }
    }
}
