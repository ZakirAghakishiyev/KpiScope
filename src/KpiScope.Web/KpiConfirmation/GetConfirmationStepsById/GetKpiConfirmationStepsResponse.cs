using KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Web.KpiConfirmation.GetConfirmationStepsById;

public class KpiConfirmationStepDto
{
    public int StepNumber { get; set; }
    public string ApproverName { get; set; } = string.Empty;
    public ConfirmationStatusEnum Status { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
}

public class GetKpiConfirmationStepsResponse
{
    public int ConfirmationId { get; set; }
    public List<KpiConfirmationStepDto> Steps { get; set; } = new();
}
