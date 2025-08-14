using KpiScope.Core.BaseEntityAggregate;

namespace KpiScope.Core.KpiAggregate;

public class DynamicValue : BaseEntity, IAggregateRoot
{
    public List<TypeEnum> Types { get; set; } = [];
    public required string JsonValue { get; set; }
    public string? Name { get; set; }
}
