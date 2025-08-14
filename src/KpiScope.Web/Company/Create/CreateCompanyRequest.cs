namespace KpiScope.Web.Company.Create;

public class CreateCompanyRequest
{
    public const string Route = "/Companies";
    public static string BuildRoute() => Route;

    public required string Name { get; set; } = string.Empty;
    public required string Address { get; set; } = string.Empty;
}
