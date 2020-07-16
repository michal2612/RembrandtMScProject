using System.ComponentModel.DataAnnotations;

namespace Rembrandt.Contracts.Classes.Stats
{
    public class SkipReasonsDto
    {
        public string Reason { get; set; }
        public int ReasonCount { get; set; }
    }
}