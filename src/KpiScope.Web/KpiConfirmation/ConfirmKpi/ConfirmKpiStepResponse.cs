using KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Web.KpiConfirmation.ConfirmKpi;

public class ConfirmKpiStepResponse
{
    public int StepNumber { get; set; }
    public ConfirmationStatusEnum StepStatus { get; set; }
}
