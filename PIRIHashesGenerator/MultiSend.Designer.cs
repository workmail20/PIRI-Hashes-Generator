namespace PIRIHashesGenerator
{
    partial class MultiSend
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
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Font = new Font("Kanit", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 135);
            textBox1.MaxLength = 100000000;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = " PRTMRdFE2mVStmA3S3h6dHEG6rR9Kr6CpY1FBJy9wqQ 12345678.00000001";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(457, 173);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += TextBox1_TextChanged;
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
            button2.Location = new Point(12, 314);
            button2.Name = "button2";
            button2.Size = new Size(121, 38);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
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
            button1.Location = new Point(348, 314);
            button1.Name = "button1";
            button1.Size = new Size(121, 38);
            button1.TabIndex = 9;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(457, 93);
            panel1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientActiveCaption;
            label2.Font = new Font("Kanit", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(41, 27);
            label2.Name = "label2";
            label2.Size = new Size(375, 57);
            label2.TabIndex = 1;
            label2.Text = "PRTMRdFE2mVStmA3S3h6dHEG6rR9Kr6CpY1FBJy9wqQ 1.10000001\r\nPRTMRVHeJFbGMjhhgvVmUNrM8ky1j5sgjeBxcDEiQvX    2,00000001\r\nPRTMRgWiM2MsepLZbuBpDCq9sGoWaJvxHBB5W6PsK4n 500.2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Kanit", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 5);
            label1.Name = "label1";
            label1.Size = new Size(409, 20);
            label1.TabIndex = 0;
            label1.Text = "Paste address and amount with space or tab separator, line by line:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Kanit", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 12;
            label3.Text = "Total tasks: 0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Kanit", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(147, 111);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 13;
            label4.Text = "Amount: 0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Kanit", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(343, 111);
            label5.Name = "label5";
            label5.Size = new Size(40, 19);
            label5.TabIndex = 14;
            label5.Text = "Fee: 0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Kanit", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(159, 323);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 15;
            label6.Text = "Sent count: 0";
            // 
            // MultiSend
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(481, 364);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MultiSend";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Multi Send";
            Activated += MultiSend_Activated;
            FormClosing += MultiSend_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        public Button button2;
        public Button button1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}