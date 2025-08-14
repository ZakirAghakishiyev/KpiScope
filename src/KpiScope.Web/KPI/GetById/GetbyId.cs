namespace KpiScope.Web.KPI.GetById;

public class GetbyId(IKpiEndpointService _endpointService):Endpoint<GetKpiByIdRequest, GetKpiByIdResponse>
{
    public override void Configure()
    {
        Get(GetKpiByIdRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetKpiByIdRequest request, CancellationToken ct)
    {
        var response = await _endpointService.GetKpiByIdAsync(request, ct);
        await SendOkAsync(response, ct);
    }
}
