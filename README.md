# Simple Piano
 
The program is a simulation of a piano which allows you to play on one, to change
an instrument, to play 3 default songs and to record and save your own song as a WAV file.

## Specification of the program

The program was created using C# language - WinForms and is a desktop simulation of a piano.

After the start, an interactive window with piano keys shows up. The range of the tones
is two octaves. Every key produces corresponding tone when left-clicked on or when the user
presses the corresponding key on the keyboard. 

There are several buttons in the window:
 
1. **Button "Help"** when pressed, shows a guide how to work with the application.

2. **Button "Options"** shows a window in which the volume of the application, 
visibility of the notes on the piano keys and an instrument can be changed.
The user can change from 5 instruments - piano, organ, guitar, violin or trumpet.

3. **Button "Play"** is next to a ComboBox, in which there are names of the songs:
"Happy Birthday", "Jingle Bells" and "Ode to Joy". When "Play" is pressed the corresponding
song is automatically played.

4. **Button "Stop"** stops the song that is currently playing.

5. **Button "Start Recording"** opens a dialog window in which the user chooses the location where
a recording will be saved and starts recording. 

6. **Button "Stop Recording"** stops recording and opens a directory with the recorded audio.	

## Code documentation

### Used libraries 

The program uses 2 libraries which are freeware for non-profit use: NAudio and BASS
http://www.un4seen.com/   and    https://github.com/naudio/NAudio

### Files needed for the program to run correctly

1. In the "Tones" directory there are 5 subdirectories, each for one instrument. Each of those contains 25 WAV files, which correspond to the tones. 
Do not change the names of these files as it will break the program.

2. In the "Songs" directory there are 3 TXT files for each song that can be played automatically on the piano.
They are read-only and on each line there is a tone and length of the tone (in ms), separated by space.
Empty lines are ignored.

3. File bass.dll contains the BASS library.

### PianoKey class

The class represents one key of the piano. When initializing, it takes the name of tone (string), PictureBox and Color (white or black)
as parameters.

BlickDelay constant - in ms, says how fast should the key blick when pressed.

Variables:
1. PictureBox, string of the tone and a Color
2. PressedOnce - auxilliary bool for the Play method
3. Sound - integerated reprezentation of the sound, from BASS library

Methods:
1. **SetInstrument** - takes a string parameter which must be one of the following: "Piano", "Organ", "Guitar", "Violin" or "Trumpet"
The instrument is then changed accordingly.
2. **Play** - play the initiated sound
3. **Release** - makes it possible to call the Play method again. Called when the key on the keyboard is released.
4. **PlayOnce** - calls Play and then Release.
5. **Blick** - does the animation of key being pressed. 


### MainForm class

Represents the main window. Its methods are sorted to regions logically.

1. **Key press handlers**
2. **Tones and Keys show handlers**
3. **Button handlers**
4. **Initialization handlers** - called from the constructor of the class. Variables for piano keys and also dictionaries 
are initialized here.

Method **MainForm_FormClosing** is called when a recording is running and the application is closed without stopping the recording.

### Options class

Representation of the "Options" window. Methods of this class call methods of the MainForm class.

### ExceptionHandlers class

Contains two methods, each for one possible exception. 

Method **NotFound** is called when a file was not found.
Method **InvalidScript** is called when there was an error in **PlaySong** method in **SongPlayer** class.

### SongPlayer class

This class is used when the "Play" button is pressed. 

Method **PlaySong** reads one of the TXT files mentioned above and plays their content.
If the TXT file is in wrong format or if the file is missing, the excepiton is raised.

Method **StopSong** disables the Stop button, breaking the loop in the **PlaySong** method.

### SoundChanger class

This class manages the change of the sound's volume and instrument for each tone.

Method **ChangeInstrument** changes the instrument for each piano key.
Method **ChangeVolume** changes the volume for each piano key.

### Record class

Representation of the "Record Mode". Uses the NAudio library to catch the system sound.
Uses 2 classes from this library: WaveFileWriter and WasapiLoopbackCapture
Methods:
1. **StartRecord_Click** - inicializes these 2 classes - Capture captures system audio and writer writes it to WAV file.
Contains 2 simple lambda functions that ensure the sound from buffer to file is written and finally the recording starts.
2. **CancelRecording** - stops recording (and displays the directory where it was saved). This method is called when the user 
presses Stop Recoring button or closes the application. 

## Note

All of the sounds for the piano were recorded from the MuseScore 3 application. It is a freeware and allows the use of it's recordings without the need
of purchasing the license. 
https://musescore.org
