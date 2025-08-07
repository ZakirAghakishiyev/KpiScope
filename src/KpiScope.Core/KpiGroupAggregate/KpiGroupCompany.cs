using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.CompanyAggregate;
using KpiScope.Core.UserAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiGroupCompany : BaseEntity, IAggregateRoot
{
    public int KpiGroupId { get; set; }
    public int CompanyId { get; set; }
    public int UserId { get; set; }
    public KpiGroup? KpiGroup { get; set; }
    public Company? Company { get; set; }
    public User? User { get; set; }
}
