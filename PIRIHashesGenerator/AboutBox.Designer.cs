namespace PIRIHashesGenerator
{
    partial class AboutBox
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            textBoxDescription = new TextBox();
            okButton = new Button();
            logoPictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.FloralWhite;
            textBoxDescription.Font = new Font("Kanit", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDescription.Location = new Point(266, 186);
            textBoxDescription.Margin = new Padding(7, 3, 4, 3);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.ScrollBars = ScrollBars.Both;
            textBoxDescription.Size = new Size(299, 137);
            textBoxDescription.TabIndex = 30;
            textBoxDescription.TabStop = false;
            textBoxDescription.Text = "Program to generate encrypted PIRIChain wallet files";
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.BackColor = Color.White;
            okButton.Cursor = Cursors.Hand;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Font = new Font("Kanit", 10F, FontStyle.Regular, GraphicsUnit.Point);
            okButton.Location = new Point(457, 329);
            okButton.Margin = new Padding(4, 3, 4, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(108, 37);
            okButton.TabIndex = 31;
            okButton.Text = "&ОК";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += OkButton_Click;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = Color.LavenderBlush;
            logoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(0, 0);
            logoPictureBox.Margin = new Padding(4, 3, 4, 3);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(255, 374);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 26;
            logoPictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Kanit", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(266, 10);
            label1.Name = "label1";
            label1.Size = new Size(220, 32);
            label1.TabIndex = 32;
            label1.Text = "PIRI Hashes Generator";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 23);
            label2.Name = "label2";
            label2.Size = new Size(62, 23);
            label2.TabIndex = 33;
            label2.Text = "Version:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 46);
            label3.Name = "label3";
            label3.Size = new Size(57, 23);
            label3.TabIndex = 34;
            label3.Text = "Author:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 69);
            label4.Name = "label4";
            label4.Size = new Size(49, 23);
            label4.TabIndex = 35;
            label4.Text = "Email:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Kanit", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(266, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(299, 101);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.MediumPurple;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Cursor = Cursors.Hand;
            textBox3.Font = new Font("Kanit", 10F, FontStyle.Underline, GraphicsUnit.Point);
            textBox3.Location = new Point(84, 69);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(156, 20);
            textBox3.TabIndex = 41;
            textBox3.Text = "version";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.MediumPurple;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Cursor = Cursors.Hand;
            textBox2.Font = new Font("Kanit", 10F, FontStyle.Underline, GraphicsUnit.Point);
            textBox2.Location = new Point(84, 46);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(145, 20);
            textBox2.TabIndex = 40;
            textBox2.Text = "version";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.MediumPurple;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.Hand;
            textBox1.Font = new Font("Kanit", 10F, FontStyle.Underline, GraphicsUnit.Point);
            textBox1.Location = new Point(84, 26);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(101, 20);
            textBox1.TabIndex = 39;
            textBox1.Text = "version";
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(579, 374);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(textBoxDescription);
            Controls.Add(okButton);
            Controls.Add(logoPictureBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            Activated += AboutBox_Activated;
            Load += AboutBox_Load;
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxDescription;
        private Button okButton;
        private PictureBox logoPictureBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
