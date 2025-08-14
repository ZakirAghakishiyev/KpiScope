using KpiScope.Web.Value.DynamicValue.Create;

namespace KpiScope.Web.Value.KpiValue.Create;

public class CreateKpiValueRequest
{
    public int KpiId { get; set; }
    public required CreateDynamicValueRequest DynamicValue{ get; set; }
    public int StatusEnum { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
}
