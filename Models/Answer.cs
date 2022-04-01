using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }

        [Required]
        public string QuestionId { get; set; }
        public Question Question { get; set; }
    }

    public class AnswerTransfer
    {
        public string Text;
        public string QuestionId;
    }
}