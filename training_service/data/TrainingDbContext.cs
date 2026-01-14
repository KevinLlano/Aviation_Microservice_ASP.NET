using Microsoft.EntityFrameworkCore;
using training_service.model;

namespace training_service.data
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
        {
        }

        // DbSets represent tables in the database
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique index for Course.CourseCode
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique();

            // Configure unique index for Instructor.Email
            modelBuilder.Entity<Instructor>()
                .HasIndex(i => i.Email)
                .IsUnique();

            // Configure relationships
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Course)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure enum to store as string
            modelBuilder.Entity<Lesson>()
                .Property(l => l.Type)
                .HasConversion<string>();
        }
    }
}
