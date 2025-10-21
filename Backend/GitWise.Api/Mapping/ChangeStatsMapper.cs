using GitWise.Api.Models;
using Gitwise.Domain.Models;

namespace GitWise.Api.Mapping;

public static class ChangeStatsMapper
{
    public static ChangeStatsDto FromDomain(this ChangeStats changeStats)
    {
        return new ChangeStatsDto(
            changeStats.Total,
            changeStats.Additions,
            changeStats.Deletions);
    }
    
    public static ChangeStats ToDomain(this ChangeStatsDto changeStatsDto)
    {
        return new ChangeStats(
            changeStatsDto.Total,
            changeStatsDto.Additions,
            changeStatsDto.Deletions);
    }
}