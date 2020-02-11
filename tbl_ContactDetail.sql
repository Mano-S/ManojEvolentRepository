USE [Smartcity]
GO

/****** Object:  Table [dbo].[tbl_ContactDetail]    Script Date: 2/12/2020 12:15:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_ContactDetail](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [varchar](15) NULL,
	[Status] [varchar](10) NULL,
 CONSTRAINT [PK_tbl_ContactDetail] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

