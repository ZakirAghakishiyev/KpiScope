namespace KpiScope.Web.Value.KpiValue.Create;

public class CreateKpiValueResponse
{
    public int Id { get; set; }
    public int KpiId { get; set; }
    public int ValueId { get; set; }
    public int StatusEnum { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
}
