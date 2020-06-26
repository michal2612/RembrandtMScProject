
namespace Rembrandt.Dataset.Core.Models
{
    public class Contributor
    {
        public int Id { get; protected set; }
        public int? Age { get; protected set; }
        public int? Gender { get; protected set; }
        public bool? DutchNationality { get; protected set; }
        public string Education { get; protected set; }
        public bool VisitDaily { get; protected set; }
        public bool? VisitAlone { get; protected set; }
        public bool? VisitOtherParks { get; protected set; }
        public bool MoreInvolved { get; protected set; }
        public bool NatureOriented { get; protected set; }
        public bool WithChildren { get; protected set; }
        public Activities Activities { get; protected set; }

        protected Contributor()
        {
            
        }

    }
}