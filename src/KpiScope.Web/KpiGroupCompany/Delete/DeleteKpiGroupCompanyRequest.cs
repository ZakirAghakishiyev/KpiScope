using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KpiGroupCompany.Delete;

public class DeleteKpiGroupCompanyRequest
{
    public const string Route = "/KpiGroupCompanies/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public required int Id { get; set; }
}
