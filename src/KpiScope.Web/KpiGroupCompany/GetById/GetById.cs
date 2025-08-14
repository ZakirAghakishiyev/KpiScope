using Microsoft.VisualBasic.FileIO;

namespace KpiScope.Web.KpiGroupCompany.GetById;

public class GetById(IKpiGroupCompanyEndpointService _endpointService):Endpoint<GetKpiGroupCompanyByIdRequest, GetKpiGroupCompanyByIdResponse>
{
    public override void Configure()
    {
        Get(GetKpiGroupCompanyByIdRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new GetKpiGroupCompanyByIdRequest { Id = 1 };
        });
    }

    public override async Task HandleAsync(GetKpiGroupCompanyByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _endpointService.GetByIdAsync(request, cancellationToken);

        if (result is null)
            return;
        await SendOkAsync(result, cancellationToken);
    }
}
