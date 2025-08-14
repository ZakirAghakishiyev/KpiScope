using KpiScope.Core.KpiAggregate;
using KpiScope.Web.Value.DynamicValue.Update;

namespace KpiScope.Web.Value.KpiValue.Update;

public class UpdateKpiValueRequest
{
    public int Id { get; set; }
    public UpdateDynamicValueRequest? Value { get; set; } 
    public StatusEnum StatusEnum { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
}
