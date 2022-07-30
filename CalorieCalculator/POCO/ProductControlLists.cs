using DietCallories.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DietCallories.POCO
{
    public class ProductControlLists
    {
        private readonly IEnumerable<ProductControl> products;

        private ProductControlLists(IEnumerable<ProductControl> products)
        {
            this.products = new List<ProductControl>(products);
        }

        public static ProductControlLists Create(IEnumerable<ProductControl> products)
        {
            return new ProductControlLists(products);
        }

        public IOrderedEnumerable<ProductControl> Carbohydrates
        {
            get =>
                 products
                    .Where(p => p.Product.Protein <= 13 && p.Product.Carbohydrates > 5 || p.Product.Carbohydrates >= 2.5 && p.Product.Fat <= 2.5)
                    .OrderByDescending(p => p.Product.Carbohydrates);
        }

        public IOrderedEnumerable<ProductControl> Proteins
        {
            get => products
                .Except(Carbohydrates)
                .Where(p => p.Product.Protein > 11 && p.Product.Carbohydrates < 3 && p.Product.Fat < 11)
                .OrderByDescending(p => p.Product.Protein);
        }

        public IOrderedEnumerable<ProductControl> Fat
        {
            get => products
                .Except(Proteins)
                .Except(Carbohydrates)
                .OrderByDescending(p => p.Product.Fat);
        }
    }
}
