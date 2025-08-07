using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.UserAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiConfirmationUser : BaseEntity, IAggregateRoot
{
    public int KpiConfirmationId { get; set; }
    public int UserId { get; set; }
    public int StepNumber { get; set; }
    public bool IsConfirmed { get; set; }
    public string Comment { get; set; } = string.Empty; 
    public KpiConfirmation? KpiConfirmation { get; set; }
    public User? User { get; set; }
    public DateTime? ActionDate { get; set; }
}
