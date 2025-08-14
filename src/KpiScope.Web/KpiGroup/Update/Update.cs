namespace KpiScope.Web.KpiGroup.Update;

public class Update(IKpiGroupEndpointService _endpointService) : Endpoint<UpdateKpiGroupRequest, UpdateKpiGroupResponse>
{
    public override void Configure()
    {
        Put(UpdateKpiGroupRequest.BuildRoute());
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateKpiGroupRequest req, CancellationToken ct)
    {
        var response = await _endpointService.UpdateAsync(req, ct);
        await SendOkAsync(response, ct);
    }
}
