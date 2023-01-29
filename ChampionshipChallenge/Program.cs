namespace ChampionshipChallenge;
using CodeChallenge.Models;

class Program
{
    private static void Main(string[] args)
    {
        PositionModel positionModel = new PositionModel();

        Positions positions = positionModel.CheckTeamPosition();

        //Loop through all team records
        foreach (TeamRecord tr in positions.TeamRecords)
        {
            Console.WriteLine("{0} - {1} points", tr.TeamName, tr.Points);
        }
        Console.ReadKey();
    }
}