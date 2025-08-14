namespace KpiScope.Web.KpiGroupCompany.Delete;

public class Delete(IKpiGroupCompanyEndpointService _endpointService) : Endpoint<DeleteKpiGroupCompanyRequest, DeleteKpiGroupCompanyResponse>
{
    public override void Configure()
    {
        Delete(DeleteKpiGroupCompanyRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new DeleteKpiGroupCompanyRequest { Id = 1 };
        });
    }
    
    public override async Task HandleAsync(DeleteKpiGroupCompanyRequest request, CancellationToken cancellationToken)
    {
        var result = await _endpointService.DeleteAsync(request, cancellationToken);

        if (result is null)
            return;
        await SendOkAsync(result, cancellationToken);
    }
}
