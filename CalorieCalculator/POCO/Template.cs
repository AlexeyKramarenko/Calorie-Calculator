using CalorieCalculator.DTO;
using CalorieCalculator.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalorieCalculator.POCO
{
    public class Template
    {

        private readonly IEnumerable<ProductRecord> _records;
        private readonly CalculationSummary _calculationSummary;

        public Template(
            IEnumerable<ProductRecord> records,
            CalculationSummary calculationSummary)
        {
            _records = new List<ProductRecord>(records);
            _calculationSummary = calculationSummary;
        }

        public string GetProductsDocumentContent() =>
             new StringBuilder()
                 .AppendLine()
                 .ForEach(NonZeroAmountRecords, (record) => $"{record.ProductName}: {record.ProductAmount}")
                 .Append(End)
                 .ToString();

        private string End
        {
            get => $@" 
                    Proteins: {_calculationSummary.ProteinsResult}g
                    Fats: {_calculationSummary.FatResult}g
                    Сarbohydrates: {_calculationSummary.СarbohydratesResult}g 
                    Kcal: {_calculationSummary.Kcal}";
        }

        private IEnumerable<ProductRecord> NonZeroAmountRecords
        {
            get => _records.Where(r => r.ProductAmount != 0);
        }

    }
}
