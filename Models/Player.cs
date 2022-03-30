using System.Linq;

namespace QuizApi.Services
{
    public class Player
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public DateTime LastActive { get; set; }
    }
}