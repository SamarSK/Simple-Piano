using System;
using System.Windows.Forms;

namespace SimplePiano
{
    public partial class Options : Form
    {
        private readonly MainForm Main;

        public Options(MainForm main)
        {
            InitializeComponent();
            Volume.Maximum = 50;
            Main = main;
        }

        /// <summary>
        /// Ensure the checkboxes are checked/unchecked as desired
        /// </summary>
        public void SetCheckboxes()
        {
            if (Main.TonesVisible())
            {
                ShowTones.Checked = true;
            }

            if (Main.KeysVisible())
            {
                ShowKeys.Checked = true;
            }
        }

        /// <summary>
        /// Change to a selected instrument
        /// </summary>
        private void InsSetter_Click(object sender, EventArgs e)
        {
            SoundChanger changer = new SoundChanger(Main);
            if (Instruments.SelectedItem != null)
            {
                changer.ChangeInstrument(Instruments.SelectedItem.ToString());
            }
            InsSetter.Enabled = false;
        }

        /// <summary>
        /// Show/Hide keys 
        /// </summary>
        private void ShowKeys_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowKeys.Checked)
            {
                Main.ShowKeys();
            }
            else
            {
                Main.HideKeys();
            }
        }

        /// <summary>
        /// Show/Hide tones
        /// </summary>
        private void ShowTones_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowTones.Checked)
            {
                Main.ShowTones();
            }
            else
            {
                Main.HideTones();
            }
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            SoundChanger changer = new SoundChanger(Main);
            changer.ChangeVolume(Volume.Value);
        }

        /// <summary>
        /// Enable button for a change of instrument
        /// </summary>
        private void Instruments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsSetter.Enabled = true;
        }

    }
}
