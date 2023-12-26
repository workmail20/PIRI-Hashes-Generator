using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using pirichain_api_workmail20;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using ExtensionMethods;
using static Net.Codecrete.QrCodeGenerator.QrCode;
using DocumentFormat.OpenXml.EMMA;
using Org.BouncyCastle.Utilities.Net;
using static NPOI.SS.Formula.Functions.LinearRegressionFunction;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.Sec;
using DocumentFormat.OpenXml.Vml;
using Windows.Security.Cryptography.Core;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Windows.ApplicationModel.ConversationalAgent;
using NPOI.Util;
using System.Text.Unicode;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace ExtensionMethods
{
    public static class MyJObject
    {
        public static string TryGetStringValue(this JObject _JObject, string key)
        {
            if (_JObject.TryGetValue(key, StringComparison.InvariantCulture, out JToken? jdata))
            {
                return jdata.ToString();
            }
            else
            {
                return "";
            }
        }

        public static int TryGetIntValue(this JObject _JObject, string key)
        {
            if (_JObject.TryGetValue(key, StringComparison.InvariantCulture, out JToken? jdata))
            {
                return (int)jdata;
            }
            else
            {
                return 0;
            }
        }
    }
}

namespace PIRIHashesGenerator.units
{
    public class HTTPSend
    {
        static public async Task<string> SendHttpPOST_json(string url, string data = "")
        {
            string Result = "";
            try
            {
                HttpClient httpClient = new(new HttpClientHandler
                {
                    MaxConnectionsPerServer = 10
                })
                {
                    Timeout = TimeSpan.FromSeconds(60.0)
                };
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36 Edg/93.0.961.47");

                CancellationTokenSource cts = new();
                try
                {
                    StringContent stringContent = new(data, Encoding.UTF8, "application/json");
                    stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(url, stringContent, cts.Token);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        Result = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
                catch (WebException)
                {
                    Result = "";
                }
                catch (TaskCanceledException ex2)
                {
                    Result = ((!(ex2.CancellationToken == cts.Token)) ? "" : "");
                }
                httpClient.Dispose();
            }
            catch (Exception)
            {

            }

            return Result;
        }
    }
        public class PIRIClass
    {
        static public async Task<string> SendHttpPOST_json(string url, string data = "")
        {
            string Result = "";
            try
            {
                HttpClient httpClient = new(new HttpClientHandler
                {
                    MaxConnectionsPerServer = 10
                })
                {
                    Timeout = TimeSpan.FromSeconds(60.0)
                };
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36 Edg/93.0.961.47");

                CancellationTokenSource cts = new();
                try
                {
                    StringContent stringContent = new(data, Encoding.UTF8, "application/json");
                    stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(url, stringContent, cts.Token);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        Result = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
                catch (WebException)
                {
                    Result = "";
                }
                catch (TaskCanceledException ex2)
                {
                    Result = ((!(ex2.CancellationToken == cts.Token)) ? "" : "");
                }
                httpClient.Dispose();
            }
            catch (Exception)
            {

            }

            return Result;
        }

        static public async Task<string> GetBalance(string wallet)
        {
            string Result = "Error";
            try
            {
                PirichainAPI_w20 pw = new(true);
                string json = await pw.getBalance(wallet);
                JObject wallets = JObject.Parse(json);

                Result = wallets.TryGetStringValue("balance");
            }
            catch (Exception)
            {

            }
            return Result;
        }

        static public async Task<Tuple<string, string, string>> GetPerformance()
        {
            string amount = "0";
            string blockCount = "0";
            string transactionCount = "0";

            try
            {
                PirichainAPI_w20 pw = new(true);
                string json = await pw.getCirculation();
                JObject wallets = JObject.Parse(json);

                amount = wallets.TryGetStringValue("amount");

                json = await pw.getStats();
                wallets = JObject.Parse(json);

                blockCount = wallets.TryGetStringValue("blockCount");
                transactionCount = wallets.TryGetStringValue("transactionCount");
            }
            catch (Exception)
            {

            }
            return new Tuple<string, string, string>(amount, blockCount, transactionCount);
        }

        static public async Task<List<TransactionRecord>> GetTransactions(string wallet, SettingsAndSession SnS)
        {
            List<TransactionRecord> _tlist = new();



            int found = 0;
            int get = 1;
            try
            {
                PirichainAPI_w20 pw = new(true);
                while (true)
                {
                    string json = await pw.listTransactionsByAddr(wallet, (found).ToString(), get.ToString());
                    get *= 2;

                    JObject trans = JObject.Parse(json);

                    if (trans.TryGetValue("doc", StringComparison.InvariantCulture, out JToken? jdoc))
                    {
                        if (!jdoc.Any()) break;

                        foreach (JToken it in jdoc)
                        {
                            found++;
                            JObject? oit = it.ToObject<JObject>();
                            if (oit != null)
                            {
                                string type = "-";
                                string transactionHash = "";
                                string from = "";
                                string to = "-";
                                string amount = "";
                                string direction = "";
                                string fee = "";

                                transactionHash = oit.TryGetStringValue("transactionHash");
                                from = oit.TryGetStringValue("from");


                                amount = oit.TryGetStringValue("amount").Replace(',', '.');

                                if (amount != "0")
                                    if (decimal.TryParse(amount, NumberStyles.Number | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out decimal _dec))
                                    {
                                        amount = _dec.ToString("0.00000000").Replace(',', '.');
                                    }

                                to = oit.TryGetStringValue("to");
                                fee = oit.TryGetStringValue("fee");

                                if (amount == "0")
                                {
                                    type = "DATA";
                                }
                                else
                                {
                                    type = "COIN";
                                }


                                if (from == wallet) direction = "OUT"; else direction = "IN";

                                if (transactionHash == SnS.lastTransactionHash)
                                {
                                    if (_tlist.Count > 0)
                                    {
                                        SnS.lastTransactionHash = _tlist[^1].TransactionHash;
                                    }

                                    return _tlist;
                                }

                                TransactionRecord row = new
                                (
                                    type,
                                    transactionHash,
                                    from,
                                    to,
                                    amount,
                                    direction
                                );

                                _tlist.Insert(0, row);
                            }
                        }
                    }
                    else
                    {
                        _tlist.Clear();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _ = ex;
                // Thread.Sleep(1000);
            }
            if (_tlist.Count > 0)
            {
                SnS.lastTransactionHash = _tlist[^1].TransactionHash;
            }
            return _tlist;
        }
        static public async Task<List<string[]>> GetDataByAddress(string wallet, int needcount)
        {
            List<string[]> datalist = new();
            try
            {
                int get = 0;
                PirichainAPI_w20 pw = new(true);
                string json = await pw.listDataByAddress(wallet, "0", "1");
                JObject trans = JObject.Parse(json);
                int count = 0;

                count = trans.TryGetIntValue("count");

                if (count > 0)
                {
                    get = needcount;
                    int parts = 1;
                    if (get < count)
                    {
                        parts = (int)Math.Round((float)count / (float)get, 0, MidpointRounding.ToZero);
                    }

                    for (int i = 1; i >= 0; i--)
                    {
                        if ((parts - i) >= 0)
                        {
                            json = await pw.listDataByAddress(wallet, (parts - i).ToString(), get.ToString());
                            trans = JObject.Parse(json);
                            if (trans.TryGetValue("data", StringComparison.InvariantCulture, out JToken? jdata))
                            {
                                foreach (JToken it in jdata)
                                {
                                    JObject? oit = it.ToObject<JObject>();
                                    if (oit != null)
                                    {
                                        string enc = "";
                                        string transactionHash = "";
                                        string from = "";
                                        string to = "";
                                        string key = "";
                                        string value = "";

                                        transactionHash = oit.TryGetStringValue("txID");
                                        from = oit.TryGetStringValue("from");
                                        key = oit.TryGetStringValue("key");
                                        value = oit.TryGetStringValue("value");
                                        to = oit.TryGetStringValue("to");
                                        enc = oit.TryGetStringValue("enc");

                                        datalist.Add(new string[] { transactionHash, from, to, key, value, enc });

                                    }
                                }
                            }
                            else
                            {
                                datalist.Clear();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return datalist;
        }

        async public static Task<Tuple<string, string, string>> SendPIRI(string amount, string address, string priv, string to, string _public)
        {

            string error = "-1";
            string message = "";
            string tx = "";
            try
            {
                //    PirichainAPI_w20 pw = new(true);
                //  string json = await pw.sendToken(address, priv, to, amount, "-1");
                string json = await SendRawTransaction(address, to, priv, _public, decimal.Parse(amount, System.Globalization.CultureInfo.CreateSpecificCulture("en-us")), -1);
                JObject wallets = JObject.Parse(json);

                if (wallets.ContainsKey("error"))
                {
                    error = wallets.TryGetStringValue("error");
                    tx = wallets.TryGetStringValue("tx");
                    message = wallets.TryGetStringValue("message");
                    if (message.Length == 0) message = wallets.TryGetStringValue("data");
                }
            }
            catch (Exception) { }
            return new Tuple<string, string, string>(error, message, tx);
        }

        async public static Task<Tuple<string, string, string, string>> CreatePIRI()
        {
            string pri = "";
            string pub = "";
            string words = "";
            string publicKey = "";
            try
            {
                PirichainAPI_w20 pw = new(true);
                string json = await pw.createNewAddress();

                JObject wallets = JObject.Parse(json);

                if (wallets.ContainsKey("pri"))
                {
                    pri = wallets.TryGetStringValue("pri");
                    pub = wallets.TryGetStringValue("pub");
                    words = wallets.TryGetStringValue("words");
                    publicKey = wallets.TryGetStringValue("publicKey");
                }
            }
            catch (Exception) { }
            return new Tuple<string, string, string, string>(pub, pri, words, publicKey);
        }


        async public static Task<bool> PingPIRI()
        {
            bool res = false;
            try
            {
                PirichainAPI_w20 pw = new(true);
                string json = await pw.getCirculation();
                if (json.Length > 2)
                {
                    JObject wallets = JObject.Parse(json);

                    string amount = wallets.TryGetStringValue("amount");
                    if (amount.Length > 0)
                    {
                        res = true;
                    }
                }
            }
            catch (Exception) { }
            return res;
        }

        async public static Task<bool> IsValidPIRI(string pi)
        {
            bool res = false;
            try
            {
                PirichainAPI_w20 pw = new(true);
                string json = await pw.isValidAddress(pi);
                if (json.Length > 2)
                {
                    if (json == "true")
                    {
                        res = true;
                    }
                }
            }
            catch (Exception) { }
            return res;
        }

        async public static Task<Tuple<string, string, string>> SendDATAPIRI(string addr, string prvt, string to, string cst, string publ)
        {

            string error = "-1";
            string message = "";
            string tx = "";
            try
            {
                PirichainAPI_w20 pw = new(true);

                string json = await pw.pushData(addr, prvt, to, cst, publ);

                JObject wallets = JObject.Parse(json);

                if (wallets.ContainsKey("error"))
                {
                    error = wallets.TryGetStringValue("error");
                    tx = wallets.TryGetStringValue("tx");
                    message = wallets.TryGetStringValue("message");
                    if (message.Length == 0) message = wallets.TryGetStringValue("data");
                }
            }
            catch (Exception) { }
            return new Tuple<string, string, string>(error, tx, message);
        }


        static public string PrepareSendTokenWithSignature(string _from, string _toAddress, decimal _amount, int _assetID, long _globTime)
        {
            object package = new
            {
                amount = "########",
                assetID = _assetID,
                fee = 0.1m,
                from = _from,
                timeStamp = _globTime,
                to = _toAddress,
            };

            string converted = JsonConvert.SerializeObject(package);
            if (_amount >= 0.000001m)
            {
                string d = _amount.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                d = d.TrimEnd('0');
                d = d.TrimEnd('.');
                converted = converted.Replace("\"########\"", d);
            }
            else
            {
                converted = converted.Replace("\"########\"", _amount.ToString("0.###e+0", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")));
            }
            return converted;
        }

        static public byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 1);
            newArray[0] = newByte;
            return newArray;
        }

        static public byte[] SignToDer(byte[] _in)
        {
            byte[] h1 = { 0x30, 0x00 };

            byte[] b1 = new byte[32];
            byte[] b2 = new byte[32];
            Array.Copy(_in, 0, b1, 0, 32);
            if (b1[0] > 0x7F) b1 = AddByteToArray(b1, 0x00);
            b1 = AddByteToArray(b1, (byte)b1.Length);
            b1 = AddByteToArray(b1, 0x02);

            Array.Copy(_in, 32, b2, 0, 32);
            if (b2[0] > 0x7F) b2 = AddByteToArray(b2, 0x00);
            b2 = AddByteToArray(b2, (byte)b2.Length);
            b2 = AddByteToArray(b2, 0x02);

            byte[] result = h1.Concat(b1).Concat(b2).ToArray();
            result[1] = (byte)(result.Length - 2);
            return result;
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        async static public Task<string> SendRawTransaction(string _from, string _toAddress, string _private, string _public, decimal _amount, int _assetID)
        {
            string result = "";
            try
            {
                string _public0 = _public[2..];
                long timeStamp0 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                string message_ = PrepareSendTokenWithSignature(_from, _toAddress, _amount, _assetID, timeStamp0);


                ECDsa ecdsa1 = ECDsa.Create();
                ecdsa1.ImportParameters(new ECParameters
                {
                    D = Convert.FromHexString(_private),
                    Q = new ECPoint
                    {
                        X = Convert.FromHexString(_public0[..64]),
                        Y = Convert.FromHexString(_public0.AsSpan(64, 64))
                    },
                    Curve = ECCurve.CreateFromFriendlyName("secP256k1")
                });


                var h = Convert.FromHexString(Encryption.QuickHash(message_).ToLower());
                var signature0 = ecdsa1.SignHash(h, DSASignatureFormat.Rfc3279DerSequence);
                var signature0hash = BitConverter.ToString(signature0).Replace("-", string.Empty).ToLower();

                var b = ecdsa1.VerifyHash(h, Convert.FromHexString(signature0hash), DSASignatureFormat.Rfc3279DerSequence);

                if (b == false) return "Signature Error";

                object data = new
                {
                    publicKey = _public,
                    address = _from,
                    to = _toAddress,
                    amount = "########",
                    assetID = _assetID,
                    signaturedData = signature0hash,
                    timeStamp = timeStamp0,
                };

                string converted = JsonConvert.SerializeObject(data);
                if (_amount >= 0.000001m)
                {
                    string d = _amount.ToString("0.00000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                    d = d.TrimEnd('0');
                    d = d.TrimEnd('.');
                    converted = converted.Replace("\"########\"", d);
                }
                else
                {
                    converted = converted.Replace("\"########\"", _amount.ToString("0.###e+0", System.Globalization.CultureInfo.CreateSpecificCulture("en-us")));
                }

                result = await SendHttpPOST_json("https://core.pirichain.com/sendRawTransaction", converted);
            }
            catch (Exception)
            {

            }

            return result;
        }

        public static decimal ComissionCalculate(decimal sum, decimal min, decimal max, decimal percent, int _type)
        {
            return 0.0m;
            //decimal _comm = ((sum / 100.0m) * percent);
            //if (_comm > max)
            //{
            //    _comm = max;
            //}
            //if (_comm < min)
            //{
            //    _comm = min;
            //}

            //if (_comm == 0.0m)
            //{
            //    if (_type == 1)//coin
            //    {
            //        _comm += 0.1m;
            //    }
            //    return _comm;
            //}

            //if (_type == 1)//coin
            //{
            //    _comm += 0.2m;
            //}
            //else if (_type == 2)//data
            //{
            //    _comm += 0.1m;
            //}

            //return _comm;
        }

        public static int CalculatePUSHBytes(string from, string to, string key, string data, int enc)
        {
            int result = 0;

            int keyl = ((key.Length % 16) == 0) && (enc == 2) ? key.Length + 16 : key.Length;
            int vall = ((data.Length % 16) == 0) && (enc > 0) ? data.Length + 16 : data.Length;

            if (enc == 1)
            {
                if ((vall % 16) != 0)
                {
                    vall += (16 - (vall % 16));
                }
                vall *= 2;
            }
            if (enc == 2)
            {

                if ((keyl % 16) != 0)
                {
                    keyl += (16 - (keyl % 16));
                }
                keyl *= 2;
                if ((vall % 16) != 0)
                {
                    vall += 16 - (vall % 16);
                }
                vall *= 2;
            }


            if (from == to)
            {
                result += keyl + vall + 110;
            }
            else
            if (from != to)
            {
                result += keyl + vall + 161;
            }
            return result;
        }
    }
}
