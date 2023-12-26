using FlashCap;
using Windows.Media.Capture.Frames;
using Windows.Media.Capture;
using ZXing.SkiaSharp;
using Windows.Media.MediaProperties;
using Windows.Graphics.Imaging;
using Windows.UI.Core;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.Foundation;
using System;
using System.Diagnostics;
using PIRIHashesGenerator.units;

namespace PIRIHashesGenerator
{


    public partial class WebCamQR : Form
    {
        //    CaptureDevice? CurrentDevice = null;
        bool inited = false;
        //   private readonly object cameraLock = new();
        private int TestQRTimer = 0;
        public string Piriwallet = "Searching...";
        readonly BarcodeReader QRreader;
        MediaCapture? mediaCapture;
        MediaFrameReader? mediaFrameReader;
        List<CamSource>? CamSource_;

        private SoftwareBitmap? backBuffer = null;
        private bool taskRunning = false;
        SettingsAndSession sns;
        public WebCamQR(SettingsAndSession _sns)
        {
            sns = _sns;
            InitializeComponent();
            var f = sns.fontFamily;
            comboBox1.Font = new Font(f, comboBox1.Font.SizeInPoints, comboBox1.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            button4.Font = new Font(f, button4.Font.SizeInPoints, button4.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(f, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            label4.Font = new Font(f, label4.Font.SizeInPoints, label4.Font.Style, GraphicsUnit.Point);

        QRreader = new();
        }
        async private Task RunStream()
        {
            label4.Visible = false;
            try
            {
                if ((CamSource_ != null) && (CamSource_[0] != null))
                {
                    var camsrc = CamSource_[0];
                    mediaCapture = new();

                    var settings = new MediaCaptureInitializationSettings()
                    {
                        SourceGroup = camsrc.MediaFrameSourceGroup_,
                        SharingMode = MediaCaptureSharingMode.ExclusiveControl,
                        MemoryPreference = MediaCaptureMemoryPreference.Cpu,
                        StreamingCaptureMode = StreamingCaptureMode.Video
                    };

                    await mediaCapture.InitializeAsync(settings);
                    var sourceid = camsrc.MediaFrameSourceInfo_;
                    if (sourceid != null)
                    {
                        var colorFrameSource = mediaCapture.FrameSources[sourceid.Id];
                        var preferredFormat = colorFrameSource.SupportedFormats[camsrc.Index_];

                        if (preferredFormat != null)
                        {
                            await colorFrameSource.SetFormatAsync(preferredFormat);
                            mediaFrameReader = await mediaCapture.CreateFrameReaderAsync(colorFrameSource, MediaEncodingSubtypes.Bgra8);
                            mediaFrameReader.FrameArrived += FrameWorker;
                            MediaFrameReaderStartStatus result = await mediaFrameReader.StartAsync();
                            if (result != MediaFrameReaderStartStatus.Success)
                            {
                                label4.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                label4.Visible = true;
            }
        }

        private void TestQRCode(MemoryStream ms)
        {
            int NewTick = (Environment.TickCount);

            if ((NewTick - TestQRTimer) > 100)
            {
                TestQRTimer = (Environment.TickCount);
                try
                {
                    Bitmap bm = new(ms);
                    SkiaSharp.SKBitmap sbm = SkiaSharp.Views.Desktop.Extensions.ToSKBitmap(bm);

                    var result = QRreader.Decode(sbm);
                    if (result != null)
                    {
                        if (result.Text != null)
                        {
                            if (result.Text.Contains("PRTM")) Piriwallet = result.Text;
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        async private void ReRunStream(int i)
        {
            label4.Visible = false;

            try
            {
                await mediaFrameReader?.StopAsync();
                if (mediaFrameReader != null) mediaFrameReader.FrameArrived -= FrameWorker;
                mediaCapture?.Dispose();
                mediaCapture = null;
                //  await Task.Delay(1000);
            }
            catch (Exception) { }

            try
            {
                if ((CamSource_ != null) && (CamSource_[i] != null))
                {
                    var camsrc = CamSource_[i];

                    mediaCapture = new();

                    var settings = new MediaCaptureInitializationSettings()
                    {
                        SourceGroup = camsrc.MediaFrameSourceGroup_,
                        SharingMode = MediaCaptureSharingMode.ExclusiveControl,
                        MemoryPreference = MediaCaptureMemoryPreference.Cpu,
                        StreamingCaptureMode = StreamingCaptureMode.Video
                    };

                    await mediaCapture.InitializeAsync(settings);
                    var sourceid = camsrc.MediaFrameSourceInfo_;
                    if (sourceid != null)
                    {
                        var colorFrameSource = mediaCapture.FrameSources[sourceid.Id];
                        var preferredFormat = colorFrameSource.SupportedFormats[camsrc.Index_];

                        if (preferredFormat != null)
                        {
                            await colorFrameSource.SetFormatAsync(preferredFormat);
                            mediaFrameReader = await mediaCapture.CreateFrameReaderAsync(colorFrameSource, MediaEncodingSubtypes.Bgra8);
                            mediaFrameReader.FrameArrived += FrameWorker;
                            MediaFrameReaderStartStatus result = await mediaFrameReader.StartAsync();
                            if (result != MediaFrameReaderStartStatus.Success)
                            {
                                label4.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                label4.Visible = true;
            }
        }

        async private void WebCamQR_Load(object sender, EventArgs e)
        {
            try
            {
                CamSource_ = new();

                var frameSourceGroups = await MediaFrameSourceGroup.FindAllAsync();
                foreach (var sourceGroup in frameSourceGroups)
                {

                    try
                    {
                        var settings = new MediaCaptureInitializationSettings()
                        {
                            SourceGroup = sourceGroup,
                            SharingMode = MediaCaptureSharingMode.ExclusiveControl,
                            MemoryPreference = MediaCaptureMemoryPreference.Cpu,
                            StreamingCaptureMode = StreamingCaptureMode.Video
                        };

                        mediaCapture = new();
                        await mediaCapture.InitializeAsync(settings);

                        foreach (var sourceInfo in sourceGroup.SourceInfos)
                        {
                            if (((sourceInfo.MediaStreamType == MediaStreamType.VideoPreview) ||
                                 (sourceInfo.MediaStreamType == MediaStreamType.VideoRecord)) &&
                                (sourceInfo.SourceKind == MediaFrameSourceKind.Color) &&
                                (sourceInfo.IsShareable == true) && (sourceInfo.DeviceInformation.IsEnabled == true))
                            {
                                var colorFrameSource = mediaCapture.FrameSources[sourceInfo.Id];
                                var preferredFormat = colorFrameSource.SupportedFormats;
                                int ind = 0;
                                foreach (var pf in preferredFormat)
                                {
                                    CamSource n = new()
                                    {
                                        //MediaFrameFormat_ = sf,
                                        MediaFrameSourceGroup_ = sourceGroup,
                                        MediaFrameSourceInfo_ = sourceInfo,
                                        Height = pf.VideoFormat.Height,
                                        Width = pf.VideoFormat.Width,
                                        FPS = (uint)(Math.Round((double)pf.FrameRate.Numerator / pf.FrameRate.Denominator, 2)),
                                        Type_ = pf.Subtype,
                                        Name = sourceGroup.DisplayName,
                                        Index_ = ind
                                    };
                                    CamSource_.Add(n);
                                    ind++;
                                }

                            }
                        }
                        mediaCapture?.Dispose();
                        mediaCapture = null;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        ErrorInfo ei = new(sns.fontFamily);
                        ei.textBox1.Text = "The app was denied access to the camera.\r\nPlease allow access in Windows settings";
                        ei.ShowDialog();
                        return;
                    }
                    catch (Exception)
                    {

                    }
                }

                CamSource_ = CamSource.PrepareSmallList(CamSource_);


                foreach (var descriptor in CamSource_)
                {
                    string? cam = descriptor.Name;
                    string? cam2 = descriptor.Width.ToString();
                    string? cam3 = descriptor.Height.ToString();
                    string? cam4 = descriptor.FPS.ToString();
                    string? cam5 = descriptor.Type_;
                    if (cam != null)
                        comboBox1.Items.Add("[" + cam2 + "x" + cam3 + "x" + cam4 + " " + cam5 + "] " + cam);
                }
                comboBox1.SelectedIndex = 0;
                inited = true;
                await RunStream();
            }
            catch (Exception)
            {

            }

        }

        async private void WebCamQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  if (CurrentDevice != null) await CurrentDevice.StopAsync();
            try
            {
                await mediaFrameReader?.StopAsync();
                if (mediaFrameReader != null) mediaFrameReader.FrameArrived -= FrameWorker;
                mediaCapture?.Dispose();
                mediaCapture = null;
            }
            catch (Exception)
            {

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inited) ReRunStream(comboBox1.SelectedIndex);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Piriwallet;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Piriwallet = "Searching...";
            this.Close();
        }

        private static async Task<byte[]> EncodedBytes(SoftwareBitmap? soft, Guid encoderId)
        {
            byte[]? array = null;

            using (var ms = new InMemoryRandomAccessStream())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, ms);
                encoder.SetSoftwareBitmap(soft);

                try
                {
                    await encoder.FlushAsync();
                }
                catch (Exception) { return Array.Empty<byte>(); }

                array = new byte[ms.Size];
                await ms.ReadAsync(array.AsBuffer(), (uint)ms.Size, InputStreamOptions.None);
            }
            return array;
        }

        private void FrameWorker(MediaFrameReader sender, MediaFrameArrivedEventArgs args)
        {
            try
            {
                var mediaFrameReference = sender.TryAcquireLatestFrame();
                var videoMediaFrame = mediaFrameReference?.VideoMediaFrame;
                var softwareBitmap = videoMediaFrame?.SoftwareBitmap;

                if (softwareBitmap != null)
                {
                    //if (softwareBitmap.BitmapPixelFormat != Windows.Graphics.Imaging.BitmapPixelFormat.Bgra8 ||
                    //    softwareBitmap.BitmapAlphaMode != Windows.Graphics.Imaging.BitmapAlphaMode.Premultiplied)
                    //{
                    //    softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                    //}

                    // Swap the processed frame to _backBuffer and dispose of the unused image.
                    softwareBitmap = Interlocked.Exchange(ref backBuffer, softwareBitmap);
                    softwareBitmap?.Dispose();

                    pictureBox1.Invoke((MethodInvoker)async delegate
                    {
                        try
                        {
                            if (taskRunning)
                            {
                                return;
                            }
                            taskRunning = true;

                            // Keep draining frames from the backbuffer until the backbuffer is empty.
                            SoftwareBitmap? latestBitmap;
                            while ((latestBitmap = Interlocked.Exchange(ref backBuffer, null)) != null)
                            {
                                byte[] data = await EncodedBytes(latestBitmap, BitmapEncoder.BmpEncoderId);
                                if (data.Length > 0)
                                {
                                    MemoryStream ms = new(data, 0, data.Length);
                                    var bitmap = Image.FromStream(ms);
                                    pictureBox1.Image = bitmap;
                                    TestQRCode(ms);
                                    ms.Close();
                                }
                                latestBitmap.Dispose();
                            }

                            taskRunning = false;
                        }
                        catch (Exception) { }
                    });

                }

                mediaFrameReference?.Dispose();
            }
            catch (Exception) { }
        }

    }

    public class CamSource
    {
        public MediaFrameSourceGroup? MediaFrameSourceGroup_ { get; set; }
        public MediaFrameSourceInfo? MediaFrameSourceInfo_ { get; set; }
        public MediaFrameFormat? MediaFrameFormat_ { get; set; }
        public string? Name { get; set; }
        public uint Height { get; set; }
        public uint Width { get; set; }
        public uint FPS { get; set; }
        public string? Type_ { get; set; }
        public int Index_ { get; set; }



        static public bool CheckExist(List<CamSource> cs_, CamSource in_)
        {
            bool result = false;

            foreach (CamSource incs in cs_)
            {
                if ((incs.Name == in_.Name) && (incs.Type_ == in_.Type_) && (incs.FPS == in_.FPS))
                {
                    if (incs.Width >= in_.Width)
                    {
                        result = true;
                    }
                }
                else
                {
                    ;
                }
            }

            return result;

        }
        static public List<CamSource> PrepareSmallList(List<CamSource> cs_)
        {
            List<CamSource> result = new();

            while (true)
            {
                int rind = 0;

                CamSource max = cs_[0];

                int rind2 = 0;
                foreach (CamSource incs2 in cs_)
                {
                    if ((incs2.Name == max.Name) && (incs2.FPS == max.FPS) && (incs2.Type_ == max.Type_) && (incs2.Width > max.Width))
                    {
                        rind = rind2;
                        max = incs2;
                    }
                    rind2++;
                }

                if (!CheckExist(result, max))
                {
                    result.Add(max);
                }
                cs_.RemoveAt(rind);
                if (cs_.Count == 0) break;
            }

            return result;
        }
    }
}
