using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PIRIHashesGenerator.units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace PIRIHashesGenerator
{
    partial class AboutBox : Form
    {
        public SettingsAndSession SnS;
        public AboutBox(SettingsAndSession _sns, FontFamily f)
        {
            InitializeComponent();
            textBoxDescription.Font = new Font(f, textBoxDescription.Font.SizeInPoints, textBoxDescription.Font.Style, GraphicsUnit.Point);
            okButton.Font = new Font(f, okButton.Font.SizeInPoints, okButton.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(f, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            label4.Font = new Font(f, label4.Font.SizeInPoints, label4.Font.Style, GraphicsUnit.Point);

            textBox3.Font = new Font(f, textBox3.Font.SizeInPoints, textBox3.Font.Style, GraphicsUnit.Point);
            textBox2.Font = new Font(f, textBox2.Font.SizeInPoints, textBox2.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);

            SnS = _sns;

            if (!SettingsAndSession.IsRunningAsUwp())
            {
            }
            else
            {
            }


            this.textBoxDescription.Text = AssemblyDescription + "";

            this.textBox1.Text = AssemblyVersion;
            this.textBox2.Text = "@workmail20";
            this.textBox3.Text = "work_mail20@protonmail.com";
        }

        #region Методы доступа к атрибутам сборки


        public static string AssemblyVersion
        {
            get
            {
                Version? v = Assembly.GetExecutingAssembly().GetName().Version;
                return (v == null) ? "" : v.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void AboutBox_Activated(object sender, EventArgs e)
        {
            okButton.Focus();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {

        }

    }
}
