using System.Collections.Generic;
using Un4seen.Bass;

namespace SimplePiano
{
	public class SoundChanger
	{
        private readonly MainForm Main;

        public SoundChanger(MainForm main)
		{
            Main = main;
		}
        public void ChangeInstrument(string instrument)
        {
            foreach (KeyValuePair<string, PianoKey> pair in Main.PianoDict)
            {
                pair.Value.SetInstrument(instrument);
            }
        }
        public void ChangeVolume(int volume)
        {
            float value = (float)volume / 100;
            foreach (KeyValuePair<string, PianoKey> pair in Main.PianoDict)
            {
                // for each tone change it's volume to new value
                Bass.BASS_ChannelSetAttribute(pair.Value.Sound, BASSAttribute.BASS_ATTRIB_VOL, value);
            }

        }
    }
}
