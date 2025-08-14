using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.Company.GetById;

public class GetCompanyByIdRequest
{
    public const string Route = "/Companies/{Id}";
    public static string BuildRoute() => Route;
    [FromRoute]
    public int Id { get; set; }
}
