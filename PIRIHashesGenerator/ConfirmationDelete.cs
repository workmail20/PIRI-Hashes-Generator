using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace PIRIHashesGenerator
{
    public partial class ConfirmationDelete : Form
    {
        public bool Result = false;
        public ConfirmationDelete(FontFamily f)
        {
            InitializeComponent();

            button2.Font = new Font(f, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(f, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            panel1.Font = new Font(f, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);

    }

        private void Button1_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmationDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
