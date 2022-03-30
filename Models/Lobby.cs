namespace QuizApi.Services
{
    public class Lobby
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public DateTime LastActive { get; set; } = DateTime.Now;
        public bool IsStart { get; set; } = false;
        public Player OwnerLobby { get; set; } = null!;
        public List<Player> PlayersInLobby { get; set; } = new();
    }
}