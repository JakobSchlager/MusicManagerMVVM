using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagerContextLib
{
    public class MusicManagerContext : DbContext
    {
        public MusicManagerContext() { }
        public MusicManagerContext(DbContextOptions<MusicManagerContext> options) : base(options) { }
        public DbSet<Artist> ArtistSet { get; set; }
        //public DbSet<Record> Records { get; set; }
        public DbSet<Song> SongSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine($"Db Onconfiguring: IsConfigured={optionsBuilder.IsConfigured}");
            if (optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\Users\jakob\OneDrive\_Schule\_Porgrammieren\VisualStudio\C#\MusicManager\MusicManagerContextLib\MusicManager.mdf;database=Persons;integrated security=True;MultipleActiveResultSets=True";
                optionsBuilder.UseSqlServer(connectionString); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }
    }
}
