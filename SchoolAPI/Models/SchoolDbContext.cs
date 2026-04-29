using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<School> Schools { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id = 1,
                    Name = "ENISo",
                    Sections = "GIA, GE, GM, GC",
                    Director = "Mahdi Abdessalem",
                    Rating = 4.5,
                    WebSite = "https://www.eniso.tn"
                },
                new School
                {
                    Id = 2,
                    Name = "ENIT",
                    Sections = "Informatique, Genie Civil, Telecom",
                    Director = "Karim Ben Salem",
                    Rating = 4.7,
                    WebSite = "https://www.enit.rnu.tn"
                },
                new School
                {
                    Id = 3,
                    Name = "ENIM",
                    Sections = "Mecanique, Electromecanique",
                    Director = "Sami Bouzid",
                    Rating = 4.2
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

