using KpiScope.Web.KpiConfirmation.ConfirmKpi;
using KpiScope.Web.KpiConfirmation.GetConfirmationById;
using KpiScope.Web.KpiConfirmation.GetConfirmationStepsById;
using KpiScope.Web.KpiConfirmation.RejectKpi;
using KpiScope.Web.KpiConfirmation.StartConfirmation;

namespace KpiScope.Web.KpiConfirmation;

public interface IKpiConfirmationEndpointService
{
    public Task<RejectKpiStepResponse> RejectKpiAsync(RejectKpiStepRequest request);
    public Task<ConfirmKpiStepResponse> ConfirmKpiAsync(ConfirmKpiStepRequest request);
    public Task<GetKpiConfirmationResponse> GetConfirmationAsync(int id);
    public Task<GetKpiConfirmationStepsResponse> GetConfirmationStepAsync(int id);
    public Task<StartKpiConfirmationResponse> StartConfirmationAsync(StartKpiConfirmationRequest request); 
}
