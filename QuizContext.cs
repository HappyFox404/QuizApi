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

    public bool RecreateDatabase()
    {
        bool status = Database.EnsureDeleted();
        status = Database.EnsureCreated();
        return status;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>().HasOne(a => a.Question).WithMany(q => q.Answers).HasForeignKey(a => a.QuestionId).HasPrincipalKey(q => q.Id);

        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "История" },
            new Category() { Id = 2, Name = "Культура" },
            new Category() { Id = 3, Name = "Естествознание" },
            new Category() { Id = 4, Name = "География" },
            new Category() { Id = 5, Name = "Спорт" },
            new Category() { Id = 6, Name = "Разное" }
        );
    }
}