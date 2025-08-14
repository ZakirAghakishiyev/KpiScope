namespace KpiScope.Web.KpiGroup.List;

public class List(IKpiGroupEndpointService _endpointService) : EndpointWithoutRequest<IEnumerable<ListKpiGroupResponse>>
{
    public override void Configure()
    {
        Get("/KpiGroups");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await _endpointService.ListAsync(ct);
        await SendOkAsync(response, ct);
    }
}
