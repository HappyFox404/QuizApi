namespace QuizApi.Services
{
    public class PlayerServices
    {
        public static List<Player> Players { get; set; } = new();
        public static int LastId = 0;

        public static void Init()
        {
            CreatePlayer("test 1");
            CreatePlayer("test 2");
            CreatePlayer("test 3");
        }

        public static Player? GetPlayer(int id) => Players.FirstOrDefault(p => p.Id == id);

        public static int CreatePlayer(string name)
        {
            var player = new Player()
            {
                Name = name,
                Id = LastId++,
                LastActive = DateTime.Now
            };
            Players.Add(player);
            return player.Id;
        }

        public static bool RenevalActive(int id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return false;

            player.LastActive = DateTime.Now;
            return true;
        }

        public static bool ChangeName(int id, string name)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return false;

            player.Name = name;
            return true;
        }

        public static bool DeletePlayer(int id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return false;

            Players.Remove(player);
            return true;
        }
    }
}