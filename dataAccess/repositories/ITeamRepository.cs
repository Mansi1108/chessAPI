using chessAPI.dataAccess.models;
using chessAPI.models.team;

namespace chessAPI.dataAccess.repositores;

public interface ITeamRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addTeam(clsNewTeam team);
    Task<IEnumerable<clsTeamEntityModel<TI, TC>>> getTeams();
    Task<IEnumerable<clsTeamEntityModel<TI, TC>>> addTeams(IEnumerable<clsNewTeam> teams);
    Task<IEnumerable<clsTeamEntityModel<TI, TC>>> getTeamssByGame(TI TeamId);
    Task updateTeam(clsTeam<TI> updatedPlayer);
    Task deleteTeam(TI id);
}