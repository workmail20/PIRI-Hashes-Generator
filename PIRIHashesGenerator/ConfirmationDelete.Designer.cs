namespace PIRIHashesGenerator
{
    partial class ConfirmationDelete
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
            panel1 = new Panel();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(490, 172);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Kanit", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(40, 47);
            label2.Name = "label2";
            label2.Size = new Size(409, 25);
            label2.TabIndex = 9;
            label2.Text = "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            // 
            // button2
            // 
            button2.BackColor = Color.Firebrick;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            button2.FlatAppearance.MouseDownBackColor = Color.Maroon;
            button2.FlatAppearance.MouseOverBackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(100, 113);
            button2.Name = "button2";
            button2.Size = new Size(121, 38);
            button2.TabIndex = 8;
            button2.Text = "No";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            button1.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
            button1.FlatAppearance.MouseOverBackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(267, 113);
            button1.Name = "button1";
            button1.Size = new Size(121, 38);
            button1.TabIndex = 7;
            button1.Text = "Yes";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Maroon;
            button3.Enabled = false;
            button3.Location = new Point(15, 86);
            button3.Name = "button3";
            button3.Size = new Size(458, 10);
            button3.TabIndex = 7;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Kanit", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(40, 15);
            label1.Name = "label1";
            label1.Size = new Size(388, 32);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to delete the file?";
            // 
            // ConfirmationDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(515, 199);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmationDelete";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Delete";
            Load += ConfirmationDelete_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public Button button2;
        public Button button1;
        private Button button3;
        private Label label1;
        public Label label2;
        public Panel panel1;
    }
}