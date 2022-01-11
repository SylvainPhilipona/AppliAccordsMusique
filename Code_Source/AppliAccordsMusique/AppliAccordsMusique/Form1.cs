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

            //Get and display all chords
            GetAndDisplayChords();

            //If the combobox contains at least 1 item
            if (cboChords.Items.Count > 0)
            {
                //Set the default chords selected
                cboChords.SelectedIndex = 0;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                isStarted = true;
                btnStart.Text = "Stop";
                btnNewList.Enabled = false;
                btnDeleteList.Enabled = false;
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
                btnNewList.Enabled = true;
                btnDeleteList.Enabled = true;
                cboChords.Enabled = true;
                cboTimer.Enabled = true;
                timer.Stop();
            }
        }

        private void GetAndDisplayChords()
        {
            //Reset
            chords = new Dictionary<string, List<string>>();
            cboChords.Items.Clear();
            cboChords.ResetText();

            //Go trough all chords
            foreach (Chord chord in ChordsJSON.GetChords())
            {
                //Add the chords in the dictionnary
                chords.Add(chord.title, chord.chords);

                //Add the chord in the combobox
                cboChords.Items.Add(chord.title);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //If the combobox contains at least 1 item
            if (cboChords.Items.Count > 0)
            {
                //Generate a random chord
                string rndCHord = selectedChords[new Random().Next(0, selectedChords.Count)];

                //Set the font size
                lblChord.Font = new Font("Consolas", (float)250 / rndCHord.Length, FontStyle.Regular);

                //Display the chord
                lblChord.Text = rndCHord;
            }
        }

        private void cboTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the tick speed value
            tickSpeed = Int32.Parse(Regex.Match(cboTimer.SelectedItem.ToString(), @"\d+").Value);
        }

        private void cboChords_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////If the combobox contains at least 1 item
            ////if (cboChords.Items.Count > 0)
            ////{
            ////    //Set the chords selected
            ////    selectedChords = chords[cboChords.SelectedItem.ToString()];

            ////    //Enable the start button
            ////    btnStart.Enabled = true;
            ////}
            ////else
            ////{
            ////    selectedChords = null;

            ////    //Disable the start button
            ////    btnStart.Enabled = false;
            ////}
        }

        private void cboChords_TextChanged(object sender, EventArgs e)
        {
            //If the combobox contains at least 1 item
            if (cboChords.Items.Count > 0)
            {
                //Set the chords selected
                selectedChords = chords[cboChords.SelectedItem.ToString()];

                //Enable the start button
                btnStart.Enabled = true;
            }
        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            NewChordList newChordList = new NewChordList();
            newChordList.ShowDialog();
            GetAndDisplayChords();
            cboChords.SelectedIndex = cboChords.Items.Count - 1;
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            if(cboChords.Items.Count > 0)
            {
                string listToDelete = cboChords.SelectedItem.ToString();

                //Display the confirm popup
                DialogResult result = MessageBox.Show($"Voulez vraiment supprimer la liste {listToDelete} ?", $"Suppression de la liste {listToDelete}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //Validate the delete
                if (result == DialogResult.Yes)
                {
                    //Delete the list
                    ChordsJSON.RemoveChords(listToDelete);
                    GetAndDisplayChords();

                    //If the combobox don't contains at least 1 item
                    if (cboChords.Items.Count <= 0)
                    {
                        selectedChords = null;

                        //Disable the start button
                        btnStart.Enabled = false;
                    }
                    else
                    {
                        cboChords.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}
