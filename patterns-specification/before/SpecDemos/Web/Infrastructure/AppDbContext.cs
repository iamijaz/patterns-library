using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Web.Models;

namespace Web.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new AppDbContextInitializer());
            Database.Log = s => Debug.WriteLine(s);
        }
    }
}