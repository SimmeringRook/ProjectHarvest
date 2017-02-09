namespace Client_Desktop
{
    partial class PantryForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pantryTabControl = new System.Windows.Forms.TabControl();
            this.mealPlannerTabPage = new System.Windows.Forms.TabPage();
            this.mealPlannerMainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.weekTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.planButton1 = new System.Windows.Forms.Button();
            this.dayLabelsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.saturdayLabel = new System.Windows.Forms.Label();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.thursdayLabel = new System.Windows.Forms.Label();
            this.wednesdayLabel = new System.Windows.Forms.Label();
            this.tuesdayLabel = new System.Windows.Forms.Label();
            this.mondayLabel = new System.Windows.Forms.Label();
            this.sundayLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inventoryTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metricIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.harvestDataSet = new Client_Desktop.HarvestDataSet();
            this.recipeTabPage = new System.Windows.Forms.TabPage();
            this.inventoryTableAdapter = new Client_Desktop.HarvestDataSetTableAdapters.InventoryTableAdapter();
            this.mainMenuStrip.SuspendLayout();
            this.pantryTabControl.SuspendLayout();
            this.mealPlannerTabPage.SuspendLayout();
            this.mealPlannerMainTableLayout.SuspendLayout();
            this.weekTableLayout.SuspendLayout();
            this.dayLabelsTableLayout.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.inventoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.harvestDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mainMenuStrip.Size = new System.Drawing.Size(1088, 44);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pantryTabControl
            // 
            this.pantryTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pantryTabControl.Controls.Add(this.mealPlannerTabPage);
            this.pantryTabControl.Controls.Add(this.inventoryTabPage);
            this.pantryTabControl.Controls.Add(this.recipeTabPage);
            this.pantryTabControl.Location = new System.Drawing.Point(0, 48);
            this.pantryTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pantryTabControl.Name = "pantryTabControl";
            this.pantryTabControl.SelectedIndex = 0;
            this.pantryTabControl.Size = new System.Drawing.Size(1088, 633);
            this.pantryTabControl.TabIndex = 1;
            // 
            // mealPlannerTabPage
            // 
            this.mealPlannerTabPage.Controls.Add(this.mealPlannerMainTableLayout);
            this.mealPlannerTabPage.Location = new System.Drawing.Point(8, 39);
            this.mealPlannerTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mealPlannerTabPage.Name = "mealPlannerTabPage";
            this.mealPlannerTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mealPlannerTabPage.Size = new System.Drawing.Size(1072, 586);
            this.mealPlannerTabPage.TabIndex = 0;
            this.mealPlannerTabPage.Text = "Meal Planner";
            this.mealPlannerTabPage.UseVisualStyleBackColor = true;
            // 
            // mealPlannerMainTableLayout
            // 
            this.mealPlannerMainTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mealPlannerMainTableLayout.AutoSize = true;
            this.mealPlannerMainTableLayout.ColumnCount = 2;
            this.mealPlannerMainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mealPlannerMainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.mealPlannerMainTableLayout.Controls.Add(this.weekTableLayout, 1, 1);
            this.mealPlannerMainTableLayout.Controls.Add(this.dayLabelsTableLayout, 1, 0);
            this.mealPlannerMainTableLayout.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.mealPlannerMainTableLayout.Location = new System.Drawing.Point(4, 9);
            this.mealPlannerMainTableLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mealPlannerMainTableLayout.Name = "mealPlannerMainTableLayout";
            this.mealPlannerMainTableLayout.RowCount = 2;
            this.mealPlannerMainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mealPlannerMainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.mealPlannerMainTableLayout.Size = new System.Drawing.Size(1066, 569);
            this.mealPlannerMainTableLayout.TabIndex = 1;
            // 
            // weekTableLayout
            // 
            this.weekTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weekTableLayout.BackColor = System.Drawing.Color.Transparent;
            this.weekTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.weekTableLayout.ColumnCount = 7;
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.weekTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.weekTableLayout.Controls.Add(this.button20, 6, 2);
            this.weekTableLayout.Controls.Add(this.button19, 5, 2);
            this.weekTableLayout.Controls.Add(this.button18, 4, 2);
            this.weekTableLayout.Controls.Add(this.button17, 3, 2);
            this.weekTableLayout.Controls.Add(this.button16, 2, 2);
            this.weekTableLayout.Controls.Add(this.button15, 1, 2);
            this.weekTableLayout.Controls.Add(this.button14, 0, 2);
            this.weekTableLayout.Controls.Add(this.button13, 6, 1);
            this.weekTableLayout.Controls.Add(this.button12, 5, 1);
            this.weekTableLayout.Controls.Add(this.button11, 4, 1);
            this.weekTableLayout.Controls.Add(this.button10, 3, 1);
            this.weekTableLayout.Controls.Add(this.button9, 2, 1);
            this.weekTableLayout.Controls.Add(this.button8, 1, 1);
            this.weekTableLayout.Controls.Add(this.button7, 0, 1);
            this.weekTableLayout.Controls.Add(this.button6, 6, 0);
            this.weekTableLayout.Controls.Add(this.button5, 5, 0);
            this.weekTableLayout.Controls.Add(this.button4, 4, 0);
            this.weekTableLayout.Controls.Add(this.button3, 3, 0);
            this.weekTableLayout.Controls.Add(this.button2, 2, 0);
            this.weekTableLayout.Controls.Add(this.button1, 1, 0);
            this.weekTableLayout.Controls.Add(this.planButton1, 0, 0);
            this.weekTableLayout.Location = new System.Drawing.Point(110, 61);
            this.weekTableLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.weekTableLayout.Name = "weekTableLayout";
            this.weekTableLayout.RowCount = 3;
            this.weekTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekTableLayout.Size = new System.Drawing.Size(952, 503);
            this.weekTableLayout.TabIndex = 0;
            // 
            // button20
            // 
            this.button20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button20.Location = new System.Drawing.Point(815, 340);
            this.button20.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(132, 36);
            this.button20.TabIndex = 21;
            this.button20.Text = "Plan";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button19.Location = new System.Drawing.Point(680, 340);
            this.button19.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(126, 36);
            this.button19.TabIndex = 20;
            this.button19.Text = "Plan";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button18.Location = new System.Drawing.Point(545, 340);
            this.button18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(126, 36);
            this.button18.TabIndex = 19;
            this.button18.Text = "Plan";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button17.Location = new System.Drawing.Point(410, 340);
            this.button17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(126, 36);
            this.button17.TabIndex = 18;
            this.button17.Text = "Plan";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button16.Location = new System.Drawing.Point(275, 340);
            this.button16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(126, 36);
            this.button16.TabIndex = 17;
            this.button16.Text = "Plan";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.Location = new System.Drawing.Point(140, 340);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(126, 36);
            this.button15.TabIndex = 16;
            this.button15.Text = "Plan";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.Location = new System.Drawing.Point(5, 340);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(126, 36);
            this.button14.TabIndex = 15;
            this.button14.Text = "Plan";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.Location = new System.Drawing.Point(815, 173);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(132, 36);
            this.button13.TabIndex = 14;
            this.button13.Text = "Plan";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.Location = new System.Drawing.Point(680, 173);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(126, 36);
            this.button12.TabIndex = 13;
            this.button12.Text = "Plan";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button11.Location = new System.Drawing.Point(545, 173);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(126, 36);
            this.button11.TabIndex = 12;
            this.button11.Text = "Plan";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.Location = new System.Drawing.Point(410, 173);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(126, 36);
            this.button10.TabIndex = 11;
            this.button10.Text = "Plan";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(275, 173);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(126, 36);
            this.button9.TabIndex = 10;
            this.button9.Text = "Plan";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(140, 173);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 36);
            this.button8.TabIndex = 9;
            this.button8.Text = "Plan";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(5, 173);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 36);
            this.button7.TabIndex = 8;
            this.button7.Text = "Plan";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(815, 6);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(132, 36);
            this.button6.TabIndex = 7;
            this.button6.Text = "Plan";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(680, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 36);
            this.button5.TabIndex = 6;
            this.button5.Text = "Plan";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(545, 6);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 36);
            this.button4.TabIndex = 5;
            this.button4.Text = "Plan";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(410, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Plan";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(275, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Plan";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(140, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Plan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // planButton1
            // 
            this.planButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planButton1.Location = new System.Drawing.Point(5, 6);
            this.planButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.planButton1.Name = "planButton1";
            this.planButton1.Size = new System.Drawing.Size(126, 36);
            this.planButton1.TabIndex = 1;
            this.planButton1.Text = "Plan";
            this.planButton1.UseVisualStyleBackColor = true;
            // 
            // dayLabelsTableLayout
            // 
            this.dayLabelsTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayLabelsTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.dayLabelsTableLayout.ColumnCount = 7;
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.dayLabelsTableLayout.Controls.Add(this.saturdayLabel, 6, 0);
            this.dayLabelsTableLayout.Controls.Add(this.fridayLabel, 5, 0);
            this.dayLabelsTableLayout.Controls.Add(this.thursdayLabel, 4, 0);
            this.dayLabelsTableLayout.Controls.Add(this.wednesdayLabel, 3, 0);
            this.dayLabelsTableLayout.Controls.Add(this.tuesdayLabel, 2, 0);
            this.dayLabelsTableLayout.Controls.Add(this.mondayLabel, 1, 0);
            this.dayLabelsTableLayout.Controls.Add(this.sundayLabel, 0, 0);
            this.dayLabelsTableLayout.Location = new System.Drawing.Point(110, 5);
            this.dayLabelsTableLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dayLabelsTableLayout.Name = "dayLabelsTableLayout";
            this.dayLabelsTableLayout.RowCount = 1;
            this.dayLabelsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dayLabelsTableLayout.Size = new System.Drawing.Size(952, 46);
            this.dayLabelsTableLayout.TabIndex = 1;
            // 
            // saturdayLabel
            // 
            this.saturdayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saturdayLabel.AutoSize = true;
            this.saturdayLabel.Location = new System.Drawing.Point(815, 1);
            this.saturdayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saturdayLabel.Name = "saturdayLabel";
            this.saturdayLabel.Size = new System.Drawing.Size(132, 44);
            this.saturdayLabel.TabIndex = 6;
            this.saturdayLabel.Text = "Saturday";
            this.saturdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fridayLabel
            // 
            this.fridayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fridayLabel.AutoSize = true;
            this.fridayLabel.Location = new System.Drawing.Point(680, 1);
            this.fridayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Size = new System.Drawing.Size(126, 44);
            this.fridayLabel.TabIndex = 5;
            this.fridayLabel.Text = "Friday";
            this.fridayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thursdayLabel.AutoSize = true;
            this.thursdayLabel.Location = new System.Drawing.Point(545, 1);
            this.thursdayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.Size = new System.Drawing.Size(126, 44);
            this.thursdayLabel.TabIndex = 4;
            this.thursdayLabel.Text = "Thursday";
            this.thursdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wednesdayLabel.AutoSize = true;
            this.wednesdayLabel.Location = new System.Drawing.Point(410, 1);
            this.wednesdayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.Size = new System.Drawing.Size(126, 44);
            this.wednesdayLabel.TabIndex = 3;
            this.wednesdayLabel.Text = "Wednesday";
            this.wednesdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tuesdayLabel.AutoSize = true;
            this.tuesdayLabel.Location = new System.Drawing.Point(275, 1);
            this.tuesdayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.Size = new System.Drawing.Size(126, 44);
            this.tuesdayLabel.TabIndex = 2;
            this.tuesdayLabel.Text = "Tuesday";
            this.tuesdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mondayLabel
            // 
            this.mondayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mondayLabel.AutoSize = true;
            this.mondayLabel.Location = new System.Drawing.Point(140, 1);
            this.mondayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.Size = new System.Drawing.Size(126, 44);
            this.mondayLabel.TabIndex = 1;
            this.mondayLabel.Text = "Monday";
            this.mondayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sundayLabel
            // 
            this.sundayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sundayLabel.AutoSize = true;
            this.sundayLabel.Location = new System.Drawing.Point(5, 1);
            this.sundayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sundayLabel.Name = "sundayLabel";
            this.sundayLabel.Size = new System.Drawing.Size(126, 44);
            this.sundayLabel.TabIndex = 0;
            this.sundayLabel.Text = "Sunday";
            this.sundayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 61);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(98, 503);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 406);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Evening";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 225);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Afternoon";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Morning";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inventoryTabPage
            // 
            this.inventoryTabPage.Controls.Add(this.dataGridView1);
            this.inventoryTabPage.Location = new System.Drawing.Point(8, 39);
            this.inventoryTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inventoryTabPage.Name = "inventoryTabPage";
            this.inventoryTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inventoryTabPage.Size = new System.Drawing.Size(1072, 586);
            this.inventoryTabPage.TabIndex = 1;
            this.inventoryTabPage.Text = "Inventory";
            this.inventoryTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeIDDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.metricIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inventoryBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 5);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1064, 576);
            this.dataGridView1.TabIndex = 0;
            //
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeIDDataGridViewTextBoxColumn
            // 
            this.typeIDDataGridViewTextBoxColumn.DataPropertyName = "TypeID";
            this.typeIDDataGridViewTextBoxColumn.HeaderText = "TypeID";
            this.typeIDDataGridViewTextBoxColumn.Name = "typeIDDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // metricIDDataGridViewTextBoxColumn
            // 
            this.metricIDDataGridViewTextBoxColumn.DataPropertyName = "MetricID";
            this.metricIDDataGridViewTextBoxColumn.HeaderText = "MetricID";
            this.metricIDDataGridViewTextBoxColumn.Name = "metricIDDataGridViewTextBoxColumn";
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.harvestDataSet;
            // 
            // harvestDataSet
            // 
            this.harvestDataSet.DataSetName = "HarvestDataSet";
            this.harvestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recipeTabPage
            // 
            this.recipeTabPage.Location = new System.Drawing.Point(8, 39);
            this.recipeTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeTabPage.Name = "recipeTabPage";
            this.recipeTabPage.Size = new System.Drawing.Size(1072, 586);
            this.recipeTabPage.TabIndex = 2;
            this.recipeTabPage.Text = "Recipes";
            this.recipeTabPage.UseVisualStyleBackColor = true;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // PantryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 700);
            this.Controls.Add(this.pantryTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PantryForm";
            this.Text = "Pantry";
            this.Load += new System.EventHandler(this.PantryForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.pantryTabControl.ResumeLayout(false);
            this.mealPlannerTabPage.ResumeLayout(false);
            this.mealPlannerTabPage.PerformLayout();
            this.mealPlannerMainTableLayout.ResumeLayout(false);
            this.weekTableLayout.ResumeLayout(false);
            this.dayLabelsTableLayout.ResumeLayout(false);
            this.dayLabelsTableLayout.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.inventoryTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.harvestDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl pantryTabControl;
        private System.Windows.Forms.TabPage mealPlannerTabPage;
        private System.Windows.Forms.TabPage inventoryTabPage;
        private System.Windows.Forms.TableLayoutPanel mealPlannerMainTableLayout;
        private System.Windows.Forms.TableLayoutPanel weekTableLayout;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button planButton1;
        private System.Windows.Forms.TableLayoutPanel dayLabelsTableLayout;
        private System.Windows.Forms.Label saturdayLabel;
        private System.Windows.Forms.Label fridayLabel;
        private System.Windows.Forms.Label thursdayLabel;
        private System.Windows.Forms.Label wednesdayLabel;
        private System.Windows.Forms.Label tuesdayLabel;
        private System.Windows.Forms.Label mondayLabel;
        private System.Windows.Forms.Label sundayLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage recipeTabPage;
        private HarvestDataSet harvestDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private HarvestDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn metricIDDataGridViewTextBoxColumn;
    }
}

