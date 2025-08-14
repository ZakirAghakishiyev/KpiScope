namespace KpiScope.Web.KpiConfirmation.RejectKpi;

public class RejectKpiStepRequest
{
    public const string Route = "/kpiConfirmations/{id}/reject";
    public static string BuildRoute() => Route;
    public int Id { get; set; }
    public int StepUserId { get; set; }
    public int KpiGroupCompanyId { get; set; }
    public int ConfirmationId { get; set; }
    public string Comment { get; set; } = string.Empty;
}

