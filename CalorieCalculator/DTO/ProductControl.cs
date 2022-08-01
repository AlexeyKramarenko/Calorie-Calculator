namespace CalorieCalculator.DTO
{
    public class ProductControl
    {
        public string TextBoxControlName { get; }
        public Product Product { get; }

        public ProductControl(string controlName, Product product)
        {
            TextBoxControlName = controlName;
            Product = product;
        }
    }
}
