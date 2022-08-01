using CalorieCalculator.DTO;
using System;
using System.Collections.Generic;

namespace CalorieCalculator.POCO
{
    public class ProductModel
    {
        public double Proteins { get => Math.Round(_proteins); }
        public double Fats { get => Math.Round(_fat); }
        public double Carbohydrates { get => Math.Round(_carbohydrates); }
        public double Kcal { get => Math.Round(_kcal); }
        public double Calcium { get => Math.Round(_calcium, 2); }

        private float _proteins { get; set; }
        private float _fat { get; set; }
        private float _carbohydrates { get; set; }
        private float _kcal { get; set; }
        private float _calcium { get; set; }

        private ProductModel() { }

        public static ProductModel Create(List<(Product, float)> list) =>
            new ProductModel().Append(list);

        public ProductModel Append(List<(Product, float)> list)
        {
            list.ForEach(a => Append(a.Item1, a.Item2));
            return this;
        }

        private void Append(Product product, float selectedValue)
        {
            _proteins += product.Protein * selectedValue / 100;
            _fat += product.Fat * selectedValue / 100;
            _carbohydrates += product.Carbohydrates * selectedValue / 100;
            _kcal += product.Kcal * selectedValue / 100;
            _calcium += product.Calcium * selectedValue / 100;
        }

        private double ProteinsKcalPercentage() =>
            Math.Floor(100 / _kcal * _proteins * 4);

        private double FatsKcalPercentage() =>
            Math.Floor(100 / _kcal * _fat * 9);

        private double CarbohydratesKcalPercentage() =>
            Math.Floor(100 / _kcal * _carbohydrates * 4);

        public string PFC() =>
            $"Proteins: {ProteinsKcalPercentage()} % {Environment.NewLine}Fats: {FatsKcalPercentage()} % {Environment.NewLine}Carbohydrates: {CarbohydratesKcalPercentage()} %";
    }
}
