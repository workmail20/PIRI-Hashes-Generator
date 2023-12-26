using Net.Codecrete.QrCodeGenerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pirichain_api_workmail20;
using System.Globalization;
using System.Text;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using PIRIHashesGenerator.Properties;
using Clipboard = System.Windows.Clipboard;
using Point = System.Drawing.Point;
using PIRIHashesGenerator.units;
using ListViewItem = System.Windows.Forms.ListViewItem;
using TaskbarMenu;
using NAudio.Wave;
using MathNet.Numerics;
using NPOI.SS.Formula.Functions;
using System.ComponentModel;
using License = PIRIHashesGenerator.units.License;
using System.Windows.Forms;
using Microsoft.Win32;
using Windows.Storage.Pickers;
using NAudio.Midi;
using WinRT.Interop;
using Windows.Storage;
using System.Diagnostics;
using Org.BouncyCastle.Asn1.Pkcs;
using DocumentFormat.OpenXml.Drawing;
using Path = System.IO.Path;
using Bitcoin.BIP39;
using System.Security.Cryptography;
using DevHawk.Security.Cryptography;
using SimpleBase;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Drawing.Text;
using ExtensionMethods;

namespace PIRIHashesGenerator
{
    public partial class PIRIHashesGenerator : Form
    {

        // public readonly TrayInfo_ tray;
        private bool _forceClose = false;
        public readonly SettingsAndSession SnS;
        private readonly Notifications notifications;
        private readonly object checkTransLock = new();
        private readonly System.Threading.Timer _timer;
        private readonly object _locker = new();
        readonly TickTimer tickTimer;
        private bool Needendreq = false;
        bool HashInited = false;
        readonly License license;
        bool FormCreated = false;

        public PIRIHashesGenerator()
        {
            SnS = new(this);
            InitializeComponent();


            var f = SnS.fontFamily;
            textBox7.Font = new Font(f, textBox7.Font.SizeInPoints, textBox7.Font.Style, GraphicsUnit.Point);
            toolStripMenuItem4.Font = new Font(f, toolStripMenuItem4.Font.SizeInPoints, toolStripMenuItem4.Font.Style, GraphicsUnit.Point);
            toolStripMenuItem3.Font = new Font(f, toolStripMenuItem3.Font.SizeInPoints, toolStripMenuItem3.Font.Style, GraphicsUnit.Point);
            toolStripMenuItem2.Font = new Font(f, toolStripMenuItem2.Font.SizeInPoints, toolStripMenuItem2.Font.Style, GraphicsUnit.Point);
            toolStripMenuItem1.Font = new Font(f, toolStripMenuItem1.Font.SizeInPoints, toolStripMenuItem1.Font.Style, GraphicsUnit.Point);
            contextMenuStrip2.Font = new Font(f, contextMenuStrip2.Font.SizeInPoints, contextMenuStrip2.Font.Style, GraphicsUnit.Point);
            copyToolStripMenuItem.Font = new Font(f, copyToolStripMenuItem.Font.SizeInPoints, copyToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            contextMenuStrip1.Font = new Font(f, contextMenuStrip1.Font.SizeInPoints, contextMenuStrip1.Font.Style, GraphicsUnit.Point);
            settingsToolStripMenuItem.Font = new Font(f, settingsToolStripMenuItem.Font.SizeInPoints, settingsToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            //     toolStripStatusLabel5.Font = new Font(f, toolStripStatusLabel5.Font.SizeInPoints, toolStripStatusLabel5.Font.Style, GraphicsUnit.Point);
            toolStripStatusLabel4.Font = new Font(f, toolStripStatusLabel4.Font.SizeInPoints, toolStripStatusLabel4.Font.Style, GraphicsUnit.Point);
            toolStripStatusLabel3.Font = new Font(f, toolStripStatusLabel3.Font.SizeInPoints, toolStripStatusLabel3.Font.Style, GraphicsUnit.Point);
            aboutToolStripMenuItem1.Font = new Font(f, aboutToolStripMenuItem1.Font.SizeInPoints, aboutToolStripMenuItem1.Font.Style, GraphicsUnit.Point);
            helpToolStripMenuItem.Font = new Font(f, helpToolStripMenuItem.Font.SizeInPoints, helpToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            exitToolStripMenuItem.Font = new Font(f, exitToolStripMenuItem.Font.SizeInPoints, exitToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            toolStripStatusLabel2.Font = new Font(f, toolStripStatusLabel2.Font.SizeInPoints, toolStripStatusLabel2.Font.Style, GraphicsUnit.Point);
            // miniToolStrip.Font = new Font(f, miniToolStrip.Font.SizeInPoints, miniToolStrip.Font.Style, GraphicsUnit.Point);
            toolStripStatusLabel1.Font = new Font(f, toolStripStatusLabel1.Font.SizeInPoints, toolStripStatusLabel1.Font.Style, GraphicsUnit.Point);
            openToolStripMenuItem.Font = new Font(f, openToolStripMenuItem.Font.SizeInPoints, openToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            //      statusStrip1.Font = new Font(f, statusStrip1.Font.SizeInPoints, statusStrip1.Font.Style, GraphicsUnit.Point);
            aboutToolStripMenuItem.Font = new Font(f, aboutToolStripMenuItem.Font.SizeInPoints, aboutToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            menuStrip1.Font = new Font(f, menuStrip1.Font.SizeInPoints, menuStrip1.Font.Style, GraphicsUnit.Point);

            listView4.Font = new Font(f, listView4.Font.SizeInPoints, listView4.Font.Style, GraphicsUnit.Point);
            label14.Font = new Font(f, label14.Font.SizeInPoints, label14.Font.Style, GraphicsUnit.Point);
            textBox5.Font = new Font(f, textBox5.Font.SizeInPoints, textBox5.Font.Style, GraphicsUnit.Point);
            label15.Font = new Font(f, label15.Font.SizeInPoints, label15.Font.Style, GraphicsUnit.Point);
            textBox6.Font = new Font(f, textBox6.Font.SizeInPoints, textBox6.Font.Style, GraphicsUnit.Point);
            comboBox1.Font = new Font(f, comboBox1.Font.SizeInPoints, comboBox1.Font.Style, GraphicsUnit.Point);
            button21.Font = new Font(f, button21.Font.SizeInPoints, button21.Font.Style, GraphicsUnit.Point);
            button20.Font = new Font(f, button20.Font.SizeInPoints, button20.Font.Style, GraphicsUnit.Point);
            button19.Font = new Font(f, button19.Font.SizeInPoints, button19.Font.Style, GraphicsUnit.Point);
            button23.Font = new Font(f, button23.Font.SizeInPoints, button23.Font.Style, GraphicsUnit.Point);
            groupBox5.Font = new Font(f, groupBox5.Font.SizeInPoints, groupBox5.Font.Style, GraphicsUnit.Point);
            tabPage4.Font = new Font(f, tabPage4.Font.SizeInPoints, tabPage4.Font.Style, GraphicsUnit.Point);

            label8.Font = new Font(f, label8.Font.SizeInPoints, label8.Font.Style, GraphicsUnit.Point);
            label9.Font = new Font(f, label9.Font.SizeInPoints, label9.Font.Style, GraphicsUnit.Point);
            textBox13.Font = new Font(f, textBox13.Font.SizeInPoints, textBox13.Font.Style, GraphicsUnit.Point);
            textBox14.Font = new Font(f, textBox14.Font.SizeInPoints, textBox14.Font.Style, GraphicsUnit.Point);
            textBox15.Font = new Font(f, textBox15.Font.SizeInPoints, textBox15.Font.Style, GraphicsUnit.Point);
            button22.Font = new Font(f, button22.Font.SizeInPoints, button22.Font.Style, GraphicsUnit.Point);
            groupBox4.Font = new Font(f, groupBox4.Font.SizeInPoints, groupBox4.Font.Style, GraphicsUnit.Point);
            tabPage3.Font = new Font(f, tabPage3.Font.SizeInPoints, tabPage3.Font.Style, GraphicsUnit.Point);
            label11.Font = new Font(f, label11.Font.SizeInPoints, label11.Font.Style, GraphicsUnit.Point);
            label12.Font = new Font(f, label12.Font.SizeInPoints, label12.Font.Style, GraphicsUnit.Point);
            label13.Font = new Font(f, label13.Font.SizeInPoints, label13.Font.Style, GraphicsUnit.Point);
            textBox2.Font = new Font(f, textBox2.Font.SizeInPoints, textBox2.Font.Style, GraphicsUnit.Point);
            textBox3.Font = new Font(f, textBox3.Font.SizeInPoints, textBox3.Font.Style, GraphicsUnit.Point);



            listView2.Font = new Font(f, listView2.Font.SizeInPoints, listView2.Font.Style, GraphicsUnit.Point);
            textBox16.Font = new Font(f, textBox16.Font.SizeInPoints, textBox16.Font.Style, GraphicsUnit.Point);
            button33.Font = new Font(f, button33.Font.SizeInPoints, button33.Font.Style, GraphicsUnit.Point);
            button34.Font = new Font(f, button34.Font.SizeInPoints, button34.Font.Style, GraphicsUnit.Point);
            label10.Font = new Font(f, label10.Font.SizeInPoints, label10.Font.Style, GraphicsUnit.Point);
            button35.Font = new Font(f, button35.Font.SizeInPoints, button35.Font.Style, GraphicsUnit.Point);
            tabPage2.Font = new Font(f, tabPage2.Font.SizeInPoints, tabPage2.Font.Style, GraphicsUnit.Point);
            listView3.Font = new Font(f, listView3.Font.SizeInPoints, listView3.Font.Style, GraphicsUnit.Point);
            button16.Font = new Font(f, button16.Font.SizeInPoints, button16.Font.Style, GraphicsUnit.Point);
            button17.Font = new Font(f, button17.Font.SizeInPoints, button17.Font.Style, GraphicsUnit.Point);
            button18.Font = new Font(f, button18.Font.SizeInPoints, button18.Font.Style, GraphicsUnit.Point);
            groupBox3.Font = new Font(f, groupBox3.Font.SizeInPoints, groupBox3.Font.Style, GraphicsUnit.Point);
            label7.Font = new Font(f, label7.Font.SizeInPoints, label7.Font.Style, GraphicsUnit.Point);


            button26.Font = new Font(f, button26.Font.SizeInPoints, button26.Font.Style, GraphicsUnit.Point);
            button27.Font = new Font(f, button27.Font.SizeInPoints, button27.Font.Style, GraphicsUnit.Point);
            groupBox1.Font = new Font(f, groupBox1.Font.SizeInPoints, groupBox1.Font.Style, GraphicsUnit.Point);
            label6.Font = new Font(f, label6.Font.SizeInPoints, label6.Font.Style, GraphicsUnit.Point);
            label16.Font = new Font(f, label16.Font.SizeInPoints, label16.Font.Style, GraphicsUnit.Point);
            textBox4.Font = new Font(f, textBox4.Font.SizeInPoints, textBox4.Font.Style, GraphicsUnit.Point);
            button2.Font = new Font(f, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
            groupBox2.Font = new Font(f, groupBox2.Font.SizeInPoints, groupBox2.Font.Style, GraphicsUnit.Point);
            toolStripButton3.Font = new Font(f, toolStripButton3.Font.SizeInPoints, toolStripButton3.Font.Style, GraphicsUnit.Point);
            toolStripTextBox2.Font = new Font(f, toolStripTextBox2.Font.SizeInPoints, toolStripTextBox2.Font.Style, GraphicsUnit.Point);
            toolStripLabel2.Font = new Font(f, toolStripLabel2.Font.SizeInPoints, toolStripLabel2.Font.Style, GraphicsUnit.Point);
            toolStrip2.Font = new Font(f, toolStrip2.Font.SizeInPoints, toolStrip2.Font.Style, GraphicsUnit.Point);

            textBox9.Font = new Font(f, textBox9.Font.SizeInPoints, textBox9.Font.Style, GraphicsUnit.Point);
            textBox10.Font = new Font(f, textBox10.Font.SizeInPoints, textBox10.Font.Style, GraphicsUnit.Point);
            textBox11.Font = new Font(f, textBox11.Font.SizeInPoints, textBox11.Font.Style, GraphicsUnit.Point);
            textBox12.Font = new Font(f, textBox12.Font.SizeInPoints, textBox12.Font.Style, GraphicsUnit.Point);
            button6.Font = new Font(f, button6.Font.SizeInPoints, button6.Font.Style, GraphicsUnit.Point);
            button7.Font = new Font(f, button7.Font.SizeInPoints, button7.Font.Style, GraphicsUnit.Point);
            button8.Font = new Font(f, button8.Font.SizeInPoints, button8.Font.Style, GraphicsUnit.Point);
            button9.Font = new Font(f, button9.Font.SizeInPoints, button9.Font.Style, GraphicsUnit.Point);
            button10.Font = new Font(f, button10.Font.SizeInPoints, button10.Font.Style, GraphicsUnit.Point);
            button11.Font = new Font(f, button11.Font.SizeInPoints, button11.Font.Style, GraphicsUnit.Point);
            button15.Font = new Font(f, button15.Font.SizeInPoints, button15.Font.Style, GraphicsUnit.Point);
            button24.Font = new Font(f, button24.Font.SizeInPoints, button24.Font.Style, GraphicsUnit.Point);
            button25.Font = new Font(f, button25.Font.SizeInPoints, button25.Font.Style, GraphicsUnit.Point);
            button37.Font = new Font(f, button37.Font.SizeInPoints, button37.Font.Style, GraphicsUnit.Point);

            button13.Font = new Font(f, button13.Font.SizeInPoints, button13.Font.Style, GraphicsUnit.Point);
            button14.Font = new Font(f, button14.Font.SizeInPoints, button14.Font.Style, GraphicsUnit.Point);
            button28.Font = new Font(f, button28.Font.SizeInPoints, button28.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            button31.Font = new Font(f, button31.Font.SizeInPoints, button31.Font.Style, GraphicsUnit.Point);
            button32.Font = new Font(f, button32.Font.SizeInPoints, button32.Font.Style, GraphicsUnit.Point);
            tabPage1.Font = new Font(f, tabPage1.Font.SizeInPoints, tabPage1.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(f, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            label4.Font = new Font(f, label4.Font.SizeInPoints, label4.Font.Style, GraphicsUnit.Point);
            label5.Font = new Font(f, label5.Font.SizeInPoints, label5.Font.Style, GraphicsUnit.Point);
            textBox8.Font = new Font(f, textBox8.Font.SizeInPoints, textBox8.Font.Style, GraphicsUnit.Point);

            button29.Font = new Font(f, button29.Font.SizeInPoints, button29.Font.Style, GraphicsUnit.Point);
            button30.Font = new Font(f, button30.Font.SizeInPoints, button30.Font.Style, GraphicsUnit.Point);
            tabControl1.Font = new Font(f, tabControl1.Font.SizeInPoints, tabControl1.Font.Style, GraphicsUnit.Point);
            passwordEncryptToolStripMenuItem.Font = new Font(f, passwordEncryptToolStripMenuItem.Font.SizeInPoints, passwordEncryptToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            encryptedToolStripMenuItem.Font = new Font(f, encryptedToolStripMenuItem.Font.SizeInPoints, encryptedToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            notEncryptedToolStripMenuItem.Font = new Font(f, notEncryptedToolStripMenuItem.Font.SizeInPoints, notEncryptedToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            toolStripDropDownButton1.Font = new Font(f, toolStripDropDownButton1.Font.SizeInPoints, toolStripDropDownButton1.Font.Style, GraphicsUnit.Point);
            toolStripButton1.Font = new Font(f, toolStripButton1.Font.SizeInPoints, toolStripButton1.Font.Style, GraphicsUnit.Point);
            toolStripTextBox1.Font = new Font(f, toolStripTextBox1.Font.SizeInPoints, toolStripTextBox1.Font.Style, GraphicsUnit.Point);
            toolStripLabel1.Font = new Font(f, toolStripLabel1.Font.SizeInPoints, toolStripLabel1.Font.Style, GraphicsUnit.Point);
            // toolStrip1.Font = new Font(f, toolStrip1.Font.SizeInPoints, toolStrip1.Font.Style, GraphicsUnit.Point);
            listView1.Font = new Font(f, listView1.Font.SizeInPoints, listView1.Font.Style, GraphicsUnit.Point);
            button12.Font = new Font(f, button12.Font.SizeInPoints, button12.Font.Style, GraphicsUnit.Point);


            toolStripMenuItem5.Font = new Font(f, toolStripMenuItem5.Font.SizeInPoints, toolStripMenuItem5.Font.Style, GraphicsUnit.Point);
            contextMenuStrip4.Font = new Font(f, contextMenuStrip4.Font.SizeInPoints, contextMenuStrip4.Font.Style, GraphicsUnit.Point);
            contextMenuStrip3.Font = new Font(f, contextMenuStrip3.Font.SizeInPoints, contextMenuStrip3.Font.Style, GraphicsUnit.Point);
            timerToolStripMenuItem.Font = new Font(f, timerToolStripMenuItem.Font.SizeInPoints, timerToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            button4.Font = new Font(f, button4.Font.SizeInPoints, button4.Font.Style, GraphicsUnit.Point);
            button5.Font = new Font(f, button5.Font.SizeInPoints, button5.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            panel3.Font = new Font(f, panel3.Font.SizeInPoints, panel3.Font.Style, GraphicsUnit.Point);
            panel2.Font = new Font(f, panel2.Font.SizeInPoints, panel2.Font.Style, GraphicsUnit.Point);
            button36.Font = new Font(f, button36.Font.SizeInPoints, button36.Font.Style, GraphicsUnit.Point);
            panel1.Font = new Font(f, panel1.Font.SizeInPoints, panel1.Font.Style, GraphicsUnit.Point);
            label17.Font = new Font(f, label17.Font.SizeInPoints, label17.Font.Style, GraphicsUnit.Point);
            textBox17.Font = new Font(f, textBox17.Font.SizeInPoints, textBox17.Font.Style, GraphicsUnit.Point);



            toolStripMenuItem7.Font = new Font(f, toolStripMenuItem7.Font.SizeInPoints, toolStripMenuItem7.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(f, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            label18.Font = new Font(f, label18.Font.SizeInPoints, label18.Font.Style, GraphicsUnit.Point);
            label21.Font = new Font(f, label21.Font.SizeInPoints, label21.Font.Style, GraphicsUnit.Point);
            panel4.Font = new Font(f, panel4.Font.SizeInPoints, panel4.Font.Style, GraphicsUnit.Point);
            //   toolStripButton2.Font = new Font(f, toolStripButton2.Font.SizeInPoints, toolStripButton2.Font.Style, GraphicsUnit.Point);
            nnnToolStripMenuItem.Font = new Font(f, nnnToolStripMenuItem.Font.SizeInPoints, nnnToolStripMenuItem.Font.Style, GraphicsUnit.Point);
            label20.Font = new Font(f, label20.Font.SizeInPoints, label20.Font.Style, GraphicsUnit.Point);
            label19.Font = new Font(f, label19.Font.SizeInPoints, label19.Font.Style, GraphicsUnit.Point);
            toolStripMenuItem6.Font = new Font(f, toolStripMenuItem6.Font.SizeInPoints, toolStripMenuItem6.Font.Style, GraphicsUnit.Point);


            //  tra.y = new TrayInfo_();

            notifications = new(this);
            tickTimer = new();
            license = new();

            _timer = new System.Threading.Timer(TimerCallback_checkCommand, null, System.Threading.Timeout.Infinite, 15);
            _timer.Change(0, 15);
        }

        public class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            public WindowWrapper(IntPtr handle)
            {
                _hwnd = handle;
            }

            public IntPtr Handle
            {
                get { return _hwnd; }
            }

            private readonly IntPtr _hwnd;
        }

        private void TimerCallback_checkCommand(object? state)
        {
            if (!FormCreated) return;

            bool hasLock = false;

            Monitor.TryEnter(_locker, ref hasLock);
            if (!hasLock)
            {
                return;
            }

            if (TaskbarMenu0.commandProxy.OpenMainForm == true)
            {
                TaskbarMenu0.commandProxy.OpenMainForm = false;

                this.Invoke((MethodInvoker)delegate
                {
                    this.Visible = true;
                    this.TopMost = true;
                    this.Focus();
                    //   this.BringToFront();
                });
                Thread.Sleep(30);
                this.Invoke((MethodInvoker)delegate
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    this.TopMost = false;
                });
            }

            if (TaskbarMenu0.commandProxy.Exit == true)
            {
                TaskbarMenu0.commandProxy.Exit = false;

                this.Invoke((MethodInvoker)delegate
                {
                    ConfirmationClose s = new(SnS.fontFamily)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    var result = s.ShowDialog(new WindowWrapper(this.Handle));
                    if (result == DialogResult.Yes)
                    {
                        _forceClose = true;
                        this.Close();
                    }
                });
            }
            if (TaskbarMenu0.commandProxy.OpenSettings == true)
            {
                TaskbarMenu0.commandProxy.OpenSettings = false;

                this.Invoke((MethodInvoker)delegate
                {
                    Settings_ s = new(this)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    s.ShowDialog(new WindowWrapper(this.Handle));
                });
            }
            if (TaskbarMenu0.commandProxy.OpenAbout == true)
            {
                TaskbarMenu0.commandProxy.OpenAbout = false;

                this.Invoke((MethodInvoker)delegate
                {
                    AboutBox box = new(SnS, SnS.fontFamily)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    box.ShowDialog(new WindowWrapper(this.Handle));
                });
            }

            if (hasLock)
            {
                Monitor.Exit(_locker);
            }
        }

        async Task CheckNetwork()
        {
            string s1;
            string s2;
            string s3;
            (s1, s2, s3) = await PIRIClass.GetPerformance();
            if ((s1 != "0") && (s2 != "0") && (s3 != "0"))
            {
                textBox13.Text = s1;
                textBox14.Text = s2;
                textBox15.Text = s3;

                CriticalDATA.CanWork = true;

            }
            else
            {
                CriticalDATA.CanWork = false;
            }

            if (CriticalDATA.CanWork)
            {
                toolStripStatusLabel2.Text = "Online";
                toolStripStatusLabel2.ForeColor = System.Drawing.Color.Lime;
            }
            else
            {
                toolStripStatusLabel2.Text = "Offline";
                toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void DrawFont()
        {


        }

        async private void PIRIHashesGenerator_Load(object sender, EventArgs e)
        {

            FormCreated = true;

            if (SnS.UserSettings["autoloadWallet"].Length > 2)
            {
                if (SnS.UserSettings["autoloadPassword"].Length > 0)
                {
                    textBox16.Text = SnS.UserSettings["autoloadPassword"];
                }
                toolStripTextBox2.Text = SnS.UserSettings["autoloadWallet"];
                Button_LoadHash(sender, e);
            }

            if (textBox8.Text.Length > 0)
            {
                SnS.InitTransactions();
                LoadTransactions();
            }

            await CheckNetwork();

            toolStripDropDownButton1.DropDownItems[0].PerformClick();
            comboBox1.SelectedIndex = 0;

            toolStripTextBox1.Text = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes");


            //  await PIRIClass.SendRawTransaction("PRTMR5sqPyVKHjeHMZkAqKx7AjJGmwdhUkx8aj7PdCn", "PRTMPqg1HaCVCwitYtPCycNkdTkE9431DcWG28dqqvR",
            // textBox9.Text, textBox11.Text, 0.00000001m, -1);

            if (CriticalDATA.IsDebug == false)
            {
                if (SettingsAndSession.IsRunningAsUwp())
                {
                    //if (await license.CheckLicense() == false)
                    //{
                    //    for (int i = 10; i >= 0; i--)
                    //    {
                    //        await Task.Delay(1000);
                    //        toolStripStatusLabel4.ForeColor = System.Drawing.Color.Red;
                    //        toolStripStatusLabel4.Text = "License not found, the program will close in " + i.ToString() + " seconds";
                    //    }
                    //    _forceClose = true;
                    //    this.Close();
                    //}
                }
                else
                {

                }
            }
            //   notifications.RunDebug();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadHash(sender, e);
            tabControl1.SelectedIndex = 1;
        }



        private void LoadHash(object sender, EventArgs e)
        {
            string p = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes");
            FileBrowserDialog fb = new(p, SnS);
            fb.ShowDialog();

            if ((fb.valid) && (File.Exists(Path.Combine(p, fb.SelectedFile))))
            {
                toolStripTextBox2.Text = Path.Combine(p, fb.SelectedFile);
            }

            Button_LoadHash(sender, e);
        }

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.SelectAll();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            string copy = toolStripTextBox1.Text;
            Clipboard.SetText(copy);
        }

        private void ToolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                toolStripDropDownButton1.Text = e.ClickedItem.Text;
            }
        }


        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            LoadHash(sender, e);
        }

        private void ToolStripButton2_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ToolStripDropDownButton1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ToolStripButton1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfirmationClose s = new(SnS.fontFamily);
            var result = s.ShowDialog();
            if (result == DialogResult.Yes)
            {
                _forceClose = true;
                this.Close();
            }
        }
        private void ToolStripTextBox2_Click(object sender, EventArgs e)
        {
            LoadHash(sender, e);
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox box = new(SnS, SnS.fontFamily);
            box.ShowDialog();
        }

        private void ToolStrip2_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ToolStripButton3_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ToolStripButton4_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        void LoadTransactions()
        {
            listView3.Items.Clear();
            foreach (TransactionRecord _tlistItem in SnS._transactionhistory)
            {
                string[] row = { (listView3.Items.Count + 1).ToString(),_tlistItem.Direction, _tlistItem.TransactionHash, _tlistItem.From,
                        _tlistItem.To, _tlistItem.Amount, _tlistItem.Type };

                var listViewItem = new System.Windows.Forms.ListViewItem(row);
                listView3.Items.Insert(0, listViewItem);
            }
        }

        async Task DoneReq()
        {
            await Task.Delay(2000);
            if (toolStripStatusLabel4.Text == "Done.")
            {
                toolStripStatusLabel4.Text = "Waiting...";
                toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            }
        }

        async private Task DpicPUSH()
        {

            for (int i = 0; i <= 666; i++)
            {
                await Task.Delay(15);
                if (Needendreq)
                {
                    Needendreq = false;
                    return;

                }
            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Enabled = false;
                pictureBox2.Image = null;
            }
        }

        async private Task Dpic()
        {
            for (int i = 0; i <= 666; i++)
            {
                await Task.Delay(15);
                if (Needendreq)
                {
                    Needendreq = false;
                    return;

                }
            }
            if (pictureBox1.Image != null)
            {
                pictureBox1.Enabled = false;
                pictureBox1.Image = null;
            }
        }


        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            string in_ = textBox4.Text.Replace(",", ".");
            string s = "0123456789.";
            string ns = "";
            foreach (var item in in_)
            {
                if (s.IndexOf(item) != -1)
                {
                    ns += item;
                }
            }

            if (!ns.Contains('.', StringComparison.InvariantCulture))
            {
                if (ns.Length > 10) ns = ns[..10];
            }
            else
            {
                List<string> totalamounts = new()
                {
                    ns[..ns.IndexOf(".")],
                    ns[(ns.IndexOf(".") + 1)..]
                };
                if (totalamounts[0].Length > 10) totalamounts[0] = totalamounts[0][..10];
                if (totalamounts[1].Length > 8) totalamounts[1] = totalamounts[1][..8];

                ns = totalamounts[0] + "." + totalamounts[1];
            }

            if (ns != textBox4.Text)
            {
                textBox4.Text = ns;
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }


        private void ListView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[2].Width = (this.Width - 952) > 0 ? 470 + (this.Width - 952) : 470;
        }
        private void ListView4_Resize(object sender, EventArgs e)
        {
            int freepx = this.Width - 952;
            listView4.Columns[1].Width = (int)(freepx > 0 ? 170 + (freepx * 0.3) : 170);
            listView4.Columns[2].Width = (int)(freepx > 0 ? 145 + (freepx * 0.2) : 145);
            listView4.Columns[3].Width = (int)(freepx > 0 ? 145 + (freepx * 0.2) : 145);
            listView4.Columns[4].Width = (int)(freepx > 0 ? 85 + (freepx * 0.15) : 85);
            listView4.Columns[5].Width = (int)(freepx > 0 ? 100 + (freepx * 0.15) : 100);
            // listView4.Columns[6].Width = (int)(freepx > 0 ? 140 + (freepx * 0.1) : 140);
        }
        private void ListView3_Resize(object sender, EventArgs e)
        {
            int freepx = this.Width - 952;
            listView3.Columns[2].Width = (int)(freepx > 0 ? 210 + (freepx * 0.35) : 210);
            listView3.Columns[3].Width = (int)(freepx > 0 ? 160 + (freepx * 0.25) : 160);
            listView3.Columns[4].Width = (int)(freepx > 0 ? 160 + (freepx * 0.25) : 160);
            listView3.Columns[5].Width = (int)(freepx > 0 ? 100 + (freepx * 0.15) : 100);
            // listView3.Columns[6].Width = (int)(freepx > 0 ? 100 + (this.Width - 952) * 0.15 : 100);
        }
        private void ListView2_Resize(object sender, EventArgs e)
        {
            int freepx = this.Width - 952;
            listView2.Columns[1].Width = (int)(freepx > 0 ? 300 + (freepx * 0.4) : 300);
            listView2.Columns[2].Width = (int)(freepx > 0 ? 200 + (freepx * 0.25) : 200);
            listView2.Columns[3].Width = (int)(freepx > 0 ? 200 + (freepx * 0.25) : 200);
            listView2.Columns[4].Width = (int)(freepx > 0 ? 120 + (freepx * 0.1) : 120);
        }
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings_ s = new(this);
            s.ShowDialog();
        }

        async private void PIRIHashesGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_forceClose)
            {
                e.Cancel = false;
                return;
            }

            if (SnS.UserSettings["closeTotray"] == "+")
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                await Task.Delay(150);
                this.Visible = false;
                return;
            }

            ConfirmationClose s = new(SnS.fontFamily);
            var result = s.ShowDialog();
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ToolStripDropDownButton1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripDropDownButton1.Text == "Encrypt with password")
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }
        private void WalletsContext(Object? sender, System.EventArgs e)
        {
            Clipboard.Clear();
            string copy = listView1.FocusedItem.SubItems[1].Text + "\t" + listView1.FocusedItem.SubItems[2].Text;
            Clipboard.SetText(copy);

        }

        private void WalletsContextCopy(Object? sender, System.EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Point localPoint = (new Point(contextMenuStrip1.Left, contextMenuStrip1.Top));
                // Point localPointScreen = this.PointToScreen(localPoint);
                localPoint = listView1.PointToClient(localPoint);

                ListViewHitTestInfo hitTest = listView1.HitTest(localPoint);
                var row = hitTest.Item.Index;
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                string copy = listView1.Items[row].SubItems[columnIndex].Text;

                Clipboard.SetText(copy);
            }
            catch (Exception)
            {

            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView1.FocusedItem;
                if (focusedItem != null)
                {

                    contextMenuStrip1.Items[0].Click += WalletsContextCopy;
                    contextMenuStrip1.Items[1].Click += WalletsContext;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }



        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox { Text.Length: > 40 })
            {
                button24.Enabled = true;
            }
            else
            {
                button24.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool hasLock = false;

            if (HashInited == false) return;

            Monitor.TryEnter(checkTransLock, ref hasLock);
            if (!hasLock)
            {
                return;
            }
            this.Invoke((MethodInvoker)async delegate
            {


                await CheckNetwork();

                bool newTrans = false;
                TransactionRecord? lasttrans = null;
                bool secondDownload = SnS._transactionhistory.Count > 0;

                List<TransactionRecord> _tlist = await PIRIClass.GetTransactions(textBox8.Text, SnS);

                if (_tlist.Count > 0)
                {
                    foreach (TransactionRecord _tlistItem in _tlist)
                    {
                        if (!SnS.CheckTransactionHash(_tlistItem.TransactionHash))
                        {
                            SnS._transactionhistory.Add(_tlistItem);
                            if (_tlistItem.Direction == "IN")
                            {
                                lasttrans = _tlistItem;
                                newTrans = true;
                            }

                            string[] row = { (listView3.Items.Count + 1).ToString(),_tlistItem.Direction, _tlistItem.TransactionHash, _tlistItem.From,
                        _tlistItem.To, _tlistItem.Amount, _tlistItem.Type };

                            var listViewItem = new System.Windows.Forms.ListViewItem(row);
                            listView3.Items.Insert(0, listViewItem);
                        }
                    }
                    if ((newTrans) && (lasttrans != null) && (secondDownload)) notifications.RunNotifications(lasttrans);
                    SnS.UpdateTransactions();
                }
                if (textBox8.Text.Length > 40) textBox12.Text = await PIRIClass.GetBalance(textBox8.Text);
            });

            if (hasLock)
            {
                Monitor.Exit(checkTransLock);
            }
        }




        private static void TransactionsOpenWeb(string tx)
        {
            var destinationurl = "https://piriscan.com/transaction/" + tx;
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }

        private void LastTransactionsContext(Object? sender, System.EventArgs e)
        {
            Clipboard.Clear();
            string copy = listView2.FocusedItem.SubItems[1].Text + "\t" + listView2.FocusedItem.SubItems[2].Text +
                "\t" + listView2.FocusedItem.SubItems[3].Text + "\t" + listView2.FocusedItem.SubItems[4].Text;
            Clipboard.SetText(copy);

        }

        private void LastTransactionsContextCopy(Object? sender, System.EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Point localPoint = (new Point(contextMenuStrip2.Left, contextMenuStrip2.Top));
                // Point localPointScreen = this.PointToScreen(localPoint);
                localPoint = listView2.PointToClient(localPoint);

                ListViewHitTestInfo hitTest = listView2.HitTest(localPoint);
                var row = hitTest.Item.Index;
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                string copy = listView2.Items[row].SubItems[columnIndex].Text;

                Clipboard.SetText(copy);
            }
            catch (Exception)
            {

            }
        }

        private void LastTransactionsOpenWeb(Object? sender, System.EventArgs e)
        {
            TransactionsOpenWeb(listView2.FocusedItem.SubItems[1].Text);
        }

        private void ListView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView2.FocusedItem;
                if (focusedItem != null)
                {
                    contextMenuStrip2.Items[0].Click += LastTransactionsContextCopy;
                    contextMenuStrip2.Items[1].Click += LastTransactionsContext;

                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void LastTransactionsHistoryContext(Object? sender, System.EventArgs e)
        {
            Clipboard.Clear();
            string copy = listView3.FocusedItem.SubItems[1].Text + "\t" + listView3.FocusedItem.SubItems[2].Text +
                "\t" + listView3.FocusedItem.SubItems[3].Text + "\t" + listView3.FocusedItem.SubItems[4].Text + "\t" + listView3.FocusedItem.SubItems[5].Text;
            Clipboard.SetText(copy);

        }

        private void LastTransactionsHistoryContextCopy(Object? sender, System.EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Point localPoint = (new Point(contextMenuStrip3.Left, contextMenuStrip3.Top));
                // Point localPointScreen = this.PointToScreen(localPoint);
                localPoint = listView3.PointToClient(localPoint);

                ListViewHitTestInfo hitTest = listView3.HitTest(localPoint);
                var row = hitTest.Item.Index;
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                string copy = listView3.Items[row].SubItems[columnIndex].Text;

                Clipboard.SetText(copy);
            }
            catch (Exception)
            {

            }
        }

        private void LastTransactionsHistoryOpenWeb(Object? sender, System.EventArgs e)
        {
            TransactionsOpenWeb(listView3.FocusedItem.SubItems[2].Text);
        }

        private void ListView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView3.FocusedItem;
                if (focusedItem != null)
                {
                    contextMenuStrip3.Items[0].Click += LastTransactionsHistoryContextCopy;
                    contextMenuStrip3.Items[1].Click += LastTransactionsHistoryContext;

                    contextMenuStrip3.Show(Cursor.Position);
                }
            }
        }


        private void LastTransactionsDATAContext(Object? sender, System.EventArgs e)
        {
            Clipboard.Clear();
            string copy = listView4.FocusedItem.SubItems[1].Text + "\t" + listView4.FocusedItem.SubItems[2].Text +
                "\t" + listView4.FocusedItem.SubItems[3].Text + "\t" + listView4.FocusedItem.SubItems[4].Text + "\t" + listView4.FocusedItem.SubItems[5].Text + "\t" + listView4.FocusedItem.SubItems[6].Text;
            Clipboard.SetText(copy);

        }

        private void LastTransactionsDATAContextCopy(Object? sender, System.EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Point localPoint = (new Point(contextMenuStrip4.Left, contextMenuStrip4.Top));
                // Point localPointScreen = this.PointToScreen(localPoint);
                localPoint = listView4.PointToClient(localPoint);

                ListViewHitTestInfo hitTest = listView4.HitTest(localPoint);
                var row = hitTest.Item.Index;
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                string copy = listView4.Items[row].SubItems[columnIndex].Text;

                Clipboard.SetText(copy);
            }
            catch (Exception)
            {

            }
        }

        private void LastTransactionsDATAOpenWeb(Object? sender, System.EventArgs e)
        {
            TransactionsOpenWeb(listView4.FocusedItem.SubItems[1].Text);
        }

        private void ListView4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView4.FocusedItem;
                if (focusedItem != null)
                {
                    contextMenuStrip4.Items[0].Click += LastTransactionsDATAContextCopy;
                    contextMenuStrip4.Items[1].Click += LastTransactionsDATAContext;

                    contextMenuStrip4.Show(Cursor.Position);
                }
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            string in_ = textBox6.Text;
            string s = "0123456789";
            string ns = "";
            foreach (var item in in_)
            {
                if (s.IndexOf(item) != -1)
                {
                    ns += item;
                }
            }
            textBox6.Text = ns;
        }

        private void PIRIHashesGenerator_Shown(object sender, EventArgs e)
        {
            if (SnS.UserSettings["runMinimized"] == "+")
            {

                if (this.WindowState != FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        async private void PIRIHashesGenerator_Resize(object sender, EventArgs e)
        {
            if (SnS.UserSettings["minTotray"] == "+")
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    await Task.Delay(150);
                    this.Visible = false;
                }
            }
        }


        private void Button12_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in this.listView1.Items)
            {
                if (itemRow.Checked == false)
                {
                    itemRow.Checked = true;
                }
                else
                {
                    itemRow.Checked = false;
                }
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            List<string> strings = new();
            string wallet;
            string _private;

            foreach (ListViewItem itemRow in this.listView1.Items)
            {
                if (itemRow.Checked == true)
                {
                    wallet = itemRow.SubItems[1].Text;
                    _private = itemRow.SubItems[2].Text;

                    strings.Add(wallet + "\t" + _private);
                }

            }

            if (strings.Count > 0)
            {
                Clipboard.Clear();
                string fullbuff = "";
                foreach (string s in strings)
                {
                    fullbuff += s + "\r\n";
                }
                Clipboard.SetText(fullbuff);
            }
        }


        private void Button12_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void Button_CreateQR(object sender, EventArgs e)
        {
            try
            {
                var qr = QrCode.EncodeText(textBox8.Text, QrCode.Ecc.Medium);
                string svg = qr.ToSvgString(2);

                QRCodeForm box = new(SnS.fontFamily);

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svg));
                var _svg = new SkiaSharp.Extended.Svg.SKSvg(new SKSize(247, 247));
                _svg.Load(stream);
                var picture = _svg.Picture;
                var bitmap = new SKBitmap(247, 247);
                using var canvas = new SKCanvas(bitmap);
                canvas.DrawPicture(picture);
                using var image = SKImage.FromBitmap(bitmap);
                box.label1.Text = "" + textBox8.Text;
                box.label1.Location = new Point((377 - box.label1.Size.Width) / 2, 23);
                box.pictureBox1.Image = SKBitmap.FromImage(image).ToBitmap();
                box.ShowDialog();
            }
            catch (Exception) { }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox8.Text);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox9.Text);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox10.Text);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox11.Text);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox12.Text);
        }

        async private void Button11_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            button11.Enabled = false;

            textBox12.Text = await PIRIClass.GetBalance(textBox8.Text);

            button11.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;
            _ = DoneReq();
        }

        async private void Button22_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            button22.Enabled = false;

            (textBox13.Text, textBox14.Text, textBox15.Text) = await PIRIClass.GetPerformance();

            button22.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;
            _ = DoneReq();
        }



        private void Button25_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            string copy = @"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""" + "\r\n";
            copy += "PIRI Wallet ID: " + textBox8.Text + "\r\n";
            copy += "PIRI private key: " + textBox9.Text + "\r\n";
            copy += "PIRI secret`s words: " + textBox10.Text + "\r\n";
            copy += "PIRI public key: " + textBox11.Text + "\r\n";
            copy += "PIRI balance: " + textBox12.Text + "\r\n";
            copy += @"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""@Piri_wallet"""""";" + "\r\n";
            Clipboard.SetText(copy);
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in this.listView3.Items)
            {
                if (itemRow.Checked == false)
                {
                    itemRow.Checked = true;
                }
                else
                {
                    itemRow.Checked = false;
                }
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            List<string> strings = new();

            string hash;
            string from;
            string to;
            string amount;
            string type;

            foreach (ListViewItem itemRow in this.listView3.Items)
            {
                if (itemRow.Checked == true)
                {
                    hash = itemRow.SubItems[1].Text;
                    from = itemRow.SubItems[2].Text;
                    to = itemRow.SubItems[3].Text;
                    amount = itemRow.SubItems[4].Text;
                    type = itemRow.SubItems[5].Text;

                    strings.Add(hash + "\t" + from + "\t" + to + "\t" + amount + "\t" + type);
                }
            }

            if (strings.Count > 0)
            {
                Clipboard.Clear();
                string fullbuff = "";
                foreach (string s in strings)
                {
                    fullbuff += s + "\r\n";
                }
                Clipboard.SetText(fullbuff);
            }
        }

        private void Button_ExportHashes(object sender, EventArgs e)
        {
            string p = "";

            try
            {
                ExportDialog ed = new(Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export"), SnS);
                ed.ShowDialog();

                if (ed.valid)
                {
                    p = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export\\" + ed.FileName);
                }

                if (p.Length > 2)
                {
                    if (p.LastIndexOf(".pdf") > p.Length - 9)
                    {
                        Files_export.Piriwallets_savePDF(listView1, p);
                    }
                    else if (p.LastIndexOf(".xlsx") > p.Length - 9)
                    {
                        Files_export.Piriwallets_saveXLSX(listView1, p);
                    }
                    else if (p.LastIndexOf(".docx") > p.Length - 9)
                    {

                        Files_export.Piriwallets_saveDOCX(listView1, p);
                    }
                    else if (p.LastIndexOf(".csv") > p.Length - 9)
                    {
                        Files_export.Piriwallets_saveCSV(listView1, p);
                    }
                    else if (p.LastIndexOf(".html") > p.Length - 9)
                    {
                        Files_export.Piriwallets_saveHTML(listView1, p);
                    }
                    else if (p.LastIndexOf(".txt") > p.Length - 9)
                    {
                        Files_export.Piriwallets_saveTXT(listView1, p);
                    }

                }

            }
            catch (Exception)
            {

            }

            if (File.Exists(p))
            {
                Success si = new(SnS.fontFamily);
                si.textBox1.Text = "The file is saved in: \r\n" + p;
                si.textBox1.SelectionStart = 0;
                si.textBox1.SelectionLength = 0;
                si.button1.Focus();
                si.ShowDialog();
            }
            else
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }
        }

        private void Button_ExportTransactions(object sender, EventArgs e)
        {
            string p = "";
            try
            {
                ExportDialog ed = new(Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export"), SnS);
                ed.ShowDialog();

                if (ed.valid)
                {
                    p = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export\\" + ed.FileName);
                }

                if (p.Length > 2)
                {
                    if (p.LastIndexOf(".pdf") > p.Length - 9)
                    {
                        Files_export.PiriTransactions_savePDF(listView3, p);
                    }
                    else if (p.LastIndexOf(".xlsx") > p.Length - 9)
                    {

                        Files_export.PiriTransactions_saveXLSX(listView3, p);
                    }
                    else if (p.LastIndexOf(".docx") > p.Length - 9)
                    {

                        Files_export.PiriTransactions_saveDOCX(listView3, p);

                    }
                    else if (p.LastIndexOf(".csv") > p.Length - 9)
                    {
                        Files_export.PiriTransactions_saveCSV(listView3, p);
                    }
                    else if (p.LastIndexOf(".html") > p.Length - 9)
                    {
                        Files_export.PiriTransactions_saveHTML(listView3, p);
                    }
                    else if (p.LastIndexOf(".txt") > p.Length - 9)
                    {
                        Files_export.PiriTransactions_saveTXT(listView3, p);

                    }
                }
            }
            catch (Exception)
            {

            }
            if (File.Exists(p))
            {
                Success si = new(SnS.fontFamily);
                si.textBox1.Text = "The file is saved in: \r\n" + p;
                si.textBox1.SelectionStart = 0;
                si.textBox1.SelectionLength = 0;
                si.button1.Focus();
                si.ShowDialog();
            }
            else
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }
        }

        private void Button_ExportPIRIWallet(object sender, EventArgs e)
        {
            string p = "";
            try
            {
                ExportDialog ed = new(Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export"), SnS);
                ed.ShowDialog();

                if (ed.valid)
                {
                    p = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export\\" + ed.FileName);
                }

                if (p.Length > 2)
                {
                    if (p.LastIndexOf(".pdf") > p.Length - 9)
                    {
                        Files_export.PiriwalletDATA_savePDF(textBox12.Text + " PIRI", textBox8.Text, textBox10.Text, textBox9.Text, textBox11.Text, p);
                    }
                    else if (p.LastIndexOf(".xlsx") > p.Length - 9)
                    {

                        Files_export.PiriwalletDATA_saveXLSX(textBox12.Text, textBox8.Text, textBox10.Text, textBox9.Text, textBox11.Text, p);
                    }
                    else if (p.LastIndexOf(".docx") > p.Length - 9)
                    {

                        Files_export.PiriwalletDATA_saveDOCX(textBox12.Text, textBox8.Text, textBox10.Text, textBox9.Text, textBox11.Text, p);

                    }
                    else if (p.LastIndexOf(".csv") > p.Length - 9)
                    {
                        Files_export.PiriwalletDATA_saveCSV(textBox12.Text, textBox8.Text, textBox10.Text, textBox9.Text, textBox11.Text, p);
                    }
                    else if (p.LastIndexOf(".html") > p.Length - 9)
                    {
                        Files_export.PiriwalletDATA_saveHTML(textBox12.Text, textBox8.Text, textBox10.Text, textBox9.Text, textBox11.Text, p);
                    }
                    else if (p.LastIndexOf(".txt") > p.Length - 9)
                    {
                        Files_export.PiriwalletDATA_saveTXT(textBox12.Text, textBox8.Text, textBox10.Text, textBox9.Text, textBox11.Text, p);

                    }
                }

            }
            catch (Exception)
            {

            }
            if (File.Exists(p))
            {
                Success si = new(SnS.fontFamily);
                si.textBox1.Text = "The file is saved in: \r\n" + p;
                si.textBox1.SelectionStart = 0;
                si.textBox1.SelectionLength = 0;
                si.button1.Focus();
                si.ShowDialog();
            }
            else
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }
        }

        private void Button_ExportPIRIDB(object sender, EventArgs e)
        {
            string p = "";
            try
            {
                ExportDialog ed = new(Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export"), SnS);
                ed.ShowDialog();

                if (ed.valid)
                {
                    p = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes\\export\\" + ed.FileName);
                }

                if (p.Length > 2)
                {
                    if (p.LastIndexOf(".pdf") > p.Length - 9)
                    {
                        Files_export.PiriData_savePDF(listView4, p);
                    }
                    else if (p.LastIndexOf(".xlsx") > p.Length - 9)
                    {

                        Files_export.PiriData_saveXLSX(listView4, p);
                    }
                    else if (p.LastIndexOf(".docx") > p.Length - 9)
                    {

                        Files_export.PiriData_saveDOCX(listView4, p);

                    }
                    else if (p.LastIndexOf(".csv") > p.Length - 9)
                    {
                        Files_export.PiriData_saveCSV(listView4, p);
                    }
                    else if (p.LastIndexOf(".html") > p.Length - 9)
                    {
                        Files_export.PiriData_saveHTML(listView4, p);
                    }
                    else if (p.LastIndexOf(".txt") > p.Length - 9)
                    {
                        Files_export.PiriData_saveTXT(listView4, p);

                    }
                }

            }
            catch (Exception)
            {

            }
            if (File.Exists(p))
            {
                Success si = new(SnS.fontFamily);
                si.textBox1.Text = "The file is saved in: \r\n" + p;
                si.textBox1.SelectionStart = 0;
                si.textBox1.SelectionLength = 0;
                si.button1.Focus();
                si.ShowDialog();
            }
            else
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in this.listView4.Items)
            {
                if (itemRow.Checked == false)
                {
                    itemRow.Checked = true;
                }
                else
                {
                    itemRow.Checked = false;
                }
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            List<string> strings = new();

            string tx;
            string from;
            string to;
            string key;
            string value;
            string type;

            foreach (ListViewItem itemRow in this.listView4.Items)
            {

                if (itemRow.Checked == true)
                {

                    tx = itemRow.SubItems[1].Text;
                    from = itemRow.SubItems[2].Text;
                    to = itemRow.SubItems[3].Text;
                    key = itemRow.SubItems[4].Text;
                    value = itemRow.SubItems[5].Text;
                    type = itemRow.SubItems[6].Text;

                    strings.Add(tx + "\t" + from + "\t" + to + "\t" + key + "\t" + value + "\t" + type);
                }
            }

            if (strings.Count > 0)
            {
                Clipboard.Clear();
                string fullbuff = "";
                foreach (string s in strings)
                {
                    fullbuff += s + "\r\n";
                }
                Clipboard.SetText(fullbuff);
            }
        }



        private void Button26_Click(object sender, EventArgs e)
        {
            if (textBox9.PasswordChar == '*')
            {
                textBox9.PasswordChar = '\0';
                button26.BackgroundImage = Resources.eye1;
            }
            else
            {
                textBox9.PasswordChar = '*';
                button26.BackgroundImage = Resources.eye2;
            }
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            if (textBox10.PasswordChar == '*')
            {
                textBox10.PasswordChar = '\0';
                button27.BackgroundImage = Resources.eye1;
            }
            else
            {
                textBox10.PasswordChar = '*';
                button27.BackgroundImage = Resources.eye2;
            }
        }


        private void Button28_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WebCamQR cr = new(SnS);
            cr.ShowDialog();
            if (cr.Piriwallet != "Searching...")
            {
                textBox7.Text = cr.Piriwallet;
            }
        }
        private async void Button_CreateHash(object sender, EventArgs e)
        {
            //  notifications.RunDebug();
            //SnS.UpdateFont(this);
            bool res = false;
            string path = "";

            if (CriticalDATA.CanWork == false)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Network Error";
                ei.ShowDialog();
                return;
            }

            try
            {
                var fhh = File.Create(Path.Combine(toolStripTextBox1.Text, "t0.t0"));
                fhh?.Close();

            }
            catch (Exception) { }

            if (!File.Exists(Path.Combine(toolStripTextBox1.Text, "t0.t0")))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Wrong output folder";
                ei.ShowDialog();
                return;
            }
            File.Delete(Path.Combine(toolStripTextBox1.Text, "t0.t0"));

            if ((toolStripDropDownButton1.Text == "Encrypt with password") && ((textBox1.Text.Length < 8)))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Password must be 8-32 length";
                ei.ShowDialog();
                return;
            }

            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            button31.Enabled = false;
            try
            {
                path = Path.Combine(toolStripTextBox1.Text, string.Concat("hashcontainer", "_", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.InvariantCulture), ".pirihash"));

                string pub = "";
                string pri = "";
                string words = "";
                string publicKey = "";


                var bip39er = new BIP39(256, "", BIP39.Language.English);
                pri = BitConverter.ToString(bip39er.EntropyBytes).Replace("-", string.Empty).ToLower();
                if (!Encryption.CheckChecksumBIP(bip39er.EntropyBytes, bip39er.MnemonicSentence)) throw new Exception();

                words = bip39er.MnemonicSentence;
                ECDsa ecdsa1 = ECDsa.Create();
                ecdsa1.ImportParameters(new ECParameters
                {
                    D = Convert.FromHexString(pri),
                    Curve = ECCurve.CreateFromFriendlyName("secP256k1")
                });

                var ex = ecdsa1.ExportParameters(false).Q.X;
                var ey = ecdsa1.ExportParameters(false).Q.Y;
                if ((ex != null) && (ey != null))
                {
                    publicKey = "04" + BitConverter.ToString(ex).Replace("-", string.Empty).ToLower() +
                    BitConverter.ToString(ey).Replace("-", string.Empty).ToLower();
                }


                string pk = Encryption.QuickHashX2(publicKey).ToLower();
                Lazy<RIPEMD160> ripemd160 = new(() => new RIPEMD160());
                pk = BitConverter.ToString(ripemd160.Value.ComputeHash(Encoding.ASCII.GetBytes(pk))).Replace("-", string.Empty).ToLower();
                string secondHash = "83" + pk;
                string hashLast = Encryption.QuickHashX2(secondHash).ToLower();
                hashLast = Encryption.QuickHashX2(hashLast).ToLower();
                string firstByte = hashLast[..8];
                string resultStr = secondHash + firstByte;
                pub = "PR" + Base58.Bitcoin.EncodeCheck(Convert.FromHexString(resultStr), 0x83);


                if ((pub.Length > 0) && (pri.Length > 0) && (words.Length > 0) && (publicKey.Length > 0) && (await PIRIClass.IsValidPIRI(pub)))
                {

                    string[] row = { (listView1.Items.Count + 1).ToString(), pub, words };
                    var listViewItem = new System.Windows.Forms.ListViewItem(row);
                    listView1.Items.Insert(0, listViewItem);


                    var jsonwallet = new
                    {
                        pub,
                        pri,
                        words,
                        publicKey
                    };

                    string jsonString = JsonConvert.SerializeObject(jsonwallet);

                    string fullwallet = "";
                    if (toolStripDropDownButton1.Text == "Encrypt")
                    {
                        fullwallet = "_enc_pirihash:" + (Encryption.EncryptString(jsonString, "piri_secret_garden_000"));
                    }
                    else if ((toolStripDropDownButton1.Text == "Encrypt with password") && (textBox1.Text.Length > 0))
                    {

                        fullwallet = "_fenc_pirihash:" + (Encryption.EncryptString(jsonString, textBox1.Text));
                    }
                    else
                    {
                        fullwallet = "_open_pirihash:" + jsonString;
                    }
                    string datastring = fullwallet;
                    byte[] info = new UTF8Encoding(true).GetBytes(datastring);
                    using FileStream fh = File.Create(path);
                    fh.Write(info, 0, info.Length);
                    res = true;
                }
            }
            catch (Exception)
            {

            }

            if (!res)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }
            else
            {

                //Success si = new();
                //si.textBox1.Text = "The import was successful, the hash was saved to a file: \r\n" + path;
                //si.textBox1.SelectionStart = 0;
                //si.textBox1.SelectionLength = 0;
                //si.button1.Focus();
                //si.ShowDialog();
            }
            button31.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;

            _ = DoneReq();
        }
        //async private void Button_CreateHash(object sender, EventArgs e)
        //        {
        //            //notifications.RunDebug();
        //            if (CriticalDATA.CanWork == false)
        //            {
        //                ErrorInfo ei = new();
        //                ei.textBox1.Text = "Network Error";
        //                ei.ShowDialog();
        //                return;
        //            }

        //            try
        //            {
        //                var fhh = File.Create(Path.Combine(toolStripTextBox1.Text, "t0.t0"));
        //                fhh?.Close();

        //            }
        //            catch (Exception) { }

        //            if (!File.Exists(Path.Combine(toolStripTextBox1.Text, "t0.t0")))
        //            {
        //                ErrorInfo ei = new();
        //                ei.textBox1.Text = "Wrong output folder";
        //                ei.ShowDialog();
        //                return;
        //            }
        //            File.Delete(Path.Combine(toolStripTextBox1.Text, "t0.t0"));

        //            if ((toolStripDropDownButton1.Text == "Encrypt with password") && ((textBox1.Text.Length < 8)))
        //            {
        //                ErrorInfo ei = new();
        //                ei.textBox1.Text = "Password must be 8-32 length";
        //                ei.ShowDialog();
        //                return;
        //            }

        //            toolStripStatusLabel4.Text = "Requesting...";
        //            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
        //            button31.Enabled = false;
        //            try
        //            {
        //                string path = Path.Combine(toolStripTextBox1.Text, string.Concat("hashcontainer", "_", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.InvariantCulture), ".pirihash"));
        //                using FileStream fh = File.Create(path);
        //                string pub = "";
        //                string pri = "";
        //                string words = "";
        //                string publicKey = "";
        //                (pub, pri, words, publicKey) = await PIRIClass.CreatePIRI();
        //                if ((pub.Length > 0) && (pri.Length > 0) && (words.Length > 0) && (publicKey.Length > 0))
        //                {

        //                    string[] row = { (listView1.Items.Count + 1).ToString(), pub, words };
        //                    var listViewItem = new System.Windows.Forms.ListViewItem(row);
        //                    listView1.Items.Insert(0, listViewItem);


        //                    var jsonwallet = new
        //                    {
        //                        pub,
        //                        pri,
        //                        words,
        //                        publicKey
        //                    };

        //                    string jsonString = JsonConvert.SerializeObject(jsonwallet);

        //                    string fullwallet = "";
        //                    if (toolStripDropDownButton1.Text == "Encrypt")
        //                    {
        //                        fullwallet = "_enc_pirihash:" + (Encryption.EncryptString(jsonString, "piri_secret_garden_000"));
        //                    }
        //                    else if ((toolStripDropDownButton1.Text == "Encrypt with password") && (textBox1.Text.Length > 0))
        //                    {

        //                        fullwallet = "_fenc_pirihash:" + (Encryption.EncryptString(jsonString, textBox1.Text));
        //                    }
        //                    else
        //                    {
        //                        fullwallet = "_open_pirihash:" + jsonString;
        //                    }
        //                    string datastring = fullwallet;
        //                    byte[] info = new UTF8Encoding(true).GetBytes(datastring);
        //                    fh.Write(info, 0, info.Length);
        //                }
        //            }
        //            catch (Exception)
        //            {

        //            }
        //            button31.Enabled = true;
        //            toolStripStatusLabel4.Text = "Done.";
        //            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;

        //            _ = DoneReq();
        //        }

        private void Button32_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                textBox1.PasswordChar = '\0';
                button32.BackgroundImage = Resources.eye1;
            }
            else
            {
                textBox1.PasswordChar = '*';
                button32.BackgroundImage = Resources.eye2;
            }
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            if (textBox16.PasswordChar == '*')
            {
                textBox16.PasswordChar = '\0';
                button33.BackgroundImage = Resources.eye1;
            }
            else
            {
                textBox16.PasswordChar = '*';
                button33.BackgroundImage = Resources.eye2;
            }
        }

        async private void Button_LoadHash(object sender, EventArgs e)
        {


            HashInited = false;

            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            groupBox2.Enabled = false;

            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            listView4.Items.Clear();
            listView3.Items.Clear();
            SnS.lastTransactionHash = "";
            SnS._transactionhistory.Clear();
            SnS.UpdateTransactions();

            if (!File.Exists(toolStripTextBox2.Text))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Select input file";
                ei.ShowDialog();
                return;
            }

            try
            {
                string walletfile = File.ReadAllText(toolStripTextBox2.Text);
                if (walletfile.Length > 0)
                {
                    char[] _trim = { '\r', '\n', ' ' };
                    walletfile = walletfile.TrimStart(_trim);

                    if (walletfile.IndexOf("_enc_pirihash:") == 0)
                    {
                        walletfile = Encryption.DecryptString(walletfile[(walletfile.IndexOf(":") + 1)..].TrimEnd(_trim), "piri_secret_garden_000");
                    }
                    else
                    if (walletfile.IndexOf("_open_pirihash:") == 0)
                    {
                        walletfile = walletfile[(walletfile.IndexOf(":") + 1)..].TrimEnd(_trim);
                    }
                    else
                    if ((walletfile.IndexOf("_fenc_pirihash:") == 0) && (textBox16.Text.Length > 0))
                    {
                        walletfile = Encryption.DecryptString(walletfile[(walletfile.IndexOf(":") + 1)..].TrimEnd(_trim), textBox16.Text);
                    }

                    JObject _json = JObject.Parse(walletfile);

                    string pri = "";
                    string pub = "";
                    string words = "";
                    string publicKey = "";

                    if (_json.TryGetValue("pri", StringComparison.InvariantCulture, out JToken? jpri))
                    {
                        pri = jpri.ToString();
                    }
                    if (_json.TryGetValue("pub", StringComparison.InvariantCulture, out JToken? jpub))
                    {
                        pub = jpub.ToString();
                    }
                    if (_json.TryGetValue("words", StringComparison.InvariantCulture, out JToken? jwords))
                    {
                        words = jwords.ToString();
                    }
                    if (_json.TryGetValue("publicKey", StringComparison.InvariantCulture, out JToken? jpublicKey))
                    {
                        publicKey = jpublicKey.ToString();
                    }

                    if (pub.Length > 40)
                    {

                        textBox8.Text = pub;
                        textBox9.Text = pri;
                        textBox10.Text = words;
                        textBox11.Text = publicKey;
                        textBox5.Text = pub;

                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;
                        groupBox4.Enabled = true;
                        groupBox5.Enabled = true;

                        Button11_Click(sender, e);
                        await GetTransactions();
                        await GetDataPIRI();
                        HashInited = true;
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void Button35_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
        }



        private void Button29_Click_1(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox17.Text);
        }

        private void Button30_Click_1(object sender, EventArgs e)
        {
            if (textBox17.Text.Length > 0) TransactionsOpenWeb(textBox17.Text);
        }

        private void Button32_Click_1(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                textBox1.PasswordChar = '\0';
                button32.BackgroundImage = Resources.eye1;
            }
            else
            {
                textBox1.PasswordChar = '*';
                button32.BackgroundImage = Resources.eye2;
            }
        }

        async private Task GetTransactions()
        {
            List<TransactionRecord> _tlist = await PIRIClass.GetTransactions(textBox8.Text, SnS);

            if (_tlist.Count > 0)
            {
                foreach (TransactionRecord _tlistItem in _tlist)
                {
                    if (!SnS.CheckTransactionHash(_tlistItem.TransactionHash))
                    {
                        SnS._transactionhistory.Add(_tlistItem);


                        string[] row = { (listView3.Items.Count + 1).ToString(),_tlistItem.Direction, _tlistItem.TransactionHash, _tlistItem.From,
                        _tlistItem.To, _tlistItem.Amount, _tlistItem.Type };

                        var listViewItem = new System.Windows.Forms.ListViewItem(row);
                        listView3.Items.Insert(0, listViewItem);
                    }

                }
                SnS.UpdateTransactions();
            }
        }

        async private void Button_GetTransactions(object sender, EventArgs e)
        {
            if (CriticalDATA.CanWork == false)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Network Error";
                ei.ShowDialog();
                return;
            }
            var hasLock = false;
            Monitor.TryEnter(checkTransLock, ref hasLock);
            if (!hasLock)
            {
                return;
            }

            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            button36.Enabled = false;

            await GetTransactions();

            button36.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;
            _ = DoneReq();

            Monitor.Exit(checkTransLock);
        }

        async private Task GetDataPIRI()
        {
            listView4.Items.Clear();

            List<string[]> datalist = await PIRIClass.GetDataByAddress(textBox8.Text, int.Parse(textBox6.Text));
            if (datalist.Count > 0)
            {
                List<string[]> datalist2 = new();

                if (datalist.Count > int.Parse(textBox6.Text))
                {
                    for (int i = datalist.Count - 1; i >= 0; i--)
                    {

                        datalist2.Insert(0, datalist[i]);
                        if (datalist2.Count == int.Parse(textBox6.Text)) break;
                    }
                    datalist = datalist2;
                }

                foreach (string[] _tlistItem in datalist)
                {
                    string enctype = "Not encrypted";
                    if (_tlistItem[5] == "1") enctype = "Value encrypted";
                    if (_tlistItem[5] == "2") enctype = "Key + Value encrypted";

                    string[] row = { (listView4.Items.Count + 1).ToString(), _tlistItem[0], _tlistItem[1],
                        _tlistItem[2], _tlistItem[3], _tlistItem[4], enctype};

                    var listViewItem = new System.Windows.Forms.ListViewItem(row);
                    listView4.Items.Insert(0, listViewItem);
                }
            }
        }

        async private void Button_GetDB(object sender, EventArgs e)
        {
            if (CriticalDATA.CanWork == false)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Network Error";
                ei.ShowDialog();
                return;
            }



            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            button5.Enabled = false;

            await GetDataPIRI();

            button5.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;

            _ = DoneReq();
        }

        async private void Button_SendDB(object sender, EventArgs e)
        {
            string _from = textBox8.Text;
            string to = textBox5.Text;

            if (CriticalDATA.CanWork == false)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Network Error";
                ei.ShowDialog();
                return;
            }

            if (textBox2.Text.Length == 0)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "The key must be at least 1 character.";
                ei.ShowDialog();
                return;
            }

            if (textBox3.Text.Length == 0)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "The value must be at least 1 character.";
                ei.ShowDialog();
                return;
            }


            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;
            button5.Enabled = false;
            Needendreq = true;
            pictureBox2.Image = null;


            string dataPush = "{\"key\":\"" + textBox2.Text + "\",\"value\":\"" + textBox3.Text + "\",\"enc\":\"" + comboBox1.SelectedIndex.ToString() + "\"}";
            string encryption = "No encryption";
            if (comboBox1.SelectedIndex == 0) encryption = "No encryption";
            if (comboBox1.SelectedIndex == 1) encryption = "Value encryption";
            if (comboBox1.SelectedIndex == 2) encryption = "Key + Value encryption";

            ConfirmationPush cd = new(SnS)
            {
                _fulldata = "KEY: " + textBox2.Text + "\r\nVALUE: " + textBox3.Text + "\r\nENC: " + encryption
            };

            string formdataPush = "Key: " + (textBox2.Text.Length > 10 ? string.Concat(textBox2.Text.AsSpan(0, 10), "...") : textBox2.Text) +
                ", Value: " + (textBox3.Text.Length > 10 ? string.Concat(textBox3.Text.AsSpan(0, 10), "...") : textBox3.Text);

            cd.textBox1.Text = to;
            cd.textBox2.Text = formdataPush;
            cd.textBox3.Text = _from;
            int pb = PIRIClass.CalculatePUSHBytes(to, _from, textBox2.Text, textBox3.Text, comboBox1.SelectedIndex);

            cd.textBox4.Text = pb.ToString() + " Bytes";

            string amount = (pb * 0.0005).ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));

            List<string> amounts = new()
                    {
                        amount[..amount.IndexOf(".")],
                        amount[(amount.IndexOf(".") + 1)..]
                    };
            if (amounts[0].Length > 10) amounts[0] = amounts[0][..10];
            if (amounts[1].Length > 8) amounts[1] = amounts[1][..8];

            amount = amounts[0] + "." + amounts[1];

            decimal commission = PIRIClass.ComissionCalculate((pb * 0.0005m), CriticalDATA.CommissionMin, CriticalDATA.CommissionMax, CriticalDATA.CommissionPerc, 2);
            string totalamount = ((pb * 0.0005m) + commission).ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));


            List<string> totalamounts = new()
                    {
                        totalamount[..totalamount.IndexOf(".")],
                        totalamount[(totalamount.IndexOf(".") + 1)..]
                    };
            if (totalamounts[0].Length > 10) totalamounts[0] = totalamounts[0][..10];
            if (totalamounts[1].Length > 8) totalamounts[1] = totalamounts[1][..8];

            totalamount = totalamounts[0] + "." + totalamounts[1];

            cd.textBox5.Text = amount + " PIRI";
            cd.textBox6.Text = commission.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")) + " PIRI";
            cd.textBox7.Text = totalamount + " PIRI";
            cd.textBox8.Text = encryption;

            cd.button4.Location = new Point(cd.textBox2.Location.X + cd.textBox2.Width + 5, 67);

            cd.button2.Focus();
            cd.ShowDialog();

            if (cd.DialogResult == DialogResult.OK)
            {
                string error;
                string message;
                string tx;


                if (to == _from)
                {
                    to = "";
                }
                label20.Visible = true;
                (error, tx, message) = await PIRIClass.SendDATAPIRI(_from, textBox9.Text, to, dataPush, textBox11.Text);
                if (error != "0")
                {
                    if (message.Length > 1)
                    {
                        ErrorInfo ei = new(SnS.fontFamily);
                        ei.textBox1.Text = message;
                        ei.ShowDialog();
                    }
                    else
                    {
                        ErrorInfo ei = new(SnS.fontFamily);
                        ei.textBox1.Text = "Something was wrong";
                        ei.ShowDialog();
                    }

                    pictureBox2.Image = Resources.error;
                    pictureBox2.Enabled = true;
                }
                if (tx.Length > 0)
                {
                    if (error == "0")
                    {
                        //if (commission != 0.0m)
                        //{
                        //    for (int ii = 0; ii <= 0; ii++)
                        //    {
                        //        await Task.Delay(3000);
                        //        if (await PIRIClass.PayComission(commission - 0.1m, textBox8.Text, CriticalDATA.CentralWallet, textBox9.Text, textBox11.Text) == true) break;
                        //    }
                        //}

                        pictureBox2.Image = Resources.good;
                        pictureBox2.Enabled = true;
                    }
                    textBox17.Text = tx;
                }
                label20.Visible = false;
            }

            button5.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;

            Needendreq = false;
            _ = DoneReq();
            _ = DpicPUSH();
        }

        async private void Button_SendPIRI(object sender, EventArgs e)
        {
            if (CriticalDATA.CanWork == false)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Network Error";
                ei.ShowDialog();
                return;
            }
            pictureBox1.Image = null;
            Needendreq = true;

            if ((textBox4.Text.Length == 0) || (decimal.Parse(textBox4.Text, CultureInfo.InvariantCulture) < 0.00000001m))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "The amount must be greater than or equal to 0.00000001 PIRI";
                ei.ShowDialog();
                return;
            }

            if ((textBox7.Text.Length == 0))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "The PIRI recipient must be a valid PIRI address";
                ei.ShowDialog();
                return;
            }
            button4.Enabled = false;

            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;

            try
            {
                string address = textBox8.Text;
                if (address.Length > 64) address = address[..64];
                string priv = textBox9.Text;
                string to = textBox7.Text;
                if (to.Length > 64) to = to[..64];
                string amount = textBox4.Text;

                decimal dec_amount = decimal.Parse(amount, CultureInfo.InvariantCulture);
                decimal commission = PIRIClass.ComissionCalculate(dec_amount, CriticalDATA.CommissionMin, CriticalDATA.CommissionMax, CriticalDATA.CommissionPerc, 1) + 0.1m;
                string totalamount = (dec_amount + commission).ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));


                List<string> totalamounts = new()
                    {
                        totalamount[..totalamount.IndexOf(".")],
                        totalamount[(totalamount.IndexOf(".") + 1)..]
                    };
                if (totalamounts[0].Length > 10) totalamounts[0] = totalamounts[0][..10];
                if (totalamounts[1].Length > 8) totalamounts[1] = totalamounts[1][..8];
                totalamount = totalamounts[0] + "." + totalamounts[1];

                Confirmation cd = new(SnS.fontFamily);
                cd.textBox1.Text = to;
                cd.textBox2.Text = address;
                cd.textBox3.Text = amount + " PIRI";
                cd.textBox4.Text = commission.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")) + " PIRI";
                cd.textBox5.Text = totalamount + " PIRI";


                cd.button2.Focus();
                cd.ShowDialog();

                if (cd.DialogResult == DialogResult.OK)
                {
                    string error;
                    string message;
                    string tx;
                    label19.Visible = true;
                    (error, message, tx) = await PIRIClass.SendPIRI(amount, address, priv, to, textBox11.Text);


                    if (error == "0" && tx.Length > 8)
                    {
                        //if (commission != 0.0m)
                        //{
                        //    for (int ii = 0; ii <= 0; ii++)
                        //    {
                        //        await Task.Delay(3000);
                        //        if (await PIRIClass.PayComission(commission - 0.2m, address, CriticalDATA.CentralWallet, priv, textBox11.Text) == true) break;
                        //    }
                        //}


                        string[] row = { (listView2.Items.Count + 1).ToString(), tx, to, address, amount };
                        var listViewItem = new ListViewItem(row);
                        listView2.Items.Insert(0, listViewItem);

                        pictureBox1.Image = Resources.good;
                        pictureBox1.Enabled = true;
                    }
                    else
                    {
                        if (error == "1" && message.Length > 1)
                        {
                            ErrorInfo ei = new(SnS.fontFamily);
                            ei.textBox1.Text = message;
                            ei.ShowDialog();
                        }
                        else
                        {
                            ErrorInfo ei = new(SnS.fontFamily);
                            ei.textBox1.Text = "Something went wrong. Please check your internet connection, balance (to prevent double spending), wait 1 minute and try again.";
                            ei.ShowDialog();
                        }
                        pictureBox1.Image = Resources.error;
                        pictureBox1.Enabled = true;
                    }
                    label19.Visible = false;
                }
            }
            catch (Exception)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }

            button4.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;
            Needendreq = false;
            _ = DoneReq();
            _ = Dpic();
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            long sec = (tickTimer.WorkTime / 1000) % 60;
            long min = (tickTimer.WorkTime / 1000 / 60) % 60;
            long hours = (tickTimer.WorkTime / 1000 / 60 / 60);


            this.Invoke(delegate
            {
                timerToolStripMenuItem.Text = hours.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
            });
        }

        async private void LicenseChecker_Tick(object sender, EventArgs e)
        {
            //  await license.CheckLicense();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            var exeName = System.Windows.Forms.Application.ExecutablePath;
            ProcessStartInfo startInfo = new(exeName, Path.Combine(SnS.lap, "PiriHashes_w20\\hashes"))
            {
                Verb = "runas",
                UseShellExecute = true,
                WorkingDirectory = Path.Combine(SnS.lap, "PiriHashes_w20\\hashes")
            };
            System.Diagnostics.Process.Start(startInfo);
        }

        private void ToolStripButton2_MouseMove_1(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        async private void Button1_Click(object sender, EventArgs e)
        {
            bool res = false;
            string path = "";

            try
            {
                var fhh = File.Create(Path.Combine(toolStripTextBox1.Text, "t0.t0"));
                fhh?.Close();

            }
            catch (Exception) { }

            if (!File.Exists(Path.Combine(toolStripTextBox1.Text, "t0.t0")))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Wrong output folder";
                ei.ShowDialog();
                return;
            }
            File.Delete(Path.Combine(toolStripTextBox1.Text, "t0.t0"));

            if ((toolStripDropDownButton1.Text == "Encrypt with password") && ((textBox1.Text.Length < 8)))
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Password must be 8-32 length";
                ei.ShowDialog();
                return;
            }

            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;

            try
            {
                path = Path.Combine(toolStripTextBox1.Text, string.Concat("hashcontainer", "_", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.InvariantCulture), ".pirihash"));

                string pub = "";
                string pri = "";
                string words = "";
                string publicKey = "";

                SecretInput si = new(SnS.fontFamily);
                si.ShowDialog();
                words = si.SecretWords;

                var bip39er = new BIP39(words, "", BIP39.Language.English);
                pri = BitConverter.ToString(bip39er.EntropyBytes).Replace("-", string.Empty).ToLower();

                if (!Encryption.CheckChecksumBIP(bip39er.EntropyBytes, bip39er.MnemonicSentence)) throw new Exception();

                ECDsa ecdsa1 = ECDsa.Create();
                ecdsa1.ImportParameters(new ECParameters
                {
                    D = Convert.FromHexString(pri),
                    Curve = ECCurve.CreateFromFriendlyName("secP256k1")
                });

                var ex = ecdsa1.ExportParameters(false).Q.X;
                var ey = ecdsa1.ExportParameters(false).Q.Y;
                if ((ex != null) && (ey != null))
                {
                    publicKey = "04" + BitConverter.ToString(ex).Replace("-", string.Empty).ToLower() +
                    BitConverter.ToString(ey).Replace("-", string.Empty).ToLower();
                }


                string pk = Encryption.QuickHashX2(publicKey).ToLower();
                Lazy<RIPEMD160> ripemd160 = new(() => new RIPEMD160());
                pk = BitConverter.ToString(ripemd160.Value.ComputeHash(Encoding.ASCII.GetBytes(pk))).Replace("-", string.Empty).ToLower();
                string secondHash = "83" + pk;
                string hashLast = Encryption.QuickHashX2(secondHash).ToLower();
                hashLast = Encryption.QuickHashX2(hashLast).ToLower();
                string firstByte = hashLast[..8];
                string resultStr = secondHash + firstByte;
                pub = "PR" + Base58.Bitcoin.EncodeCheck(Convert.FromHexString(resultStr), 0x83);


                if ((pub.Length > 0) && (pri.Length > 0) && (words.Length > 0) && (publicKey.Length > 0) && (await PIRIClass.IsValidPIRI(pub)))
                {

                    string[] row = { (listView1.Items.Count + 1).ToString(), pub, words };
                    var listViewItem = new System.Windows.Forms.ListViewItem(row);
                    listView1.Items.Insert(0, listViewItem);


                    var jsonwallet = new
                    {
                        pub,
                        pri,
                        words,
                        publicKey
                    };

                    string jsonString = JsonConvert.SerializeObject(jsonwallet);

                    string fullwallet = "";
                    if (toolStripDropDownButton1.Text == "Encrypt")
                    {
                        fullwallet = "_enc_pirihash:" + (Encryption.EncryptString(jsonString, "piri_secret_garden_000"));
                    }
                    else if ((toolStripDropDownButton1.Text == "Encrypt with password") && (textBox1.Text.Length > 0))
                    {

                        fullwallet = "_fenc_pirihash:" + (Encryption.EncryptString(jsonString, textBox1.Text));
                    }
                    else
                    {
                        fullwallet = "_open_pirihash:" + jsonString;
                    }
                    string datastring = fullwallet;
                    byte[] info = new UTF8Encoding(true).GetBytes(datastring);
                    using FileStream fh = File.Create(path);
                    fh.Write(info, 0, info.Length);
                    res = true;
                }
            }
            catch (Exception)
            {

            }

            if (!res)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
            }
            else
            {

                Success si = new(SnS.fontFamily);
                si.textBox1.Text = "The import was successful, the hash was saved to a file: \r\n" + path;
                si.textBox1.SelectionStart = 0;
                si.textBox1.SelectionLength = 0;
                si.button1.Focus();
                si.ShowDialog();
            }

            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;

            _ = DoneReq();
        }

        private void PIRIHashesGenerator_Activated(object sender, EventArgs e)
        {
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            if (CriticalDATA.CanWork == false)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Network Error";
                ei.ShowDialog();
                return;
            }
            pictureBox1.Image = null;
            Needendreq = true;

            button37.Enabled = false;

            toolStripStatusLabel4.Text = "Requesting...";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Aquamarine;

            try
            {

                MultiSend ms = new(SnS, textBox8.Text, textBox9.Text, textBox11.Text, listView2);
                ms.ShowDialog();
                if (ms.Result == true)
                {
                    pictureBox1.Image = Resources.good;
                    pictureBox1.Enabled = true;
                }
                else
                {
                    ErrorInfo ei = new(SnS.fontFamily);
                    ei.textBox1.Text = "Something was wrong";
                    ei.ShowDialog();
                    pictureBox1.Image = Resources.error;
                    pictureBox1.Enabled = true;
                }
            }
            catch (Exception)
            {
                ErrorInfo ei = new(SnS.fontFamily);
                ei.textBox1.Text = "Something was wrong";
                ei.ShowDialog();
                pictureBox1.Image = Resources.error;
                pictureBox1.Enabled = true;
            }

            button37.Enabled = true;
            toolStripStatusLabel4.Text = "Done.";
            toolStripStatusLabel4.ForeColor = System.Drawing.Color.Lime;
            Needendreq = false;
            _ = DoneReq();
            _ = Dpic();
        }
    }
}