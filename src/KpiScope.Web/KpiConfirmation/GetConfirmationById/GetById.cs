namespace KpiScope.Web.KpiConfirmation.GetConfirmationById;

public class GetById(IKpiConfirmationEndpointService _endpointService) : EndpointWithoutRequest<GetKpiConfirmationResponse>
{
    public override void Configure()
    {
        Get("/kpiConfirmations/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<int>("id");
        var response = await _endpointService.GetConfirmationAsync(id);
        await SendAsync(response, cancellation: cancellationToken);
    }
}
