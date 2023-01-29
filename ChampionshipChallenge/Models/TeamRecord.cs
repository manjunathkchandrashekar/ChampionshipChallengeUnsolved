using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Models
{
    public class TeamRecord
    {
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int Points { get; set; }
        public int GoalsScored { get; set; }

        public TeamRecord()
        { }

        public TeamRecord(string teamName) : this()
        {
            this.TeamName = teamName;
        }

        internal void AddDraw(int score)
        {
            this.Draws++;
            this.Points++;
            this.GoalsScored += score;
        }

        internal void AddWin(int score)
        {
            this.Wins++;
            this.Points += 3;
            this.GoalsScored += score;
        }

        internal void AddLoss(int score)
        {
            this.Losses++;
            this.Points += 0;
            this.GoalsScored += score;
        }
    }
}
