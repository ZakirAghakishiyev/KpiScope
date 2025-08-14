using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KpiGroup.Update;

public class UpdateKpiGroupRequest
{
    public const string Route = "/KpiGroups/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
}
