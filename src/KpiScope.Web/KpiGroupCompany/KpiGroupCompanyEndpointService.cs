using KpiGroupAgg=KpiScope.Core.KpiGroupAggregate;
using KpiScope.Web.KpiGroupCompany.Create;
using KpiScope.Web.KpiGroupCompany.Delete;
using KpiScope.Web.KpiGroupCompany.GetById;
using KpiScope.Web.KpiGroupCompany.List;
using KpiScope.Web.KpiGroupCompany.Update;
using AM = AutoMapper;
using Ardalis.SharedKernel;
using KpiScope.Core.KpiGroupAggregate.Specifications;
namespace KpiScope.Web.KpiGroupCompany;

public class KpiGroupCompanyEndpointService(IRepository<KpiGroupAgg.KpiGroupCompany> _repository,AM.IMapper _mapper) : IKpiGroupCompanyEndpointService
{
    public async Task<CreateKpiGroupCompanyResponse> CreateAsync(CreateKpiGroupCompanyRequest req, CancellationToken ct)
    {
        if (req is null)
            throw new ArgumentNullException(nameof(req), "Request cannot be null");
        var KpiGroupCompany = _mapper.Map<KpiGroupAgg.KpiGroupCompany>(req);
        var res = await _repository.AddAsync(KpiGroupCompany, ct);
        if (res is null)
            throw new Exception("Failed to create KpiGroupCompany");
        return _mapper.Map<CreateKpiGroupCompanyResponse>(res);
    }

    public async Task<DeleteKpiGroupCompanyResponse> DeleteAsync(DeleteKpiGroupCompanyRequest req, CancellationToken ct)
    {
        if (req is null)
            throw new ArgumentNullException(nameof(req), "Request cannot be null");
        var KpiGroupCompany = await _repository.GetByIdAsync(req.Id, ct);
        if (KpiGroupCompany is null)
            throw new KeyNotFoundException($"KpiGroupCompany with ID {req.Id} not found");
        await _repository.DeleteAsync(KpiGroupCompany, ct);
        return new DeleteKpiGroupCompanyResponse { Id = req.Id };
    }

    public async Task<GetKpiGroupCompanyByIdResponse> GetByIdAsync(GetKpiGroupCompanyByIdRequest req, CancellationToken ct)
    {
        if (req is null)
            throw new ArgumentNullException(nameof(req), "Request cannot be null");
        var spec = new KpiGroupCompanyByIdSpec(req.Id);
        var KpiGroupCompany = await _repository.FirstOrDefaultAsync(spec, ct);
        if (KpiGroupCompany is null)
            throw new KeyNotFoundException($"KpiGroupCompany with ID {req.Id} not found");  
        return _mapper.Map<GetKpiGroupCompanyByIdResponse>(KpiGroupCompany);
    }

    public async Task<IEnumerable<ListKpiGroupCompanyResponse>> ListAsync(CancellationToken ct)
    {
        var KpiGroupCompanies = await _repository.ListAsync(new KpiGroupCompanySpec(),ct);
        if (KpiGroupCompanies is null || !KpiGroupCompanies.Any())
            return Enumerable.Empty<ListKpiGroupCompanyResponse>();
        return _mapper.Map<IEnumerable<ListKpiGroupCompanyResponse>>(KpiGroupCompanies);
    }

    public async Task<UpdateKpiGroupCompanyResponse> UpdateAsync(UpdateKpiGroupCompanyRequest req, CancellationToken ct)
    {
        if (req is null)
            throw new ArgumentNullException(nameof(req), "Request cannot be null");
        var kpiGroupCompany = await _repository.GetByIdAsync(req.Id, ct);
        if (kpiGroupCompany is null)
            throw new KeyNotFoundException($"KpiGroupCompany with ID {req.Id} not found");
        _mapper.Map(req, kpiGroupCompany);
        var updatedKpiGroupCompany = await _repository.UpdateAsync(kpiGroupCompany, ct);
        if (updatedKpiGroupCompany <1)
            throw new Exception("Failed to update KpiGroupCompany");    
        return _mapper.Map<UpdateKpiGroupCompanyResponse>(kpiGroupCompany);
    }
}
