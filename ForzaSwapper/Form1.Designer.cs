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
            comboBox1 = new ComboBox();
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
            label4 = new Label();
            tabPage3 = new TabPage();
            label2 = new Label();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            button3 = new Button();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvSwaps).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(26, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            button1.Location = new Point(3, 12);
            button1.Name = "button1";
            button1.Size = new Size(88, 60);
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
            tabControl1.Location = new Point(93, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(706, 446);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(radioButton2);
            tabPage1.Controls.Add(radioButton1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(698, 418);
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
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(698, 418);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(153, 9);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 3;
            label4.Text = "Car";
            label4.Click += label4_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(radioButton5);
            tabPage3.Controls.Add(radioButton4);
            tabPage3.Controls.Add(radioButton3);
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(comboBox4);
            tabPage3.Controls.Add(comboBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(698, 418);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "DriveTrain Edit";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(165, 20);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 1;
            label2.Text = "Car";
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
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(21, 16);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(133, 23);
            comboBox3.TabIndex = 0;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(3, 78);
            button3.Name = "button3";
            button3.Size = new Size(88, 64);
            button3.TabIndex = 2;
            button3.Text = "Engine Name Spreadsheet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(button3);
            Controls.Add(button1);
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
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
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
        private Label label4;
        private ListBox listBox1;
        private Button button3;
        private TabPage tabPage3;
        private Label label2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
    }
}
