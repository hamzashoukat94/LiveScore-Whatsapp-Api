using CricketAPI.Standard.Models;

namespace Hackathon.Models
{
    public class Match
    {
        public int Id { get; set; }
        public TeamByID VisitiorTeam { get; set; }

        public string Wickets { get; set; }
        public string Score { get; set; }
        public TeamByID LocalTeam { get; set; }

        public string Inning {  get; set; }

        public string Elected { get; set; }

        public string TossWon { get; set; }
        public string Type { get; set; }

        public string Note { get; set; }

        public string Over { get; set; }

        public override string ToString()
        {
            string note = String.IsNullOrEmpty(Note) ? string.Empty : $"\r\nStatus : {Note}";
            return $"Match No : {Id} \r\n{LocalTeam.Data.Name} vs {VisitiorTeam.Data.Name} \r\nMatch Type: {Type}" +
                $" \r\nOvers: {Over}\r\nScore: {Score}/{Wickets}  \r\nToss : {TossWon } has won the toss and elected {Elected}\r\nInning: {Inning} {note}";
        }
    }
}
