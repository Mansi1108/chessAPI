using chessAPI.models.team;

namespace chessAPI.business.interfaces;

public interface ITeamBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsTeam<TI>> addTeam(clsNewTeam newTeam);
    Task<List<clsTeam<TI>>> getTeams();
}