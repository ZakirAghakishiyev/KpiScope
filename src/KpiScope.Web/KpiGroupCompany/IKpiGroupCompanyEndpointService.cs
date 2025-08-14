using KpiScope.Web.KpiGroupCompany.Create;
using KpiScope.Web.KpiGroupCompany.Delete;
using KpiScope.Web.KpiGroupCompany.GetById;
using KpiScope.Web.KpiGroupCompany.Update;
using KpiScope.Web.KpiGroupCompany.List;

namespace KpiScope.Web.KpiGroupCompany;

public interface IKpiGroupCompanyEndpointService
{
    Task<CreateKpiGroupCompanyResponse> CreateAsync(CreateKpiGroupCompanyRequest req, CancellationToken ct);
    Task<UpdateKpiGroupCompanyResponse> UpdateAsync(UpdateKpiGroupCompanyRequest req, CancellationToken ct);
    Task<DeleteKpiGroupCompanyResponse> DeleteAsync(DeleteKpiGroupCompanyRequest req, CancellationToken ct);
    Task<GetKpiGroupCompanyByIdResponse> GetByIdAsync(GetKpiGroupCompanyByIdRequest req, CancellationToken ct);
    Task<IEnumerable<ListKpiGroupCompanyResponse>> ListAsync(CancellationToken ct);
}
