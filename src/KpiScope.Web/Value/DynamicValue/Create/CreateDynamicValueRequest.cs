using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.Value.DynamicValue.Create;

public class CreateDynamicValueRequest:Request
{
    public required string Name { get; set; }
}

