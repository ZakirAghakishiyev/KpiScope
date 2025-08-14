namespace KpiScope.Web.Company.Create;

public class CreateCompanyResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Address { get; set; } = string.Empty;
}
