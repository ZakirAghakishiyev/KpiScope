using Entity=KpiScope.Core.CompanyAggregate;
namespace KpiScope.Web.Company.Create;

public class Create(ICompanyEndpointService _companyService) : Endpoint<CreateCompanyRequest, CreateCompanyResponse>
{
    public override void Configure()
    {
        Post(CreateCompanyRequest.Route);
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = await _companyService.CreateAsync(request, cancellationToken);

        await SendOkAsync(company, cancellation: cancellationToken);
    }
}

