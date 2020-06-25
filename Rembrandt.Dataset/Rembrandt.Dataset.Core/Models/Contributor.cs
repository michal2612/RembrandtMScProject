namespace Rembrandt.Dataset.Core.Models
{
    public class Contributor
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public bool? DutchNationality { get; set; }
        public string Education { get; set; }
        public bool VisitDaily { get; set; }
        public bool? VisitAlone { get; set; }
        public bool? VisitOtherParks { get; set; }
        public bool MoreInvolved { get; set; }
        public bool NatureOriented { get; set; }
        public bool WithChildren { get; set; }
        public Activities Activities { get; set; }

        protected Contributor()
        {
            
        }

    }
}