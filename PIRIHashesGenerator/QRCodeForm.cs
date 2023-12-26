

namespace PIRIHashesGenerator
{
    public partial class QRCodeForm : Form
    {
        public QRCodeForm(FontFamily f)
        {
            InitializeComponent();

            panel1.Font = new Font(f, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);

    }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QRCodeForm_Load(object sender, EventArgs e)
        {
            label1.Left = (panel1.Width - label1.Width) / 2;
        }
    }
}
