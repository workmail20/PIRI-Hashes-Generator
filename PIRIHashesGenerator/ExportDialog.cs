using PIRIHashesGenerator.units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace PIRIHashesGenerator
{
    public partial class ExportDialog : Form
    {
        public string FileName = "";
        public bool valid = false;
        private readonly string startFolder;
        SettingsAndSession sns;
        public FontFamily _infont;
        public ExportDialog(string FolderPath, SettingsAndSession _sns)
        {
            sns = _sns;
            _infont = sns.fontFamily;
            InitializeComponent();

            var f = sns.fontFamily;
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            button4.Font = new Font(f, button4.Font.SizeInPoints, button4.Font.Style, GraphicsUnit.Point);
            listView1.Font = new Font(f, listView1.Font.SizeInPoints, listView1.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            comboBox1.Font = new Font(f, comboBox1.Font.SizeInPoints, comboBox1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);


        startFolder = FolderPath;

            string[] allfiles = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in allfiles)
            {
                string[] it = { Path.GetFileName(file), File.GetCreationTime(file).ToString() };

                var listViewItem = new System.Windows.Forms.ListViewItem(it)
                {
                    UseItemStyleForSubItems = false
                };
                listViewItem.SubItems.Add("DEL", System.Drawing.Color.Red, System.Drawing.Color.White, new System.Drawing.Font(_infont, 10, System.Drawing.FontStyle.Underline));
                listView1.Items.Add(listViewItem);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            valid = true;
            FileName = textBox1.Text + comboBox1.Text;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportDialog_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.InvariantCulture);
            comboBox1.SelectedIndex = 0;
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePos = listView1.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hitTest = listView1.HitTest(mousePos);
            var row = hitTest.Item.Index;
            int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
            if (columnIndex == 2)
            {
                ConfirmationDelete cd = new(sns.fontFamily);
                cd.label2.Text = listView1.Items[row].SubItems[0].Text;
                if (cd.label2.Text.Length > 36) cd.label2.Text = "..." + cd.label2.Text[^36..];
                cd.label2.Location = new Point((cd.panel1.Width - cd.label2.Width) / 2, 47);
                cd.ShowDialog();
                if (cd.Result)
                {
                    File.Delete(Path.Combine(startFolder, listView1.Items[row].SubItems[0].Text));

                    listView1.Items.Clear();
                    string[] allfiles = Directory.GetFiles(startFolder, "*.*", SearchOption.TopDirectoryOnly);
                    foreach (string file in allfiles)
                    {
                        string[] it = { Path.GetFileName(file), File.GetCreationTime(file).ToString() };
                        var listViewItem = new System.Windows.Forms.ListViewItem(it)
                        {
                            UseItemStyleForSubItems = false
                        };
                        listViewItem.SubItems.Add("DEL", System.Drawing.Color.Red, System.Drawing.Color.White, new System.Drawing.Font(_infont, 10, System.Drawing.FontStyle.Underline));
                        listView1.Items.Add(listViewItem);
                    }
                }
            }
        }
    }
}
