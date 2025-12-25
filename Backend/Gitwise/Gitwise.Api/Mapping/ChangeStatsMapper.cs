using Gitwise.Api.Models;
using SummaryEngine.Domain.Models;

namespace Gitwise.Api.Mapping;

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