namespace CalorieCalculator.DTO
{
    public class CalculationSummary
    {
        public int ProteinsResult { get; }
        public int FatResult { get; }
        public int СarbohydratesResult { get; }
        public int Kcal { get; }

        public CalculationSummary(int proteinsResult, int fatResult, int сarbohydratesResult, int kcal)
        {
            ProteinsResult = proteinsResult;
            FatResult = fatResult;
            СarbohydratesResult = сarbohydratesResult;
            Kcal = kcal;
        }
    }
}
