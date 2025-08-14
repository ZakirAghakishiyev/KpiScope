using KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Web.KpiConfirmation.StartConfirmation;

public class StartKpiConfirmationResponse
{
    public int Id { get; set; }
    public ConfirmationStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

