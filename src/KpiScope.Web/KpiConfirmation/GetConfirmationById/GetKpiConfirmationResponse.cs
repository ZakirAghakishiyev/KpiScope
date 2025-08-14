using KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Web.KpiConfirmation.GetConfirmationById;

public class GetKpiConfirmationResponse
{
    public int Id { get; set; }
    public int KpiGroupCompanyId { get; set; }
    public string KpiGroupName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public ConfirmationStatusEnum Status { get; set; }
    public int CurrentStepNumber { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
