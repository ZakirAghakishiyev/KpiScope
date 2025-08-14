using KpiScope.Web.KPI.AddValue;
using KpiScope.Web.KPI.Create;
using KpiScope.Web.KPI.Delete;
using KpiScope.Web.KPI.GetById;
using KpiScope.Web.KPI.List;
using KpiScope.Web.KPI.Update;

namespace KpiScope.Web.KPI;

public interface IKpiEndpointService
{
    public Task<GetKpiByIdResponse> GetKpiByIdAsync(GetKpiByIdRequest request, CancellationToken ct);
    public Task<CreateKpiResponse> CreateKpiAsync(CreateKpiRequest request, CancellationToken ct);
    public Task<DeleteKpiResponse> DeleteKpiAsync(DeleteKpiRequest request, CancellationToken ct);
    public Task<UpdateKpiResponse> UpdateKpiAsync(UpdateKpiRequest request, CancellationToken ct);
    public Task<IEnumerable<ListKpiResponse>> ListKpiAsync(CancellationToken ct);
    public Task<AddValueResponse> AddValueAsync(AddValueRequest request, CancellationToken ct);
}
