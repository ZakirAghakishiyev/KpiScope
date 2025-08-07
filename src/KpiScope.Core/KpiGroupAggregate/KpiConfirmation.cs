using KpiScope.Core.BaseEntityAggregate;
using KpiScope.Core.KpiAggregate;

namespace KpiScope.Core.KpiGroupAggregate;

public class KpiConfirmation : BaseEntity, IAggregateRoot
{
    public int KpiGroupCompanyId { get; set; }
    public int StepNumber { get; set; }
    public List<KpiValue> KpiValues { get; set; } = [];
    public List<KpiConfirmationUser> ConfirmationStepUsers { set; get; } = [];
    public KpiGroupCompany? KpiGroup { get; set; }

}
