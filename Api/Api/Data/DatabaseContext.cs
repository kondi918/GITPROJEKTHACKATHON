using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Quizes> Quizes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>()
                .HasOne(q => q.Quiz)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answers>()
                .HasOne(a => a.Questions)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserAnswers>()
                .HasOne(ua => ua.Users)
                .WithMany(u => u.UserAnswers)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserAnswers>()
                .HasOne(ua => ua.Questions)
                .WithMany(q => q.UserAnswers)
                .HasForeignKey(ua => ua.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserAnswers>()
                .HasOne(ua => ua.Answers)
                .WithMany(a => a.UserAnswers)
                .HasForeignKey(ua => ua.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserAnswers>()
                .HasOne(ua => ua.Quizes)
                .WithMany(q => q.UserAnswers)
                .HasForeignKey(ua => ua.QuizId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
