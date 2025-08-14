using KpiScope.Core.KpiAggregate;

namespace KpiScope.Web.Value.DynamicValue.Update;



public class UpdateDynamicValueRequest:Request
{
    public required string Name { get; set; }
}
