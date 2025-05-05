using AutoMapper;
using MediatR;
using MonthlyRevenueAPI.Models;

public record CreateMonthlyRevenueCommand(MonthlyRevenueDto Dto) : IRequest;

public class CreateMonthlyRevenueHandler : IRequestHandler<CreateMonthlyRevenueCommand>
{
    private readonly IRevenueRepository _repo;
    private readonly IMapper _mapper;

    public CreateMonthlyRevenueHandler(IRevenueRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateMonthlyRevenueCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<MonthlyRevenue>(request.Dto);
        await _repo.AddAsync(entity);
        return Unit.Value;
    }
}
