using QuestPDF.Drawing;
using System.Runtime.InteropServices;

namespace PIRIHashesGenerator
{
    internal static class Program
    {
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);

        private static readonly string appGuid = "40ed4469-8cf6-446c-b723-bdbda31e68aa";

        [STAThread]
        static void Main()
        {
            // MessageBox.Show("0000000");

            // ***this line is added***

             // ApplicationConfiguration.Initialize();

            global::System.Windows.Forms.Application.EnableVisualStyles();
            global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
           // global::System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
           global::System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.DpiUnaware);

            using Mutex mutex = new(false, appGuid);
            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("Program is already Running", "PIRI Hashes Generator");
                return;
            }


            Application.Run(new PIRIHashesGenerator());
        }
    } 
}