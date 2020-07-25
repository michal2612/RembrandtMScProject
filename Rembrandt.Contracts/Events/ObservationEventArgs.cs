using System;

namespace Rembrandt.Contracts.Events
{
    public class ObservationEventArgs : EventArgs
    {
        public int SiteId { get; set; }
    }
}