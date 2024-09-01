using Educational_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Educational_Platform.Database_Connection
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User", "Educational_Platform");
            modelBuilder.Entity<Student>().ToTable("Student", "Educational_Platform");
            modelBuilder.Entity<Teacher>().ToTable("Teacher", "Educational_Platform");
            modelBuilder.Entity<Course>().ToTable("Course", "Educational_Platform");
            modelBuilder.Entity<CourseStudent>().ToTable("CourseStudent", "Educational_Platform");
            modelBuilder.Entity<CourseTeacher>().ToTable("CourseTeacher", "Educational_Platform");
            modelBuilder.Entity<Post>().ToTable("Post", "Educational_Platform");
            modelBuilder.Entity<Message>().ToTable("Message", "Educational_Platform");
            modelBuilder.Entity<Scheduling>().ToTable("Scheduling", "Educational_Platform");
            modelBuilder.Entity<Rating>().ToTable("Rating", "Educational_Platform");
            modelBuilder.Entity<Comment>().ToTable("Comment", "Educational_Platform");
            modelBuilder.Entity<Registration>().ToTable("Registration", "Educational_Platform");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<CourseTeacher> CourseTeacher { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Registration> Registration { get; set; }
    }
}
