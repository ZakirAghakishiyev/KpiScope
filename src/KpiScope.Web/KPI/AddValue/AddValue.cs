namespace KpiScope.Web.KPI.AddValue;

public class AddValue(IKpiEndpointService _endpointService) : Endpoint<AddValueRequest, AddValueResponse>
{
    public override void Configure()
    {
        Post(AddValueRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddValueRequest request, CancellationToken ct)
    {
        var response = await _endpointService.AddValueAsync(request, ct);
        await SendAsync(response, cancellation: ct);
    }
}
