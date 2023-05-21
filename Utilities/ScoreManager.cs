using GameRules;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Utilities
{
    class Record
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int Points1 { get; set; }
        public int Points2 { get; set; }
        public DateTime Date { get; set; }
    }
    class ScoreManager
    {
        public static ObservableCollection<Record> Scores { get; private set; } = new ObservableCollection<Record>();

        private static readonly string path = "scores.sav";

        static ScoreManager()
        {
            string input = "[]";
            try
            {
                input = System.IO.File.ReadAllText(path);
            }
            catch { }

            foreach (Record record in JsonSerializer.Deserialize<ObservableCollection<Record>>(input))
            {
                Scores.Add(record);
            }
        }

        public static void SaveScore(Player player1, Player player2)
        {
            Scores.Add(new Record() { Player1 = player1.Name, Points1 = player1.Score, Player2 = player2.Name, Points2 = player2.Score, Date = DateTime.Now });

            System.IO.File.WriteAllText(path, JsonSerializer.Serialize(Scores));
        }
    }
}
