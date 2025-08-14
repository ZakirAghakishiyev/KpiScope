using KpiScope.Web.KpiGroup;
using KpiScope.Web.User;

namespace KpiScope.Web.KpiGroupCompany.Create;

public class CreateKpiGroupCompanyResponse
{
    public required int Id { get; set; }
    public required int KpiGroupId { get; set; }
    public required int CompanyId { get; set; }
    public required int UserId { get; set; }
}
