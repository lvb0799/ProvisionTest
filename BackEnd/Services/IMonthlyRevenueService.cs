using MonthlyRevenueAPI.Models;

public interface IMonthlyRevenueService
{
    Task<IEnumerable<MonthlyRevenue>> GetAllAsync();
    Task<IEnumerable<MonthlyRevenue>> GetByCompanyIdAsync(string companyId);
    Task AddAsync(MonthlyRevenue revenue);
}
