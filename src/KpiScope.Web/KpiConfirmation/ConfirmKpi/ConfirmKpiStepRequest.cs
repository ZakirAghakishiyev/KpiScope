namespace KpiScope.Web.KpiConfirmation.ConfirmKpi;

public class ConfirmKpiStepRequest
{
    public const string Route = "/kpiConfirmations/{id}/confirm";
    public static string BuildRoute() => Route;
    public int Id { get; set; }
    public int StepUserId { get; set; }
    public int KpiGroupCompanyId { get; set; }
    public int ConfirmationId { get; set; }
    public string Comment { get; set; } = string.Empty;
}
