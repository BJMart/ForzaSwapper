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
            button5 = new Button();
            tabPage2 = new TabPage();
            EngineSwapTabTable = new TableLayoutPanel();
            CarEngineListBox = new ListBox();
            TopLeftEngineSwapTable = new TableLayoutPanel();
            EngineSelectTable = new TableLayoutPanel();
            tabPage3 = new TabPage();
            panel2 = new Panel();
            comboBox4 = new ComboBox();
            radioButton3 = new RadioButton();
            button4 = new Button();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            EngineManager = new TabPage();
            button7 = new Button();
            buttonDuplicateEngine = new Button();
            button6 = new Button();
            label2 = new Label();
            comboBoxEngineManager = new ComboBox();
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
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            EngineManager.SuspendLayout();
            BackTable.SuspendLayout();
            LeftBarTable.SuspendLayout();
            CarSelectorTable.SuspendLayout();
            SuspendLayout();
            // 
            // CarSelectorComboBox
            // 
            CarSelectorComboBox.Dock = DockStyle.Fill;
            CarSelectorComboBox.FormattingEnabled = true;
            CarSelectorComboBox.Location = new Point(3, 4);
            CarSelectorComboBox.Margin = new Padding(3, 4, 3, 4);
            CarSelectorComboBox.Name = "CarSelectorComboBox";
            CarSelectorComboBox.Size = new Size(139, 28);
            CarSelectorComboBox.TabIndex = 0;
            CarSelectorComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dgvSwaps
            // 
            dgvSwaps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSwaps.Dock = DockStyle.Fill;
            dgvSwaps.Location = new Point(300, 204);
            dgvSwaps.Margin = new Padding(3, 4, 3, 4);
            dgvSwaps.Name = "dgvSwaps";
            dgvSwaps.RowHeadersWidth = 51;
            dgvSwaps.Size = new Size(685, 635);
            dgvSwaps.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(3, 4);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(184, 28);
            comboBox2.TabIndex = 0;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(188, 92);
            button1.TabIndex = 2;
            button1.Text = "DB Location";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(193, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 40);
            label1.TabIndex = 3;
            label1.Text = "Engine";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 52);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(101, 33);
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
            tabControl1.Controls.Add(EngineManager);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(203, 4);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1002, 884);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(radioButton2);
            tabPage1.Controls.Add(radioButton1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(button5);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(994, 851);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Handling Mods";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(18, 41);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(117, 24);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 8);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(76, 24);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Level 1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 84);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(158, 8);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(183, 107);
            button5.TabIndex = 4;
            button5.Text = "Add all tyre compounds";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(EngineSwapTabTable);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(994, 851);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Engine Swapper";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // EngineSwapTabTable
            // 
            EngineSwapTabTable.ColumnCount = 2;
            EngineSwapTabTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 297F));
            EngineSwapTabTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 689F));
            EngineSwapTabTable.Controls.Add(dgvSwaps, 1, 1);
            EngineSwapTabTable.Controls.Add(CarEngineListBox, 1, 0);
            EngineSwapTabTable.Controls.Add(TopLeftEngineSwapTable, 0, 0);
            EngineSwapTabTable.Dock = DockStyle.Fill;
            EngineSwapTabTable.Location = new Point(3, 4);
            EngineSwapTabTable.Margin = new Padding(3, 4, 3, 4);
            EngineSwapTabTable.Name = "EngineSwapTabTable";
            EngineSwapTabTable.RowCount = 2;
            EngineSwapTabTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            EngineSwapTabTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            EngineSwapTabTable.Size = new Size(988, 843);
            EngineSwapTabTable.TabIndex = 5;
            // 
            // CarEngineListBox
            // 
            CarEngineListBox.Dock = DockStyle.Fill;
            CarEngineListBox.FormattingEnabled = true;
            CarEngineListBox.Location = new Point(300, 4);
            CarEngineListBox.Margin = new Padding(3, 4, 3, 4);
            CarEngineListBox.Name = "CarEngineListBox";
            CarEngineListBox.Size = new Size(685, 192);
            CarEngineListBox.TabIndex = 4;
            // 
            // TopLeftEngineSwapTable
            // 
            TopLeftEngineSwapTable.ColumnCount = 1;
            TopLeftEngineSwapTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TopLeftEngineSwapTable.Controls.Add(EngineSelectTable, 0, 0);
            TopLeftEngineSwapTable.Controls.Add(button2, 0, 1);
            TopLeftEngineSwapTable.Dock = DockStyle.Fill;
            TopLeftEngineSwapTable.Location = new Point(3, 4);
            TopLeftEngineSwapTable.Margin = new Padding(3, 4, 3, 4);
            TopLeftEngineSwapTable.Name = "TopLeftEngineSwapTable";
            TopLeftEngineSwapTable.RowCount = 2;
            TopLeftEngineSwapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TopLeftEngineSwapTable.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            TopLeftEngineSwapTable.Size = new Size(291, 192);
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
            EngineSelectTable.Location = new Point(3, 4);
            EngineSelectTable.Margin = new Padding(3, 4, 3, 4);
            EngineSelectTable.Name = "EngineSelectTable";
            EngineSelectTable.RowCount = 1;
            EngineSelectTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            EngineSelectTable.Size = new Size(285, 40);
            EngineSelectTable.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel2);
            tabPage3.Controls.Add(panel1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(994, 851);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "DriveTrain Edit";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox4);
            panel2.Controls.Add(radioButton3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(radioButton4);
            panel2.Controls.Add(radioButton5);
            panel2.Location = new Point(7, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(202, 207);
            panel2.TabIndex = 5;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "FWD", "RWD", "AWD" });
            comboBox4.Location = new Point(16, 16);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(151, 28);
            comboBox4.TabIndex = 0;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(16, 53);
            radioButton3.Margin = new Padding(3, 4, 3, 4);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(64, 24);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "RWD";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // button4
            // 
            button4.Location = new Point(16, 152);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(152, 31);
            button4.TabIndex = 3;
            button4.Text = "Add/Modify";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(16, 85);
            radioButton4.Margin = new Padding(3, 4, 3, 4);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(64, 24);
            radioButton4.TabIndex = 2;
            radioButton4.TabStop = true;
            radioButton4.Text = "AWD";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(16, 119);
            radioButton5.Margin = new Padding(3, 4, 3, 4);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(62, 24);
            radioButton5.TabIndex = 2;
            radioButton5.TabStop = true;
            radioButton5.Text = "FWD";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(209, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(750, 833);
            panel1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(7, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // EngineManager
            // 
            EngineManager.Controls.Add(button7);
            EngineManager.Controls.Add(buttonDuplicateEngine);
            EngineManager.Controls.Add(button6);
            EngineManager.Controls.Add(label2);
            EngineManager.Controls.Add(comboBoxEngineManager);
            EngineManager.Location = new Point(4, 24);
            EngineManager.Name = "EngineManager";
            EngineManager.Padding = new Padding(3);
            EngineManager.Size = new Size(869, 635);
            EngineManager.TabIndex = 3;
            EngineManager.Text = "Engine Manager";
            EngineManager.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(260, 54);
            button7.Name = "button7";
            button7.Size = new Size(121, 40);
            button7.TabIndex = 2;
            button7.Text = "Delete Engine";
            button7.UseVisualStyleBackColor = true;
            button7.Click += buttonDeleteEngine_Click;
            // 
            // buttonDuplicateEngine
            // 
            buttonDuplicateEngine.Location = new Point(133, 54);
            buttonDuplicateEngine.Name = "buttonDuplicateEngine";
            buttonDuplicateEngine.Size = new Size(121, 40);
            buttonDuplicateEngine.TabIndex = 2;
            buttonDuplicateEngine.Text = "Duplicate Engine";
            buttonDuplicateEngine.UseVisualStyleBackColor = true;
            buttonDuplicateEngine.Click += buttonDuplicateEngine_Click;
            // 
            // button6
            // 
            button6.Location = new Point(6, 54);
            button6.Name = "button6";
            button6.Size = new Size(121, 40);
            button6.TabIndex = 2;
            button6.Text = "Export engine to other forza";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 25);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Engines";
            // 
            // comboBoxEngineManager
            // 
            comboBoxEngineManager.FormattingEnabled = true;
            comboBoxEngineManager.Location = new Point(6, 25);
            comboBoxEngineManager.Name = "comboBoxEngineManager";
            comboBoxEngineManager.Size = new Size(121, 23);
            comboBoxEngineManager.TabIndex = 0;
            comboBoxEngineManager.SelectedIndexChanged += comboBoxEngineManager_SelectedIndexChanged;
            // 
            // CarSelectorLabel
            // 
            CarSelectorLabel.AutoSize = true;
            CarSelectorLabel.Dock = DockStyle.Fill;
            CarSelectorLabel.Location = new Point(148, 0);
            CarSelectorLabel.Name = "CarSelectorLabel";
            CarSelectorLabel.Size = new Size(37, 45);
            CarSelectorLabel.TabIndex = 3;
            CarSelectorLabel.Text = "Car";
            CarSelectorLabel.Click += label4_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 104);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(188, 92);
            button3.TabIndex = 2;
            button3.Text = "Engine Name Spreadsheet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // BackTable
            // 
            BackTable.ColumnCount = 2;
            BackTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            BackTable.ColumnStyles.Add(new ColumnStyle());
            BackTable.Controls.Add(tabControl1, 1, 0);
            BackTable.Controls.Add(LeftBarTable, 0, 0);
            BackTable.Dock = DockStyle.Fill;
            BackTable.Location = new Point(0, 0);
            BackTable.Margin = new Padding(3, 4, 3, 4);
            BackTable.Name = "BackTable";
            BackTable.RowCount = 1;
            BackTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            BackTable.Size = new Size(1181, 892);
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
            LeftBarTable.Location = new Point(3, 4);
            LeftBarTable.Margin = new Padding(3, 4, 3, 4);
            LeftBarTable.Name = "LeftBarTable";
            LeftBarTable.RowCount = 4;
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            LeftBarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 121F));
            LeftBarTable.Size = new Size(194, 884);
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
            CarSelectorTable.Location = new Point(3, 204);
            CarSelectorTable.Margin = new Padding(3, 4, 3, 4);
            CarSelectorTable.Name = "CarSelectorTable";
            CarSelectorTable.RowCount = 1;
            CarSelectorTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CarSelectorTable.Size = new Size(188, 45);
            CarSelectorTable.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 892);
            Controls.Add(BackTable);
            Margin = new Padding(3, 4, 3, 4);
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            EngineManager.ResumeLayout(false);
            EngineManager.PerformLayout();
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
        private Button button4;
        private Panel panel2;
        private ComboBox comboBox1;
        private Panel panel1;
        private Button button5;
        private TabPage EngineManager;
        private ComboBox comboBoxEngineManager;
        private Label label2;
        private Button button6;
        private Button buttonDuplicateEngine;
        private Button button7;
    }
}
