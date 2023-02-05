namespace chessAPI.models.team;

public sealed class clsNewTeam
{
    public clsNewTeam()
    {
        name = "";
        created_at = DateTime.Now;
    }

    public string name { get; set; }
    public DateTime created_at { get; set; }
}