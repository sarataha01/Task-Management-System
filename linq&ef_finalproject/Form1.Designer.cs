namespace linq_ef_finalproject
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            comboBox2 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            comboBox3 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label8 = new Label();
            comboBox4 = new ComboBox();
            label9 = new Label();
            comboBox5 = new ComboBox();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            label10 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            panel1 = new Panel();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.SlateGray;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.SlateGray;
            dataGridViewCellStyle1.Font = new Font("Constantia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(13, 198);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1005, 191);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 22);
            label1.TabIndex = 1;
            label1.Text = "Task Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 70);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 22);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 338);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 22);
            label3.TabIndex = 3;
            label3.Text = "Due Date";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlLight;
            textBox1.Location = new Point(152, 24);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(305, 29);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlLight;
            textBox2.Location = new Point(152, 68);
            textBox2.Margin = new Padding(4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(305, 245);
            textBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ControlLight;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(152, 384);
            comboBox1.Margin = new Padding(4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(305, 30);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Transparent;
            dateTimePicker1.Location = new Point(152, 331);
            dateTimePicker1.Margin = new Padding(4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(305, 29);
            dateTimePicker1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 393);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 22);
            label4.TabIndex = 8;
            label4.Text = "Priority";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 444);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 22);
            label5.TabIndex = 9;
            label5.Text = "Status";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.ControlLight;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(152, 436);
            comboBox2.Margin = new Padding(4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(305, 30);
            comboBox2.TabIndex = 10;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 104);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(67, 22);
            label6.TabIndex = 11;
            label6.Text = "Search:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 498);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(81, 22);
            label7.TabIndex = 12;
            label7.Text = "Category";
            // 
            // comboBox3
            // 
            comboBox3.BackColor = SystemColors.ControlLight;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(152, 488);
            comboBox3.Margin = new Padding(4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(305, 30);
            comboBox3.TabIndex = 13;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Location = new Point(39, 556);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(117, 32);
            button1.TabIndex = 14;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.System;
            button2.Location = new Point(181, 556);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(117, 32);
            button2.TabIndex = 15;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.System;
            button3.Location = new Point(322, 556);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(117, 32);
            button3.TabIndex = 16;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(441, 104);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(130, 22);
            label8.TabIndex = 17;
            label8.Text = "Filter by status:";
            // 
            // comboBox4
            // 
            comboBox4.BackColor = SystemColors.ControlLight;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(582, 97);
            comboBox4.Margin = new Padding(4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(188, 30);
            comboBox4.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(24, 148);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(110, 22);
            label9.TabIndex = 19;
            label9.Text = "Sort by date:";
            // 
            // comboBox5
            // 
            comboBox5.BackColor = SystemColors.ControlLight;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(140, 140);
            comboBox5.Margin = new Padding(4);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(188, 30);
            comboBox5.TabIndex = 20;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ControlLight;
            textBox3.Location = new Point(140, 98);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(225, 29);
            textBox3.TabIndex = 23;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.ControlLight;
            checkBox1.Location = new Point(441, 145);
            checkBox1.Margin = new Padding(4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(170, 26);
            checkBox1.TabIndex = 24;
            checkBox1.Text = "Group by priority";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(341, 431);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(47, 22);
            label10.TabIndex = 25;
            label10.Text = "Page";
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.System;
            button4.Location = new Point(494, 426);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(117, 32);
            button4.TabIndex = 26;
            button4.Text = "<";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.System;
            button5.Location = new Point(619, 426);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(117, 32);
            button5.TabIndex = 27;
            button5.Text = ">";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.System;
            button6.Location = new Point(302, 563);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(209, 32);
            button6.TabIndex = 28;
            button6.Text = "Generate Report";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.System;
            button7.Location = new Point(550, 563);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(209, 32);
            button7.TabIndex = 29;
            button7.Text = "Avg Completion Time";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(1030, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 612);
            panel1.TabIndex = 30;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Constantia", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label11.Location = new Point(1043, 16);
            label11.Name = "label11";
            label11.Size = new Size(114, 22);
            label11.TabIndex = 31;
            label11.Text = "Task Details";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Constantia", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(24, 29);
            label12.Name = "label12";
            label12.Size = new Size(87, 35);
            label12.TabIndex = 32;
            label12.Text = "Hello";
            label12.Click += label12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1513, 653);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(panel1);
            Controls.Add(checkBox1);
            Controls.Add(comboBox5);
            Controls.Add(label9);
            Controls.Add(comboBox4);
            Controls.Add(label8);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label10);
            Controls.Add(dataGridView1);
            Font = new Font("Constantia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonFace;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Task Management System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label5;
        private ComboBox comboBox2;
        private Label label6;
        private Label label7;
        private ComboBox comboBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label8;
        private ComboBox comboBox4;
        private Label label9;
        private ComboBox comboBox5;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private Label label10;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Panel panel1;
        private Label label11;
        private Label label12;
    }
}
