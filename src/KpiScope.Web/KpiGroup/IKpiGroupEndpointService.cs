using KpiScope.Web.KpiGroup.Create;
using KpiScope.Web.KpiGroup.Delete;
using KpiScope.Web.KpiGroup.GetById;
using KpiScope.Web.KpiGroup.List;
using KpiScope.Web.KpiGroup.Update;

namespace KpiScope.Web.KpiGroup;

public interface IKpiGroupEndpointService
{
    public Task<IEnumerable<ListKpiGroupResponse>> ListAsync(CancellationToken ct);
    public Task<CreateKpiGroupResponse> CreateAsync(CreateKpiGroupRequest req, CancellationToken ct);
    public Task<UpdateKpiGroupResponse> UpdateAsync(UpdateKpiGroupRequest req, CancellationToken ct);
    public Task<DeleteKpiGroupResponse> DeleteAsync(DeleteKpiGroupRequest req, CancellationToken ct);
    public Task<GetKpiGroupByIdResponse> GetAsync(GetKpiGroupByIdRequest req, CancellationToken ct);
}
