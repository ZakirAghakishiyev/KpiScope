using KpiScope.Web.Company;
using KpiScope.Web.KpiGroup;
using KpiScope.Web.User;

namespace KpiScope.Web.KpiGroupCompany.GetById;

public class GetKpiGroupCompanyByIdResponse
{
        public required int Id { get; set; }
        public KpiGroupDto? KpiGroup { get; set; }
        public CompanyDto? Company { get; set; }
        public UserDto? Owner { get; set; }
}
