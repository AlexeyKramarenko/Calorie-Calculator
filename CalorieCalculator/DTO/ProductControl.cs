namespace CalorieCalculator.DTO
{
    public class ProductControl
    {
        public string TextBoxName { get; }
        public Product Product { get; }

        public ProductControl(string textBoxName, Product product)
        {
            TextBoxName = textBoxName;
            Product = product;
        }
    }
}
