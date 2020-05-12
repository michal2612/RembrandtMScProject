using Microsoft.EntityFrameworkCore;

namespace user_microservice.Models
{
    public class UserContext : DbContext
    {
        public DbSet<TestClass> TestClass { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public UserContext(DbContextOptions db) : base(db)
        {

        }
    }
}
