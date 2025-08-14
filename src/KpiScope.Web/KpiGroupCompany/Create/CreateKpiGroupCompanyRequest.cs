namespace KpiScope.Web.KpiGroupCompany.Create;

public class CreateKpiGroupCompanyRequest
{
    public const string Route = "/KpiGroupCompanies";
    public static string BuildRoute() => Route;

    public required int KpiGroupId { get; set; }
    public required int CompanyId { get; set; }
    public required int UserId { get; set; }
}
