using Microsoft.EntityFrameworkCore;

namespace user_microservice.Models
{
    public class UserContext : DbContext
    {
        public DbSet<TestClass> TestClass { get; set; }

        public UserContext(DbContextOptions db) : base(db)
        {

        }
    }
}
