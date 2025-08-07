using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Core.KpiAggregate;

public class Kpi : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
    public GriEnum GriIndex { set; get; }
    public PeriodEnum TimePeriod { get; set; }
    public int KpiGroupId { get; set; }
    public KpiGroup? KpiGroup { get; set; }
    public List<KpiValue> KpiValues { get; set; } = [];
}
