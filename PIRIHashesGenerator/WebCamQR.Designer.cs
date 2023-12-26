namespace PIRIHashesGenerator
{
    partial class WebCamQR
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(11, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(480, 270);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.Cursor = Cursors.Hand;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(116, 318);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(375, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Kanit", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(70, 348);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(421, 25);
            textBox1.TabIndex = 4;
            textBox1.Text = "Searching...";
            // 
            // button3
            // 
            button3.BackColor = Color.Aquamarine;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Kanit", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(352, 378);
            button3.Name = "button3";
            button3.Size = new Size(139, 31);
            button3.TabIndex = 5;
            button3.Text = "Confirm";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Kanit", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 349);
            label1.Name = "label1";
            label1.Size = new Size(53, 23);
            label1.TabIndex = 6;
            label1.Text = "Wallet:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Kanit", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(11, 318);
            label2.Name = "label2";
            label2.Size = new Size(99, 23);
            label2.TabIndex = 7;
            label2.Text = "Select source:";
            // 
            // button4
            // 
            button4.BackColor = Color.LightSalmon;
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Kanit", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(192, 378);
            button4.Name = "button4";
            button4.Size = new Size(139, 31);
            button4.TabIndex = 8;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.HighlightText;
            label3.Font = new Font("Kanit", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(157, 9);
            label3.Name = "label3";
            label3.Size = new Size(189, 30);
            label3.TabIndex = 9;
            label3.Text = "Please scan QR code ";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 15;
            timer1.Tick += Timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Kanit", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(412, -1);
            label4.Name = "label4";
            label4.Size = new Size(79, 43);
            label4.TabIndex = 10;
            label4.Text = "Error";
            label4.Visible = false;
            // 
            // WebCamQR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(503, 419);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WebCamQR";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Scan QR code";
            FormClosing += WebCamQR_FormClosing;
            Load += WebCamQR_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button3;
        private Label label1;
        private Label label2;
        private Button button4;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
    }
}