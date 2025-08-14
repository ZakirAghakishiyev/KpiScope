namespace KpiScope.Core.KpiAggregate.Specifications;

public class KpiSpec : Specification<Kpi>
{
    public KpiSpec()
    {
        Query
            .Include(k => k.KpiGroup)
            .Include(k => k.KpiValues)
            .ThenInclude(kv => kv.Value);
    }
    
}
