using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public List<Question> Questions { get; set; } = new();
    }

    public class CategoryTransfer
    {
        public string Name { get; set; }
    }
}