namespace KpiScope.Web.Company.List;

public class List(ICompanyEndpointService _companyService) : EndpointWithoutRequest<IEnumerable<ListCompanyResponse>>
{
    public override void Configure()
    {
        Get("/Companies");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var companies = await _companyService.ListAsync(cancellationToken);
        if (companies == null || !companies.Any())
        {
            await SendNotFoundAsync(cancellation: cancellationToken);
            return;
        }

        await SendOkAsync(companies, cancellation: cancellationToken);
    }
}
