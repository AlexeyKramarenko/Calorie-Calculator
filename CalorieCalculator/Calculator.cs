using DietCallories.DTO;
using DietCallories.Helpers;
using DietCallories.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DietCallories
{
    public partial class Calculator : Form
    {
        private List<ProductControl> _productControls;

        public Calculator()
        {
            InitializeComponent();
            AddEmptyTextBoxesToPanels();
        }

        private void AddEmptyTextBoxesToPanels()
        {
            ClearControls();

            var products = JsonHelper.LoadJson().ToProducts();
            _productControls = products;
            CreateControls(products);
        }

        #region Event Handlers 

        private void ClearControls()
        {
            fatPnl.Controls.Clear();
            carbohydratesPnl.Controls.Clear();
            proteinsPnl.Controls.Clear();
        }

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
                if (e.KeyCode == Keys.C)
                {
                    Calculate();
                }
                if (e.KeyCode == Keys.P)
                {
                    Calculate();
                }
            }
        }

        private void selectedOnlyBtn_Click(object sender, EventArgs e)
        {
            ControlsHelper.ToggleEmptyTextBoxes(new List<Panel> { carbohydratesPnl, fatPnl, proteinsPnl }, false);
        }

        private void allProductsBtn_Click(object sender, EventArgs e)
        {
            ControlsHelper.ToggleEmptyTextBoxes(new List<Panel> { carbohydratesPnl, fatPnl, proteinsPnl }, true);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Calculate();
            var panels = new List<Panel> { proteinsPnl, carbohydratesPnl, fatPnl };
            var productRecords = ControlsHelper.ExtractDefinedProductsWithAmount(panels);
            string productsDocumentContent = new Template(productRecords, GetCalculationSummary()).GetProductsDocumentContent();
            var doc = new ResultDocument(".", "document.txt");
            doc.SaveDocument(productsDocumentContent);
            doc.OpenFolderWithCreatedDocument();
            doc.OpenDocumentWithCalculatedCallories();
        }

        #endregion

        private CalculationSummary GetCalculationSummary() =>
             new CalculationSummary(
                int.Parse(lblProteinsResult.Text),
                int.Parse(lblFatResult.Text),
                int.Parse(lblСarbohydratesResult.Text),
                int.Parse(lblKcal.Text));

        private void Calculate()
        {
            var list = new List<(Product, float)>();

            _productControls.ForEach(item =>
            {
                TextBox txb = FindByName(item.TextBoxControlName);

                if (txb != null)
                {
                    ControlsHelper.UpdateTextBoxColor(txb, Color.Green);
                    float productAmount = ControlsHelper.ParseToFloat(txb);
                    list.Add(new(item.Product, productAmount));

                }
            });

            var productModel = ProductModel.Create(list);

            PopulateControlsWithProductModel(productModel);
        }

        private void PopulateControlsWithProductModel(ProductModel productModel)
        {
            lbPFC.Text = productModel.PFC();
            lbCalcium.Text = $"Calcium: {productModel.Calcium}g";
            lblProteinsResult.Text = productModel.Proteins.ToString();
            lblFatResult.Text = productModel.Fats.ToString();
            lblСarbohydratesResult.Text = productModel.Carbohydrates.ToString();
            lblKcal.Text = productModel.Kcal.ToString();
        }

        private void CreateControls(IEnumerable<ProductControl> products)
        {
            var ctls = ProductControlLists.Create(products);

            AddControls(ctls.Fat, fatPnl);
            AddControls(ctls.Proteins, proteinsPnl);
            AddControls(ctls.Carbohydrates, carbohydratesPnl);
        }

        private TextBox FindByName(string controlName)
        {
            var txt1 = (TextBox)proteinsPnl.Controls.Find(controlName, false).FirstOrDefault();
            var txt2 = (TextBox)carbohydratesPnl.Controls.Find(controlName, false).FirstOrDefault();
            var txt3 = (TextBox)fatPnl.Controls.Find(controlName, false).FirstOrDefault();

            TextBox txb = txt1 != null ? txt1
                                        : txt2 != null ? txt2
                                                       : txt3 != null ? txt3
                                                                      : null;
            return txb;
        }

        private void AddControlsToPanel(
           int yIndex,
           int x,
           ProductControl item,
           Panel panel)
        {
            var y = yIndex * 40;

            var nameLbl = new Label { Text = item.Product.Name, Width = 200, Location = new Point(x, y) };

            var amountTxt = new TextBox();
            amountTxt.Name = item.TextBoxControlName;
            amountTxt.Width = 50;
            amountTxt.Location = new Point(x + 200, y);
            amountTxt.Text = "";
            amountTxt.KeyDown += textBox_KeyDown;

            panel.Controls.Add(nameLbl);
            panel.Controls.Add(amountTxt);
        }

        private void AddControls(
               IOrderedEnumerable<ProductControl> productCtls,
               Panel panel)
        {
            for (int i = 0; i < productCtls.Count(); i++)
            {
                AddControlsToPanel(i, x: 0, item: productCtls.ElementAt(i), panel);
            }
        }
    }
}