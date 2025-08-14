namespace KpiScope.Web.KpiGroupCompany.List;

public class List(IKpiGroupCompanyEndpointService _endpointService):EndpointWithoutRequest<IEnumerable<ListKpiGroupCompanyResponse>>
{
    public override void Configure()
    {
        Get("/KpiGroupCompanies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _endpointService.ListAsync(cancellationToken);
        await SendOkAsync(result, cancellationToken);
    }
}
