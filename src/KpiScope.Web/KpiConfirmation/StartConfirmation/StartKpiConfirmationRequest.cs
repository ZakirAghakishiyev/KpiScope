namespace KpiScope.Web.KpiConfirmation.StartConfirmation;

public class StartKpiConfirmationRequest
{
    public const string Route = "/kpiConfirmations";
    public static string BuildRoute() => Route;
    public int KpiGroupCompanyId { get; set; }
    public DateTime PeriodStart { get; set; } 
    public DateTime PeriodEnd { get; set; }
}
