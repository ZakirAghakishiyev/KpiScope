namespace KpiScope.Core.KpiAggregate.Specifications;

public class KpiValueByIdSpec : Specification<KpiValue>
{
    public KpiValueByIdSpec(int id)
    {
        Query
            .Where(kv => kv.Id == id)
            .Include(kv => kv.Value);
    }
}
