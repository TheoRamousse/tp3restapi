using Microsoft.EntityFrameworkCore;
using RestApi.Models.Entities;
using System.Reflection;

namespace RestApi.Models.Contexts
{
    public class MovieContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<GuestEntity> Guests { get; set; }
        public DbSet<RelationEntity> Relations { get; set; }

        public string DbPath { get; }

        public MovieContext()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DbPath = System.IO.Path.Join(path, "movie.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
