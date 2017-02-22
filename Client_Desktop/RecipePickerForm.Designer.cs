namespace Client_Desktop
{
    partial class RecipePickerForm
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
            this.components = new System.ComponentModel.Container();
            this.filtersLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selectButton = new System.Windows.Forms.Button();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recipeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // filtersLabel
            // 
            this.filtersLabel.AutoSize = true;
            this.filtersLabel.Location = new System.Drawing.Point(373, 12);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(77, 25);
            this.filtersLabel.TabIndex = 4;
            this.filtersLabel.Text = "Filters:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 50);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servings:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(205, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 33);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(626, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(130, 33);
            this.comboBox2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recipeNameDataGridViewTextBoxColumn,
            this.servingsDataGridViewTextBoxColumn,
            this.rCategoryDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.recipeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(20, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(791, 254);
            this.dataGridView1.TabIndex = 6;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(339, 493);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(139, 48);
            this.selectButton.TabIndex = 7;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // recipeBindingSource
            // 
            this.recipeBindingSource.DataSource = typeof(Core.Recipe);
            // 
            // recipeNameDataGridViewTextBoxColumn
            // 
            this.recipeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.recipeNameDataGridViewTextBoxColumn.DataPropertyName = "RecipeName";
            this.recipeNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.recipeNameDataGridViewTextBoxColumn.Name = "recipeNameDataGridViewTextBoxColumn";
            this.recipeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // servingsDataGridViewTextBoxColumn
            // 
            this.servingsDataGridViewTextBoxColumn.DataPropertyName = "Servings";
            this.servingsDataGridViewTextBoxColumn.HeaderText = "Servings";
            this.servingsDataGridViewTextBoxColumn.Name = "servingsDataGridViewTextBoxColumn";
            this.servingsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rCategoryDataGridViewTextBoxColumn
            // 
            this.rCategoryDataGridViewTextBoxColumn.DataPropertyName = "RCategory";
            this.rCategoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.rCategoryDataGridViewTextBoxColumn.Name = "rCategoryDataGridViewTextBoxColumn";
            this.rCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(558, 121);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(218, 47);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Update Results";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // RecipePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 553);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.filtersLabel);
            this.Name = "RecipePickerForm";
            this.Text = "RecipePickerForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource recipeBindingSource;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button updateButton;
    }
}