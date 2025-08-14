namespace KpiScope.Web.KpiGroup.Create;

public class Create(IKpiGroupEndpointService _endpointService) : Endpoint<CreateKpiGroupRequest, CreateKpiGroupResponse>
{
    public override void Configure()
    {
        Post(CreateKpiGroupRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreateKpiGroupRequest { Name = "KPI Group Name" };
        });
    }

    public override async Task HandleAsync(CreateKpiGroupRequest request, CancellationToken cancellationToken)
    {
        var result = await _endpointService.CreateAsync(request, cancellationToken);

        if (result is null)
        {
            return;
        }
        await SendOkAsync(result, cancellationToken);
    }
}
