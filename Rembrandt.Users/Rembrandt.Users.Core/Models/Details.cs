using System.ComponentModel.DataAnnotations;

namespace Rembrandt.Users.Core.Models
{
    public class Details
    {
        [Key]
        public int Id { get; set; }
        
        public string Salt { get; set; }
    }
}