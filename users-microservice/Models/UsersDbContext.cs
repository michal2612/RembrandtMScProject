using Microsoft.EntityFrameworkCore;

namespace users_microservice.Models
{
    public class UsersDbContext : DbContext
    {
        public DbSet<TestClass> TestClass { get; set; }

        public UsersDbContext(DbContextOptions db)
        {

        }
    }
}
