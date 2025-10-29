using SummaryEngine.Domain.Models;
using SummaryEngine.Presentation.Models;

namespace SummaryEngine.Presentation.Mapping;

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