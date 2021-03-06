USE [GifCollection]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06/01/2018 04:10:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 06/01/2018 04:10:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gif]    Script Date: 06/01/2018 04:10:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gif](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SourceId] [nvarchar](50) NULL,
	[ThumbnailSizeImageUrl] [nvarchar](150) NULL,
	[LargeSizeImageUrl] [nvarchar](150) NULL,
	[Rating] [nvarchar](5) NULL,
	[StarRating] [int] NULL,
	[IsFavourite] [bit] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Gif] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageTag]    Script Date: 06/01/2018 04:10:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageTag](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_ImageTag] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [PK_Category_FK_Gif]    Script Date: 06/01/2018 04:10:47 ******/
ALTER TABLE [dbo].[Gif]  WITH CHECK ADD  CONSTRAINT [PK_Category_FK_Gif] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Gif] CHECK CONSTRAINT [PK_Category_FK_Gif]
GO
/****** Object:  ForeignKey [PK_User_FK_Gif]    Script Date: 06/01/2018 04:10:47 ******/
ALTER TABLE [dbo].[Gif]  WITH CHECK ADD  CONSTRAINT [PK_User_FK_Gif] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Gif] CHECK CONSTRAINT [PK_User_FK_Gif]
GO
/****** Object:  ForeignKey [PK_Gif_FK_ImageTag]    Script Date: 06/01/2018 04:10:47 ******/
ALTER TABLE [dbo].[ImageTag]  WITH CHECK ADD  CONSTRAINT [PK_Gif_FK_ImageTag] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Gif] ([ImageId])
GO
ALTER TABLE [dbo].[ImageTag] CHECK CONSTRAINT [PK_Gif_FK_ImageTag]
GO
