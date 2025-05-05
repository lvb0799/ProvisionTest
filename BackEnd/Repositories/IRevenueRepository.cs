using MonthlyRevenueAPI.Models;

public interface IRevenueRepository
{
    Task<IEnumerable<MonthlyRevenue>> GetAllAsync();
    Task AddAsync(MonthlyRevenue revenue);
}
