﻿using System;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace PoolEight.Utilities
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

        public static void SaveScore(string player1, int score1, string player2, int score2)
        {
            Scores.Add(new Record() { Player1 = player1, Points1 = score1, Player2 = player2, Points2 = score2, Date = DateTime.Now });

            System.IO.File.WriteAllText(path, JsonSerializer.Serialize(Scores));
        }
    }
}
