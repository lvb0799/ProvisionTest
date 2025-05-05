USE [Provision]
GO

/****** Object:  StoredProcedure [dbo].[GetAllMonthlyRevenue]    Script Date: 2025/5/6 ¤W¤È 01:49:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllMonthlyRevenue]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM [Provision].[dbo].[MonthlyRevenue]
    ORDER BY DataYearMonth DESC, CompanyId;
END;

GO


