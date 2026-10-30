using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VesselManagementApi.Data;

namespace VesselManagementApi.Controllers;

[ApiController]
[Route("api/operations-dashboard")]
public sealed class OperationsDashboardController(VesselManagementDbContext dbContext) : ControllerBase
{
    /// <summary>返回运营驾驶舱的核心汇总指标。</summary>
    [HttpGet("summary")]
    public async Task<ActionResult<OperationsSummaryDto>> GetSummary(CancellationToken cancellationToken)
    {
        var ownerCount = await dbContext.Owners.CountAsync(cancellationToken);
        var assetCount = await dbContext.Ships.CountAsync(cancellationToken);
        var assignedAssetCount = await dbContext.ShipOwners
            .Select(x => x.ShipId)
            .Distinct()
            .CountAsync(cancellationToken);

        return Ok(new OperationsSummaryDto(
            ownerCount,
            assetCount,
            assignedAssetCount,
            assetCount - assignedAssetCount,
            DateTimeOffset.UtcNow));
    }
}

public sealed record OperationsSummaryDto(
    int CustomerCount,
    int AssetCount,
    int AssignedAssetCount,
    int UnassignedAssetCount,
    DateTimeOffset GeneratedAt);
