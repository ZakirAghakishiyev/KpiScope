namespace KpiScope.Web.KPI.Delete;

public class Delete(IKpiEndpointService _endpointService):Endpoint<DeleteKpiRequest, DeleteKpiResponse>
{
    public override void Configure()
    {
        Delete(DeleteKpiRequest.Route);
        AllowAnonymous();
    }


    public override async Task HandleAsync(DeleteKpiRequest request, CancellationToken ct)
    {
        var response = await _endpointService.DeleteKpiAsync(request, ct);
        await SendAsync(response, cancellation: ct);
    }
}
