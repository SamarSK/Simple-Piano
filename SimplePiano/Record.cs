using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using NAudio.Wave;

namespace SimplePiano
{
    public class Record
    {
        private readonly MainForm Main;

        private string OutputFileName;
        private WaveFileWriter RecordedAudioWriter = null;
        private WasapiLoopbackCapture SoundCapture = null;

        public Record(MainForm main)
        {
            Main = main;
        }

        /// <summary>
        /// Starts recording.
        /// </summary>
        public void Start()
        {
            // show dialog window
            var dialog = new SaveFileDialog();
            dialog.Filter = "Wave files | *.wav";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // get name of output file
            OutputFileName = dialog.FileName;

            SoundCapture = new WasapiLoopbackCapture();
            RecordedAudioWriter = new WaveFileWriter(OutputFileName, SoundCapture.WaveFormat);

            // when the capture receives audio, start writing the buffer into the mentioned file
            SoundCapture.DataAvailable += (s, a) =>
            {
                RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
            };

            // when the capture Stops
            SoundCapture.RecordingStopped += (s, a) =>
            {
                RecordedAudioWriter.Dispose();
                RecordedAudioWriter = null;
                SoundCapture.Dispose();
            };

            Main.StartRecord.Enabled = false;
            Main.StopRecord.Enabled = true;

            SoundCapture.StartRecording();
        }

        public void CancelRecordMode()
        {
            if (Main.StopRecord.Enabled)
            {
                SoundCapture.StopRecording();

                Main.StartRecord.Enabled = true;
                Main.StopRecord.Enabled = false;
                // open the directory where the output was stored
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Path.GetDirectoryName(OutputFileName),
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);
            }
            Main.StartRecord.Enabled = true;
        }

        /// <summary>
        /// Stops recording.
        /// </summary>
        public void Stop()
        {
            CancelRecordMode();
        }
    }
}
