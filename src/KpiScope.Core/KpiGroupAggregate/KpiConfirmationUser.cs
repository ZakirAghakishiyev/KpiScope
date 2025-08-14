using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.KpiAggregate;
using KpiScope.Core.UserAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiConfirmationUser : BaseEntity, IAggregateRoot
{
    public int UserId { get; set; }
    public bool? IsConfirmed { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime? ActionDate { get; set; }
    public User? User { get; set; } 
}
