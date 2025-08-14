using KpiScope.Core.KpiAggregate;
using KpiScope.Web.KPI.List;
using KpiScope.Web.KpiGroup;
using KGroupAgg=KpiScope.Core.KpiGroupAggregate;

namespace KpiScope.Web.KPI.GetById;

public class GetKpiByIdResponse
{
    public int Id { set; get; }
    public required string Name { get; set; }
    public GriEnum GriIndex { set; get; }
    public PeriodEnum TimePeriod { get; set; }
    public KpiGroupDto? KpiGroup { get; set; }
    //public List<KpiValueDto> KpiValues { get; set; } = [];
    public List<dynamic> JsonValues { get; set; }=[];
}

public class KpiValueDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DynamicValue? Value { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}