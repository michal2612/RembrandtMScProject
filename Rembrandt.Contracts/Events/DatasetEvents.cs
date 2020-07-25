namespace Rembrandt.Contracts.Events
{
    public class DatasetEvents
    {
        public delegate void ObservationAddedEventHandler(object source, ObservationEventArgs args);

        public event ObservationAddedEventHandler ObservationAdded;

        protected virtual void OnObservationAdded(int siteId)
        {
            if(ObservationAdded != null)
                ObservationAdded(this, new ObservationEventArgs() {SiteId = siteId});
        }
    }
}