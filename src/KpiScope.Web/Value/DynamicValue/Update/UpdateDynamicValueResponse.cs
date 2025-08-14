namespace KpiScope.Web.Value.DynamicValue.Update;

public class UpdateDynamicValueResponse
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public string JsonValue { get; set; } = string.Empty;
}
