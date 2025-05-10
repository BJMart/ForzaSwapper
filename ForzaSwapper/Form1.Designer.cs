namespace ForzaSwapper
{
    partial class Form1
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
            CarSelectorComboBox = new ComboBox();
            dgvSwaps = new DataGridView();
            comboBox2 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            EngineSwapTabTable = new TableLayoutPanel();
            CarEngineListBox = new ListBox();
            TopLeftEngineSwapTable = new TableLayoutPanel();
            EngineSelectTable = new TableLayoutPanel();
            tabPage3 = new TabPage();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            comboBox4 = new ComboBox();
            CarSelectorLabel = new Label();
            button3 = new Button();
            BackTable = new TableLayoutPanel();
            LeftBarTable = new TableLayoutPanel();
            CarSelectorTable = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvSwaps).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            EngineSwapTabTable.SuspendLayout();
            TopLeftEngineSwapTable.SuspendLayout();
            EngineSelectTable.SuspendLayout();
            tabPage3.SuspendLayout();
            BackTable.SuspendLayout();
            LeftBarTable.SuspendLayout();
            CarSelectorTable.SuspendLayout();
            SuspendLayout();
            // 
            // CarSelectorComboBox
            // 
            CarSelectorComboBox.Dock = DockStyle.Fill;
            CarSelectorComboBox.FormattingEnabled = true;
            CarSelectorComboBox.Location = new Point(3, 3);
            CarSelectorComboBox.Name = "CarSelectorComboBox";
            CarSelectorComboBox.Size = new Size(120, 23);
            CarSelectorComboBox.TabIndex = 0;
            CarSelectorComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // 
            // dgvSwaps
            // 
            dgvSwaps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSwaps.Dock = DockStyle.Fill;
            dgvSwaps.Location = new Point(263, 153);
            dgvSwaps.Name = "dgvSwaps";
            dgvSwaps.RowHeadersWidth = 51;
            dgvSwaps.Size = new Size(597, 473);
            dgvSwaps.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(3, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(159, 23);
            comboBox2.TabIndex = 0;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(163, 69);

            button1.TabIndex = 2;
            button1.Text = "DB Location";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(168, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 30);
            label1.TabIndex = 3;
            label1.Text = "Engine";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 39);
            button2.Name = "button2";
            button2.Size = new Size(88, 25);
            button2.TabIndex = 2;
            button2.Text = "Swap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(178, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(877, 663);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(radioButton2);
            tabPage1.Controls.Add(radioButton1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(869, 635);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Handling Mods";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(16, 31);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 19);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(16, 6);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(61, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Level 1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(EngineSwapTabTable);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(869, 635);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Engine Swapper";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // EngineSwapTabTable
            // 
            EngineSwapTabTable.ColumnCount = 2;
            EngineSwapTabTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            EngineSwapTabTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            EngineSwapTabTable.Controls.Add(dgvSwaps, 1, 1);
            EngineSwapTabTable.Controls.Add(CarEngineListBox, 1, 0);
            EngineSwapTabTable.Controls.Add(TopLeftEngineSwapTable, 0, 0);
            EngineSwapTabTable.Dock = DockStyle.Fill;
            EngineSwapTabTable.Location = new Point(3, 3);
            EngineSwapTabTable.Name = "EngineSwapTabTable";
            EngineSwapTabTable.RowCount = 2;
            EngineSwapTabTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            EngineSwapTabTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            EngineSwapTabTable.Size = new Size(863, 629);
            EngineSwapTabTable.TabIndex = 5;
            // 
            // CarEngineListBox
            // 
            CarEngineListBox.Dock = DockStyle.Fill;
            CarEngineListBox.FormattingEnabled = true;
            CarEngineListBox.ItemHeight = 15;
            CarEngineListBox.Location = new Point(263, 3);
            CarEngineListBox.Name = "CarEngineListBox";
            CarEngineListBox.Size = new Size(597, 144);
            CarEngineListBox.TabIndex = 4;
            // 
            // TopLeftEngineSwapTable
            // 
            TopLeftEngineSwapTable.ColumnCount = 1;
            TopLeftEngineSwapTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TopLeftEngineSwapTable.Controls.Add(EngineSelectTable, 0, 0);
            TopLeftEngineSwapTable.Controls.Add(button2, 0, 1);
            TopLeftEngineSwapTable.Dock = DockStyle.Fill;
            TopLeftEngineSwapTable.Location = new Point(3, 3);
            TopLeftEngineSwapTable.Name = "TopLeftEngineSwapTable";
            TopLeftEngineSwapTable.RowCount = 2;
            TopLeftEngineSwapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TopLeftEngineSwapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            TopLeftEngineSwapTable.Size = new Size(254, 144);
            TopLeftEngineSwapTable.TabIndex = 5;
            // 
            // EngineSelectTable
            // 
            EngineSelectTable.ColumnCount = 2;
            EngineSelectTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            EngineSelectTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            EngineSelectTable.Controls.Add(comboBox2, 0, 0);
            EngineSelectTable.Controls.Add(label1, 1, 0);
            EngineSelectTable.Dock = DockStyle.Fill;
            EngineSelectTable.Location = new Point(3, 3);
            EngineSelectTable.Name = "EngineSelectTable";
            EngineSelectTable.RowCount = 1;
            EngineSelectTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            EngineSelectTable.Size = new Size(248, 30);
            EngineSelectTable.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(radioButton5);
            tabPage3.Controls.Add(radioButton4);
            tabPage3.Controls.Add(radioButton3);
            tabPage3.Controls.Add(comboBox4);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(869, 635);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "DriveTrain Edit";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(21, 99);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(50, 19);
            radioButton5.TabIndex = 2;
            radioButton5.TabStop = true;
            radioButton5.Text = "FWD";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(21, 74);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(51, 19);
            radioButton4.TabIndex = 2;
            radioButton4.TabStop = true;
            radioButton4.Text = "AWD";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(21, 49);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(51, 19);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "RWD";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "FWD", "RWD", "AWD" });
            comboBox4.Location = new Point(21, 22);
            comboBox4.Margin = new Padding(3, 2, 3, 2);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(133, 23);
            comboBox4.TabIndex = 0;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // CarSelectorLabel
            // 
            CarSelectorLabel.AutoSize = true;
            CarSelectorLabel.Dock = DockStyle.Fill;
            CarSelectorLabel.Location = new Point(129, 0);
            CarSelectorLabel.Name = "CarSelectorLabel";
            CarSelectorLabel.Size = new Size(31, 34);
            CarSelectorLabel.TabIndex = 3;
            CarSelectorLabel.Text = "Car";
            CarSelectorLabel.Click += label4_Click;

            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 78);
            button3.Name = "button3";
            button3.Size = new Size(163, 69);

            button3.TabIndex = 2;
            button3.Text = "Engine Name Spreadsheet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // BackTable
            // 
            BackTable.ColumnCount = 2;
            BackTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            BackTable.ColumnStyles.Add(new ColumnStyle());
            BackTable.Controls.Add(tabControl1, 1, 0);
            BackTable.Controls.Add(LeftBarTable, 0, 0);
            BackTable.Dock = DockStyle.Fill;
            BackTable.Location = new Point(0, 0);
            BackTable.Name = "BackTable";
            BackTable.RowCount = 1;
            BackTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            BackTable.Size = new Size(1033, 669);
            BackTable.TabIndex = 6;
            // 
            // LeftBarTable
            // 
            LeftBarTable.ColumnCount = 1;
            LeftBarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LeftBarTable.Controls.Add(button1, 0, 0);
            LeftBarTable.Controls.Add(button3, 0, 1);
            LeftBarTable.Controls.Add(CarSelectorTable, 0, 2);
            LeftBarTable.Dock = DockStyle.Fill;
            LeftBarTable.Location = new Point(3, 3);
            LeftBarTable.Name = "LeftBarTable";
            LeftBarTable.RowCount = 4;
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 91F));
            LeftBarTable.Size = new Size(169, 663);
            LeftBarTable.TabIndex = 6;
            // 
            // CarSelectorTable
            // 
            CarSelectorTable.ColumnCount = 2;
            CarSelectorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.30061F));
            CarSelectorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.6993866F));
            CarSelectorTable.Controls.Add(CarSelectorComboBox, 0, 0);
            CarSelectorTable.Controls.Add(CarSelectorLabel, 1, 0);
            CarSelectorTable.Dock = DockStyle.Fill;
            CarSelectorTable.Location = new Point(3, 153);
            CarSelectorTable.Name = "CarSelectorTable";
            CarSelectorTable.RowCount = 1;
            CarSelectorTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CarSelectorTable.Size = new Size(163, 34);
            CarSelectorTable.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1033, 669);
            Controls.Add(BackTable);

            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSwaps).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            EngineSwapTabTable.ResumeLayout(false);
            TopLeftEngineSwapTable.ResumeLayout(false);
            EngineSelectTable.ResumeLayout(false);
            EngineSelectTable.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            BackTable.ResumeLayout(false);
            LeftBarTable.ResumeLayout(false);
            CarSelectorTable.ResumeLayout(false);
            CarSelectorTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CarSelectorComboBox;
        private DataGridView dgvSwaps;
        private ComboBox comboBox2;
        private Button button1;
        private Label label1;
        private Button button2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RadioButton radioButton1;
        private TextBox textBox1;
        private RadioButton radioButton2;
        private Label CarSelectorLabel;
        private ListBox CarEngineListBox;
        private Button button3;
        private TabPage tabPage3;
        private ComboBox comboBox4;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private TableLayoutPanel BackTable;
        private TableLayoutPanel LeftBarTable;
        private TableLayoutPanel CarSelectorTable;
        private TableLayoutPanel EngineSwapTabTable;
        private TableLayoutPanel TopLeftEngineSwapTable;
        private TableLayoutPanel EngineSelectTable;
    }
}
