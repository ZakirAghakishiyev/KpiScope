using KpiScope.Core.KpiAggregate;
using KpiScope.Web.KPI.GetById;
using KpiScope.Web.KpiGroup;

namespace KpiScope.Web.KPI.List;

public class ListKpiResponse
{
    public int Id { set; get; }
    public required string Name { get; set; }
    public GriEnum GriIndex { set; get; }
    public PeriodEnum TimePeriod { get; set; }
    public KpiGroupDto? KpiGroup { get; set; }
    public List<KpiValueDto> KpiValues { get; set; } = [];
}
