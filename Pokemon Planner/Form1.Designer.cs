namespace Pokemon_Planner
{
    partial class FormMain
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxLocations = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelPokemon = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewPokemonTable = new System.Windows.Forms.DataGridView();
            this.colGame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevelRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanelSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelCurrentlySelected = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPokemonTable)).BeginInit();
            this.flowLayoutPanelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(968, 616);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(960, 590);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Location Lookup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxLocations, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelPokemon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewPokemonTable, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelSettings, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 584);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // listBoxLocations
            // 
            this.listBoxLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLocations.FormattingEnabled = true;
            this.listBoxLocations.Location = new System.Drawing.Point(3, 83);
            this.listBoxLocations.Name = "listBoxLocations";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxLocations, 2);
            this.listBoxLocations.Size = new System.Drawing.Size(229, 498);
            this.listBoxLocations.TabIndex = 4;
            this.listBoxLocations.SelectedIndexChanged += new System.EventHandler(this.listBoxLocations_SelectedIndexChanged);
            // 
            // flowLayoutPanelPokemon
            // 
            this.flowLayoutPanelPokemon.AutoScroll = true;
            this.flowLayoutPanelPokemon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPokemon.Location = new System.Drawing.Point(238, 3);
            this.flowLayoutPanelPokemon.Name = "flowLayoutPanelPokemon";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanelPokemon, 2);
            this.flowLayoutPanelPokemon.Size = new System.Drawing.Size(713, 164);
            this.flowLayoutPanelPokemon.TabIndex = 6;
            // 
            // dataGridViewPokemonTable
            // 
            this.dataGridViewPokemonTable.AllowUserToAddRows = false;
            this.dataGridViewPokemonTable.AllowUserToDeleteRows = false;
            this.dataGridViewPokemonTable.AllowUserToResizeColumns = false;
            this.dataGridViewPokemonTable.AllowUserToResizeRows = false;
            this.dataGridViewPokemonTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewPokemonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPokemonTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGame,
            this.colMethod,
            this.colLevelRange,
            this.colChance,
            this.colCondition});
            this.dataGridViewPokemonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPokemonTable.Enabled = false;
            this.dataGridViewPokemonTable.Location = new System.Drawing.Point(238, 173);
            this.dataGridViewPokemonTable.Name = "dataGridViewPokemonTable";
            this.dataGridViewPokemonTable.ReadOnly = true;
            this.dataGridViewPokemonTable.RowHeadersVisible = false;
            this.dataGridViewPokemonTable.Size = new System.Drawing.Size(713, 408);
            this.dataGridViewPokemonTable.TabIndex = 3;
            this.dataGridViewPokemonTable.SelectionChanged += new System.EventHandler(this.DataGridViewPokemonTable_SelectionChanged);
            // 
            // colGame
            // 
            this.colGame.HeaderText = "Game";
            this.colGame.Name = "colGame";
            this.colGame.ReadOnly = true;
            this.colGame.Width = 60;
            // 
            // colMethod
            // 
            this.colMethod.HeaderText = "Method";
            this.colMethod.Name = "colMethod";
            this.colMethod.ReadOnly = true;
            this.colMethod.Width = 68;
            // 
            // colLevelRange
            // 
            this.colLevelRange.HeaderText = "Level Range";
            this.colLevelRange.Name = "colLevelRange";
            this.colLevelRange.Width = 93;
            // 
            // colChance
            // 
            this.colChance.HeaderText = "Chance";
            this.colChance.Name = "colChance";
            this.colChance.ReadOnly = true;
            this.colChance.Width = 69;
            // 
            // colCondition
            // 
            this.colCondition.HeaderText = "Condition";
            this.colCondition.Name = "colCondition";
            this.colCondition.ReadOnly = true;
            this.colCondition.Width = 76;
            // 
            // flowLayoutPanelSettings
            // 
            this.flowLayoutPanelSettings.Controls.Add(this.textBox1);
            this.flowLayoutPanelSettings.Controls.Add(this.progressBar1);
            this.flowLayoutPanelSettings.Controls.Add(this.labelCurrentlySelected);
            this.flowLayoutPanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSettings.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelSettings.Name = "flowLayoutPanelSettings";
            this.flowLayoutPanelSettings.Size = new System.Drawing.Size(229, 74);
            this.flowLayoutPanelSettings.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(226, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // labelCurrentlySelected
            // 
            this.labelCurrentlySelected.AutoSize = true;
            this.labelCurrentlySelected.Location = new System.Drawing.Point(3, 55);
            this.labelCurrentlySelected.Name = "labelCurrentlySelected";
            this.labelCurrentlySelected.Size = new System.Drawing.Size(125, 13);
            this.labelCurrentlySelected.TabIndex = 6;
            this.labelCurrentlySelected.Text = "Currently Selected: None";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(960, 590);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "?";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 616);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(477, 364);
            this.Name = "FormMain";
            this.Text = "Pokémon Planner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPokemonTable)).EndInit();
            this.flowLayoutPanelSettings.ResumeLayout(false);
            this.flowLayoutPanelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxLocations;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPokemon;
        private System.Windows.Forms.DataGridView dataGridViewPokemonTable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSettings;
        private System.Windows.Forms.Label labelCurrentlySelected;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGame;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevelRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondition;
    }
}

