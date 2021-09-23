# Simple Piano - Samuel Tomko

Program predstavuje simuláciu hry na klavíri. Umožňuje uživateľovi hrať na grafickom
klavíri stláčaním klávies na klávesnici, meniť hudobný nástroj, pustiť si prednastavené
pesničky, či nahrať svoju vlastnú pesničku a uložiť ju ako WAV súbor. Jedná sa o zápočtový program
z predmetu Programovanie 2 NPRG031, pre rok 2020/2021.

## Špecifikácia programu

### Pôvodná verzia

Program je vytvorený pomocou WinForms a jedná sa o desktopovú simuláciu hry na klavíri.

Po spustení programu sa otvorí interaktívne okno, na ktorom sú vykreslené klávesy
klavíra v rozsahu dvoch oktáv. Každá klávesa vydáva jej pridelený tón, ak na ňu uživateľ
klikne myšou, alebo ak stlačí na klávesnici príslušnú klávesu. Akonáhle sa klávesa aktivuje,
preblikne červenou farbou.

Ďalej je v okne niekoľko tlačidiel:
 
1. **Tlačidlo "Help"** po stlačení zobrazí podrobnú nápovedu, ako sa s programom zachádza.

2. **Tlačidlo "Options"** zobrazí okno, v ktorom sa dá nastaviť hlasitosť aplikácie,
zobrazenie nôt na klávesách a zvuk nástroja, aký má klavír vydávať (klavír, orgán, gitara, 
husle alebo trúbka).

3. **Tlačidlo "Play"** má pri sebe ComboBox, v ktorom sú názvy pesničiek:
"Happy Birthday", "Jingle Bells" a "Ode to Joy". Po stlačení "Play" sa práve 
vybraná pesnička automaticky zahrá.

4. **Tlačidlo "Stop"** zastaví prehrávanie aktuálnej pesničky.

5. **Tlačidlo "Edit Mode"** presunie aplikáciu do tkzv. "Edit módu", v ktorom bude môcť uživateľ nahrať
svoju vlastnú pesničku. 
Okno sa týmto tranformuje následovne:	

Tlačidla "Play" a "Stop" a ComboBox zmiznú. Tlačidlo "Edit Mode" bude nahradené tlačidlom "Exit Edit Mode".
Pribudnú tlačidlá "Record" a "Stop Recording". Po stlačení "Record" bude môcť uživateľ hrať
na klavíri a aplikácia bude túto hru zaznamenávať. Po stlačení "Stop Recording" sa nahrávanie preruší.
Po tomto sa zviditeľní tlačidlo "Export To Wav", ktoré uloží poslednú nahrávku na uživateľom zvolené miesto,
vo formáte .wav.

### Zmeny voči povôdnej verzii - detaily, v ktorých sa finálna verzia líši
"Edit Mode" je nahradený tlačidlom "Record Mode". Funkcia je rovnaká ako v pôvodnej špecifikácii, líši sa len v detailoch.
1. Tlačidlo otvorí nové okno, v ktorom sú 2 tlačidlá: "Start recording" a "Stop recording"
2. Po stlačení "Start recording" sa otvorí dialógové okno, pomocou ktorého uživateľ zvolí lokalitu, kam sa uloží nahrávka.
3. Po stlačení "Stop recording" (alebo po zavretí okna počas nahrávania) sa otvorí priečinok s nahrávkou.

## Uživateľská dokumentácia

Program funguje tak, ako bolo špecifikované vyššie.

Príslušné klávesy pre jednotlivé tóny sú v tomto poradí (zľava doprava):
W, 3, E, 4, R, T, 6, Y, 7, U, 8, I,
Z, S, X, D, C, V, G, B, H, N, J, M, ","

V pravej hornej časti okna je tlačidlo **"Show Help"**, ktoré zobrazí v dolnej časti okna
nápovedu, ako pracovať s programom. Opätovným stlačením táto nápoveda zmizne.

V ľavej časti okna sa nachádza combobox, v ktorom si uživateľ môže vybrať jednú z troch
prednastavených pesničiek. Práve vybranú pesničku môže spustiť stlačením tlačidla "Play"
a zastaviť ju tlačidlom **"Stop"**. Ak uživateľ stlačí **"Stop"**, pesnička sa "resetuje" a pri
ďalšom stlačení **"Play"** sa začne hrať od začiatku.

V pravej časti okna sú tlačidlá **"Options"** a **"Record Mode"**.

Po stlačení **"Options"** sa otvorí nové okno, kde uživateľ môže nastaviť niekoľko vecí.

1. Potiahnutím kurzora **"Volume"** sa zmení hlasitosť aplikácie (zľava doprava sa zvyšuje).

2. Kliknutím na combobox možno zvoliť iný zvuk pre klavír, na výber má uživateľ z 5 nástrojov.
Po výbere nástroja je nutné stlačiť tlačidlo **"Set Instrument"**. Zmena sa zaznamená akonáhle
tlačidlo **"Set Instrument"** zmení stav.

3. V okne je taktiež možné zaškrtnúť 2 checkboxy, a tým na klavíri zobraziť príslušné tóny
klávies, alebo príslušné klávesy na klávesnici.

Po stlačení **"Record Mode"** sa otvorí okno s dvoma tlačidlami. 
Toto okno slúži na nahranie zvuku z počítača do súboru vo WAV formáte.

1. Po stlačení **"Start Recording"** sa otvorí dialógové okno, vďaka ktorému môže uživateľ zvoliť
miesto v počítači, kam chce svoju nahrávku uložiť.
Od tohto momentu sa zaznamenáva všetok systémový zvuk počítača, teda aj hra na klavíri.

2. Stlačením **"Stop Recording"** sa nahrávanie zastaví a automaticky sa otvorí priečinok, v ktorom
sa nahrávka nachádza.

## Programátorská dokumentácia

### Použité knižnice

V programe sú použité 2 knižnice na prácu o zvukom: NAudio a BASS, oboje s freeware licenciou, ak sa nejedná o profitový projekt.
http://www.un4seen.com/   a    https://github.com/naudio/NAudio

### Súbory potrebné na chod programu

Nasledujúce súbory sa nachádzajú v priečinku SimplePiano\bin\Debug:
1. V priečinku "Tones" sa nachádza 5 podpriečinkov pre každý hudobný nástroj. V každom podpriečinku je 25 WAV súborov, každý odpovedá jednému tónu pre 
daný nástroj. Tieto súbory sa pri štarte programu načítajú do pamäti a ďalej sa s nimi pracuje. Zmena názvov súborov ako aj priečinkov vyústi v 
nefunkčnosť programu.

2. V priečinku "Songs" sú 3 TXT súbory obsahujúce návod, ako zahrať konkrétnu pieseň. Sú read-only a na každom riadku je jeden tón, ktorý má program
zahrať, spolu s dĺžkou ako dlho má trvať (v milisekundách). Prázdne riadky sú ignorované.

3. Súbor bass.dll je potrebný pre správne skompilovanie programu, keďže obsahuje spomínanú knižnicu.

### Trieda PianoKey

Trieda reprezentuje jednu klávesu klavíra. Pri inicializácii je potrebné jej zadať tón vo forme stringu, PictureBox a farbu (čiernu ak ide
o poltón, bielu inak).

Konštanta BlickDelay - v milisekundách vyjadruje ako rýchlo má klávesa prebliknúť.

Premenné:
1. PictureBox, string tónu a Color
2. PressedOnce - pomocný bool pre Play metodu
3. Sound - integerová reprezentácia zvuku, z knižnice BASS

Metody:
1. **SetInstrument** - dostane stringový parameter, ktorý musí byť rovnaký, ako je názov podpriečinku, ktorý obsahuje tóny vo formáte WAV.
Na základe stringu zmení zvuk tónu.
2. **Play** - zahrá aktuálne nastavený zvuk
3. **Release** - umožní opätovné zavolanie metody Play. Toto je tu preto, aby sa nespúšťal stále ten istý tón, ak uživateľ drží stlačenú jednu klávesu.
4. **PlayOnce** - zavolá Play a potom release.
5. **Blick** - prevedie animáciu stlačenia klávesy. 


### Trieda MainForm

Trieda reprezentuje hlavné okno, ktoré sa spustí ako prvé. Jej metody sú rozčlenené do regiónov podľa logických súvislostí.

1. **Metody pre výnimky**
2. **Metody na zmenu zvuku**
3. **Metody pre stlačenie/pustenie klávesy na klávesnici**
4. **Metody na zobrazenie príslušných tónov a kláves**
5. **Metody pre kliknutie na klávesu** - jednoduchá funkcia, pri kliknutí na klávesu sa zahrá príslušný tón.
6. **Metody pre tlačidlá** - priamočiaré metody, až na **PlayButton_Click** metódu:
Táto obsahuje jednoduchý algoritmus, ktorý prečíta jeden zo spomínaných TXT súborov. Číta ho riadok po riadku, zhora dolu a podľa obsahu
riadku zahrá príslušný tón. Metoda je async, keďže využíva "await", aby takto simulovala dĺžku tónu  v milisekundách.
7. **Inicializačné metody** - volajú sa z konštruktoru triedy. Inicializujú premenné pre klávesy a taktiež slovník, ktorý tieto premenné
obsahuje a priraďuje im stringové kľúče, ktoré odpovedajú názvom WAV súborov príslušných tónov.

Ďalej metoda **MainForm_FormClosing** ošetrí prípad, kedy nahrávanie beží a uživateľ sa rozhodne zatvoriť aplikáciu bez zastavenia nahrávania.
Metoda **SendAllWhiteToBack** pošle všetky biele klávesy dozadu - využitie pri animácii "bliknutia klávesy".

### Trieda Options

Reprezentácia okna "Options". Metody tejto triedy volajú metody triedy MainForm.

### Trieda RecordMode

Reprezentácia okna "Record Mode". Využíva knižnicu NAudio na zachytenie systémového zvuku.
Využíva 2 triedy z tejto knižnice: WaveFileWriter a WasapiLoopbackCapture
Metody:
1. **StartRecord_Click** - inicializuje tieto 2 triedy - Capture zachytáva systémové audio a writer ho potom zapisuje do WAV súboru.
Obsahuje 2 jednoduché lambda funkcie, ktoré zabezpečia zápis zvuku z bufferu do súboru a nakoniec začne samotné nahrávanie.
2. **CancelRecording** - zastaví nahrávanie (a zobrazí priečinok, kam sa súbor nahral). Táto funkcia je volaná, ak uživateľ stlačí
Stop Recoring tlačidlo, zavrie Record Mode okno alebo zavrie aplikáciu. 

## Poznámka

Všetky zvuky pre klavír sú získané z aplikácie MuseScore 3, ktorá je freeware a dovoľuje používať jej zvukové nahrávky bez nutnosti kúpy licenie.

# Update po konzultácii

1. Metódy Form1_KeyDown, Form1_KeyUp a Mouse event handlery boli zjednodušené a zobecnené
2. Pribudla trieda **SongPlayer**, v ktorej sa nachádzajú pôvodné metódy PlayButton_Click a StopButton_Click
3. Pribudla trieda **SoundChanger**, v ktorej sa nachádzajú pôvodné metódy ChangeInstrument a ChangeVolume
4. Pribudla trieda **ExceptionHandlers**, v ktorej sa nachádzajú pôvodné metódy na riešenie výnimiek
5. Bola odstránená inštancia "Self" v triede MainForm, namiesto nej sa na MainForm predáva referencia tam, kde je to potrebné
6. Priečinky **Tones** a **Songs** sa už nenachádzajú v priečinku **bin**, ale pri builde sa tam prekopítujú

# Druhý update po konzultácii

1. Úprava názvov premenných a komentárov
2. Použitie "using" v triede SongPlayer, metóde PlaySong
3. Nahradil som Formu **RecordMode** triedou Record. Nahrávanie teraz funguje pomocou dvoch tlačidiel, ktoré sú súčasťou hlavného okna.
