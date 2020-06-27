namespace Rembrandt.Dataset.Infrastructure.DTO
{
    public class ContributorDto
    {
        public string Id { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public bool? DutchNationality { get; set; }
        public int? Education { get; set; }
        public bool? VisitDaily { get; set; }
        public int? VisitFreq { get; set; }
        public bool? VisitAlone { get; set; }
        public int? VisitOtherParks { get; set; }
        public bool? MoreInvolved { get; set; }
        public int? NatureOriented { get; set; }
        public bool? WithChildren { get; set; }
    }
}