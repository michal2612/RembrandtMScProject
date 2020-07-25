using System.Collections.Generic;

namespace Rembrandt.Contracts.Classes.Stats
{
    public class ObservationStatDto
    {
        public List<SkipReasonsDto> SkipReasons { get; set; }

        public int SiteId { get; set; }

        public List<PhotoAddressDto> PhotosAddresses { get; set; }

        public AttributesStatDto Attributes { get; set; }

        public ActivitiesStatDto Activities { get; set; }
    }
}