using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;

namespace SimplePiano
{
    public class PianoKey
    {
        private readonly MainForm Main;
        public readonly PictureBox Box;
        private readonly string Tone;
        private const int BlickDelay = 150; //in milliseconds
        private bool PressedOnce = true;
        public int Sound;
        private readonly Color Color;

        /// <summary>
        /// The class that represents one key on the piano.
        /// </summary>
        /// <param name="box">Corresponding picture box.</param>
        /// <param name="tone">Use one of the following strings: "c, cis, d, dis, e, f, fis, g, gis, a, ais, b, c2, cis2, ..., c3".</param>
        /// <param name="color">Use Color.White for "c, d, e, f, g, a, b" and Color.Black for "cis, dis, fis, gis, ais" tones.</param>
        public PianoKey(PictureBox box, string tone, Color color, MainForm main)
        {
            Main = main;
            Box = box;
            Tone = tone;
            Color = color;
            SetInstrument("Piano");
        }

        /// <summary>
        /// Sets the musical instrument.
        /// </summary>
        /// <param name="instrument"> Use one of the following strings: "Piano, Organ, Trumpet, Guitar, Violin".</param>
        public void SetInstrument(string instrument)
        {
            string path = @"Tones\" + instrument + @"\" + Tone + ".wav";
            Sound = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_DEFAULT);
            if (Sound == 0)
            {
                // File on path does not exist
                ExceptionHandlers exception = new ExceptionHandlers();
                exception.NotFound(path);
                System.Environment.Exit(1);
            }          
        }

        /// <summary>
        /// Plays the corresponding sound.
        /// Can be played again only after Release() method is called.
        /// </summary>
        public void Play()
        {
            if (PressedOnce)
            {
                Blick();
                Bass.BASS_ChannelPlay(Sound, true);
                PressedOnce = false;
            }
        }

        /// <summary>
        /// Allow the sound to be played again.
        /// </summary>
        public void Release()
        {
            PressedOnce = true;
        }

        /// <summary>
        /// Play the corresponding sound and call Release() method automatically after.
        /// </summary>
        public void PlayOnce()
        {
            Play();
            Release();
        }

        /// <summary>
        /// Perform the animation of piano key being pressed.
        /// </summary>
        private async void Blick()
        {
            Box.BringToFront();
            Box.BackColor = Color.Red;
            await Task.Delay(BlickDelay);

            Box.BackColor = Color;
            Box.SendToBack();
            if (Color == Color.Black)
            {
                Main.SendAllWhiteToBack();
            }
        }
    }
}
