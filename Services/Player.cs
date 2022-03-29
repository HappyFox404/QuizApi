using System.Linq;

namespace QuizApi.Services
{
    public class Player
    {
        public static List<Player> Players { get; set; } = new();

        public string Name { get; set; }
        public long Id { get; set; }
        public DateTime LastActive { get; set; }

        private static long s_generateId()
        {
            long total = Players.Sum(p => p.Id);
            long newId = Math.Abs(total - (Players.Count + 1 * (Players.Count / 2)));
            return newId;
        }

        public static long CreatePlayer(string name)
        {
            var player = new Player()
            {
                Name = name,
                Id = s_generateId(),
                LastActive = DateTime.Now
            };
            Players.Add(player);
            return player.Id;
        }

        public static bool RenevalActive(long id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return false;

            player.LastActive = DateTime.Now;
            return true;
        }

        public static bool ChangeName(long id, string name)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return false;

            player.Name = name;
            return true;
        }

        public static bool DeletePlayer(long id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return false;

            Players.Remove(player);
            return true;
        }
    }
}