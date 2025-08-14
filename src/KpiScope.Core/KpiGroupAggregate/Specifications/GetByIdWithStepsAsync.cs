namespace KpiScope.Core.KpiGroupAggregate.Specifications;

public class GetByIdWithStepsAsync: Specification<KpiConfirmation>
{
    public GetByIdWithStepsAsync(int id)
    {
        Query
            .Where(c => c.Id == id)
            .Include(c => c.Steps)
            .ThenInclude(s => s.Approvers)
            .ThenInclude(u => u.User);
    }
}
