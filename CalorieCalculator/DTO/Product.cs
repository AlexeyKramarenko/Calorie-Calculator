namespace DietCallories.DTO
{
    public class Product
    {
        public string Name { get; }
        public float Protein { get; }
        public float Fat { get; }
        public float Carbohydrates { get; }
        public float Kcal { get; }
        public float Calcium { get; }

        public Product(string name, float protein, float fat, float carbohydrates, float kcal, float calcium)
        {
            Name = name;
            Protein = protein;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Kcal = kcal;
            Calcium = calcium;
        }
    }
}
