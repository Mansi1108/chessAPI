namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qGame : IQGame
{
    private const string _selectAll = @" 
    SELECT id, started, whites, blacks, turn, winner 
    FROM public.game";
    private const string _selectOne = @"
    SELECT id, started, whites, blacks, turn, winner 
    FROM public.game
    WHERE id=@ID";
    private const string _add = @"
    INSERT INTO public.game(started, whites, turn)
	VALUES (@STARTED, @WHITES, @TURN) RETURNING id";
    private const string _delete = @"
    DELETE FROM public.game 
    WHERE id = @ID";
    private const string _update = @"
    UPDATE public.game
        SET blacks = @BLACKS,
        WHERE id=1 AND NOT EXISTS (
            SELECT x.player_id
            FROM team_player x
            WHERE team_id = @WHITES
            AND EXISTS (
                SELECT 1 FROM team_player y
                WHERE team_id = @BLACKS AND x.player_id = y.player_id
            )
        )
	RETURNING id";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
}