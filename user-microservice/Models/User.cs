using System.ComponentModel.DataAnnotations;

namespace user_microservice.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public Roles Role { get; set; }

        public User()
        {

        }
    }
}
