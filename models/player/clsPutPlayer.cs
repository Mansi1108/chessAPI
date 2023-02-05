namespace chessAPI.models.player;

public sealed class clsPutPlayer
{
    public clsPutPlayer()
    {
        this.id = 0;
        this.email = "";
    }

    public int id { get; set; }
    public string email { get; set; }
}