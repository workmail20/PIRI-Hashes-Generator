using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Utilities.Net;
using PIRIHashesGenerator.units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Lights.Effects;

namespace PIRIHashesGenerator
{
    struct Transaction
    {
        public string WalletID { get; set; }
        public decimal Amount { get; set; }
    }
    public partial class MultiSend : Form
    {
        List<Transaction> WalletsAndTrans = new();
        decimal TotalAmount = 0.0m;
        decimal TotalFee = 0.0m;
        readonly SettingsAndSession SnS;
        readonly string MyWallet;
        readonly string MyPrvt;
        readonly string MyPublic;
        public bool Result = false;
        readonly ListView LV;
        bool needStop = false;
        bool statusWorking = false;
        public MultiSend(SettingsAndSession _SnS, string myWallet, string myPrvt, string myPublic, ListView _lv)
        {
            SnS = _SnS;
            MyWallet = myWallet;
            MyPrvt = myPrvt;
            MyPublic = myPublic;
            LV = _lv;

            InitializeComponent();


            textBox1.Font = new Font(_SnS.fontFamily, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            button2.Font = new Font(_SnS.fontFamily, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(_SnS.fontFamily, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            panel1.Font = new Font(_SnS.fontFamily, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(_SnS.fontFamily, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(_SnS.fontFamily, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(_SnS.fontFamily, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            label4.Font = new Font(_SnS.fontFamily, label4.Font.SizeInPoints, label4.Font.Style, GraphicsUnit.Point);
            label5.Font = new Font(_SnS.fontFamily, label5.Font.SizeInPoints, label5.Font.Style, GraphicsUnit.Point);
            label6.Font = new Font(_SnS.fontFamily, label6.Font.SizeInPoints, label6.Font.Style, GraphicsUnit.Point);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.Text = "Stopping...";
            needStop = true;

            if (!statusWorking) this.Close();
        }

        async private void Button1_Click(object sender, EventArgs e)
        {
            WalletsAndTrans = new();
            TotalAmount = 0.0m;
            TotalFee = 0.0m;


            button1.Enabled = false;
            // button2.Enabled = false;
            button1.Text = "Working...";
            statusWorking = true;

            bool abort = false;
            int TotalTransactionsSend = 0;
            decimal TotalAmountSend = 0.0m;

            string task = textBox1.Text;
            task = task.Replace("\t", " ");
            task = String.Join(" ", task.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            task = task.Replace(",", ".");
            string[] lines = task.Split("\n");
            foreach (string line in lines)
            {
                string[] splited = line.Split(" ");
                if (splited.Length > 1)
                {
                    try
                    {
                        Transaction trans = new()
                        {
                            Amount = decimal.Parse(splited[1].Trim(new char[] { '\r', '\n', ' ' }), CultureInfo.InvariantCulture),
                            WalletID = splited[0].Trim(new char[] { '\r', '\n', ' ' }),
                        };
                        if ((trans.WalletID.Length > 32) && (trans.Amount > 0.00000000m))
                        {
                            TotalAmount += trans.Amount;
                            TotalFee += 0.1m;
                            WalletsAndTrans.Add(trans);
                        }
                    }
                    catch (Exception) { }
                }
            }

            if (WalletsAndTrans.Count > 0)
            {
                Confirmation cd = new(SnS.fontFamily);
                cd.textBox1.Text = WalletsAndTrans.Count.ToString() + " Unique transactions";
                cd.textBox2.Text = MyWallet;
                cd.textBox3.Text = TotalAmount.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")) + " PIRI";
                cd.textBox4.Text = TotalFee.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")) + " PIRI";
                cd.textBox5.Text = (TotalAmount + TotalFee).ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")) + " PIRI";

                cd.button2.Focus();
                cd.ShowDialog();

                if (cd.DialogResult == DialogResult.OK)
                {
                    foreach (Transaction _wallet in WalletsAndTrans)
                    {
                        if (needStop)
                        {
                            statusWorking = false;
                            abort = true;
                            break;
                        }

                        string error;
                        string message;
                        string tx;
                        (error, message, tx) = await PIRIClass.SendPIRI(_wallet.Amount.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")), MyWallet, MyPrvt, _wallet.WalletID, MyPublic);


                        if (error == "0" && tx.Length > 8)
                        {
                            string[] row = { (LV.Items.Count + 1).ToString(), tx, _wallet.WalletID, MyWallet, _wallet.Amount.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")) };
                            var listViewItem = new ListViewItem(row);
                            LV.Items.Insert(0, listViewItem);

                            TotalTransactionsSend++;
                            TotalAmountSend += _wallet.Amount + 0.1m;
                            label6.Text = "Sent count: " + TotalTransactionsSend.ToString();
                        }
                        else
                        {
                            if (error == "1" && message.Length > 1)
                            {
                                ErrorInfo ei = new(SnS.fontFamily);
                                ei.textBox1.Text = message;
                                ei.ShowDialog();
                                abort = true;
                                statusWorking = false;
                                break;
                            }
                            else
                            {
                                ErrorInfo ei = new(SnS.fontFamily);
                                ei.textBox1.Text = "Something went wrong. Please check your internet connection, balance (to prevent double spending), wait 1 minute and try again.";
                                ei.ShowDialog();
                                abort = true;
                                statusWorking = false;
                                break;
                            }
                        }
                        await Task.Delay(2000);
                    }

                    if (abort)
                    {
                        Success si = new(SnS.fontFamily);
                        si.textBox1.Text = "The operation was aborted.\r\nTotal transactions: " + TotalTransactionsSend.ToString() + "\r\nTotal PIRI+Fee: " + TotalAmountSend.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                        si.textBox1.SelectionStart = 0;
                        si.textBox1.SelectionLength = 0;
                        si.button1.Focus();
                        si.ShowDialog();
                    }
                    else
                    {
                        Success si = new(SnS.fontFamily);
                        si.textBox1.Text = "The operation was successful.\r\nTotal transactions: " + TotalTransactionsSend.ToString() + "\r\nTotal PIRI+Fee: " + TotalAmountSend.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                        si.textBox1.SelectionStart = 0;
                        si.textBox1.SelectionLength = 0;
                        si.button1.Focus();
                        si.ShowDialog();
                        Result = true;
                    }
                    statusWorking = false;
                    this.Close();
                }
            }
            else
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Enter at least 1 address and amount";
                ei.ShowDialog();
            }

            statusWorking = false;
            button1.Enabled = true;
            //  button2.Enabled = true;
            button1.Text = "Send";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            decimal _TotalAmount = 0.0m;
            decimal _TotalFee = 0.0m;
            int _TotalTasks = 0;

            string task = textBox1.Text;
            task = task.Replace("\t", " ");
            task = String.Join(" ", task.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            task = task.Replace(",", ".");
            string[] lines = task.Split("\n");
            foreach (string line in lines)
            {
                string[] splited = line.Split(" ");
                if (splited.Length > 1)
                {
                    try
                    {
                        Transaction trans = new()
                        {
                            Amount = decimal.Parse(splited[1].Trim(new char[] { '\r', '\n', ' ' }), CultureInfo.InvariantCulture),
                            WalletID = splited[0].Trim(new char[] { '\r', '\n', ' ' }),
                        };

                        if ((trans.WalletID.Length > 32) && (trans.Amount > 0.00000000m))
                        {
                            _TotalAmount += trans.Amount;
                            _TotalFee += 0.1m;
                            _TotalTasks++;
                        }
                    }
                    catch (Exception) { }
                }
            }

            label3.Text = "Total tasks: " + _TotalTasks.ToString();
            label4.Text = "Amount: " + _TotalAmount.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            label5.Text = "Fee: " + _TotalFee.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
        }

        private void MultiSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2.Text = "Stopping...";
            needStop = true;

            if (statusWorking)
            {
                e.Cancel = true;
            }
        }

        private void MultiSend_Activated(object sender, EventArgs e)
        {
            button1.Focus();
        }
    }
}
