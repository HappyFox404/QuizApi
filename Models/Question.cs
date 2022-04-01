using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Text { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public List<Answer> Answers { get; set; }
    }

    public class QuestionTransfer
    {
        public string Text { get; set; }
        public int CategoryId { get; set; }
    }
}