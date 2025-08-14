using Ardalis.SharedKernel;
using AM=AutoMapper;
using KpiScope.Core.KpiGroupAggregate;
using ConfAgg=KpiScope.Core.KpiGroupAggregate;
using KpiScope.Web.KpiConfirmation.StartConfirmation;
using KpiScope.Web.KpiConfirmation.GetConfirmationById;
using KpiScope.Web.KpiConfirmation.GetConfirmationStepsById;
using KpiScope.Web.KpiConfirmation.ConfirmKpi;
using KpiScope.Web.KpiConfirmation.RejectKpi;
using KpiScope.Core.KpiGroupAggregate.Specifications;

namespace KpiScope.Web.KpiConfirmation;

public class KpiConfirmationEndpointService
                            (IRepository<ConfAgg.KpiConfirmation> _confirmationRepo,
                            IRepository<KpiConfirmationStep> _stepRepo,
                            IRepository<KpiConfirmationUser> _stepUserRepo,
                            AM.IMapper _mapper)
                            : IKpiConfirmationEndpointService
{
    public async Task<StartKpiConfirmationResponse> StartConfirmationAsync(StartKpiConfirmationRequest request)
    {
        var confirmation = new ConfAgg.KpiConfirmation
        {
            KpiGroupCompanyId = request.KpiGroupCompanyId,
            CurrentStepNumber = 1,
            Status = ConfirmationStatusEnum.Pending,
            CreatedAt = DateTime.UtcNow
        };

        await _confirmationRepo.AddAsync(confirmation);
        await _confirmationRepo.SaveChangesAsync();

        return _mapper.Map<StartKpiConfirmationResponse>(confirmation);
    }

    public async Task<GetKpiConfirmationResponse> GetConfirmationAsync(int id)
    {
        var confirmation = await _confirmationRepo.GetByIdAsync(id);
        if (confirmation == null)
            throw new KeyNotFoundException($"KPI Confirmation {id} not found");

        return _mapper.Map<GetKpiConfirmationResponse>(confirmation);
    }

    public async Task<GetKpiConfirmationStepsResponse> GetConfirmationStepAsync(int id)
    {
        var confirmation = await _confirmationRepo.FirstOrDefaultAsync(new GetByIdWithStepsAsync(id));

        if (confirmation == null)
            throw new KeyNotFoundException($"KPI Confirmation {id} not found");
        
        return new GetKpiConfirmationStepsResponse
        {
            ConfirmationId = confirmation.Id,
            Steps = _mapper.Map<List<KpiConfirmationStepDto>>(confirmation.Steps)
        };
    }

    public async Task<ConfirmKpiStepResponse> ConfirmKpiAsync(ConfirmKpiStepRequest request)
    {
        var stepUser = await _stepUserRepo.AddAsync(new KpiConfirmationUser
        {
            UserId = request.StepUserId,
            IsConfirmed = true,
            Comment = request.Comment,
            ActionDate = DateTime.UtcNow
        });
        var confirmation = await _confirmationRepo.GetByIdAsync(request.ConfirmationId)
            ?? throw new KeyNotFoundException($"KPI Confirmation {request.ConfirmationId} not found");
        var stepNumber = ++confirmation.CurrentStepNumber;
        var step = await _stepRepo.AddAsync(new KpiConfirmationStep
        {
            KpiConfirmationId = request.ConfirmationId,
            StepNumber = stepNumber,
            Status = ConfirmationStatusEnum.Approved,
            StartedAt = DateTime.UtcNow,
            CompletedAt = DateTime.UtcNow,
            Approvers = new List<KpiConfirmationUser> { stepUser }
        });

        return new ConfirmKpiStepResponse
        {
            StepNumber = step.StepNumber,
            StepStatus = step.Status,
        };
    }

    public async Task<RejectKpiStepResponse> RejectKpiAsync(RejectKpiStepRequest request)
    {
       var stepUser = await _stepUserRepo.AddAsync(new KpiConfirmationUser
        {
            UserId = request.StepUserId,
            IsConfirmed = true,
            Comment = request.Comment,
            ActionDate = DateTime.UtcNow
        });
        var confirmation = await _confirmationRepo.GetByIdAsync(request.ConfirmationId)
            ?? throw new KeyNotFoundException($"KPI Confirmation {request.ConfirmationId} not found");
        var stepNumber = ++confirmation.CurrentStepNumber;
        var step = await _stepRepo.AddAsync(new KpiConfirmationStep
        {
            KpiConfirmationId = request.ConfirmationId,
            StepNumber = stepNumber,
            Status = ConfirmationStatusEnum.Rejected,
            StartedAt = DateTime.UtcNow,
            CompletedAt = DateTime.UtcNow,
            Approvers = new List<KpiConfirmationUser> { stepUser }
        });

        return new RejectKpiStepResponse
        {
            StepNumber = step.StepNumber,
            StepStatus = step.Status,
        };
    }

}
