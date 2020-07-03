using Rembrandt.Dataset.Core.Context;

namespace Rembrandt.Dataset.Infrastructure
{
    public static class StaticContext
    {
        public static ObservationContext ObservationContext()
            => new ObservationContext();
    }
}