using DocumentFormat.OpenXml.EMMA;
using Org.BouncyCastle.Bcpg.OpenPgp;
using PIRIHashesGenerator.units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Storage.Pickers;
using static System.Windows.Forms.ListView;

namespace PIRIHashesGenerator
{
    public partial class FileBrowserDialog : Form
    {
        public string SelectedFile;
        public bool valid = false;
        private readonly string startFolder;
        readonly SettingsAndSession sns;
        public FileBrowserDialog(string FolderPath, SettingsAndSession _sns)
        {
            sns= _sns;
            InitializeComponent();

            var f = sns.fontFamily;
            listView1.Font = new Font(f, listView1.Font.SizeInPoints, listView1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            button4.Font = new Font(f, button4.Font.SizeInPoints, button4.Font.Style, GraphicsUnit.Point);



            SelectedFile = "";
            startFolder = FolderPath;

            string[] allfiles = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in allfiles)
            {
                string[] it = { Path.GetFileName(file), File.GetCreationTime(file).ToString() };
                var listViewItem = new System.Windows.Forms.ListViewItem(it)
                {
                    UseItemStyleForSubItems = false
                };
                listViewItem.SubItems.Add("DEL", System.Drawing.Color.Red, System.Drawing.Color.White, new System.Drawing.Font(sns.fontFamily, 10, System.Drawing.FontStyle.Underline));
                listView1.Items.Add(listViewItem);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            valid = true;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SelectedFile = "";
            this.Close();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedListViewItemCollection l = listView1.SelectedItems;
            if (l.Count > 0)
            {
                SelectedFile = l[0].SubItems[0].Text;
            }
        }

        private void FileBrowserDialog_Load(object sender, EventArgs e)
        {

        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectedListViewItemCollection l = listView1.SelectedItems;
            if (l.Count > 0)
            {
                SelectedFile = l[0].SubItems[0].Text;
                valid = true;
                this.Close();
            }

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
                        listViewItem.SubItems.Add("DEL", System.Drawing.Color.Red, System.Drawing.Color.White, new System.Drawing.Font(sns.fontFamily, 10, System.Drawing.FontStyle.Underline));
                        listView1.Items.Add(listViewItem);
                    }
                }
            }
        }
    }
}
