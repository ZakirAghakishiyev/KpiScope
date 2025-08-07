using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.KpiAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiGroup : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
    public List<Kpi> KPIs { get; set; } = []; 
}
