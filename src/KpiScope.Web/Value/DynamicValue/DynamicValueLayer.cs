using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.Value.DynamicValue;

public class DynamicValueLayer
{
    public required TypeEnum Type { get; set; }
    public required dynamic Value { get; set; }
}
