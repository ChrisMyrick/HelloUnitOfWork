using Microsoft.EntityFrameworkCore;

namespace HelloUnitOfWork
{
    public class IMSDBContext : DbContext
    {
        public IMSDBContext(DbContextOptions<IMSDBContext> options) : base(options)
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Course_Tag> CourseTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GetStartedDB;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course_Tag>()
                .HasKey(bc => new { bc.CourseId, bc.TagId });

            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                  new Tag { Name = "Tag1", TagId = 1, },
                  new Tag { Name = "Tag2", TagId = 2, },
                  new Tag { Name = "Tag3", TagId = 3, }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "McBeth" },
                new Author { AuthorId = 2, Name = "Shakespeare" },
                new Author { AuthorId = 3, Name = "Panda!" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Name = "Underwater Basket Weaving", AuthorId = 1, Description="", Level = 101, FullPrice = 100.00F},
                new Course { CourseId = 2, Name = "Diesel Engine Repair", AuthorId = 2, Description = "", Level = 1012, FullPrice = 200.00F },
                new Course { CourseId = 3, Name = "Pro C#", AuthorId = 3, Description = "", Level = 201, FullPrice = 300.00F }
            );

            modelBuilder.Entity<Course_Tag>().HasData(
                new Course_Tag { CourseId = 1, TagId = 1 },
                new Course_Tag { CourseId = 2, TagId = 2 },
                new Course_Tag { CourseId = 3, TagId = 3 }
            );
        }
    }
}