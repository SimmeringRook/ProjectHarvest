namespace Client_Desktop
{
    partial class Recipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.RecipeNameTextBox = new System.Windows.Forms.TextBox();
            this.RecipeTypeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.recipeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addModifyRecipeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Location = new System.Drawing.Point(58, 59);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(75, 13);
            this.recipeNameLabel.TabIndex = 1;
            this.recipeNameLabel.Text = "Recipe Name:";
            // 
            // RecipeNameTextBox
            // 
            this.RecipeNameTextBox.Location = new System.Drawing.Point(139, 56);
            this.RecipeNameTextBox.Name = "RecipeNameTextBox";
            this.RecipeNameTextBox.Size = new System.Drawing.Size(172, 20);
            this.RecipeNameTextBox.TabIndex = 2;
            // 
            // RecipeTypeLabel
            // 
            this.RecipeTypeLabel.AutoSize = true;
            this.RecipeTypeLabel.Location = new System.Drawing.Point(99, 85);
            this.RecipeTypeLabel.Name = "RecipeTypeLabel";
            this.RecipeTypeLabel.Size = new System.Drawing.Size(34, 13);
            this.RecipeTypeLabel.TabIndex = 3;
            this.RecipeTypeLabel.Text = "Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(139, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Servings:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Add/Modify Recipe";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(12, 377);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(33, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // subtractButton
            // 
            this.subtractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtractButton.Location = new System.Drawing.Point(63, 377);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(29, 23);
            this.subtractButton.TabIndex = 9;
            this.subtractButton.Text = "-";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new System.EventHandler(this.subtractButton_Click);
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.Location = new System.Drawing.Point(265, 377);
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(122, 23);
            this.removeSelectedButton.TabIndex = 10;
            this.removeSelectedButton.Text = "Remove Selected";
            this.removeSelectedButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ingredient Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Qty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(286, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Unit";
            // 
            // recipeTableLayout
            // 
            this.recipeTableLayout.AutoScroll = true;
            this.recipeTableLayout.AutoSize = true;
            this.recipeTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.recipeTableLayout.ColumnCount = 4;
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.68421F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.31579F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.recipeTableLayout.Location = new System.Drawing.Point(13, 20);
            this.recipeTableLayout.Name = "recipeTableLayout";
            this.recipeTableLayout.RowCount = 1;
            this.recipeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.recipeTableLayout.Size = new System.Drawing.Size(375, 31);
            this.recipeTableLayout.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.recipeTableLayout);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-1, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 235);
            this.panel1.TabIndex = 14;
            // 
            // addModifyRecipeButton
            // 
            this.addModifyRecipeButton.Location = new System.Drawing.Point(139, 425);
            this.addModifyRecipeButton.Name = "addModifyRecipeButton";
            this.addModifyRecipeButton.Size = new System.Drawing.Size(136, 23);
            this.addModifyRecipeButton.TabIndex = 15;
            this.addModifyRecipeButton.Text = "Add/Modify Recipe";
            this.addModifyRecipeButton.UseVisualStyleBackColor = true;
            // 
            // Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 460);
            this.Controls.Add(this.addModifyRecipeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.removeSelectedButton);
            this.Controls.Add(this.subtractButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.RecipeTypeLabel);
            this.Controls.Add(this.RecipeNameTextBox);
            this.Controls.Add(this.recipeNameLabel);
            this.Name = "Recipe";
            this.Text = "Recipe";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label recipeNameLabel;
        private System.Windows.Forms.TextBox RecipeNameTextBox;
        private System.Windows.Forms.Label RecipeTypeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button removeSelectedButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel recipeTableLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addModifyRecipeButton;
    }
}