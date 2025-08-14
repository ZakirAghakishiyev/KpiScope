using Microsoft.AspNetCore.Mvc;

namespace KpiScope.Web.Company.Update;

public class UpdateCompanyRequest
{
    public const string Route = "/Companies/{Id}";
    public static string BuildRoute() => Route;

    [FromRoute]
    public int Id { get; set; }

    public required string Name { get; set; } = string.Empty;
    public required string Address { get; set; } = string.Empty;
}
