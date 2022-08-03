namespace CalorieCalculator.DTO
{
    public class ProductAmount
    {
        public Product Product { get; }
        public float Amount { get; }

        public ProductAmount(Product product, float amount)
        {
            Product = product;
            Amount = amount;
        }
    } 
}
