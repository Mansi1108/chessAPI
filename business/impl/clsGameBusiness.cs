using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.game;

namespace chessAPI.business.impl;

public sealed class clsGameBusiness<TI, TC> : IGameBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly IGameRepository<TI, TC> gameRepository;

    public clsGameBusiness(IGameRepository<TI, TC> gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public async Task<clsGame<TI>> addGame(clsNewGame newGame)
    {
        var x = await gameRepository.addGame(newGame).ConfigureAwait(false);
        return new clsGame<TI>(x, newGame.started, newGame.whites, newGame.blacks, newGame.turn, newGame.winner);
    }

    public async Task<List<clsGame<TI>>> getGames()
    {
        List<clsGame<TI>> games = new List<clsGame<TI>>();
        var r = await gameRepository.getGames().ConfigureAwait(false);
        foreach (var value in r)
        {
            clsGame<TI> game = new clsGame<TI>(value.id, value.started, value.whites, value.blacks, value.turn, value.winner);
            games.Add(game);
        }
        return games;
    }
    //  public async Task<clsGame<TI>> putGame()
    // {
    //     var r = await gameRepository.getGames().ConfigureAwait(false);
    //     foreach (var value in r)
    //     {
    //         clsGame<TI> game = new clsGame<TI>(value.id, value.started, value.whites, value.blacks, value.turn, value.winner);
    //         games.Add(game);
    //     }
    //     return games;
    // }
}