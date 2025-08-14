using KpiScope.Core.BaseEntityAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiConfirmationStep : BaseEntity, IAggregateRoot
{
    public int KpiConfirmationId { get; set; }
    public int StepNumber { get; set; }
    public ConfirmationStatusEnum Status { get; set; } = ConfirmationStatusEnum.Pending;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public List<KpiConfirmationUser> Approvers { get; set; } = new();

    public KpiConfirmation? KpiConfirmation { get; set; }
}
