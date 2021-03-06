﻿namespace Client_Desktop
{
    partial class RecipeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.RecipeNameTextBox = new System.Windows.Forms.TextBox();
            this.RecipeTypeLabel = new System.Windows.Forms.Label();
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.servingsTextbox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.recipeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addModifyRecipeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.recipeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Location = new System.Drawing.Point(296, 29);
            this.recipeNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(147, 25);
            this.recipeNameLabel.TabIndex = 1;
            this.recipeNameLabel.Text = "Recipe Name:";
            // 
            // RecipeNameTextBox
            // 
            this.RecipeNameTextBox.Location = new System.Drawing.Point(458, 24);
            this.RecipeNameTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.RecipeNameTextBox.Name = "RecipeNameTextBox";
            this.RecipeNameTextBox.Size = new System.Drawing.Size(340, 31);
            this.RecipeNameTextBox.TabIndex = 2;
            this.RecipeNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.recipeNameTextBox_Validating);
            // 
            // RecipeTypeLabel
            // 
            this.RecipeTypeLabel.AutoSize = true;
            this.RecipeTypeLabel.Location = new System.Drawing.Point(378, 79);
            this.RecipeTypeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RecipeTypeLabel.Name = "RecipeTypeLabel";
            this.RecipeTypeLabel.Size = new System.Drawing.Size(66, 25);
            this.RecipeTypeLabel.TabIndex = 3;
            this.RecipeTypeLabel.Text = "Type:";
            // 
            // categoryCombo
            // 
            this.categoryCombo.DisplayMember = "RCategory";
            this.categoryCombo.FormattingEnabled = true;
            this.categoryCombo.Location = new System.Drawing.Point(458, 74);
            this.categoryCombo.Margin = new System.Windows.Forms.Padding(6);
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(238, 33);
            this.categoryCombo.TabIndex = 4;
            this.categoryCombo.ValueMember = "RCategory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Servings:";
            // 
            // servingsTextbox
            // 
            this.servingsTextbox.Location = new System.Drawing.Point(458, 128);
            this.servingsTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.servingsTextbox.Name = "servingsTextbox";
            this.servingsTextbox.Size = new System.Drawing.Size(104, 31);
            this.servingsTextbox.TabIndex = 6;
            this.servingsTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.servingsTextbox_Validating);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(24, 641);
            this.addButton.Margin = new System.Windows.Forms.Padding(6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 44);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // subtractButton
            // 
            this.subtractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtractButton.Location = new System.Drawing.Point(126, 641);
            this.subtractButton.Margin = new System.Windows.Forms.Padding(6);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(82, 44);
            this.subtractButton.TabIndex = 9;
            this.subtractButton.Text = "-";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new System.EventHandler(this.subtractButton_Click);
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.Enabled = false;
            this.removeSelectedButton.Location = new System.Drawing.Point(840, 641);
            this.removeSelectedButton.Margin = new System.Windows.Forms.Padding(6);
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(244, 44);
            this.removeSelectedButton.TabIndex = 10;
            this.removeSelectedButton.Text = "Remove Selected";
            this.removeSelectedButton.UseVisualStyleBackColor = true;
            this.removeSelectedButton.Click += new System.EventHandler(this.removeSelectedButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ingredient Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(750, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Qty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(906, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Unit";
            // 
            // recipeTableLayout
            // 
            this.recipeTableLayout.AutoSize = true;
            this.recipeTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.recipeTableLayout.ColumnCount = 5;
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.73634F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.26366F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.recipeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.recipeTableLayout.Location = new System.Drawing.Point(0, 6);
            this.recipeTableLayout.Margin = new System.Windows.Forms.Padding(6);
            this.recipeTableLayout.Name = "recipeTableLayout";
            this.recipeTableLayout.RowCount = 1;
            this.recipeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.recipeTableLayout.Size = new System.Drawing.Size(1054, 60);
            this.recipeTableLayout.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.recipeTableLayout);
            this.panel1.Location = new System.Drawing.Point(24, 226);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 404);
            this.panel1.TabIndex = 14;
            // 
            // addModifyRecipeButton
            // 
            this.addModifyRecipeButton.Location = new System.Drawing.Point(384, 641);
            this.addModifyRecipeButton.Margin = new System.Windows.Forms.Padding(6);
            this.addModifyRecipeButton.Name = "addModifyRecipeButton";
            this.addModifyRecipeButton.Size = new System.Drawing.Size(272, 44);
            this.addModifyRecipeButton.TabIndex = 15;
            this.addModifyRecipeButton.Text = "Submit";
            this.addModifyRecipeButton.UseVisualStyleBackColor = true;
            this.addModifyRecipeButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(528, 195);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 26);
            this.label6.TabIndex = 16;
            this.label6.Text = "Category";
            // 
            // recipeErrorProvider
            // 
            this.recipeErrorProvider.ContainerControl = this;
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 701);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addModifyRecipeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.removeSelectedButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subtractButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.servingsTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryCombo);
            this.Controls.Add(this.RecipeTypeLabel);
            this.Controls.Add(this.RecipeNameTextBox);
            this.Controls.Add(this.recipeNameLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "RecipeForm";
            this.Text = "Recipe";
            this.Load += new System.EventHandler(this.RecipeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label recipeNameLabel;
        private System.Windows.Forms.TextBox RecipeNameTextBox;
        private System.Windows.Forms.Label RecipeTypeLabel;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox servingsTextbox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Button removeSelectedButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel recipeTableLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addModifyRecipeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider recipeErrorProvider;
    }
}