namespace chessAPI.models.team;

public sealed class clsPutTeam
{
    public clsPutTeam()
    {
        id = 0;
        name = "";
        created_at = DateTime.Now;
    }

    public int id { get; set; }
    public string name { get; set; }
    public DateTime created_at { get; set; }
}