namespace QuizApi.Services
{
    public class LobbyServices
    {
        public static List<Lobby> Lobbies { get; set; } = new();

        public static Lobby? GetLobby(long id) => Lobbies.FirstOrDefault(l => l.Id == id);
        public static IEnumerable<Lobby> GetAll() => Lobbies;

        private static long s_generateId()
        {
            long total = Lobbies.Sum(l => l.Id);
            long newId = Math.Abs(total - (Lobbies.Count + 1 * (Lobbies.Count / 2)));
            return newId;
        }

        public static IEnumerable<Lobby> GetLobbies(int count, int ofset = 0)
        {
            if (Lobbies.Count <= count)
                return Lobbies;
            return Lobbies.Skip(ofset).Take(count);
        }

        public static long CreateLobby(string name, Player owner)
        {
            var lobby = new Lobby()
            {
                Name = name,
                Id = s_generateId(),
                LastActive = DateTime.Now,
                IsStart = false,
                OwnerLobby = owner,
                PlayersInLobby = new List<Player>() { owner }
            };
            Lobbies.Add(lobby);
            return lobby.Id;
        }

        public static bool RenevalActive(long id)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            lobby.LastActive = DateTime.Now;
            return true;
        }

        public static bool ChangeName(long id, string name)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            lobby.Name = name;
            return true;
        }

        public static bool CloseLobby(long id)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            Lobbies.Remove(lobby);
            return true;
        }

        public static bool StartGame(long id)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            lobby.IsStart = true;
            return lobby.IsStart;
        }
    }
}