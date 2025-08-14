namespace KpiScope.Web.KpiConfirmation.StartConfirmation;

public class StartKpiConfirmation(IKpiConfirmationEndpointService _endpointService):Endpoint<StartKpiConfirmationRequest, StartKpiConfirmationResponse>
{
    public override void Configure()
    {
        Post(StartKpiConfirmationRequest.BuildRoute());
        AllowAnonymous();
        Description(x => x.WithName("StartKpiConfirmation"));
    }
    
    public override async Task HandleAsync(StartKpiConfirmationRequest request, CancellationToken cancellationToken)
    {
        var response = await _endpointService.StartConfirmationAsync(request);
        await SendAsync(response, cancellation: cancellationToken);
    }
}
