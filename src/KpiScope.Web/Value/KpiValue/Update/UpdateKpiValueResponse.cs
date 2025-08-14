using KpiScope.Web.Value.DynamicValue.Update;

namespace KpiScope.Web.Value.KpiValue.Update;

public class UpdateKpiValueResponse
{
    public int Id { get; set; }
    public int KpiId { get; set; }
    public UpdateDynamicValueResponse? Value { get; set; } 
    public string StatusEnum { get; set; }= string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
}
