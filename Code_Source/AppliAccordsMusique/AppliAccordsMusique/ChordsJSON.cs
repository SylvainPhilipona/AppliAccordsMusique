using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AppliAccordsMusique
{
    public static class ChordsJSON
    {
        //Propreties

        public static string JsonFileName { get; private set; } = "chords.json";
        public static string JsonFilePath { get; private set; } = Directory.GetCurrentDirectory();
        public static string JsonFileFullname { get; private set; } = $@"{JsonFilePath}\{JsonFileName}";

        //Variables

        private static List<Chord> defaultChords = new List<Chord>()
        {
            new Chord("Majeur", new List<string> { "C", "D", "E", "F", "G", "A", "B", "C#", "D#", "E#", "F#", "G#", "A#", "B#" }),
            new Chord("Mineur", new List<string> { "Cm", "Dm", "Em", "Fm", "Gm", "Am", "Bm", "C#m", "D#m", "E#m", "F#m", "G#m", "A#m", "B#m" }),
        };

        //Functions

        public static List<Chord> GetChords()
        {
            //Create the JSON file if it's dont exists
            CreateFileIfNotExists();

            //Return the JSON content as a list of chords
            return JsonConvert.DeserializeObject<List<Chord>>(File.ReadAllText(JsonFileFullname));
        }

        private static void CreateFileIfNotExists()
        {
            //Check if file dosen't exists, or is empty
            if (!File.Exists(JsonFileFullname) || File.ReadAllText(JsonFileFullname) == "")
            {
                //Convert the string to JSON
                var defaultsChordsJSON = JsonConvert.SerializeObject(defaultChords, Formatting.Indented);

                //Write in the file
                File.WriteAllText(JsonFileFullname, defaultsChordsJSON);
            }
        }

        public static bool ChordsExists(string title)
        {
            foreach(Chord chord in GetChords())
            {
                //If the title of the chord is equal to the title to check
                if(chord.title == title)
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddChords(string title, List<string> chords)
        {
            //Create the JSON file if it's dont exists
            CreateFileIfNotExists();

            //Get actual json content
            List<Chord> list = JsonConvert.DeserializeObject<List<Chord>>(File.ReadAllText(JsonFileFullname));

            //Add the new chords
            list.Add(new Chord(title, chords));

            //Convert the string to JSON
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

            //Write in the file
            File.WriteAllText(JsonFileFullname, convertedJson);
        }

        public static void RemoveChords(string title)
        {
            //Create the JSON file if it's dont exists
            CreateFileIfNotExists();

            //Get actual json content
            List<Chord> list = JsonConvert.DeserializeObject<List<Chord>>(File.ReadAllText(JsonFileFullname));

            //Go trough all the chords lists
            foreach(Chord chord in list.ToList())
            {
                //If the chord is to remove
                if(chord.title == title) 
                {
                    //Remove the chord
                    list.Remove(chord);
                }
            }

            //Convert the string to JSON
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

            //Write in the file
            File.WriteAllText(JsonFileFullname, convertedJson);
        }
    }

    public class Chord
    {
        public string title { get; set; }
        public List<string> chords { get; set; }

        public Chord(string title, List<string> chords)
        {
            this.title = title;
            this.chords = chords;
        }
    }
}
