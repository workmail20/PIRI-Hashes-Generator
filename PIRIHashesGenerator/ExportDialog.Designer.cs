namespace PIRIHashesGenerator
{
    partial class ExportDialog
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
            button3 = new Button();
            button4 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Firebrick;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            button3.FlatAppearance.MouseDownBackColor = Color.Maroon;
            button3.FlatAppearance.MouseOverBackColor = Color.Red;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(475, 346);
            button3.Name = "button3";
            button3.Size = new Size(143, 38);
            button3.TabIndex = 11;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Green;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            button4.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
            button4.FlatAppearance.MouseOverBackColor = Color.Lime;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.Window;
            button4.Location = new Point(646, 346);
            button4.Name = "button4";
            button4.Size = new Size(142, 38);
            button4.TabIndex = 10;
            button4.Text = "Export";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button4_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Cursor = Cursors.Hand;
            listView1.Font = new Font("Kanit", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(12, 42);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 248);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.MouseClick += ListView1_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File name";
            columnHeader1.Width = 380;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Create date";
            columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Command";
            columnHeader3.Width = 115;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Kanit", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(102, 312);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 12;
            label1.Text = "File name:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Kanit", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(194, 309);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(467, 31);
            textBox1.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.Cursor = Cursors.Hand;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Kanit", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { ".pdf", ".docx", ".xlsx", ".csv", ".html", ".txt" });
            comboBox1.Location = new Point(667, 308);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 33);
            comboBox1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(98, 30);
            label2.TabIndex = 15;
            label2.Text = "Export file";
            // 
            // ExportDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 398);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportDialog";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Export";
            Load += ExportDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button button3;
        public Button button4;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label2;
        private ColumnHeader columnHeader3;
    }
}