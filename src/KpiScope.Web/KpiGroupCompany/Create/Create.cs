namespace KpiScope.Web.KpiGroupCompany.Create;

public class Create(IKpiGroupCompanyEndpointService _endpointService) : Endpoint<CreateKpiGroupCompanyRequest, CreateKpiGroupCompanyResponse>
{
    public override void Configure()
    {
        Post(CreateKpiGroupCompanyRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreateKpiGroupCompanyRequest { KpiGroupId = 1, CompanyId = 1, UserId = 1 };
        });
    }
    
    public override async Task HandleAsync(CreateKpiGroupCompanyRequest request, CancellationToken cancellationToken)
    {
        var result = await _endpointService.CreateAsync(request, cancellationToken);

        if (result is null)
            return;
        await SendOkAsync(result, cancellationToken);
    }
}
