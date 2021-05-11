using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Canada",
                    ShortName = "CA"
                },
                new Country
                {
                    Id = 2,
                    Name = "United States of America",
                    ShortName = "US"
                },
                new Country
                {
                    Id = 3,
                    Name = "Mexico",
                    ShortName = "MX"
                },
                new Country
                {
                    Id = 4,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = 5,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 6,
                    Name = "Cayman Island",
                    ShortName = "CI"
                }
                );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 4,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Comfort Suites",
                    Address = "Georgetown",
                    CountryId = 6,
                    Rating = 3.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Pallladium",
                    Address = "Nassau",
                    CountryId = 5,
                    Rating = 4.0
                }
                );
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
