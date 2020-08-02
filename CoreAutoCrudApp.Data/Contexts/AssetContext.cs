using CoreAutoCrudApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAutoCrudApp.Data.Contexts
{
    public class AssetContext : DbContext
    {

        public AssetContext() : base()
        {
        }

        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../CoreAutoCrudApp.Data/asset.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            return;
        }
    }
}
