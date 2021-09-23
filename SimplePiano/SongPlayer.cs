using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplePiano
{
    public class SongPlayer
    {
        private readonly string Path;
        private readonly MainForm Main;
        public SongPlayer(string path, MainForm main)
        {
            Path = path;
            Main = main;
        }

        public async void PlaySong()
        {

            try
            {
                using (StreamReader input = new StreamReader(Path))
                {
                    Main.StopButton.Enabled = true;
                    Main.PlayButton.Enabled = false;
                    Main.SongList.Enabled = false;

                    // Read lines from special .txt file
                    string line = input.ReadLine();
                    int linecount = 0;

                    // Play the song
                    while (line != null)
                    {
                        ++linecount;
                        if (!Main.StopButton.Enabled)
                        {
                            // stop playing
                            break;
                        }
                        if (line.Length == 0)
                        {
                            // skip empty line
                            line = input.ReadLine();
                            continue;
                        }

                        // get tone and it's length from line
                        string tone = line.Split()[0];
                        string duration = line.Split()[1];

                        // play the tone
                        try
                        {
                            Main.PianoDict[tone].PlayOnce();
                        }
                        catch (KeyNotFoundException)
                        {
                            ExceptionHandlers exception = new ExceptionHandlers();
                            exception.InvalidScript(linecount, Main.SongList.Text);
                            break;
                        }

                        // wait corresponding time and then repeat
                        int durationInt;
                        try
                        {
                            durationInt = int.Parse(duration);
                        }
                        catch (FormatException)
                        {
                            ExceptionHandlers exception = new ExceptionHandlers();
                            exception.InvalidScript(linecount, Main.SongList.Text);
                            break;
                        }
                        await Task.Delay(durationInt);

                        line = input.ReadLine();
                    }

                    Main.PlayButton.Enabled = true;
                    Main.SongList.Enabled = true;
                    Main.StopButton.Enabled = false;
                };
            }
            catch (DirectoryNotFoundException)
            {
                // Invalid path to song, raise error
                ExceptionHandlers exception = new ExceptionHandlers();
                exception.NotFound(Path);
                return;
            }     
        }

        public void StopSong()
        {
            Main.StopButton.Enabled = false;
        }

    }
}