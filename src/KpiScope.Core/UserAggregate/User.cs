using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.CompanyAggregate;

namespace KpiScope.Core.UserAggregate;

public class User : BaseEntity,IAggregateRoot
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public int CompanyId{ get; set; }
    public Company? Company { get; set; }
}
