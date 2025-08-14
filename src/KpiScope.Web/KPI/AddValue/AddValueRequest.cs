using KpiScope.Web.Value.KpiValue.Create;

namespace KpiScope.Web.KPI.AddValue;

public class AddValueRequest
{
    public const string Route = "/Kpi/AddValue";
    public static string BuildRoute() => Route;
    public required CreateKpiValueRequest KpiValue { get; set; } 
}
