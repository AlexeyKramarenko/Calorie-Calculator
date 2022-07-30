﻿using DietCallories.DTO;
using DietCallories.Extensions;
using System.Collections.Generic;
using System.Text;

namespace DietCallories.POCO
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
                 .ForEach(_records, (record) => $"{record.ProductName}: {record.ProductAmount}")
                 .Append(End)
                 .ToString();

        public string End
        {
            get => $@" 
                    Proteins:{_calculationSummary.ProteinsResult}g
                    Fats: {_calculationSummary.FatResult}g
                    Сarbohydrates: {_calculationSummary.СarbohydratesResult}g 
                    Kcal: {_calculationSummary.Kcal}";
        }
    }
}