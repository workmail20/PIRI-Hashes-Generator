

using PIRIHashesGenerator.units;

namespace PIRIHashesGenerator
{
    public partial class ConfirmationPush : Form
    {
        public string _fulldata = "";
        SettingsAndSession sns;
        public ConfirmationPush(SettingsAndSession _sns)
        {
            InitializeComponent();
            sns= _sns;
            var f = sns.fontFamily;
            panel1.Font = new Font(f, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            label15.Font = new Font(f, label15.Font.SizeInPoints, label15.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            label6.Font = new Font(f, label6.Font.SizeInPoints, label6.Font.Style, GraphicsUnit.Point);
            label5.Font = new Font(f, label5.Font.SizeInPoints, label5.Font.Style, GraphicsUnit.Point);
            label4.Font = new Font(f, label4.Font.SizeInPoints, label4.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(f, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            button2.Font = new Font(f, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(f, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            label20.Font = new Font(f, label20.Font.SizeInPoints, label20.Font.Style, GraphicsUnit.Point);
            label18.Font = new Font(f, label18.Font.SizeInPoints, label18.Font.Style, GraphicsUnit.Point);
            textBox7.Font = new Font(f, textBox7.Font.SizeInPoints, textBox7.Font.Style, GraphicsUnit.Point);
            textBox6.Font = new Font(f, textBox6.Font.SizeInPoints, textBox6.Font.Style, GraphicsUnit.Point);
            textBox5.Font = new Font(f, textBox5.Font.SizeInPoints, textBox5.Font.Style, GraphicsUnit.Point);
            textBox4.Font = new Font(f, textBox4.Font.SizeInPoints, textBox4.Font.Style, GraphicsUnit.Point);
            textBox3.Font = new Font(f, textBox3.Font.SizeInPoints, textBox3.Font.Style, GraphicsUnit.Point);
            textBox2.Font = new Font(f, textBox2.Font.SizeInPoints, textBox2.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            button4.Font = new Font(f, button4.Font.SizeInPoints, button4.Font.Style, GraphicsUnit.Point);
            textBox8.Font = new Font(f, textBox8.Font.SizeInPoints, textBox8.Font.Style, GraphicsUnit.Point);
            label7.Font = new Font(f, label7.Font.SizeInPoints, label7.Font.Style, GraphicsUnit.Point);

    }
        async private Task Timer_()
        {
            label15.Text = "00:04";
            for (int i = 3; i >= 0; i--)
            {
                await Task.Delay(1000);
                label15.Text = "00:0" + i.ToString();
            }
            button1.Enabled = true;
        }


        private void ConfirmationPush_Load(object sender, EventArgs e)
        {
            _ = Timer_();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // if (label15.Text != "00:00") return;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (label15.Text != "00:00") return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ConfirmationPush_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (label15.Text != "00:00") e.Cancel = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            FullData fd = new(sns.fontFamily);
            
            fd.textBox1.Text = _fulldata;
            fd.ShowDialog();
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox6.Text, textBox6.Font);
            textBox6.Width = size.Width;
            textBox6.Height = size.Height;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox2.Text, textBox2.Font);
            textBox2.Width = size.Width;
            textBox2.Height = size.Height;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox4.Text, textBox4.Font);
            textBox4.Width = size.Width;
            textBox4.Height = size.Height;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            textBox1.Width = size.Width;
            textBox1.Height = size.Height;
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox8.Text, textBox8.Font);
            textBox8.Width = size.Width;
            textBox8.Height = size.Height;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox3.Text, textBox3.Font);
            textBox3.Width = size.Width;
            textBox3.Height = size.Height;
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox5.Text, textBox5.Font);
            textBox5.Width = size.Width;
            textBox5.Height = size.Height;
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox7.Text, textBox7.Font);
            textBox7.Width = size.Width;
            textBox7.Height = size.Height;
        }
    }
}
