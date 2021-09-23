using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Un4seen.Bass;

namespace SimplePiano
{
    public partial class MainForm : Form
    {
        Record Recorder;
        SongPlayer Player;
        private readonly Dictionary<Keys, PianoKey> KeyboardToPianoKeyDict = new Dictionary<Keys, PianoKey>();
        //key = key on the keyboard
        //value = corresponding PianoKey class

        public readonly Dictionary<string, PianoKey> PianoDict = new Dictionary<string, PianoKey>();
        //key = tone,
        //value = corresponding PianoKey class

        PianoKey C, Cis, D, Dis, E, F, Fis, G, Gis, A, Ais, B,
                 C2, Cis2, D2, Dis2, E2, F2, Fis2, G2, Gis2, A2,
                 Ais2, B2, C3;

        public MainForm()
        {
            InitializeComponent();
            InitKeys();
            InitPianoDict();
            InitKeyboardToPianoKeyDict();
        }
        /// <summary>
        /// An auxiliary method to perform animation of a key being pressed
        /// </summary>
        public void SendAllWhiteToBack()
        {
            CBox.SendToBack();
            DBox.SendToBack();
            EBox.SendToBack();
            FBox.SendToBack();
            GBox.SendToBack();
            ABox.SendToBack();
            BBox.SendToBack();
            C2Box.SendToBack();
            D2Box.SendToBack();
            E2Box.SendToBack();
            F2Box.SendToBack();
            G2Box.SendToBack();
            A2Box.SendToBack();
            B2Box.SendToBack();
            C3Box.SendToBack();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Recorder is object)
            {
                Recorder.CancelRecordMode();
            }
        }

        private void Mouse_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, PianoKey> pair in PianoDict)
            {
                if (pair.Value.Box == (Control)sender)
                {
                    pair.Value.PlayOnce();
                    return;
                }
            }
        }


        #region Key press handlers
        /// <summary>
        /// Release tone that corresponds to the key on the keyboard
        /// </summary>       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (KeyValuePair<Keys, PianoKey> pair in KeyboardToPianoKeyDict)
            {
                if (e.KeyCode == pair.Key)
                {
                    pair.Value.Release();
                }
            }
        }

        /// <summary>
        /// Play tone that corresponds to the key on the keyboard
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (PlayButton.Enabled)
            {
                foreach (KeyValuePair<Keys, PianoKey> pair in KeyboardToPianoKeyDict)
                {
                    if (e.KeyCode == pair.Key)
                    {
                        pair.Value.Play();
                    }
                }
            }
        }
        #endregion

        #region Tones and Keys show handlers
        public bool TonesVisible()
        {
            return toneC.Visible;
        }
        public bool KeysVisible()
        {
            return keyW.Visible;
        }
        public void ShowKeys()
        {
            foreach (Control current in Controls)
            {
                if (current is Label && current.AccessibleName == "keys")
                {
                    current.Visible = true;
                }
            }
        }
        public void HideKeys()
        {
            foreach (Control current in Controls)
            {
                if (current is Label && current.AccessibleName == "keys")
                {
                    current.Visible = false;
                }
            }
        }
        public void ShowTones()
        {
            foreach (Control current in Controls)
            {
                if (current is Label && current.AccessibleName == "tones")
                {
                    current.Visible = true;
                }
            }
        }
        public void HideTones()
        {
            foreach (Control current in Controls)
            {
                if (current is Label && current.AccessibleName == "tones")
                {
                    current.Visible = false;
                }
            }
        }
        #endregion

        #region Button handlers

        /// <summary>
        /// Show/Hide help box
        /// </summary>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpBox.Visible = !HelpBox.Visible;
            if (HelpBox.Visible)
            {
                HelpButton.Text = "Hide Help";
            }
            else
            {
                HelpButton.Text = "Show Help";
            }
        }

        /// <summary>
        /// Play the selected song
        /// </summary>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            string path = @"Songs\" + SongList.SelectedItem;
            Player = new SongPlayer(path, this);
            Player.PlaySong();
        }

        /// <summary>
        /// Stop the currently playing song
        /// </summary>
        private void StopButton_Click(object sender, EventArgs e)
        {
            Player.StopSong();
        }

        private void StopRecord_Click(object sender, EventArgs e)
        {
            Recorder.Stop();
        }

        private void StartRecord_Click(object sender, EventArgs e)
        {
            Recorder = new Record(this);
            Recorder.Start();
        }

        /// <summary>
        /// Start new Options window
        /// </summary>
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            using Options OptionsForm = new Options(this);
            OptionsForm.SetCheckboxes();
            OptionsForm.ShowDialog();
        }
        #endregion

        #region Initialization methods
        private void InitPianoDict()
        {
            PianoDict.Add("c", C);
            PianoDict.Add("cis", Cis);
            PianoDict.Add("d", D);
            PianoDict.Add("dis", Dis);
            PianoDict.Add("e", E);
            PianoDict.Add("f", F);
            PianoDict.Add("fis", Fis);
            PianoDict.Add("g", G);
            PianoDict.Add("gis", Gis);
            PianoDict.Add("a", A);
            PianoDict.Add("ais", Ais);
            PianoDict.Add("b", B);
            PianoDict.Add("c2", C2);
            PianoDict.Add("cis2", Cis2);
            PianoDict.Add("d2", D2);
            PianoDict.Add("dis2", Dis2);
            PianoDict.Add("e2", E2);
            PianoDict.Add("f2", F2);
            PianoDict.Add("fis2", Fis2);
            PianoDict.Add("g2", G2);
            PianoDict.Add("gis2", Gis2);
            PianoDict.Add("a2", A2);
            PianoDict.Add("ais2", Ais2);
            PianoDict.Add("b2", B2);
            PianoDict.Add("c3", C3);
        }

        private void InitKeyboardToPianoKeyDict()
        {
            KeyboardToPianoKeyDict.Add(Keys.W, C);
            KeyboardToPianoKeyDict.Add(Keys.D3, Cis);
            KeyboardToPianoKeyDict.Add(Keys.E, D);
            KeyboardToPianoKeyDict.Add(Keys.D4, Dis);
            KeyboardToPianoKeyDict.Add(Keys.R, E);
            KeyboardToPianoKeyDict.Add(Keys.T, F);
            KeyboardToPianoKeyDict.Add(Keys.D6, Fis);
            KeyboardToPianoKeyDict.Add(Keys.Y, G);
            KeyboardToPianoKeyDict.Add(Keys.D7, Gis);
            KeyboardToPianoKeyDict.Add(Keys.U, A);
            KeyboardToPianoKeyDict.Add(Keys.D8, Ais);
            KeyboardToPianoKeyDict.Add(Keys.I, B);
            KeyboardToPianoKeyDict.Add(Keys.Z, C2);
            KeyboardToPianoKeyDict.Add(Keys.S, Cis2);
            KeyboardToPianoKeyDict.Add(Keys.X, D2);
            KeyboardToPianoKeyDict.Add(Keys.D, Dis2);
            KeyboardToPianoKeyDict.Add(Keys.C, E2);
            KeyboardToPianoKeyDict.Add(Keys.V, F2);
            KeyboardToPianoKeyDict.Add(Keys.G, Fis2);
            KeyboardToPianoKeyDict.Add(Keys.B, G2);
            KeyboardToPianoKeyDict.Add(Keys.H, Gis2);
            KeyboardToPianoKeyDict.Add(Keys.N, A2);
            KeyboardToPianoKeyDict.Add(Keys.J, Ais2);
            KeyboardToPianoKeyDict.Add(Keys.M, B2);
            KeyboardToPianoKeyDict.Add(Keys.Oemcomma, C3);
        }

        /// <summary>
        /// Initialize variables for each piano key
        /// </summary>
        private void InitKeys()
        {
            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
            {
                C = new PianoKey(CBox, "c", Color.White, this);
                Cis = new PianoKey(CisBox, "cis", Color.Black, this);
                D = new PianoKey(DBox, "d", Color.White, this);
                Dis = new PianoKey(DisBox, "dis", Color.Black, this);
                E = new PianoKey(EBox, "e", Color.White, this);
                F = new PianoKey(FBox, "f", Color.White, this);
                Fis = new PianoKey(FisBox, "fis", Color.Black, this);
                G = new PianoKey(GBox, "g", Color.White, this);
                Gis = new PianoKey(GisBox, "gis", Color.Black, this);
                A = new PianoKey(ABox, "a", Color.White, this);
                Ais = new PianoKey(AisBox, "ais", Color.Black, this);
                B = new PianoKey(BBox, "b", Color.White, this);

                C2 = new PianoKey(C2Box, "c2", Color.White, this);
                Cis2 = new PianoKey(Cis2Box, "cis2", Color.Black, this);
                D2 = new PianoKey(D2Box, "d2", Color.White, this);
                Dis2 = new PianoKey(Dis2Box, "dis2", Color.Black, this);
                E2 = new PianoKey(E2Box, "e2", Color.White, this);
                F2 = new PianoKey(F2Box, "f2", Color.White, this);
                Fis2 = new PianoKey(Fis2Box, "fis2", Color.Black, this);
                G2 = new PianoKey(G2Box, "g2", Color.White, this);
                Gis2 = new PianoKey(Gis2Box, "gis2", Color.Black, this);
                A2 = new PianoKey(A2Box, "a2", Color.White, this);
                Ais2 = new PianoKey(Ais2Box, "ais2", Color.Black, this);
                B2 = new PianoKey(B2Box, "b2", Color.White, this);

                C3 = new PianoKey(C3Box, "c3", Color.White, this);
            }
        }
        #endregion
    }
}
