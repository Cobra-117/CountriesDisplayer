namespace CountryInfoApp
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    namespace CountryInfoApp.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<City> Cities { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                Console.Write("creating model");
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Tokyo", Country = "Japan", Population = 37393128 },
                new City { Id = 2, Name = "Delhi", Country = "India", Population = 31870000 },
                new City { Id = 3, Name = "Shanghai", Country = "China", Population = 27795702 }
            );
            }


        }
    }

}
