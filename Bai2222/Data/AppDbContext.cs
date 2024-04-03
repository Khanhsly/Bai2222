using Bai2222.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai2222.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
              .HasKey(sc => new { sc.StudentID, sc.CourseID });

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.student)
                .WithMany(s => s.studentCourses)
                .HasForeignKey(sc => sc.StudentID);

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.course)
                .WithMany(c => c.studentCourses)
                .HasForeignKey(sc => sc.CourseID);
        }
    }
}
