using chessAPI.models.game;

namespace chessAPI.business.interfaces;

public interface IGameBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsGame<TI>> addGame(clsNewGame newGame);
    Task<List<clsGame<TI>>> getGames();
    
}