namespace KpiScope.Web.KpiGroup.Delete;

public class Delete(IKpiGroupEndpointService _endpointService) : Endpoint<DeleteKpiGroupRequest, DeleteKpiGroupResponse>
{
    public override void Configure()
    {
        Delete(DeleteKpiGroupRequest.BuildRoute());
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteKpiGroupRequest req, CancellationToken ct)
    {
        var response = await _endpointService.DeleteAsync(req, ct);
        await SendOkAsync(response, ct);
    }
}
