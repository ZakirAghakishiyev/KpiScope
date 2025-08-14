namespace KpiScope.Core.KpiAggregate.Specifications;

public class KpiByIdSpec : Specification<Kpi>
{
    public KpiByIdSpec(int id)
    {
        Query
            .Where(k => k.Id == id)
            .Include(k => k.KpiGroup)
            .Include(k => k.KpiValues)
            .ThenInclude(kv => kv.Value);
    }
    
}
