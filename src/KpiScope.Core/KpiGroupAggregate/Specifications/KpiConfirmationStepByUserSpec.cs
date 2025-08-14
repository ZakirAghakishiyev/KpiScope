namespace KpiScope.Core.KpiGroupAggregate.Specifications;

public class KpiConfirmationStepByUserSpec : Specification<KpiConfirmationStep>
{
    public KpiConfirmationStepByUserSpec(int confirmationId, int userId)
    {
        Query
            .Where(s => s.KpiConfirmationId == confirmationId)
            .Include(s => s.Approvers)
            .Include(s => s.KpiConfirmation)
            .Where(s => s.Approvers.Any(a => a.UserId == userId));
    }
}
