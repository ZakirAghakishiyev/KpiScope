namespace KpiScope.Web.Value.DynamicValue.Create;

public class CreateDynamicValueResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string JsonValue { get; set; } = string.Empty;
}
