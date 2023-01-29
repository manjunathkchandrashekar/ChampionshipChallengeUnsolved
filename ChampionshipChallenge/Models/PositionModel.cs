using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeChallenge.Models
{
    class PositionModel
    {
        public Positions Positions { get; set; }

        /// <summary>
        /// CheckTeamPosition method reads the data of matches and assigns the team name and score respective to the teams of a match.
        /// </summary>
        /// <returns>Positions sorted on descending order based on Goals Scored</returns>
        public Positions CheckTeamPosition()
        {
            string[] matchesInfo = File.ReadAllLines(@"C:\Users\Manju\source\repos\CodeChallenge\Matches.txt");
            Match match = new Match();
            this.Positions = new Positions();

            //Loop through the lines(matches) in the text file
            foreach (string matchInfo in matchesInfo)
            {
                char[] separator = { ',', ' ' };
                String[] matchTeamScoreInfo = matchInfo.Split(separator);

                //Assiging team scores and team name
                match.FirstTeamName = matchTeamScoreInfo[0];
                match.FirstTeamScore = Convert.ToInt32(matchTeamScoreInfo[1]);
                match.SecondTeamName = matchTeamScoreInfo[2];
                match.SecondTeamScore = Convert.ToInt32(matchTeamScoreInfo[3]);

                //Calling AddMatchResults method to add the match results info
                this.AddMatchResults(match);
            }
            this.Positions.TeamRecords = this.Positions._TeamRecords.Values.OrderByDescending(team => team.GoalsScored);
            return this.Positions;

        }

        /// <summary>
        /// AddMatchResults method takes match as parameter adding the win or loss or tie and goals scored of a match.
        /// </summary>
        /// <param name="match"></param>
        public void AddMatchResults(Match match)
        {
            if (!this.Positions._TeamRecords.TryGetValue(match.FirstTeamName, out var firstTeamName))
            {
                this.Positions._TeamRecords.Add(match.FirstTeamName, new TeamRecord(match.FirstTeamName));
            }
            if (!this.Positions._TeamRecords.TryGetValue(match.SecondTeamName, out var secondTeamName))
            {
                this.Positions._TeamRecords.Add(match.SecondTeamName, new TeamRecord(match.SecondTeamName));
            }

            firstTeamName = this.Positions._TeamRecords[match.FirstTeamName.ToString()];
            secondTeamName = this.Positions._TeamRecords[match.SecondTeamName.ToString()];

            if (match.FirstTeamScore == match.SecondTeamScore)
            {
                firstTeamName.AddDraw(match.FirstTeamScore);
                secondTeamName.AddDraw(match.FirstTeamScore);
            }
            else if (match.FirstTeamScore > match.SecondTeamScore)
            {
                firstTeamName.AddWin(match.FirstTeamScore);
                secondTeamName.AddLoss(match.SecondTeamScore);
            }
            else
            {
                firstTeamName.AddLoss(match.FirstTeamScore);
                secondTeamName.AddWin(match.SecondTeamScore);
            }
        }
    }
}
