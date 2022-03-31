namespace QuizApi.Services
{
    public class LobbyServices
    {
        public static List<Lobby> Lobbies { get; set; } = new();
        public static int LastId = 0;

        public static void Init()
        {
            CreateLobby("test lobby 1", PlayerServices.GetPlayer(0));
            CreateLobby("test lobby 2", PlayerServices.GetPlayer(1));
            CreateLobby("test lobby 3", PlayerServices.GetPlayer(2));
        }

        public static Lobby? GetLobby(int id) => Lobbies.FirstOrDefault(l => l.Id == id);
        public static IEnumerable<Lobby> GetAll() => Lobbies;

        public static IEnumerable<Lobby> GetLobbies(int count, int ofset = 0)
        {
            if (Lobbies.Count <= count)
                return Lobbies;
            return Lobbies.Skip(ofset).Take(count);
        }

        public static int CreateLobby(string name, Player owner)
        {
            var lobby = new Lobby()
            {
                Name = name,
                Id = LastId++,
                LastActive = DateTime.Now,
                IsStart = false,
                OwnerLobby = owner,
                PlayersInLobby = new List<Player>() { owner }
            };
            Lobbies.Add(lobby);
            return lobby.Id;
        }

        public static bool RenevalActive(int id)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            lobby.LastActive = DateTime.Now;
            return true;
        }

        public static bool ChangeName(int id, string name)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            lobby.Name = name;
            return true;
        }

        public static bool CloseLobby(int id)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            Lobbies.Remove(lobby);
            return true;
        }

        public static bool StartGame(int id)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Id == id);

            if (lobby == null)
                return false;

            lobby.IsStart = true;
            return lobby.IsStart;
        }
    }
}