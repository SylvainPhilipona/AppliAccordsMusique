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
            new Chord("list1", new List<string> { "C", "C+", "CM" }),
            new Chord("list2", new List<string> { "C dim", "C sus", "C4" }),
            new Chord("list3", new List<string> { "C6", "Cma7", "Cm7" }),
            new Chord("list4", new List<string> { "C7", "Cm", "C5" }),
        };

        //Functions

        public static List<Chord> GetChords()
        {
            //Return the JSON content as a list of chords
            return JsonConvert.DeserializeObject<List<Chord>>(File.ReadAllText(JsonFileFullname));
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
            //Check if file dosen't exists, or is empty
            if (!File.Exists(JsonFileFullname) || File.ReadAllText(JsonFileFullname) == "")
            {
                //Convert the string to JSON
                var defaultsChordsJSON = JsonConvert.SerializeObject(defaultChords, Formatting.Indented);

                //Write in the file
                File.WriteAllText(JsonFileFullname, defaultsChordsJSON);
            }

            //Get actual json content
            List<Chord> list = JsonConvert.DeserializeObject<List<Chord>>(File.ReadAllText(JsonFileFullname));

            //Add the new chords
            list.Add(new Chord(title, chords));

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
