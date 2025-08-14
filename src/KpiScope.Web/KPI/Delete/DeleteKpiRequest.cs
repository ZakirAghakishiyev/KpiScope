using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KPI.Delete;

public class DeleteKpiRequest
{
    public const string Route = "/Kpi/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }
}
