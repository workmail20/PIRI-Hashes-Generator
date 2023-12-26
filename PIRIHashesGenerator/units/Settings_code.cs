using DocumentFormat.OpenXml.EMMA;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PIRIHashesGenerator.units
{
    public class TickTimer
    {
        public long WorkTime = 0;
        public long StartTick = 0;
        readonly Thread? _thread;
        public TickTimer()
        {
            StartTick = Environment.TickCount & Int32.MaxValue;
            _thread = new(new ThreadStart(TimerCallback_Command))
            {
                IsBackground = true
            };
            _thread.Start();
        }

        private void TimerCallback_Command()
        {
            while (true)
            {
                Thread.Sleep(16);
                int tk = Environment.TickCount & Int32.MaxValue;
                if (StartTick > tk)
                {
                    StartTick = Environment.TickCount & Int32.MaxValue;
                    WorkTime += 16;
                }
                else
                {
                    WorkTime += tk - StartTick;
                    StartTick = tk;
                }
            }
        }
    }
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

    public static class CriticalDATA
    {
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        public const bool IsDebug = false;
       public static decimal CommissionMin { get; set; } = 0.1m;
        public static decimal CommissionMax { get; set; } = 0.1m;
        public static decimal CommissionPerc { get; set; } = -1.0m;
        public static long LastUpdate { get; set; } = 0;

        public static bool CanWork { get; set; } = false;
    }


    public class SettingsAndSession
    {
        public PrivateFontCollection? collection = null;
        public FontFamily fontFamily;
        public Form _mform;
        public Dictionary<string, string> UserSettings;
        public bool IncomeTransaction = false;
        public List<TransactionRecord> _transactionhistory = new();
        public string lastTransactionHash = "";
        public string lap = "";


        public string userhash = "";
        readonly Db_sql _db;

        public SettingsAndSession(Form mform)
        {
            string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            if (workFolder != null)
            {
                collection = new();
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Black.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-BlackItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Bold.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-BoldItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraBold.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraBoldItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraLight.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraLightItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Italic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Light.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-LightItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Medium.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-MediumItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Regular.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-SemiBold.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-SemiBoldItalic.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Thin.ttf"));
                collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ThinItalic.ttf"));
                fontFamily = new("Kanit", collection);
            }
            else
            {
                fontFamily = new("Kanit");
            }


            _mform = mform;

            string _dbfilename = Encryption.QuickHash("main.db");

            try
            {
                Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                lap = localFolder.Path;
            }
            catch (Exception)
            {

            }
            if (!Directory.Exists(lap))
            {
                lap = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData));
            }

            bool exists = Directory.Exists(Path.Combine(lap, "PiriHashes_w20"));
            if (!exists)
                Directory.CreateDirectory(Path.Combine(lap, "PiriHashes_w20"));

            exists = Directory.Exists(Path.Combine(lap, "PiriHashes_w20\\database"));
            if (!exists)
                Directory.CreateDirectory(Path.Combine(lap, "PiriHashes_w20\\database"));

            exists = File.Exists(Path.Combine(lap, "PiriHashes_w20\\database\\" + _dbfilename));
            if (!exists)
                using (var h = File.Create(Path.Combine(lap, "PiriHashes_w20\\database\\" + _dbfilename)))
                {
                };

            _db = new Db_sql(Path.Combine(lap, "PiriHashes_w20\\database\\" + _dbfilename));

            if (!Directory.Exists(Path.Combine(lap, "PiriHashes_w20\\hashes")))
            {
                Directory.CreateDirectory(Path.Combine(lap, "PiriHashes_w20\\hashes"));

            }
            if (!Directory.Exists(Path.Combine(lap, "PiriHashes_w20\\hashes\\export")))
            {
                Directory.CreateDirectory(Path.Combine(lap, "PiriHashes_w20\\hashes\\export"));
            }

            UserSettings = new Dictionary<string, string>
            {
                { "autoloadWallet", "-" },
                { "autoloadPassword", "" },
                { "taskbarNotification", "-" },
                { "taskbarIncome", "-" },
                { "incomeSound", "-" },
                { "incomeSoundLevel", "-" },
                { "incomeSoundIndex", "-" },
                { "minTotray", "-" },
                { "closeTotray", "-" },
                { "runMinimized", "-" }
            };

            InitConfigs();
        }

        public static long GetUnix()
        {
            DateTime currentTime = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
            return unixTime;
        }

        public bool InitConfigs()
        {
            ConfigItem? res = _db.GetItemAsync(1);

            if (res == null || res.Userhash.Length < 1)
            {
                var deviceId = Guid.NewGuid().ToString();

                res = new ConfigItem
                {
                    ID = 1,
                    Userhash = deviceId,
                    Settings1 = JsonConvert.SerializeObject(UserSettings),
                    Settings2 = "",
                    Settings3 = "0",
                    Settings4 = "",
                    Settings5 = "",
                    Settings6 = "",
                    Settings7 = "",
                    Settings8 = "",
                    Settings9 = "",
                    Settings10 = "",
                    Settings11 = "",
                    Settings12 = "",
                    Settings13 = "",
                    Settings14 = "",
                    Settings15 = ""
                };

                _db.SaveItemAsync(res, true);
                res = _db.GetItemAsync(1);
            }


            if (res != null)
            {
                userhash = res.Userhash;
                Dictionary<string, string>? _dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Settings1);
                if (_dic != null) UserSettings = _dic;
            }

            return true;
        }

        public void UpdateSettings()
        {
            var res = _db.GetItemAsync(1);

            if (res != null && res.Userhash.Length > 0)
            {
                res.Settings1 = JsonConvert.SerializeObject(UserSettings);
                _db.SaveItemAsync(res, false);
            }
        }

        public bool InitTransactions()
        {
            ConfigItem? res = _db.GetItemAsync(2);

            if (res == null)
            {
                res = new ConfigItem
                {
                    ID = 2,
                    Userhash = "",
                    Settings1 = JsonConvert.SerializeObject(_transactionhistory),
                    Settings2 = "",
                    Settings3 = "",
                    Settings4 = "",
                    Settings5 = "",
                    Settings6 = "",
                    Settings7 = "",
                    Settings8 = "",
                    Settings9 = "",
                    Settings10 = "",
                    Settings11 = "",
                    Settings12 = "",
                    Settings13 = "",
                    Settings14 = "",
                    Settings15 = ""
                };

                _db.SaveItemAsync(res, true);
                res = _db.GetItemAsync(2);
            }


            if (res != null)
            {
                List<TransactionRecord>? _dic = JsonConvert.DeserializeObject<List<TransactionRecord>>(res.Settings1);
                if (_dic != null) _transactionhistory = _dic;
            }

            return true;
        }

        public void UpdateTransactions()
        {
            var res = _db.GetItemAsync(2);

            if (res != null)
            {
                res.Settings1 = JsonConvert.SerializeObject(_transactionhistory);
                _db.SaveItemAsync(res, false);
            }
        }

        public bool CheckTransactionHash(string hash)
        {
            var tr = _transactionhistory.FirstOrDefault(t => t?.TransactionHash == hash, null);
            if (tr != null)
            {
                return true;
            }
            return false;
        }



        //public  void UpdateFont(object _Form)
        //{
        //    //if (collection == null) {
        //    //    string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        //    //    if (workFolder != null)
        //    //    {
        //    //        collection = new();
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Black.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-BlackItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Bold.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-BoldItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraBold.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraBoldItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraLight.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ExtraLightItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Italic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Light.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-LightItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Medium.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-MediumItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Regular.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-SemiBold.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-SemiBoldItalic.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-Thin.ttf"));
        //    //        collection.AddFontFile(Path.Combine(workFolder, "fonts\\Kanit-ThinItalic.ttf"));
        //    //        fontFamily = new(_infont, collection);
        //    //    }
        //    //}

        //    //if (fontFamily != null)
        //    //{
        //    //    var gg = _Form.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        //    //    foreach (var f in gg)
        //    //    {
        //    //        if (f is Control)
        //    //        {
        //    //        //    (f. as Control).Font = new(fontFamily, _Form.Font.SizeInPoints, FontStyle.Bold, GraphicsUnit.Point);
        //    //        }

        //    //    }

        //    //}
        //    //return true;
        //}

        public static bool IsRunningAsUwp()
        {
            DesktopBridge.Helpers helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }


    }
}
