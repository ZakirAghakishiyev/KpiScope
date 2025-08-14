using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.Company.Delete;

public class DeleteCompanyRequest
{
    public const string Route = "/Companies/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }
}