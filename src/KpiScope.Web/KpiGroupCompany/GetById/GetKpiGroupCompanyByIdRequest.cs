using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.KpiGroupCompany.GetById;

public class GetKpiGroupCompanyByIdRequest
{
    public const string Route = "/KpiGroupCompanies/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public required int Id { get; set; }
}
