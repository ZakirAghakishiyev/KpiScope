namespace KpiScope.Web.KPI.Create;

public class Create(IKpiEndpointService _enpointService) : Endpoint<CreateKpiRequest, CreateKpiResponse>
{
    public override void Configure()
    {
        Post(CreateKpiRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateKpiRequest request, CancellationToken cancellationToken)
    {
        var response = await _enpointService.CreateKpiAsync(request, cancellationToken);
        await SendAsync(response, cancellation: cancellationToken);
    }
}
