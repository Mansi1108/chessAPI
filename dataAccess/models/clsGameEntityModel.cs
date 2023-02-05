using chessAPI.dataAccess.common;
namespace chessAPI.dataAccess.models;

public sealed class clsGameEntityModel<TI, TC> : relationalEntity<TI, TC>
        where TC : struct
        where TI : struct, IEquatable<TI>
{
    public clsGameEntityModel()
    {
        started = "";
        whites = 0;
        blacks = 0;
        turn = false;
        winner = 0;
    }

    public TI id { get; set; }
    public string started { get; set; }
    public int whites { get; set; }
    public int blacks { get; set; }
    public bool turn { get; set; }
    public int winner { get; set; }
    public override TI key { get => id; set => id = value; }
}