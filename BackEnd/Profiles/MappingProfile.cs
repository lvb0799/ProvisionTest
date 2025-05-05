using AutoMapper;
using MonthlyRevenueAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MonthlyRevenue, MonthlyRevenueDto>().ReverseMap();
    }
}
