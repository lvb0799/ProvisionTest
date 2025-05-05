USE [Provision]
GO

/****** Object:  Table [dbo].[MonthlyRevenue]    Script Date: 2025/5/6 ¤W¤È 01:49:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MonthlyRevenue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportDate] [date] NULL,
	[DataYearMonth] [nvarchar](6) NULL,
	[CompanyId] [nvarchar](10) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Industry] [nvarchar](50) NULL,
	[RevenueCurrentMonth] [bigint] NULL,
	[RevenueLastMonth] [bigint] NULL,
	[RevenueSameMonthLastYear] [bigint] NULL,
	[MoMChangePercent] [float] NULL,
	[YoYChangePercent] [float] NULL,
	[AccRevenueCurrent] [bigint] NULL,
	[AccRevenueLastYear] [bigint] NULL,
	[AccChangePercent] [float] NULL,
	[Note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


