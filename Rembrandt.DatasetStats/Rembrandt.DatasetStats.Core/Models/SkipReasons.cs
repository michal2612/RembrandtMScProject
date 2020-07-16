using System.ComponentModel.DataAnnotations;

namespace Rembrandt.DatasetStats.Core.Models
{
    public class SkipReasons
    {
        [Key]
        public int SkipReasonsId { get; set; }
        public string Reason { get; set; }
        public int ReasonCount { get; set; }
    }
}