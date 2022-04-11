using LataPrzestepneDB.Models;
using Microsoft.EntityFrameworkCore;

namespace LataPrzestepneDB.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext (DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }
    }
}
