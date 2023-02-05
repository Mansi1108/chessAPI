using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.team;

namespace chessAPI.business.impl;

public sealed class clsTeamBusiness<TI, TC> : ITeamBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly ITeamRepository<TI, TC> teamRepository;

    public clsTeamBusiness(ITeamRepository<TI, TC> teamRepository)
    {
        this.teamRepository = teamRepository;
    }

    public async Task<clsTeam<TI>> addTeam(clsNewTeam newTeam)
    {
        var x = await teamRepository.addTeam(newTeam).ConfigureAwait(false);
        return new clsTeam<TI>(x, newTeam.name, newTeam.created_at);
    }

    public async Task<List<clsTeam<TI>>> getTeams()
    {
        List<clsTeam<TI>> teams = new List<clsTeam<TI>>();
        var r = await teamRepository.getTeams().ConfigureAwait(false);
        foreach (var value in r)
        {
            clsTeam<TI> team = new clsTeam<TI>(value.id, value.name, value.created_at);
            teams.Add(team);
        }
        return teams;
    }
}