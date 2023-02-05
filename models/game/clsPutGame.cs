namespace chessAPI.models.game;

public sealed class clsPutGame
{
    public clsPutGame()
    {
        id = 0;
        started = DateTime.Now;
        whites = 0;
        blacks = 0;
        turn = true;
        winner = 0;
    }

    public int id { get; set; }
    public DateTime started { get; set; }
    public int? whites { get; set; }
    public int? blacks { get; set; }
    public bool turn { get; set; }
    public int? winner { get; set; }
}