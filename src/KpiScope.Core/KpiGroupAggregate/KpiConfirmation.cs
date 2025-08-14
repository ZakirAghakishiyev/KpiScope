using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.KpiAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiConfirmation : BaseEntity, IAggregateRoot
{
    public int KpiGroupCompanyId { get; set; }
    public ConfirmationStatusEnum Status { get; set; } = ConfirmationStatusEnum.Pending;
    public int CurrentStepNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
    public List<KpiValue> KpiValues { get; set; } = new();
    public List<KpiConfirmationStep> Steps { get; set; } = new();
    public KpiGroupCompany? KpiGroupCompany { get; set; }
}

