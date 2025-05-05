using Dapper;
using MonthlyRevenueAPI.Data;
using MonthlyRevenueAPI.Models;

public class MonthlyRevenueService : IMonthlyRevenueService
{
    private readonly DapperContext _context;

    public MonthlyRevenueService(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MonthlyRevenue>> GetAllAsync()
    {
        var query = "[GetAllMonthlyRevenue]";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<MonthlyRevenue>(query, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<MonthlyRevenue>> GetByCompanyIdAsync(string companyId)
    {
        var query = "[GetMonthlyRevenueByCompanyId]";
        var parameters = new { CompanyId = companyId };
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<MonthlyRevenue>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task AddAsync(MonthlyRevenue revenue)
    {
        var query = "[Provision].[InsertMonthlyRevenue]";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, revenue, commandType: System.Data.CommandType.StoredProcedure);
    }
}
