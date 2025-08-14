using Ardalis.SharedKernel;
using AM=AutoMapper;
using KpiScope.Core.KpiAggregate;
using KpiScope.Web.KPI.Create;
using KpiScope.Web.KPI.Delete;
using KpiScope.Web.KPI.GetById;
using KpiScope.Web.KPI.List;
using KpiScope.Web.KPI.Update;
using KpiScope.Core.KpiAggregate.Specifications;
using KpiScope.Web.KPI.AddValue;
using KpiScope.Web.Value.KpiValue;
using System.Text.Json;
using Namotion.Reflection;

namespace KpiScope.Web.KPI;

public class KpiEndpointService(IRepository<Kpi> _repository, IKpiValueService _valueService, AM.IMapper _mapper) : IKpiEndpointService
{
    public async Task<AddValueResponse> AddValueAsync(AddValueRequest request, CancellationToken ct)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "AddValueRequest cannot be null.");

        var kpiValueResponse =await _valueService.CreateKpiValueAsync(request.KpiValue);
        if (kpiValueResponse == null)
            throw new InvalidOperationException("Failed to add KPI value.");

        var res = new AddValueResponse
        {
            KpiValues = new List<ListKpiResponse> { _mapper.Map<ListKpiResponse>(kpiValueResponse) }
        };
        return res;
    }

    public async Task<CreateKpiResponse> CreateKpiAsync(CreateKpiRequest request, CancellationToken ct)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "CreateKpiRequest cannot be null.");

        var kpi = _mapper.Map<Kpi>(request);
        var createdKpi = await _repository.AddAsync(kpi,ct);
        if (createdKpi == null)
        {
            throw new InvalidOperationException("Failed to create KPI.");
        }
        return _mapper.Map<CreateKpiResponse>(createdKpi);
    }

    public async Task<DeleteKpiResponse> DeleteKpiAsync(DeleteKpiRequest request, CancellationToken ct)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "DeleteKpiRequest cannot be null.");

        var kpi = await _repository.GetByIdAsync(request.Id,ct);
        if (kpi == null)
        {
            throw new KeyNotFoundException($"KPI with ID {request.Id} not found.");
        }

        await _repository.DeleteAsync(kpi);
        return _mapper.Map<DeleteKpiResponse>(kpi);
    }

    public async Task<GetKpiByIdResponse> GetKpiByIdAsync(GetKpiByIdRequest request, CancellationToken ct)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "GetKpiByIdRequest cannot be null.");

        var kpi = await _repository.FirstOrDefaultAsync(new KpiByIdSpec(request.Id), ct);
        if (kpi == null)
        {
            throw new KeyNotFoundException($"KPI with ID {request.Id} not found.");
        }
        var res = _mapper.Map<GetKpiByIdResponse>(kpi);
        foreach (var item in kpi.KpiValues)
        {
            if (item.Value == null)
                continue;
            var json = JsonSerializer.Deserialize<dynamic>(item.Value.JsonValue)!;
            res.JsonValues.Add(json);
        }
        return res;
    }

    public async Task<IEnumerable<ListKpiResponse>> ListKpiAsync(CancellationToken ct)
    {
        var kpis = await _repository.ListAsync(new KpiSpec(), ct);
        if (kpis == null || !kpis.Any())
        {
            throw new InvalidOperationException("No KPIs found.");
        }
        var res = _mapper.Map<IEnumerable<ListKpiResponse>>(kpis);
        return res;
    }

    public Task<UpdateKpiResponse> UpdateKpiAsync(UpdateKpiRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

}
