public class MonthlyRevenueDto
{
    public DateTime ReportDate { get; set; }
    public string DataYearMonth { get; set; }
    public string CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string Industry { get; set; }
    public decimal RevenueCurrentMonth { get; set; }
    public decimal RevenueLastMonth { get; set; }
    public decimal RevenueSameMonthLastYear { get; set; }
    public decimal MoMChangePercent { get; set; }
    public decimal YoYChangePercent { get; set; }
    public decimal AccRevenueCurrent { get; set; }
    public decimal AccRevenueLastYear { get; set; }
    public decimal AccChangePercent { get; set; }
    public string Note { get; set; }
}
