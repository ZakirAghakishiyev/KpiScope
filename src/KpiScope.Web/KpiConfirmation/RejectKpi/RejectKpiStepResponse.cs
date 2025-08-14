using KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Web.KpiConfirmation.RejectKpi;

public class RejectKpiStepResponse
{
    public int StepNumber { get; set; }
    public ConfirmationStatusEnum StepStatus { get; set; }
    public ConfirmationStatusEnum OverallStatus { get; set; }
}

