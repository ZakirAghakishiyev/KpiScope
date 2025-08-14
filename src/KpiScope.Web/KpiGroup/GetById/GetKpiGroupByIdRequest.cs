using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KpiGroup.GetById;

public class GetKpiGroupByIdRequest
{
    public const string Route = "/KpiGroups/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }
}
