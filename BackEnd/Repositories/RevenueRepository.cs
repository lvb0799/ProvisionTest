using Dapper;
using MonthlyRevenueAPI.Models;
using System.Data.SqlClient;

public class RevenueRepository : IRevenueRepository
{
    private readonly IConfiguration _config;

    public RevenueRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<MonthlyRevenue>> GetAllAsync()
    {
        using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        var result = await conn.QueryAsync<MonthlyRevenue>("EXEC GetAllMonthlyRevenue");
        return result;
    }

    public async Task AddAsync(MonthlyRevenue revenue)
    {
        using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await conn.ExecuteAsync("EXEC InsertMonthlyRevenue @ReportDate, @DataYearMonth, @CompanyId, @ReportDate, @DataYearMonth, @CompanyId, @CompanyName, @Industry, @RevenueCurrentMonth, @RevenueLastMonth, @RevenueSameMonthLastYear, @MoMChangePercent, @YoYChangePercent, @AccRevenueCurrent, @AccRevenueLastYear, @AccChangePercent, @Note", revenue);
    }
}
