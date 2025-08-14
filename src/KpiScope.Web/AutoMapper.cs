using AutoMapper;
using KpiGroupAggregate=KpiScope.Core.KpiGroupAggregate;
using KpiScope.Web.Company.Create;
using KpiScope.Web.Company.Delete;
using KpiScope.Web.Company.GetById;
using KpiScope.Web.Company.List;
using KpiScope.Web.Company.Update;
using ComapnyAgg=KpiScope.Core.CompanyAggregate;
using KpiScope.Web.KpiGroup.Create;
using KpiScope.Web.KpiGroup.Update;
using KpiScope.Web.KpiGroup.GetById;
using KpiScope.Web.KpiGroup.List;
using KpiScope.Web.KpiGroup.Delete;
using KpiScope.Web.KpiGroupCompany.Create;
using KpiScope.Web.KpiGroupCompany.Update;
using KpiScope.Web.KpiGroupCompany.GetById;
using KpiScope.Web.KpiGroupCompany.List;
using KpiScope.Web.KpiGroupCompany.Delete;
using KpiScope.Web.KpiGroup;
using KpiScope.Web.User;
using KpiScope.Web.Company;
using UserAgg=KpiScope.Core.UserAggregate;
using KpiScope.Web.Value.KpiValue.Update;
using KpiScope.Core.KpiAggregate;
using KpiScope.Web.Value.DynamicValue.Create;
using KpiScope.Web.Value.KpiValue.Create;
using KpiScope.Web.KPI.Create;
using KpiScope.Web.KPI.Update;
using KpiScope.Web.KPI.GetById;
using KpiScope.Web.KPI.Delete;
using KpiScope.Web.KPI.List;
using KpiScope.Web.KPI.AddValue;

namespace KpiScope.Web;

public class Automapper : Profile
{
    public Automapper()
    {
        CreateMap<ComapnyAgg.Company, CreateCompanyResponse>().ReverseMap();
        CreateMap<ComapnyAgg.Company, CreateCompanyRequest>().ReverseMap();
        CreateMap<ComapnyAgg.Company, UpdateCompanyRequest>().ReverseMap();
        CreateMap<ComapnyAgg.Company, UpdateCompanyResponse>().ReverseMap();
        CreateMap<ComapnyAgg.Company, DeleteCompanyResponse>().ReverseMap();
        CreateMap<ComapnyAgg.Company, GetCompanyByIdResponse>().ReverseMap();
        CreateMap<ComapnyAgg.Company, GetCompanyByIdRequest>().ReverseMap();
        CreateMap<ComapnyAgg.Company, ListCompanyResponse>().ReverseMap();

        CreateMap<KpiGroupAggregate.KpiGroup, CreateKpiGroupResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, CreateKpiGroupRequest>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, UpdateKpiGroupResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, UpdateKpiGroupRequest>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, GetKpiGroupByIdRequest>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, GetKpiGroupByIdResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, ListKpiGroupResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, DeleteKpiGroupResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroup, DeleteKpiGroupRequest>().ReverseMap();

        CreateMap<KpiGroupAggregate.KpiGroupCompany, CreateKpiGroupCompanyResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, CreateKpiGroupCompanyRequest>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, UpdateKpiGroupCompanyResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, UpdateKpiGroupCompanyRequest>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, GetKpiGroupCompanyByIdRequest>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, GetKpiGroupCompanyByIdResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, ListKpiGroupCompanyResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, DeleteKpiGroupCompanyResponse>().ReverseMap();
        CreateMap<KpiGroupAggregate.KpiGroupCompany, DeleteKpiGroupCompanyRequest>().ReverseMap();

        CreateMap<KpiGroupAggregate.KpiGroup, KpiGroupDto>();
        CreateMap<ComapnyAgg.Company, CompanyDto>();
        CreateMap<UserAgg.User, UserDto>();

        CreateMap<UpdateKpiValueRequest, KpiValue>()
            .ForMember(dest => dest.Value, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusEnum))
            .ReverseMap();
        CreateMap<KpiValue, UpdateKpiValueResponse>().ReverseMap();
        CreateMap<KpiValue, CreateKpiValueResponse>().ReverseMap();
        CreateMap<KpiValue, CreateKpiValueRequest>().ReverseMap();

        CreateMap<Kpi, CreateKpiResponse>().ReverseMap();
        CreateMap<Kpi, CreateKpiRequest>().ReverseMap();
        CreateMap<Kpi, UpdateKpiResponse>().ReverseMap();
        CreateMap<Kpi, UpdateKpiRequest>().ReverseMap();
        CreateMap<Kpi, GetKpiByIdRequest>().ReverseMap();
        CreateMap<Kpi, GetKpiByIdResponse>().ReverseMap();
        CreateMap<Kpi, ListKpiResponse>().ReverseMap();
        CreateMap<Kpi, DeleteKpiResponse>().ReverseMap();
        CreateMap<Kpi, DeleteKpiRequest>().ReverseMap();

        CreateMap<AddValueResponse, CreateKpiValueResponse>().ReverseMap();
        CreateMap<KpiValue, CreateKpiValueResponse>().ReverseMap();
        CreateMap<ListKpiResponse, CreateKpiValueResponse>().ReverseMap();
        CreateMap<KpiValue, CreateKpiValueRequest>().ReverseMap();
        CreateMap<KpiValue, KpiValueDto>().ReverseMap();
        
        CreateMap<CreateDynamicValueResponse, DynamicValue>().ReverseMap();
        CreateMap<CreateDynamicValueRequest, DynamicValue>().ReverseMap();
    }
}
