namespace DietCallories
{
    partial class Calculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblProteinsResult = new System.Windows.Forms.Label();
            this.lblFatResult = new System.Windows.Forms.Label();
            this.lblСarbohydratesResult = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lblKcal = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.proteinsPnl = new System.Windows.Forms.Panel();
            this.carbohydratesPnl = new System.Windows.Forms.Panel();
            this.fatPnl = new System.Windows.Forms.Panel();
            this.lbPFC = new System.Windows.Forms.Label();
            this.lbCalcium = new System.Windows.Forms.Label();
            this.selectedOnlyBtn = new System.Windows.Forms.Button();
            this.allProductsBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(971, -136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "стакан";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1063, -100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "шт";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(33, 129);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 20);
            this.label28.TabIndex = 3;
            this.label28.Text = "Proteins:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(320, 129);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(108, 20);
            this.label36.TabIndex = 3;
            this.label36.Text = "Carbohydrates:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(677, 129);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(37, 20);
            this.label37.TabIndex = 3;
            this.label37.Text = "Fats:";
            // 
            // lblProteinsResult
            // 
            this.lblProteinsResult.AutoSize = true;
            this.lblProteinsResult.Location = new System.Drawing.Point(92, 129);
            this.lblProteinsResult.Name = "lblProteinsResult";
            this.lblProteinsResult.Size = new System.Drawing.Size(0, 20);
            this.lblProteinsResult.TabIndex = 3;
            // 
            // lblFatResult
            // 
            this.lblFatResult.AutoSize = true;
            this.lblFatResult.Location = new System.Drawing.Point(747, 129);
            this.lblFatResult.Name = "lblFatResult";
            this.lblFatResult.Size = new System.Drawing.Size(0, 20);
            this.lblFatResult.TabIndex = 3;
            // 
            // lblСarbohydratesResult
            // 
            this.lblСarbohydratesResult.AutoSize = true;
            this.lblСarbohydratesResult.Location = new System.Drawing.Point(415, 129);
            this.lblСarbohydratesResult.Name = "lblСarbohydratesResult";
            this.lblСarbohydratesResult.Size = new System.Drawing.Size(0, 20);
            this.lblСarbohydratesResult.TabIndex = 3;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(677, 9);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 20);
            this.label41.TabIndex = 3;
            this.label41.Text = "Kcal:";
            // 
            // lblKcal
            // 
            this.lblKcal.AutoSize = true;
            this.lblKcal.Location = new System.Drawing.Point(728, 9);
            this.lblKcal.Name = "lblKcal";
            this.lblKcal.Size = new System.Drawing.Size(0, 20);
            this.lblKcal.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(444, 15);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(127, 38);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // proteinsPnl
            // 
            this.proteinsPnl.Location = new System.Drawing.Point(66, 185);
            this.proteinsPnl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.proteinsPnl.Name = "proteinsPnl";
            this.proteinsPnl.Size = new System.Drawing.Size(250, 595);
            this.proteinsPnl.TabIndex = 7;
            // 
            // carbohydratesPnl
            // 
            this.carbohydratesPnl.AutoScroll = true;
            this.carbohydratesPnl.Location = new System.Drawing.Point(373, 185);
            this.carbohydratesPnl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.carbohydratesPnl.Name = "carbohydratesPnl";
            this.carbohydratesPnl.Size = new System.Drawing.Size(295, 595);
            this.carbohydratesPnl.TabIndex = 8;
            // 
            // fatPnl
            // 
            this.fatPnl.Location = new System.Drawing.Point(723, 185);
            this.fatPnl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fatPnl.Name = "fatPnl";
            this.fatPnl.Size = new System.Drawing.Size(283, 595);
            this.fatPnl.TabIndex = 9;
            // 
            // lbPFC
            // 
            this.lbPFC.AutoSize = true;
            this.lbPFC.Location = new System.Drawing.Point(677, 34);
            this.lbPFC.Name = "lbPFC";
            this.lbPFC.Size = new System.Drawing.Size(45, 20);
            this.lbPFC.TabIndex = 10;
            this.lbPFC.Text = "         ";
            // 
            // lbCalcium
            // 
            this.lbCalcium.AutoSize = true;
            this.lbCalcium.Location = new System.Drawing.Point(880, 18);
            this.lbCalcium.Name = "lbCalcium";
            this.lbCalcium.Size = new System.Drawing.Size(0, 20);
            this.lbCalcium.TabIndex = 11;
            // 
            // selectedOnlyBtn
            // 
            this.selectedOnlyBtn.Location = new System.Drawing.Point(171, 16);
            this.selectedOnlyBtn.Name = "selectedOnlyBtn";
            this.selectedOnlyBtn.Size = new System.Drawing.Size(128, 38);
            this.selectedOnlyBtn.TabIndex = 12;
            this.selectedOnlyBtn.Text = "Only &Selected";
            this.selectedOnlyBtn.UseVisualStyleBackColor = true;
            this.selectedOnlyBtn.Click += new System.EventHandler(this.selectedOnlyBtn_Click);
            // 
            // allProductsBtn
            // 
            this.allProductsBtn.Location = new System.Drawing.Point(53, 18);
            this.allProductsBtn.Name = "allProductsBtn";
            this.allProductsBtn.Size = new System.Drawing.Size(96, 36);
            this.allProductsBtn.TabIndex = 13;
            this.allProductsBtn.Text = "&All";
            this.allProductsBtn.UseVisualStyleBackColor = true;
            this.allProductsBtn.Click += new System.EventHandler(this.allProductsBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(315, 16);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(107, 37);
            this.clearBtn.TabIndex = 14;
            this.clearBtn.Text = "C&lear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(53, 75);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(96, 29);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Sa&ve";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 827);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.allProductsBtn);
            this.Controls.Add(this.selectedOnlyBtn);
            this.Controls.Add(this.lbCalcium);
            this.Controls.Add(this.lbPFC);
            this.Controls.Add(this.fatPnl);
            this.Controls.Add(this.carbohydratesPnl);
            this.Controls.Add(this.proteinsPnl);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblKcal);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.lblСarbohydratesResult);
            this.Controls.Add(this.lblFatResult);
            this.Controls.Add(this.lblProteinsResult);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Calculator";
            this.Text = "Calorie Calculator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblProteinsResult;
        private System.Windows.Forms.Label lblFatResult;
        private System.Windows.Forms.Label lblСarbohydratesResult;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lblKcal;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Panel proteinsPnl;
        private System.Windows.Forms.Panel carbohydratesPnl;
        private System.Windows.Forms.Panel fatPnl;
        private System.Windows.Forms.Label lbPFC;
        private System.Windows.Forms.Label lbCalcium;
        private System.Windows.Forms.Button selectedOnlyBtn;
        private System.Windows.Forms.Button allProductsBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}

