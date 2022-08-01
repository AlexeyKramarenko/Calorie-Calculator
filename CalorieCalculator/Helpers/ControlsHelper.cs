using CalorieCalculator.DTO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CalorieCalculator.Helpers
{
    public class ControlsHelper
    {
        public static List<ProductRecord> ExtractDefinedProductsWithAmount(IEnumerable<Panel> panels)
        {
            var productRecords = new List<ProductRecord>();

            foreach (var panel in panels)
            {
                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i] is TextBox)
                    {
                        TextBox txtBox = (TextBox)panel.Controls[i];

                        if (txtBox.Text != string.Empty)
                        {
                            Label lbl = (Label)panel.Controls[i - 1];
                            productRecords.Add(new ProductRecord(lbl.Text, int.Parse(txtBox.Text)));
                        }
                    }
                }
            }

            return productRecords;
        }

        public static float ParseToFloat(TextBox txb) =>
            txb.Text == "" ? 0 : float.Parse(txb.Text);


        public static void UpdateTextBoxColor(TextBox txb, Color color)
        {
            if (txb.Text != string.Empty)
            {
                txb.ForeColor = color;
            }
        }

        public static void ToggleEmptyTextBoxes(IEnumerable<Panel> panels, bool withEmptyTextBoxes)
        {
            foreach (var panel in panels)
            {
                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i] is TextBox)
                    {
                        var txtBox = (TextBox)panel.Controls[i];

                        if (txtBox.Text == string.Empty)
                        {
                            txtBox.Visible = withEmptyTextBoxes;
                        }
                    }
                }
            }
        }
    }
}
