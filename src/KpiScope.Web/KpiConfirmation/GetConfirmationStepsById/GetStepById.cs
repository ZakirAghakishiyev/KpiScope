namespace KpiScope.Web.KpiConfirmation.GetConfirmationStepsById;

public class GetStepById(IKpiConfirmationEndpointService _endpointService):EndpointWithoutRequest<GetKpiConfirmationStepsResponse>
{
    public override void Configure()
    {
        Get("/kpiConfirmations/{id}/steps");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var id = Route<int>("id");
        var response = await _endpointService.GetConfirmationStepAsync(id);
        await SendOkAsync(response, cancellationToken);
    }
}
