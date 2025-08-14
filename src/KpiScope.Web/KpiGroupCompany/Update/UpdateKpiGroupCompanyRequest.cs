using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KpiGroupCompany.Update;

public class UpdateKpiGroupCompanyRequest
{
    public const string Route = "/KpiGroupCompanies/{Id}";
    public static string BuildRoute() => Route;
    [FromRoute]
    public required int Id { get; set; }
    public required int UserId { get; set; }
}
