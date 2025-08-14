using KpiScope.Core.KpiAggregate;
using KpiScope.Web.Value.DynamicValue.Create;
using KpiScope.Web.Value.DynamicValue.Update;
using KpiAgg=KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.Value.DynamicValue;

public interface IDynamicValueService
{
    public Task<dynamic> GetDynamicValueAsync(int id);
    public Task<CreateDynamicValueResponse> CreateDynamicValueAsync(CreateDynamicValueRequest dynamicValue);
    public Task<KpiAgg.DynamicValue> DeleteDynamicValueAsync(int id);
    public Task<UpdateDynamicValueResponse> UpdateDynamicValueAsync(int id,UpdateDynamicValueRequest dynamicValue);
    public Task<IEnumerable<KpiAgg.DynamicValue>> ListDynamicValueAsync();
}