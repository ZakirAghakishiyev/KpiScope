namespace KpiScope.Web.KPI.List;

public class List(IKpiEndpointService _endpointService):EndpointWithoutRequest<IEnumerable<ListKpiResponse>>
{
    public override void Configure()
    {
        Get("/Kpi");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await _endpointService.ListKpiAsync(ct);
        await SendOkAsync(response, ct);
    }
}
