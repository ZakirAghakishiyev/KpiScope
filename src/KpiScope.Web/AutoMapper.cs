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
using ConfAgg=KpiScope.Core.KpiGroupAggregate;
using KpiScope.Web.Value.DynamicValue.Create;
using KpiScope.Web.Value.KpiValue.Create;
using KpiScope.Web.KPI.Create;
using KpiScope.Web.KPI.Update;
using KpiScope.Web.KPI.GetById;
using KpiScope.Web.KPI.Delete;
using KpiScope.Web.KPI.List;
using KpiScope.Web.KPI.AddValue;
using KpiScope.Web.KpiConfirmation.StartConfirmation;
using KpiScope.Web.KpiConfirmation.GetConfirmationById;
using KpiScope.Web.KpiConfirmation.GetConfirmationStepsById;
using KpiScope.Web.KpiConfirmation.ConfirmKpi;
using KpiScope.Web.KpiConfirmation.RejectKpi;
using KpiScope.Core.KpiGroupAggregate;

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

        // CreateMap<StartKpiConfirmationRequest, ConfAgg.KpiConfirmation>().ReverseMap();
        CreateMap<ConfAgg.KpiConfirmation, StartKpiConfirmationResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        CreateMap<GetKpiConfirmationResponse, ConfAgg.KpiConfirmation>().ReverseMap();
        CreateMap<KpiConfirmationStep, KpiConfirmationStepDto>()
            .ForMember(
                dest => dest.ApproverName,
                opt => opt.MapFrom(src => src.Approvers.FirstOrDefault() != null 
                    ? src.Approvers.First().User!.Username 
                    : string.Empty)
            )
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.CompletedAt, opt => opt.MapFrom(src => src.CompletedAt))
            .ForMember(dest => dest.Comment,
                opt => opt.MapFrom(src => src.Approvers.FirstOrDefault()!.Comment ?? string.Empty))
            .ForMember(dest => dest.StepNumber, opt => opt.MapFrom(src => src.StepNumber));
    }
}
