using AnimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalApi.Data
{
    public class AnimalContext : DbContext
    {
        public DbSet<AnimalModel>? Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=animals.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
