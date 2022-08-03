using CalorieCalculator.DTO;
using CalorieCalculator.Extensions;
using CalorieCalculator.Extensions.Functional;
using CalorieCalculator.Factories;
using CalorieCalculator.Helpers;
using CalorieCalculator.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CalorieCalculator
{
    public partial class Calculator : Form
    {
        private IEnumerable<Panel> ProductsListPanels =>
            new List<Panel> { carbohydratesPnl, fatPnl, proteinsPnl };

        public Calculator()
        {
            InitializeComponent();
            AddEmptyTextBoxesToPanels();
        }

        #region Event Handlers 

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Calculate();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            AddEmptyTextBoxesToPanels();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.L)
                {
                    AddEmptyTextBoxesToPanels();
                }
                if (e.KeyCode == Keys.C || e.KeyCode == Keys.P)
                {
                    Calculate();
                }
            }
        }

        private void selectedOnlyBtn_Click(object sender, EventArgs e)
        {
            ProductsListPanels.ToggleEmptyTextBoxes();
            ToggleTextOfSelectionBtn();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Calculate();
            var productRecords = ProductsListPanels.ExtractDefinedProductsWithAmount();
            string productsDocumentContent = new Template(productRecords, GetCalculationSummary())
                                                                                     .GetProductsDocumentContent();
            var doc = new ResultDocument(".", "document.txt");
            doc.SaveDocument(productsDocumentContent);
            doc.OpenFolderWithCreatedDocument();
            doc.OpenDocumentWithCalculatedCallories();
        }

        #endregion 

        #region Helpers

        private void ClearTextBoxes() =>
            ProductsListPanels.ForEach(p => p.Controls.Clear());


        private void AddEmptyTextBoxesToPanels()
        {
            ClearTextBoxes();
            var products = GetProductControls();
            AddControlsToPanels(products);
        }


        private void AddControlsToPanels(IEnumerable<ProductControl> products)
        {
            var ctls = ProductControlLists.Create(products);
            int heightControlInterval = 40;
            AddControls(ctls.Fat, fatPnl, heightControlInterval);
            AddControls(ctls.Proteins, proteinsPnl, heightControlInterval);
            AddControls(ctls.Carbohydrates, carbohydratesPnl, heightControlInterval);
        }


        private void AddControls(
                        IOrderedEnumerable<ProductControl> productCtls,
                        Panel panel,
                        int heightControlInterval) =>
            Enumerable
               .Range(0, productCtls.Count())
               .ForEach(i => AddLblAndTxtBoxToPanel(new Point(0, i * heightControlInterval), item: productCtls.ElementAt(i), panel));


        private void AddLblAndTxtBoxToPanel(Point point, ProductControl item, Panel panel)
        {
            panel.Controls.Add(ControlsFactory.CreateLabel(point, item));
            panel.Controls.Add(ControlsFactory.CreateTextBox(point, item, textBox_KeyDown));
        }


        private void Calculate()
        {
            if (ProductsListPanels.InputHasWrongCharacters())
            {
                MessageBox.Show("Only numbers are accepted.");
                return;
            }

            var pctls = GetProductControls();

            var productModel =
                ProductsListPanels
                    .UpdateFontColor(pctls)
                    .CalculateProductModel(pctls);

            PopulateControlsWith(productModel);
        }


        private IEnumerable<ProductControl> GetProductControls() =>
            JsonHelper.LoadJson("products.json").ToProducts();


        private CalculationSummary GetCalculationSummary() =>
            new CalculationSummary(
               int.Parse(lblProteinsResult.Text),
               int.Parse(lblFatResult.Text),
               int.Parse(lblСarbohydratesResult.Text),
               int.Parse(lblKcal.Text));


        private void PopulateControlsWith(ProductModel productModel)
        {
            lbPFC.Text = productModel.ToString();
            lbCalcium.Text = $"Calcium: {productModel.Calcium}g";
            lblProteinsResult.Text = productModel.Proteins.ToString();
            lblFatResult.Text = productModel.Fats.ToString();
            lblСarbohydratesResult.Text = productModel.Carbohydrates.ToString();
            lblKcal.Text = productModel.Kcal.ToString();
        }


        private void ToggleTextOfSelectionBtn() =>
            selectedOnlyBtn.Text =
                selectedOnlyBtn.Text == "Selected Only"
                                                ? "Show All"
                                                : "Selected Only";

        #endregion

    }
}