namespace KpiScope.Web.KpiConfirmation.RejectKpi;

public class Reject(IKpiConfirmationEndpointService _endpointService):Endpoint<RejectKpiStepRequest, RejectKpiStepResponse>
{
    public override void Configure()
    {
        Post(RejectKpiStepRequest.BuildRoute());
        AllowAnonymous();
        Description(x => x.WithName("RejectKpi"));
    }
    
    public override async Task HandleAsync(RejectKpiStepRequest request, CancellationToken cancellationToken)
    {
        var response = await _endpointService.RejectKpiAsync(request);
        await SendAsync(response, cancellation: cancellationToken);
    }
}

