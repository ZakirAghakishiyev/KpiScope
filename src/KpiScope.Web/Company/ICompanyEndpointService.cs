using KpiScope.Web.Company.Create;
using KpiScope.Web.Company.Delete;
using KpiScope.Web.Company.GetById;
using KpiScope.Web.Company.List;
using KpiScope.Web.Company.Update;

namespace KpiScope.Web.Company;

public interface ICompanyEndpointService
{
    public Task<GetCompanyByIdResponse> GetAsync(GetCompanyByIdRequest req, CancellationToken ct);
    public Task<IEnumerable<ListCompanyResponse>> ListAsync(CancellationToken ct);
    public Task<CreateCompanyResponse> CreateAsync(CreateCompanyRequest request, CancellationToken ct);
    public Task<UpdateCompanyResponse> UpdateAsync(UpdateCompanyRequest request, CancellationToken ct);
    public Task<DeleteCompanyResponse> DeleteAsync(int companyId, CancellationToken ct);
}
