using System.ComponentModel.DataAnnotations;

namespace Rembrandt.DatasetStats.Core.Models
{
    public class PhotoAddress
    {
        [Key]
        public int PrimaryKey { get; set; }
        public string Address { get; set; }
    }
}