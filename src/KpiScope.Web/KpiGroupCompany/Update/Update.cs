namespace KpiScope.Web.KpiGroupCompany.Update;

public class Update(IKpiGroupCompanyEndpointService _endpointService) : Endpoint<UpdateKpiGroupCompanyRequest, UpdateKpiGroupCompanyResponse>
{
    public override void Configure()
    {
        Put(UpdateKpiGroupCompanyRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new UpdateKpiGroupCompanyRequest { Id = 1, UserId = 1 };
        });
    }

    public override async Task HandleAsync(UpdateKpiGroupCompanyRequest request, CancellationToken cancellationToken)
    {
        var result = await _endpointService.UpdateAsync(request, cancellationToken);

        if (result is null)
            return;
        await SendOkAsync(result, cancellationToken);
    }
}
