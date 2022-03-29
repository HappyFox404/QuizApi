using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

public class QuizContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public QuizContext(DbContextOptions<QuizContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public void RecreateDatabase()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>().HasOne(a => a.Question).WithMany(q => q.Answers).HasForeignKey(a => a.QuestionId).HasPrincipalKey(q => q.Id);
    }
}