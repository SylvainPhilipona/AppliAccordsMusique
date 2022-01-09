using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;
using System.IO;
using System.Linq;

namespace AppliAccordsMusique
{
    public partial class ChordsTrain : Form
    {
        //Constants
        private int DEFAULT_TICK_SPEED = 1; //In seconds

        //Variables
        private Timer timer;
        private bool isStarted = false;
        private int tickSpeed; //In seconds

        private Dictionary<string, List<string>> chords = new Dictionary<string, List<string>>();
        private List<string> selectedChords;
        private List<int> timers = new List<int>()
        {
            1, 2, 3, 5, 7, 10, 15, 20
        };


        public ChordsTrain()
        {
            InitializeComponent();

            //Put timers in the combobox
            foreach (int i in timers)
            {
                cboTimer.Items.Add($"{i} sec");
            }
            //Select a default timer
            cboTimer.SelectedItem = $"{DEFAULT_TICK_SPEED} sec";

            //Add a chord
            //AddChords("test", new List<string> { "qwd", "ewf"});

            //Go trough all chords
            foreach (Chord chord in ChordsJSON.GetChords())
            {
                //Add the chords in the dictionnary
                chords.Add(chord.title, chord.chords);

                //Add the chord in the combobox
                cboChords.Items.Add(chord.title);
            }

            //Set the default chords selected
            cboChords.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                isStarted = true;
                btnStart.Text = "Stop";
                cboChords.Enabled = false;
                cboTimer.Enabled = false;

                //Start the timer
                timer = new Timer();
                timer.Interval = tickSpeed * 1000; //*1000 because the interval is in miliseconds
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Start();

                //Force the first tick
                Timer_Tick(null, null);
            }
            else
            {
                //Reset
                isStarted = false;
                btnStart.Text = "Start";
                cboChords.Enabled = true;
                cboTimer.Enabled = true;
                timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Generate a random chord
            string rndCHord = selectedChords[new Random().Next(0, selectedChords.Count)];

            //Set the font size
            lblChord.Font = new Font("Consolas", (float)250/rndCHord.Length, FontStyle.Regular);

            //Display the chord
            lblChord.Text = rndCHord;
        }

        private void cboTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the tick speed value
            tickSpeed = Int32.Parse(Regex.Match(cboTimer.SelectedItem.ToString(), @"\d+").Value);
        }

        private void cboChords_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the chords selected
            selectedChords = chords[cboChords.SelectedItem.ToString()];
        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            NewChordList newChordList = new NewChordList();
            newChordList.ShowDialog();
        }
    }
}
