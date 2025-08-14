using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.KPI.Create;

public class CreateKpiRequest
{
    public const string Route = "/Kpi";
    public static string BuildRoute() => Route;
    public required string Name { get; set; }
    public GriEnum GriIndex { set; get; }
    public PeriodEnum TimePeriod { get; set; }
    public int KpiGroupId { get; set; }
}
