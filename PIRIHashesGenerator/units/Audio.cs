using NAudio.CoreAudioApi;
using NAudio.Wave;


namespace PIRIHashesGenerator.units
{
    static class Audio
    {
        static readonly IWavePlayer waveOutDevice = new WaveOut();
        static AudioFileReader? audioFileReader;

        static void OnPlaybackStopped(object? sender, NAudio.Wave.StoppedEventArgs args)
        {
            try
            {
                waveOutDevice.Stop();
                audioFileReader?.Dispose();
            }
            catch (Exception)
            {

            }
        }

        static public void PlaySound(int num, int volume)
        {
            try
            {
                string? workdir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (workdir != null) audioFileReader = new AudioFileReader(Path.Combine(workdir, "sounds\\s" + num.ToString() + ".wav"));
                if (audioFileReader != null)
                {
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Volume = (volume * 10) / 100.0f;
                    waveOutDevice.PlaybackStopped += OnPlaybackStopped;
                    waveOutDevice.Play();
                }
            }
            catch (Exception)
            {

            }
        }
        static public void SetVolume(int volume)
        {
            MMDeviceEnumerator enumerator = new();
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            foreach (MMDevice item in devices)
            {
                AudioSessionManager sessionManager = item.AudioSessionManager;
                SessionCollection sessionCollection = sessionManager.Sessions;
                for (int i = 0; i < sessionCollection.Count; i++)
                {
                    AudioSessionControl sessionCntrl = sessionCollection[i];
                    uint pID = sessionCntrl.GetProcessID;
                    if (pID == Environment.ProcessId)
                    {
                        SimpleAudioVolume audioVolume = sessionCntrl.SimpleAudioVolume;
                        audioVolume.Volume = volume / 100.0f;
                    }
                }
            }
        }
    }
}
