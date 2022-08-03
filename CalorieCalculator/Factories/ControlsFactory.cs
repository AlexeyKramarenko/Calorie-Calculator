using CalorieCalculator.DTO;
using System.Drawing;
using System.Windows.Forms;

namespace CalorieCalculator.Factories
{
    public static class ControlsFactory
    {
        public static Label CreateLabel(Point point, ProductControl item) =>
             new Label
             {
                 Text = item.Product.Name,
                 Width = 200,
                 Location = point
             };

        public static TextBox CreateTextBox(Point point, ProductControl item, KeyEventHandler keyEvent)
        {
            var amountTxt = new TextBox
            {
                Name = item.TextBoxName,
                Width = 50,
                Location = new Point(point.X + 200, point.Y),
            };
            amountTxt.KeyDown += keyEvent;

            return amountTxt;
        }
    }
}
