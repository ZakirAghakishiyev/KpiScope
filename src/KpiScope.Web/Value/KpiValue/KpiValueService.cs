using System.ComponentModel;
using Ardalis.SharedKernel;
using KpiScope.Web.KpiGroupCompany.Update;
using KpiAgg = KpiScope.Core.KpiAggregate;
using AM = AutoMapper;
using KpiScope.Web.Value.DynamicValue;
using KpiScope.Web.Value.KpiValue.Update;
using KpiScope.Web.Value.KpiValue.Create;
using KpiScope.Core.KpiAggregate.Specifications;
using System.Reflection.Metadata;
using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.Value.KpiValue;


public class KpiValueService(IRepository<KpiAgg.KpiValue> _repository, IDynamicValueService _valueService, AM.IMapper _mapper) : IKpiValueService
{
    public async Task<CreateKpiValueResponse> CreateKpiValueAsync(CreateKpiValueRequest kpiValue)
    {
        if (kpiValue == null)
            throw new ArgumentNullException(nameof(kpiValue), "KpiValue cannot be null.");
        var dynamicValue = await _valueService.CreateDynamicValueAsync(kpiValue.DynamicValue!);
        var newKpiValue = _mapper.Map<KpiAgg.KpiValue>(kpiValue);
        newKpiValue.ValueId=dynamicValue.Id;
        var createdKpiValue = await _repository.AddAsync(newKpiValue);
        if (createdKpiValue == null)
            throw new InvalidOperationException("Failed to create KpiValue.");
        return _mapper.Map<CreateKpiValueResponse>(createdKpiValue);
    }

    public async Task<int> DeleteKpiValueAsync(int id)
    {
        var kpiValue = await _repository.GetByIdAsync(id);
        if (kpiValue == null)
            throw new KeyNotFoundException($"KpiValue with ID {id} not found.");
        var deletedDynamicValue = await _repository.DeleteAsync(kpiValue);
        if (deletedDynamicValue < 1)
            throw new InvalidOperationException("Failed to delete KpiValue.");
        return id;
    }

    public async Task<KpiAgg.KpiValue> GetKpiValueAsync(int id)
    {
        var kpiValue = await _repository.FirstOrDefaultAsync(new KpiValueByIdSpec(id));
        if (kpiValue == null)
            throw new KeyNotFoundException($"KpiValue with ID {id} not found.");
        return kpiValue;
    }

    public Task<IEnumerable<KpiAgg.KpiValue>> ListKpiValuesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UpdateKpiValueResponse> UpdateKpiValueAsync(UpdateKpiValueRequest kpiValue)
    {
        if (kpiValue == null)
            throw new ArgumentNullException(nameof(kpiValue), "KpiValue cannot be null.");

        var existingKpiValue = await _repository.GetByIdAsync(kpiValue.Id);
        if (existingKpiValue == null)
        {
            throw new KeyNotFoundException($"KpiValue with ID {kpiValue.Id} not found.");
        }

        if(kpiValue.Value!=null)
            await _valueService.UpdateDynamicValueAsync(kpiValue.Id, kpiValue.Value);

        var updatedKpiValue = await _repository.UpdateAsync(existingKpiValue);
        if(updatedKpiValue<1)
            throw new InvalidOperationException("Failed to update KpiValue.");

        return _mapper.Map<UpdateKpiValueResponse>(existingKpiValue);
    }
}
