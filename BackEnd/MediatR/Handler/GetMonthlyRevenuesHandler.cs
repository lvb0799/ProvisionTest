using AutoMapper;
using MediatR;

public record GetMonthlyRevenuesQuery : IRequest<IEnumerable<MonthlyRevenueDto>>;

public class GetMonthlyRevenuesHandler : IRequestHandler<GetMonthlyRevenuesQuery, IEnumerable<MonthlyRevenueDto>>
{
    private readonly IRevenueRepository _repo;
    private readonly IMapper _mapper;

    public GetMonthlyRevenuesHandler(IRevenueRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MonthlyRevenueDto>> Handle(GetMonthlyRevenuesQuery request, CancellationToken cancellationToken)
    {
        var data = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<MonthlyRevenueDto>>(data);
    }
}
