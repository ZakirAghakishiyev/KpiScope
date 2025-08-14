using Ardalis.SharedKernel;
using Entity=KpiScope.Core.CompanyAggregate;
using KpiScope.Web.Company.Create;
using KpiScope.Web.Company.Delete;
using KpiScope.Web.Company.GetById;
using KpiScope.Web.Company.List;
using KpiScope.Web.Company.Update;
using AM=AutoMapper;

namespace KpiScope.Web.Company;

public class CompanyEndpointService(IRepository<Entity.Company> _repository, AM.IMapper _mapper) : ICompanyEndpointService
{
    public async Task<CreateCompanyResponse> CreateAsync(CreateCompanyRequest request, CancellationToken ct)
    {
        if ((request is null) || string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Company name is required.");
        }
        var company = _mapper.Map<Entity.Company>(request);
        var createdCompany =await  _repository.AddAsync(company, ct);
        if (createdCompany is null)
        {
            throw new InvalidOperationException("Company creation failed.");
        }
        return _mapper.Map<CreateCompanyResponse>(createdCompany);
    }

    public async Task<DeleteCompanyResponse> DeleteAsync(int companyId, CancellationToken ct)
    {
        if (companyId <= 0)
        {
            throw new ArgumentException("Invalid company ID.");
        }

        var company = await _repository.GetByIdAsync(companyId, ct);
        if (company is null)
        {
            throw new InvalidOperationException("Company not found.");
        }

        await _repository.DeleteAsync(company, ct);
        return _mapper.Map<DeleteCompanyResponse>(company);
    }

    public async Task<GetCompanyByIdResponse> GetAsync(GetCompanyByIdRequest req, CancellationToken ct)
    {
        if (req is null || req.Id <= 0)
        {
            throw new ArgumentException("Invalid company ID.");
        }

        var company = await _repository.GetByIdAsync(req.Id, ct);
        if (company is null)
        {
            throw new InvalidOperationException("Company not found.");
        }

        return _mapper.Map<GetCompanyByIdResponse>(company);
    }

    public async Task<IEnumerable<ListCompanyResponse>> ListAsync(CancellationToken ct)
    {
        var companies = await _repository.ListAsync(ct);
        if (companies is null || !companies.Any())
        {
            throw new InvalidOperationException("No companies found.");
        }

        return companies.Select(c => _mapper.Map<ListCompanyResponse>(c));   
    }

    public async Task<UpdateCompanyResponse> UpdateAsync(UpdateCompanyRequest request, CancellationToken ct)
    {
        if (request is null || request.Id <= 0 || string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Invalid company data.");
        }

        var company = await _repository.GetByIdAsync(request.Id, ct);
        if (company is null)
        {
            throw new InvalidOperationException("Company not found.");
        }

        company.Name = request.Name;
        company.Address = request.Address;

        var updatedCompany = await _repository.UpdateAsync(company, ct);

        return _mapper.Map<UpdateCompanyResponse>(company);
    }
}
