using ABI.System;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskbarPopup
{
    public class TransactionRecord
    {
        public string Direction { get; set; }
        public string Type { get; set; }
        public string TransactionHash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Amount { get; set; }
        public TransactionRecord(string _type, string _transactionHash, string _from, string _to, string _amount, string _direction)
        {
            Direction = _direction;
            Type = _type;
            TransactionHash = _transactionHash;
            From = _from;
            To = _to;
            Amount = _amount;
        }
    }
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TaskbarPopup0 : UserControl
    {
        readonly Func<bool> statusCallback;
        public TaskbarPopup0(Func<bool> setstatus)
        {
            InitializeComponent();
            statusCallback = setstatus;
        }
        public void TaskbarPopup1_Update(TransactionRecord transaction)
        {
            this.Dispatcher.Invoke(new Action(() => {

                fromaddress.Text = transaction.From.Length > 0 ? transaction.From : "-";
                //toaddress.Text = transaction.To.Length > 0 ? transaction.To : "-";
                details.Text = transaction.Type == "DATA" ? "Received DATA in wallet database" : "Received " + transaction.Amount + " PIRI";
                id.Text = transaction.TransactionHash;
                //vp.Stop();
                //vp.Close();
                //string? executableDirectoryPath =  Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                //if (executableDirectoryPath!=null)
                //{
                //    string FilePath = Path.Combine(executableDirectoryPath, "resources/v1.mp4");
                //    vp.Source = new System.Uri(FilePath);
                //    vp.Play();
                //}

            }));

        }

        //private static void OpenTx(string tx)
        //{
        //    var destinationurl = "https://piriscan.com/transaction/" + tx;
        //    var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
        //    {
        //        UseShellExecute = true,
        //    };
        //    System.Diagnostics.Process.Start(sInfo);
        //}


        //private static void OpenAddr(string Addr)
        //{
        //    var destinationurl = "https://piriscan.com/address/" + Addr;
        //    var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
        //    {
        //        UseShellExecute = true,
        //    };
        //    System.Diagnostics.Process.Start(sInfo);
        //}

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            statusCallback();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(fromaddress.Text);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
          //  Clipboard.SetText(toaddress.Text);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(details.Text);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(id.Text);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // OpenAddr(fromaddress.Text);
            Clipboard.Clear();
            Clipboard.SetText(fromaddress.Text);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            //   OpenAddr(toaddress.Text);
            Clipboard.Clear();
          //  Clipboard.SetText(toaddress.Text);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // OpenTx(id.Text);
            Clipboard.Clear();
            Clipboard.SetText(details.Text);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           // OpenTx(id.Text);
            Clipboard.Clear();
            Clipboard.SetText(id.Text);
        }

        private static readonly Random random = new();
        public static string RandomString(int length)
        {
            const string chars = "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?";

            string res = "";
            for (int i = 0; i < length; i++)
            {
                if (res.Length % 2 == 0)
                {
                    res += chars[random.Next(chars.Length)];
                }
                else
                {
                    res += " ";
                }
            }
            return res;
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = 450;
            this.MinWidth = 450;
            this.MaxWidth = 450;

            this.Height = 225;
            this.MinHeight = 225;
            this.MaxHeight = 225;
            
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = 450;
            this.MinWidth = 450;
            this.MaxWidth = 450;

            this.Height = 225;
            this.MinHeight = 225;
            this.MaxHeight = 225;
        }

        private void Details_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //    OpenTx(id.Text);
            Clipboard.Clear();
            Clipboard.SetText(details.Text);
        }

        private void Id_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
         //   OpenTx(id.Text);
            Clipboard.Clear();
            Clipboard.SetText(id.Text);
        }

        private void Fromaddress_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //OpenAddr(fromaddress.Text);
            Clipboard.Clear();
            Clipboard.SetText(fromaddress.Text);
        }

        private void Toaddress_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // OpenAddr(toaddress.Text);
            Clipboard.Clear();
          //  Clipboard.SetText(toaddress.Text);
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           // vp.Play();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //vp.Position = TimeSpan.Zero;
            //vp.Play();
        }

        //private void Vp_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //    vp.Position = new System.TimeSpan(0, 0, 0, 0, 0);
        //}
    }
}