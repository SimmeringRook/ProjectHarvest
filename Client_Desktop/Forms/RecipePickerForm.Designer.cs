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
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.servingsCombo = new System.Windows.Forms.ComboBox();
            this.RecipeGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecipeGridView)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.categoryCombo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.servingsCombo, 3, 0);
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
            // categoryCombo
            // 
            this.categoryCombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoryCombo.FormattingEnabled = true;
            this.categoryCombo.Location = new System.Drawing.Point(205, 8);
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(181, 33);
            this.categoryCombo.TabIndex = 2;
            this.categoryCombo.SelectedIndexChanged += new System.EventHandler(this.categoryCombo_SelectedIndexChanged);
            // 
            // servingsCombo
            // 
            this.servingsCombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.servingsCombo.FormattingEnabled = true;
            this.servingsCombo.Location = new System.Drawing.Point(626, 8);
            this.servingsCombo.Name = "servingsCombo";
            this.servingsCombo.Size = new System.Drawing.Size(130, 33);
            this.servingsCombo.TabIndex = 3;
            this.servingsCombo.SelectedIndexChanged += new System.EventHandler(this.servingsCombo_SelectedIndexChanged);
            // 
            // RecipeGridView
            // 
            this.RecipeGridView.AllowUserToAddRows = false;
            this.RecipeGridView.AllowUserToDeleteRows = false;
            this.RecipeGridView.AutoGenerateColumns = false;
            this.RecipeGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecipeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecipeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.servingsDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn});
            this.RecipeGridView.DataSource = this.recipeBindingSource;
            this.RecipeGridView.Location = new System.Drawing.Point(20, 104);
            this.RecipeGridView.Name = "RecipeGridView";
            this.RecipeGridView.ReadOnly = true;
            this.RecipeGridView.RowTemplate.Height = 33;
            this.RecipeGridView.Size = new System.Drawing.Size(791, 365);
            this.RecipeGridView.TabIndex = 6;
            this.RecipeGridView.SelectionChanged += new System.EventHandler(this.RecipeGridView_SelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // servingsDataGridViewTextBoxColumn
            // 
            this.servingsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.servingsDataGridViewTextBoxColumn.DataPropertyName = "Servings";
            this.servingsDataGridViewTextBoxColumn.HeaderText = "Servings";
            this.servingsDataGridViewTextBoxColumn.Name = "servingsDataGridViewTextBoxColumn";
            this.servingsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recipeBindingSource
            // 
            this.recipeBindingSource.DataSource = typeof(Core.Adapters.Objects.Recipe);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(238, 494);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(139, 48);
            this.selectButton.TabIndex = 7;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(446, 493);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(139, 48);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RecipePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(823, 553);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.RecipeGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.filtersLabel);
            this.Name = "RecipePickerForm";
            this.Text = "RecipePickerForm";
            this.Load += new System.EventHandler(this.RecipePickerForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecipeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.ComboBox servingsCombo;
        private System.Windows.Forms.DataGridView RecipeGridView;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource recipeBindingSource;
        private System.Windows.Forms.Button cancelButton;
    }
}