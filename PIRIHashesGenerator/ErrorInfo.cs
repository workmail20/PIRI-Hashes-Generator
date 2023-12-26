using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIRIHashesGenerator
{
    public partial class ErrorInfo : Form
    {
        public ErrorInfo(FontFamily f)
        {
            InitializeComponent();
            panel1.Font = new Font(f, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            button2.Font = new Font(f, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(f, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);

    }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorInfo_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void ErrorInfo_Activated(object sender, EventArgs e)
        {
            button1.Focus();
        }
    }
}
