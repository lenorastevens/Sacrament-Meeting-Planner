using System.ComponentModel.DataAnnotations;

namespace Sacrament_Meeting_Planner.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string? Presiding { get; set; }
        public string? Conducting { get; set; }
        public int OpeningHymn { get; set; }
        public string? Invocation { get; set; }
        public int SacramentHymn { get; set; }
        public int IntermediateHymn { get; set; }
        public int ClosingHymn {  get; set; }
        public string? Benediction { get; set; }
        public string? SpeakerSubject { get; set; }
        public List<string> Speakers { get; set; } = [];        
    }
}
