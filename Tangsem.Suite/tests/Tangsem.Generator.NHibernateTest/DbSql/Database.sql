/****** Object:  Table [dbo].[Country]    Script Date: 06/12/2012 23:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[CountryCode] [nvarchar](50) NULL,
	[Continent] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Country] ON
INSERT [Country] ([Id], [Name], [CountryCode], [Continent]) VALUES (1, N'Australia', N'AU', N'Oceania')
INSERT [Country] ([Id], [Name], [CountryCode], [Continent]) VALUES (2, N'New Zealand', N'NZ', N'Oceania')
SET IDENTITY_INSERT [Country] OFF
/****** Object:  Table [dbo].[State]    Script Date: 06/12/2012 23:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [State] ON
INSERT [State] ([Id], [Name], [CountryId]) VALUES (1, N'Victoria', 1)
INSERT [State] ([Id], [Name], [CountryId]) VALUES (2, N'New South Wales', 1)
INSERT [State] ([Id], [Name], [CountryId]) VALUES (3, N'South Island', 2)
SET IDENTITY_INSERT [State] OFF
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 06/12/2012 23:26:56 ******/
ALTER TABLE [State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [Country] ([Id])
GO
ALTER TABLE [State] CHECK CONSTRAINT [FK_State_Country]
GO


CREATE VIEW v_State AS 
SELECT
[RowNum] = ROW_NUMBER() OVER (ORDER BY [State].[Name])
, [State].*
, [CountryName] = [Country].[Name]
, [Country].[CountryCode]
, [Country].[Continent]
FROM
[State] LEFT JOIN [Country]
	ON [State].[CountryId] = [Country].[Id]

GO