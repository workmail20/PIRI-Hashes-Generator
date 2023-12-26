using NAudio.Wave;
using PIRIHashesGenerator.Properties;
using PIRIHashesGenerator.units;
using System.Windows.Forms;

namespace PIRIHashesGenerator
{
    public partial class Settings_ : Form
    {
        readonly IWavePlayer waveOutDevice = new WaveOut();
        AudioFileReader? audioFileReader;
        readonly SettingsAndSession SaS;
        bool formcreated = false;
        public Settings_(PIRIHashesGenerator generator)
        {
            InitializeComponent();

            var f = generator.SnS.fontFamily;
            groupBox1.Font = new Font(f, groupBox1.Font.SizeInPoints, groupBox1.Font.Style, GraphicsUnit.Point);
            textBox1.Font = new Font(f, textBox1.Font.SizeInPoints, textBox1.Font.Style, GraphicsUnit.Point);
            checkBox1.Font = new Font(f, checkBox1.Font.SizeInPoints, checkBox1.Font.Style, GraphicsUnit.Point);
            button2.Font = new Font(f, button2.Font.SizeInPoints, button2.Font.Style, GraphicsUnit.Point);
            button1.Font = new Font(f, button1.Font.SizeInPoints, button1.Font.Style, GraphicsUnit.Point);
            checkBox3.Font = new Font(f, checkBox3.Font.SizeInPoints, checkBox3.Font.Style, GraphicsUnit.Point);
            checkBox2.Font = new Font(f, checkBox2.Font.SizeInPoints, checkBox2.Font.Style, GraphicsUnit.Point);
            button3.Font = new Font(f, button3.Font.SizeInPoints, button3.Font.Style, GraphicsUnit.Point);
            label2.Font = new Font(f, label2.Font.SizeInPoints, label2.Font.Style, GraphicsUnit.Point);
            label1.Font = new Font(f, label1.Font.SizeInPoints, label1.Font.Style, GraphicsUnit.Point);
            trackBar1.Font = new Font(f, trackBar1.Font.SizeInPoints, trackBar1.Font.Style, GraphicsUnit.Point);
            checkBox4.Font = new Font(f, checkBox4.Font.SizeInPoints, checkBox4.Font.Style, GraphicsUnit.Point);
            label3.Font = new Font(f, label3.Font.SizeInPoints, label3.Font.Style, GraphicsUnit.Point);
            textBox2.Font = new Font(f, textBox2.Font.SizeInPoints, textBox2.Font.Style, GraphicsUnit.Point);
            button4.Font = new Font(f, button4.Font.SizeInPoints, button4.Font.Style, GraphicsUnit.Point);
            comboBox1.Font = new Font(f, comboBox1.Font.SizeInPoints, comboBox1.Font.Style, GraphicsUnit.Point);
            checkBox6.Font = new Font(f, checkBox6.Font.SizeInPoints, checkBox6.Font.Style, GraphicsUnit.Point);
            checkBox5.Font = new Font(f, checkBox5.Font.SizeInPoints, checkBox5.Font.Style, GraphicsUnit.Point);
            checkBox7.Font = new Font(f, checkBox7.Font.SizeInPoints, checkBox7.Font.Style, GraphicsUnit.Point);
            button26.Font = new Font(f, button26.Font.SizeInPoints, button26.Font.Style, GraphicsUnit.Point);



        SaS = generator.SnS;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string p = Path.Combine(SaS.lap, "PiriHashes_w20\\hashes");
            FileBrowserDialog fb = new(p, SaS);
            fb.ShowDialog();

            if (File.Exists(Path.Combine(p, fb.SelectedFile)))
            {
                textBox1.Text = Path.Combine(p, fb.SelectedFile);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox { Checked: true })
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button3.Enabled = true;
                label3.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = false;
                label3.Enabled = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox { Checked: true })
            {
                checkBox3.Enabled = true;
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox { Checked: true })
            {
                trackBar1.Enabled = true;
                comboBox1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
                comboBox1.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void Settings__Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            checkBox1.Checked = SaS.UserSettings["autoloadWallet"] != "-";

            if (checkBox1.Checked)
            {
                textBox1.Text = SaS.UserSettings["autoloadWallet"];
                textBox2.Text = SaS.UserSettings["autoloadPassword"];
            }
            checkBox2.Checked = SaS.UserSettings["taskbarNotification"] == "+";
            checkBox3.Checked = SaS.UserSettings["taskbarIncome"] == "+";
            checkBox4.Checked = SaS.UserSettings["incomeSound"] == "+";
            if (checkBox4.Checked)
            {
                trackBar1.Value = int.Parse(SaS.UserSettings["incomeSoundLevel"]);
                comboBox1.SelectedIndex = int.Parse(SaS.UserSettings["incomeSoundIndex"]);
            }
            checkBox5.Checked = SaS.UserSettings["minTotray"] == "+";
            checkBox6.Checked = SaS.UserSettings["closeTotray"] == "+";
            checkBox7.Checked = SaS.UserSettings["runMinimized"] == "+";

            formcreated = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaS.UserSettings["autoloadWallet"] = (checkBox1.Checked && (textBox1.Text.Length > 0)) ? textBox1.Text : "-";
            SaS.UserSettings["autoloadPassword"] = (checkBox1.Checked && (textBox2.Text.Length > 0)) ? textBox2.Text : "";
            SaS.UserSettings["taskbarNotification"] = checkBox2.Checked ? "+" : "-";
            SaS.UserSettings["taskbarIncome"] = checkBox3.Checked ? "+" : "-";
            SaS.UserSettings["incomeSound"] = checkBox4.Checked ? "+" : "-";
            SaS.UserSettings["incomeSoundLevel"] = (checkBox4.Checked) ? trackBar1.Value.ToString() : "-";
            SaS.UserSettings["incomeSoundIndex"] = (checkBox4.Checked) ? comboBox1.SelectedIndex.ToString() : "-";
            SaS.UserSettings["minTotray"] = (checkBox5.Checked) ? "+" : "-";
            SaS.UserSettings["closeTotray"] = (checkBox6.Checked) ? "+" : "-";
            SaS.UserSettings["runMinimized"] = (checkBox7.Checked) ? "+" : "-";
            SaS.UpdateSettings();

            this.Close();
        }

        private void OnPlaybackStopped(object? sender, NAudio.Wave.StoppedEventArgs args)
        {
            try
            {
                this.Invoke((Action)(() =>
                {
                    waveOutDevice.Stop();
                    audioFileReader?.Dispose();
                    comboBox1.Enabled = true;
                    button4.Enabled = true;
                }));
            }
            catch (Exception) { }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            try
            {
                string? workdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (workdir != null) audioFileReader = new AudioFileReader(Path.Combine(workdir, "sounds\\s" + (comboBox1.SelectedIndex + 1).ToString() + ".wav"));
                if (audioFileReader != null)
                {
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Volume = (trackBar1.Value * 10) / 100.0f;
                    waveOutDevice.PlaybackStopped += OnPlaybackStopped;
                    waveOutDevice.Play();
                    comboBox1.Enabled = false;
                    button4.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox { Checked: true })
            {
                checkBox7.Enabled = true;
            }
            else
            {
                checkBox7.Enabled = false;
            }
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                button26.BackgroundImage = Resources.eye1;
            }
            else
            {
                textBox2.PasswordChar = '*';
                button26.BackgroundImage = Resources.eye2;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formcreated == false) return;

            try
            {
                string? workdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (workdir != null) audioFileReader = new AudioFileReader(Path.Combine(workdir, "sounds\\s" + (comboBox1.SelectedIndex + 1).ToString() + ".wav"));
                if (audioFileReader != null)
                {
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Volume = (trackBar1.Value * 10) / 100.0f;
                    waveOutDevice.PlaybackStopped += OnPlaybackStopped;
                    waveOutDevice.Play();
                    comboBox1.Enabled = false;
                    button4.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
