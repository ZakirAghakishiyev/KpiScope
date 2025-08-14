using System.Security;
using KpiScope.Web.KpiGroupCompany.Update;
using KpiScope.Web.Value.KpiValue.Create;
using KpiScope.Web.Value.KpiValue.Update;
using KpiAgg=KpiScope.Core.KpiAggregate;
namespace KpiScope.Web.Value.KpiValue;

public interface IKpiValueService
{
    public Task<KpiAgg.KpiValue> GetKpiValueAsync(int id);
    public Task<CreateKpiValueResponse> CreateKpiValueAsync(CreateKpiValueRequest kpiValue);
    public Task<int> DeleteKpiValueAsync(int id);
    public Task<UpdateKpiValueResponse> UpdateKpiValueAsync(UpdateKpiValueRequest kpiValue);
    public Task<IEnumerable<KpiAgg.KpiValue>> ListKpiValuesAsync();
}
