

using System.Windows.Forms.Integration;

namespace PIRIHashesGenerator
{
    public partial class ProxyControl : Form
    {
        readonly ElementHost ctrlHost;
        readonly TaskbarPopup.TaskbarPopup0 wpfAddressCtrl;
        public ProxyControl(TaskbarPopup.TaskbarPopup0 WPF)
        {
            InitializeComponent();
            wpfAddressCtrl = WPF;

            ctrlHost = new()
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(ctrlHost);

            ctrlHost.Child = wpfAddressCtrl;
            this.Width = 450;
            this.Height = 225;
        }

        private void ProxyControl_Load(object sender, EventArgs e)
        {

            //   panel1.Controls.Add(ctrlHost);
            //   wpfAddressCtrl.InitializeComponent();
            //   ctrlHost.Child = wpfAddressCtrl;
        }

        async public Task AnimateShow()
        {
            int y = Screen.PrimaryScreen.WorkingArea.Bottom;
            int x = Screen.PrimaryScreen.WorkingArea.Right;

            int finishy = y - 225;
            int finishx = x - 450;

            this.Location = new Point(finishx, y);
            this.Show();

            this.TopMost = true;
            this.Focus();

            await Task.Delay(15);
            for (int i = 0; i < 8; i++)
            {
                y -= (225 / 8);
                if (y < finishy) y = finishy;
                this.Location = new Point(finishx, y);
                await Task.Delay(15);
            }
            this.Location = new Point(finishx, finishy);
            this.TopMost = false;
            //this.Location = new Point(x- 470, y- 365);
        }
        public void RunPopup()
        {

            
            _ = AnimateShow();
        }
    }
}
