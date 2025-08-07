using KpiScope.Core.BaseEntityAggregate;

namespace KpiScope.Core.KpiAggregate;

public class KpiValue : BaseEntity, IAggregateRoot
{
    public int KpiId { get; set; }
    public int ValueId { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Kpi? Kpi { get; set; }
    public DynamicValue? Value { get; set; }
}
