namespace KpiScope.Core.KpiGroupAggregate.Specifications;

public class KpiGroupCompanyByIdSpec : Specification<KpiGroupCompany>
{
    public KpiGroupCompanyByIdSpec(int id)
    {
        Query
            .Where(k=> k.Id == id)
            .Include(k => k.KpiGroup)
            .Include(k => k.Company)
            .Include(k => k.Owner);
    }
}
