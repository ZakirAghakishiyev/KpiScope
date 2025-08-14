namespace KpiScope.Web.Company.Delete;

public class Delete(ICompanyEndpointService _companyService) : Endpoint<DeleteCompanyRequest, DeleteCompanyResponse>
{
    public override void Configure()
    {
        Delete(DeleteCompanyRequest.Route);;
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteCompanyRequest req, CancellationToken cancellationToken)
    {
        var company = await _companyService.DeleteAsync(req.Id, cancellationToken);

        if (company == null)
        {
            await SendNotFoundAsync(cancellation: cancellationToken);
            return;
        }

        await SendOkAsync(company, cancellation: cancellationToken);
    }
}
