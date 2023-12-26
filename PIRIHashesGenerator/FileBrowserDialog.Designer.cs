namespace PIRIHashesGenerator
{
    partial class FileBrowserDialog
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
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
            listView1.Size = new Size(776, 279);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            listView1.MouseClick += ListView1_MouseClick;
            listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File name";
            columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Create date";
            columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Command";
            columnHeader3.Width = 95;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(195, 30);
            label2.TabIndex = 5;
            label2.Text = "Select hash container";
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
            button3.Location = new Point(522, 327);
            button3.Name = "button3";
            button3.Size = new Size(121, 38);
            button3.TabIndex = 8;
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
            button4.Location = new Point(667, 327);
            button4.Name = "button4";
            button4.Size = new Size(121, 38);
            button4.TabIndex = 7;
            button4.Text = "Open";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button4_Click;
            // 
            // FileBrowserDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(800, 380);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FileBrowserDialog";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Open file";
            Load += FileBrowserDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label label2;
        public Button button3;
        public Button button4;
        private ColumnHeader columnHeader3;
    }
}