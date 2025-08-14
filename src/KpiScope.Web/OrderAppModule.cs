using Autofac;
using KpiScope.Core.KpiAggregate;
using KpiScope.Web.Company;
using KpiScope.Web.KPI;
using KpiScope.Web.KpiConfirmation;
using KpiScope.Web.KpiGroup;
using KpiScope.Web.KpiGroupCompany;
using KpiScope.Web.Register;
using KpiScope.Web.Value.DynamicValue;
using KpiScope.Web.Value.KpiValue;

namespace KpiScope.Web;

public class OrderAppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<RegisterEndpointService>()
            .AsSelf()
            .InstancePerLifetimeScope();
        builder.RegisterType<CompanyEndpointService>()
            .As<ICompanyEndpointService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<KpiGroupEndpointService>()
            .As<IKpiGroupEndpointService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<KpiGroupCompanyEndpointService>()
            .As<IKpiGroupCompanyEndpointService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<DynamicValueService>()
            .As<IDynamicValueService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<KpiValueService>()
            .As<IKpiValueService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<KpiEndpointService>()
            .As<IKpiEndpointService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<KpiConfirmationEndpointService>()
            .As<IKpiConfirmationEndpointService>()
            .InstancePerLifetimeScope();
    }

}
