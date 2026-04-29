using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.SubjectLevels;
using LmsProjectApi.Models.Subjects;
using LmsProjectApi.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LmsProjectApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectLevel> SubjectLevels { get; set; }
        public DbSet<Level> Levels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectLevel>()
                .HasKey(sl => new {sl.SubjectId, sl.LevelId});

            modelBuilder.Entity<SubjectLevel>()
                .HasIndex(sl => new { sl.SubjectId, sl.OrderIndex })
                .IsUnique();

            modelBuilder.Entity<SubjectLevel>()
                .HasOne(sl => sl.Subject)
                .WithMany(s => s.SubjectLevels)
                .HasForeignKey(sl => sl.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubjectLevel>()
                .HasOne(sl => sl.Level)
                .WithMany(l => l.SubjectLevels)
                .HasForeignKey(sl => sl.LevelId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
