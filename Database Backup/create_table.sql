USE [nsnyorg_demonationalyouth]
GO

/****** Object:  Table [dbo].[Catagory]    Script Date: 10-11-2025 11:17:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Catagory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[create_date] [datetime] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Catagory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Catagory] ADD  CONSTRAINT [DF_Catagory_create_date]  DEFAULT (getdate()) FOR [create_date]
GO


