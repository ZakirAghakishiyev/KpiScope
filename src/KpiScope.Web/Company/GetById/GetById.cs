namespace KpiScope.Web.Company.GetById;

public class GetById(ICompanyEndpointService _companyService) : Endpoint<GetCompanyByIdRequest, GetCompanyByIdResponse>
{
    public override void Configure()
    {
        Get(GetCompanyByIdRequest.Route);
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetCompanyByIdRequest req, CancellationToken ct)
    {
        var company = await _companyService.GetAsync(req, ct);
        if (company == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(company, ct);
    }
}
