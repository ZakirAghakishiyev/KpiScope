using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.KpiAggregate;
using KpiScope.Core.UserAggregate;

namespace KpiScope.Core.CompanyAggregate;

public class Company : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public List<User> Users { get; set; } = [];
    public List<Kpi> KPIs { get; set; } = [];
}
