namespace KpiScope.Web.KpiGroup.Create;

public class CreateKpiGroupRequest
{
    public const string Route = "/KpiGroups";
    public static string BuildRoute() => Route;

    public required string Name { get; set; } = string.Empty;
}
