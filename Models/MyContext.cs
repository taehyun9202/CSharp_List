using Microsoft.EntityFrameworkCore;
namespace Pirate.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PirateMember> Crews {get;set;}
    }
}