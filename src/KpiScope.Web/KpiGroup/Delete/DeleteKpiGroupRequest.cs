using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KpiGroup.Delete;

public class DeleteKpiGroupRequest
{
    public const string Route = "/KpiGroups/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }
}
