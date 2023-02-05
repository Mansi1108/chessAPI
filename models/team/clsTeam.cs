namespace chessAPI.models.team;

public sealed class clsTeam<TI>
where TI : struct, IEquatable<TI>
{
    public clsTeam(TI id, string name, DateTime created_at)
    {
        this.name = name;
        this.created_at = created_at;
    }

    public TI id { get; set; }
    public string name { get; set; }
    public DateTime created_at { get; set; }
}