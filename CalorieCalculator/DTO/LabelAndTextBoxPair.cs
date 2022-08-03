using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CalorieCalculator.DTO
{
    public class LabelAndTextBoxPair
    {
        public IEnumerable<Label> Labels { get; }
        public IEnumerable<TextBox> TextBoxes { get; }

        public LabelAndTextBoxPair(IEnumerable<Label> labels, IEnumerable<TextBox> textBoxes)
        {
            if (labels.Count() != textBoxes.Count())
                throw new ArgumentException("The Labels' and Textboxes' amounts should be equal.");

            Labels = new List<Label>(labels);
            TextBoxes = new List<TextBox>(textBoxes);
        }
    }
}
