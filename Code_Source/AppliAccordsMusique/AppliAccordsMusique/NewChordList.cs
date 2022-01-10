using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AppliAccordsMusique
{
    public partial class NewChordList : Form
    {
        //Constants

        private const int MAX_CHORD_INPUTS = 25;
        private const int MIN_CHORDS_IN_LIST = 2;

        //Variables

        private int nbInputs = 0;
        private int lastYpos = 1;
        private List<TextBox> inputsChords = new List<TextBox>();

        public NewChordList()
        {
            InitializeComponent();

            //Add the default chord
            btnAddChord_Click(null, null);
        }

        private void btnAddChord_Click(object sender, EventArgs e)
        {
            //Check if the max nuber of inputs isn't reach
            if(nbInputs < MAX_CHORD_INPUTS)
            {
                //And display the input
                TextBox inputChord = NewChordInput(lastYpos);
                inputsChords.Add(inputChord);
                panContainer.Controls.Add(inputChord);

                lastYpos += inputChord.Height + 1;
                nbInputs++;
            }
            else
            {
                MessageBox.Show(nbInputs.ToString());
            }
            
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            //Check if the name isn't empty
            if(tbListName.Text != "")
            {
                //Check if the name already exists
                if (ChordsJSON.ChordsExists(tbListName.Text))
                {
                    MessageBox.Show($"Le nom de liste \"{tbListName.Text}\" existe déja. Veuillez en choisir un autre !");

                    //Set the focus and select the text of the title input
                    tbListName.Select();
                    tbListName.SelectAll();
                }
                else
                {
                    //Create the chords list
                    Chord chords = new Chord(tbListName.Text, new List<string>());

                    //Go trough all inputs chords
                    foreach (TextBox inputChord in inputsChords)
                    {
                        //Check if the chord isn't empty
                        if (inputChord.Text != "")
                        {
                            //Add the chord
                            chords.chords.Add(inputChord.Text);
                        }
                    }

                    //Check if the list contains at least 1 chord
                    if (chords.chords.Count >= MIN_CHORDS_IN_LIST)
                    {
                        //Add the chords list
                        ChordsJSON.AddChords(chords.title, chords.chords);

                        //Close the windows
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show($"Vous devez ajouter au moins {MIN_CHORDS_IN_LIST} accords à votre liste !");

                        //Set the focus on the add input button
                        btnAddChord.Select();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vous devez donner un nom à votre liste !");

                //Set the focus on the title input
                tbListName.Select();
            }
        }

        private TextBox NewChordInput(int yPos)
        {
            //Create a textbox and set this propreties
            TextBox inputChord = new TextBox();
            inputChord.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            inputChord.Location = new Point(12, yPos);
            inputChord.Size = new Size(220, 26);
            inputChord.TabIndex = 0;
            inputChord.Text = "";
            inputChord.TextAlign = HorizontalAlignment.Center;

            return inputChord;
        }

        
    }
}
