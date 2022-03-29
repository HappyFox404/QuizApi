namespace QuizApi.Services
{
    public class Lobby
    {
        public static List<Lobby> Lobbies { get; set; } = new();

        public string Name { get; set; }
        public long Id { get; set; }
        public DateTime LastChecked { get; set; } = DateTime.Now;
        public bool IsStart { get; set; } = false;
        public List<Player> PlayersInLobby { get; set; } = new();
    }
}