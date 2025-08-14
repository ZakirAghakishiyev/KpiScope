namespace KpiScope.Web.Company.Update;

public class Update(ICompanyEndpointService _companyService):Endpoint<UpdateCompanyRequest, UpdateCompanyResponse>
{
    public override void Configure()
    {
        Put(UpdateCompanyRequest.Route);
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateCompanyRequest req, CancellationToken ct)
    {
        var company = await _companyService.UpdateAsync(req, ct);
        if (company == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(company, ct);
    }
}
