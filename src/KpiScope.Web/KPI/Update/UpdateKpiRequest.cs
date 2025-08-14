using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KPI.Update;

public class UpdateKpiRequest
{
    public const string Route = "/Kpi/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }
    public required string Name { get; set; }
}
