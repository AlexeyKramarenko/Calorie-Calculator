using CalorieCalculator.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CalorieCalculator.POCO
{
    public class ProductControlLists
    {

        private readonly IEnumerable<ProductControl> _products;

        private ProductControlLists(IEnumerable<ProductControl> products)
        {
            _products = new List<ProductControl>(products);
        }


        public static ProductControlLists Create(IEnumerable<ProductControl> products)
        {
            return new ProductControlLists(products);
        }


        public IOrderedEnumerable<ProductControl> Carbohydrates =>
            _products
                .Where(p => p.Product.Protein <= 13 && p.Product.Carbohydrates > 5 || p.Product.Carbohydrates >= 2.5 && p.Product.Fat <= 2.5)
                .OrderByDescending(p => p.Product.Carbohydrates);


        public IOrderedEnumerable<ProductControl> Proteins =>
            _products
                .Except(Carbohydrates)
                .Where(p => p.Product.Protein > 11 && p.Product.Carbohydrates < 3 && p.Product.Fat < 11)
                .OrderByDescending(p => p.Product.Protein);


        public IOrderedEnumerable<ProductControl> Fats =>
            _products
                .Except(Proteins)
                .Except(Carbohydrates)
                .OrderByDescending(p => p.Product.Fat);

    }
}
