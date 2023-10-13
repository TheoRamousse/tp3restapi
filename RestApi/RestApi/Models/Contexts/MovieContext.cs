using Microsoft.EntityFrameworkCore;
using RestApi.Models.Entities;

namespace RestApi.Models.Contexts
{
    public class MovieContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<GuestEntity> Guests { get; set; }

        public string DbPath { get; }

        public MovieContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "movie.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
