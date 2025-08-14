using Ardalis.SharedKernel;
using KGAgg=KpiScope.Core.KpiGroupAggregate;
using KpiScope.Web.KpiGroup.Create;
using KpiScope.Web.KpiGroup.Delete;
using KpiScope.Web.KpiGroup.GetById;
using KpiScope.Web.KpiGroup.List;
using KpiScope.Web.KpiGroup.Update;
using AM=AutoMapper;
using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.KpiGroup;

public class KpiGroupEndpointService(IRepository<KGAgg.KpiGroup> _repository, AM.IMapper _mapper) : IKpiGroupEndpointService
{
    public async Task<CreateKpiGroupResponse> CreateAsync(CreateKpiGroupRequest req, CancellationToken ct)
    {
        if (req is null || string.IsNullOrWhiteSpace(req.Name))
        {
            throw new ArgumentException("KPI Group name is required.");
        }

        var kpiGroup = _mapper.Map<KGAgg.KpiGroup>(req);
        var createdKpiGroup = await _repository.AddAsync(kpiGroup, ct);
        if (createdKpiGroup is null)
        {
            throw new InvalidOperationException("KPI Group creation failed.");
        }
        return _mapper.Map<CreateKpiGroupResponse>(createdKpiGroup);
    }

    public async Task<DeleteKpiGroupResponse> DeleteAsync(DeleteKpiGroupRequest req, CancellationToken ct)
    {
        if (req is null || req.Id <= 0)
        {
            throw new ArgumentException("Invalid KPI Group ID.");
        }

        var kpiGroup = await _repository.GetByIdAsync(req.Id, ct);
        if (kpiGroup is null)
        {
            throw new InvalidOperationException("KPI Group not found.");
        }

        await _repository.DeleteAsync(kpiGroup, ct);
        return _mapper.Map<DeleteKpiGroupResponse>(kpiGroup);
    }

    public async Task<GetKpiGroupByIdResponse> GetAsync(GetKpiGroupByIdRequest req, CancellationToken ct)
    {
        if (req is null || req.Id <= 0)
        {
            throw new ArgumentException("Invalid KPI Group ID.");
        }

        var kpiGroup = await _repository.GetByIdAsync(req.Id, ct);
        if (kpiGroup is null)
        {
            throw new InvalidOperationException("KPI Group not found.");
        }

        return _mapper.Map<GetKpiGroupByIdResponse>(kpiGroup);
    }

    public async Task<IEnumerable<ListKpiGroupResponse>> ListAsync(CancellationToken ct)
    {
        var kpiGroups = await _repository.ListAsync(ct);
        return _mapper.Map<IEnumerable<ListKpiGroupResponse>>(kpiGroups);
    }

    public async Task<UpdateKpiGroupResponse> UpdateAsync(UpdateKpiGroupRequest req, CancellationToken ct)
    {
        if (req is null || req.Id <= 0 || string.IsNullOrWhiteSpace(req.Name))
        {
            throw new ArgumentException("Invalid KPI Group data.");
        }

        var kpiGroup = await _repository.GetByIdAsync(req.Id, ct);
        if (kpiGroup is null)
        {
            throw new InvalidOperationException("KPI Group not found.");
        }

        kpiGroup.Name = req.Name;
        var updatedKpiGroup = await _repository.UpdateAsync(kpiGroup, ct);
        var res=new UpdateKpiGroupResponse
        {
            Id = req.Id,
            Name=kpiGroup.Name
        };
        return res;
    }
}
