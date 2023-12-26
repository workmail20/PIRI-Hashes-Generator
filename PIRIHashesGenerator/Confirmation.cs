
namespace PIRIHashesGenerator
{
    public partial class Confirmation : Form
    {
        public Confirmation(FontFamily f)
        {
            InitializeComponent();
            panel1.Font = new Font(f, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            label6.Font = new Font(f, label6.Font.SizeInPoints, label6.Font.Style, GraphicsUnit.Point);
            label5.Font = new Font(f, label5.Font.SizeInPoints, label5.Font.Style, GraphicsUnit.Point);
            label4.Font = new Font(f, label4.Font.SizeInPoints, label4.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(f, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            label15.Font = new Font(f, label15.Font.SizeInPoints, label15.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            textBox5.Font = new Font(f, textBox5.Font.SizeInPoints, textBox5.Font.Style, GraphicsUnit.Point);
            textBox4.Font = new Font(f, textBox4.Font.SizeInPoints, textBox4.Font.Style, GraphicsUnit.Point);
            textBox3.Font = new Font(f, textBox3.Font.SizeInPoints, textBox3.Font.Style, GraphicsUnit.Point);
            textBox2.Font = new Font(f, textBox2.Font.SizeInPoints, textBox2.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(f, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            button2.Font = new Font(f, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
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

        private void Confirmation_Load(object sender, EventArgs e)
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

        private void Confirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  if (label15.Text != "00:00") e.Cancel = true;
        }

        private void Confirmation_Activated(object sender, EventArgs e)
        {
            this.button2.Focus();
        }
    }
}
