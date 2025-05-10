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
            listBox1 = new ListBox();
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
            CarSelectorComboBox.Size = new Size(86, 23);
            CarSelectorComboBox.TabIndex = 0;
            CarSelectorComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dgvSwaps
            // 
            dgvSwaps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSwaps.Location = new Point(26, 95);
            dgvSwaps.Name = "dgvSwaps";
            dgvSwaps.RowHeadersWidth = 51;
            dgvSwaps.Size = new Size(654, 305);
            dgvSwaps.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(26, 35);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 0;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(132, 69);
            button1.TabIndex = 2;
            button1.Text = "DB Location";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 43);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "Engine";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(26, 64);
            button2.Name = "button2";
            button2.Size = new Size(121, 25);
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
            tabControl1.Location = new Point(147, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(650, 444);
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
            tabPage1.Size = new Size(642, 416);
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
            tabPage2.Controls.Add(listBox1);
            tabPage2.Controls.Add(dgvSwaps);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(642, 416);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Engine Swapper";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(211, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(469, 94);
            listBox1.TabIndex = 4;
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
            tabPage3.Size = new Size(642, 416);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "DriveTrain Edit";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(21, 180);
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
            radioButton4.Location = new Point(21, 155);
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
            radioButton3.Location = new Point(21, 130);
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
            comboBox4.Location = new Point(21, 96);
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
            CarSelectorLabel.Location = new Point(95, 0);
            CarSelectorLabel.Name = "CarSelectorLabel";
            CarSelectorLabel.Size = new Size(34, 34);
            CarSelectorLabel.TabIndex = 3;
            CarSelectorLabel.Text = "Car";
            CarSelectorLabel.Click += label4_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 78);
            button3.Name = "button3";
            button3.Size = new Size(132, 69);
            button3.TabIndex = 2;
            button3.Text = "Engine Name Spreadsheet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // BackTable
            // 
            BackTable.ColumnCount = 2;
            BackTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0400887F));
            BackTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.95991F));
            BackTable.Controls.Add(tabControl1, 1, 0);
            BackTable.Controls.Add(LeftBarTable, 0, 0);
            BackTable.Dock = DockStyle.Fill;
            BackTable.Location = new Point(0, 0);
            BackTable.Name = "BackTable";
            BackTable.RowCount = 1;
            BackTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            BackTable.Size = new Size(800, 450);
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
            LeftBarTable.Size = new Size(138, 444);
            LeftBarTable.TabIndex = 6;
            // 
            // CarSelectorTable
            // 
            CarSelectorTable.ColumnCount = 2;
            CarSelectorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            CarSelectorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            CarSelectorTable.Controls.Add(CarSelectorComboBox, 0, 0);
            CarSelectorTable.Controls.Add(CarSelectorLabel, 1, 0);
            CarSelectorTable.Dock = DockStyle.Fill;
            CarSelectorTable.Location = new Point(3, 153);
            CarSelectorTable.Name = "CarSelectorTable";
            CarSelectorTable.RowCount = 1;
            CarSelectorTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CarSelectorTable.Size = new Size(132, 34);
            CarSelectorTable.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackTable);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSwaps).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
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
        private ListBox listBox1;
        private Button button3;
        private TabPage tabPage3;
        private ComboBox comboBox4;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private TableLayoutPanel BackTable;
        private TableLayoutPanel LeftBarTable;
        private TableLayoutPanel CarSelectorTable;
    }
}
