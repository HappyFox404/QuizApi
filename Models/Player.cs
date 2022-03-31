using System.Linq;

namespace QuizApi.Services
{
    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime LastActive { get; set; }
    }

    public class PlayerTransfer
    {
        public string Name { get; set; }
    }
}