USE [School]
GO
/****** Object:  Table [dbo].[tblCourse]    Script Date: 07/18/2018 23:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourse](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCourse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblCourse] ([id], [name]) VALUES (N'898fe186-c8c4-415d-8e29-ac818c6f53f5', N'Asp.net MVC')
/****** Object:  Table [dbo].[tblAuthor]    Script Date: 07/18/2018 23:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAuthor](
	[id] [uniqueidentifier] NOT NULL,
	[firstname] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblAuthor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblAuthor] ([id], [firstname], [lastname], [tel]) VALUES (N'e1fdafea-e6ee-4572-a55b-3a776ecc49ec', N'Leng', N'Sokpheakdey', N'093379075')
/****** Object:  Default [DF_tblAuthor_id]    Script Date: 07/18/2018 23:36:56 ******/
ALTER TABLE [dbo].[tblAuthor] ADD  CONSTRAINT [DF_tblAuthor_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_tblCourse_id]    Script Date: 07/18/2018 23:36:56 ******/
ALTER TABLE [dbo].[tblCourse] ADD  CONSTRAINT [DF_tblCourse_id]  DEFAULT (newid()) FOR [id]
GO
