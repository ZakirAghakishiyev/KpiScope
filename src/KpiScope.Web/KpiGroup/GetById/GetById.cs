namespace KpiScope.Web.KpiGroup.GetById;

public class GetById(IKpiGroupEndpointService _endpointService) : Endpoint<GetKpiGroupByIdRequest, GetKpiGroupByIdResponse>
{
    public override void Configure()
    {
        Get(GetKpiGroupByIdRequest.BuildRoute());
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetKpiGroupByIdRequest req, CancellationToken ct)
    {
        var response = await _endpointService.GetAsync(req, ct);
        await SendOkAsync(response, ct);
    }
}
