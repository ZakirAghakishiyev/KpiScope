using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.KPI.Create;

public class CreateKpiResponse
{
    public int Id { set; get; }
    public required string Name { get; set; }
    public GriEnum GriIndex { set; get; }
    public PeriodEnum TimePeriod { get; set; }
    public int KpiGroupId { get; set; }
}
