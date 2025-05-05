USE [Provision]
GO

/****** Object:  StoredProcedure [dbo].[InsertMonthlyRevenue]    Script Date: 2025/5/6 ¤W¤È 01:49:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertMonthlyRevenue]
    @ReportDate DATE,
    @DataYearMonth NVARCHAR(6),
    @CompanyId NVARCHAR(10),
    @CompanyName NVARCHAR(100),
    @Industry NVARCHAR(50),
    @RevenueCurrentMonth BIGINT,
    @RevenueLastMonth BIGINT,
    @RevenueSameMonthLastYear BIGINT,
    @MoMChangePercent FLOAT,
    @YoYChangePercent FLOAT,
    @AccRevenueCurrent BIGINT,
    @AccRevenueLastYear BIGINT,
    @AccChangePercent FLOAT,
    @Note NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [Provision].[dbo].[MonthlyRevenue] (
        ReportDate, DataYearMonth, CompanyId, CompanyName, Industry,
        RevenueCurrentMonth, RevenueLastMonth, RevenueSameMonthLastYear,
        MoMChangePercent, YoYChangePercent, AccRevenueCurrent, AccRevenueLastYear,
        AccChangePercent, Note
    )
    VALUES (
        @ReportDate, @DataYearMonth, @CompanyId, @CompanyName, @Industry,
        @RevenueCurrentMonth, @RevenueLastMonth, @RevenueSameMonthLastYear,
        @MoMChangePercent, @YoYChangePercent, @AccRevenueCurrent, @AccRevenueLastYear,
        @AccChangePercent, @Note
    );
END;

GO


