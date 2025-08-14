namespace KpiScope.Core.KpiGroupAggregate.Specifications;

public class KpiGroupCompanySpec : Specification<KpiGroupCompany>
{
    public KpiGroupCompanySpec()
    {
        Query
            .Include(k => k.KpiGroup)
            .Include(k => k.Company)
            .Include(k => k.Owner);
    }
}
