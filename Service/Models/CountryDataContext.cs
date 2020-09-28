using System.Data.Entity;

namespace Lab2Service.Models
{
    public class CountryDataContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public CountryDataContext()
            : base("DBConnection")
        { }

    }
}