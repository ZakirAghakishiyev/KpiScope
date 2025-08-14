namespace KpiScope.Web.Company;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public required string Address { get; set; } = string.Empty;
}
