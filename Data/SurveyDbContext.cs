using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHG.Surveys.Domain.Data
{
    public class SurveyDbContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId);

            modelBuilder.Entity<UserResponse>()
                .HasMany(ur => ur.Responses)
                .WithOne(r => r.UserResponse)
                .HasForeignKey(r => r.UserResponseId);

            modelBuilder.Entity<Question>()
                .Property(q => q.Type)
                .HasConversion<string>();
        }
    }
}
