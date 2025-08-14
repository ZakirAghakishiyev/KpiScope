namespace KpiScope.Web.KpiConfirmation.ConfirmKpi;

public class Confirm(IKpiConfirmationEndpointService _endpointService) : Endpoint<ConfirmKpiStepRequest, ConfirmKpiStepResponse>
{
    public override void Configure()
    {
        Post(ConfirmKpiStepRequest.BuildRoute());
        AllowAnonymous();
        Description(x => x.WithName("ConfirmKpi"));
    }
    
    public override async Task HandleAsync(ConfirmKpiStepRequest request, CancellationToken cancellationToken)
    {
        var response = await _endpointService.ConfirmKpiAsync(request);
        await SendAsync(response, cancellation: cancellationToken);
    }
}
