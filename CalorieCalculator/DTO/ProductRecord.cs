namespace DietCallories.DTO
{
    public class ProductRecord
    {
        public string ProductName { get; }
        public int ProductAmount { get; }

        public ProductRecord(string productName, int productAmount)
        {
            ProductName = productName;
            ProductAmount = productAmount;
        }
    }
}
