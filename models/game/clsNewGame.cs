namespace chessAPI.models.game;

public sealed class clsNewGame
{
    public clsNewGame()
    {
        this.started = "";
        this.whites = 0;
        this.blacks = 0;
        this.turn = false;
        this.winner = 0;
    }

    public string started { get; set; }
    public int whites { get; set; }
    public int blacks { get; set; }
    public bool turn { get; set; }
    public int winner { get; set; }
}