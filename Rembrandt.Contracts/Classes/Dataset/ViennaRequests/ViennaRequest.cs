using System.Collections.Generic;

namespace Rembrandt.Contracts.Classes.Dataset.ViennaRequests
{
    public class ViennaRequest
    {
        public string MainCategory { get; set; }

        public List<string> RequestedActivities { get; set; }

        public ViennaRequest()
        {
            RequestedActivities = new List<string>();
        }
    }
}