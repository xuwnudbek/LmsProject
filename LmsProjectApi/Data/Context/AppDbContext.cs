using LmsProjectApi.Models.Attendances;
using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Lessons;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.Payments;
using LmsProjectApi.Models.SubjectLevels;
using LmsProjectApi.Models.Subjects;
using LmsProjectApi.Models.UserGroups;
using LmsProjectApi.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LmsProjectApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<SubjectLevel> SubjectLevels { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonSession> LessonSessions { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
