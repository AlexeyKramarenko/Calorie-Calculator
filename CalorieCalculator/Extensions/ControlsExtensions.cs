using CalorieCalculator.DTO;
using CalorieCalculator.Extensions;
using CalorieCalculator.Extensions.Functional;
using CalorieCalculator.POCO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CalorieCalculator.Extensions
{
    public static class ControlsExtensions
    {

        public static ProductModel CalculateProductModel(
                                            this IEnumerable<Panel> panels,
                                                 IEnumerable<ProductControl> productControls)
        {
            IEnumerable<ProductAmount> productAmounts =
                                GetProductTextBoxes(panels, productControls).Select((p) =>
                                            new ProductAmount(
                                                   product: p.pctl.Product,
                                                   amount: p.textBox.ToFloat()));

            return ProductModel.Create(productAmounts);
        }


        public static bool InputHasWrongCharacters(this IEnumerable<Panel> panels) =>
            panels
                .SelectMany(p => p.Controls.OfType<TextBox>())
                .Where(txt => txt.Text.Trim() != string.Empty)
                .Any(textBox => !int.TryParse(textBox.Text, out int _));


        public static IEnumerable<ProductRecord> ExtractDefinedProductsWithAmount(this IEnumerable<Panel> panels) =>
            panels
               .Select(pnl => pnl.Controls)
               .Select(ctls => new LabelAndTextBoxPair(ctls.OfType<Label>(), ctls.OfType<TextBox>()))
               .ToProductRecords();


        public static float ToFloat(this TextBox txb) =>
            string.IsNullOrEmpty(txb.Text) ? 0 : float.Parse(txb.Text);


        public static void ToggleEmptyTextBoxes(this IEnumerable<Panel> panels) =>
             panels
                .SelectMany(panel => panel.Controls.OfType<TextBox>())
                .Where(txb => txb.Text == string.Empty)
                .ForEach(txb => txb.Visible = !txb.Visible);


        public static Option<TextBox> FindTextBoxInPanels(this IEnumerable<Panel> panels, string txtBoxName) =>
             panels
                .Select(pnl => pnl.Controls)
                .SelectMany(ctls => ctls.OfType<TextBox>())
                .FirstOrNone(txb => txb.Name == txtBoxName);


        public static IEnumerable<Panel> UpdateFontColor(
                                             this IEnumerable<Panel> panels,
                                                  IEnumerable<ProductControl> productControls)
        {
            GetProductTextBoxes(panels, productControls)
                .Select(a => a.textBox)
                .UpdateTextBoxColor(Color.Green);

            return new List<Panel>(panels);
        }

        #region Private Methods

        private static IEnumerable<(ProductControl pctl, TextBox textBox)> GetProductTextBoxes(
                                                                                    IEnumerable<Panel> panels,
                                                                                    IEnumerable<ProductControl> productControls) =>
            productControls
                .Select(pctl => (pctl, option: panels.FindTextBoxInPanels(pctl.TextBoxName)))
                .Select(a => (a.pctl, a.option
                                       .Map(textBox => textBox)
                                       .Reduce(() => new TextBox())));


        private static void UpdateTextBoxColor(this IEnumerable<TextBox> txbs, Color color) =>
            txbs.Where(txb => txb.Text != string.Empty)
                .ForEach(txb => txb.ForeColor = color);


        private static IEnumerable<ProductRecord> ToProductRecords(this IEnumerable<LabelAndTextBoxPair> labelAndTextBoxes) =>
             labelAndTextBoxes.SelectMany(a => a.ToProductRecords());


        private static IEnumerable<ProductRecord> ToProductRecords(this LabelAndTextBoxPair pair)
        {
            for (int i = 0; i < pair.Labels.Count(); i++)
            {
                string txt = pair.TextBoxes.ElementAt(i).Text;

                yield return new ProductRecord(
                                     productName: pair.Labels.ElementAt(i).Text,
                                     productAmount: txt == string.Empty ? 0 : int.Parse(txt));
            }
        }

        #endregion

    }
}
