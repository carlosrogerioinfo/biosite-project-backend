USE [biosite]
GO
/****** Object:  Table [dbo].[homolog_biosite_area]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_area](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_homolog_biosite_area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[homolog_biosite_biomarker]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_biomarker](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [text] NOT NULL,
	[Unity] [varchar](10) NOT NULL,
	[BodyImageType] [smallint] NOT NULL,
	[AboveImpact] [text] NOT NULL,
	[BelowImpact] [text] NOT NULL,
 CONSTRAINT [PK_homolog_biosite_biomarker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[homolog_biosite_biomarker_organ]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_biomarker_organ](
	[BiomarkerId] [uniqueidentifier] NOT NULL,
	[OrganId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_homolog_biosite_biomarker_organ] PRIMARY KEY CLUSTERED 
(
	[BiomarkerId] ASC,
	[OrganId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[homolog_biosite_organ]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_organ](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Svg] [varchar](250) NOT NULL,
 CONSTRAINT [PK_homolog_biosite_organ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[homolog_biosite_plan]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_plan](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](150) NOT NULL,
 CONSTRAINT [PK_homolog_biosite_plan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[homolog_biosite_plan_area]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_plan_area](
	[PlanId] [uniqueidentifier] NOT NULL,
	[AreaId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_homolog_biosite_plan_area] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC,
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[homolog_biosite_user]    Script Date: 13/08/2022 21:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homolog_biosite_user](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](128) NOT NULL,
	[Email] [varchar](160) NOT NULL,
	[Active] [bit] NOT NULL,
	[Weight] [float] NOT NULL,
	[Height] [float] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[IsPregnant] [bit] NOT NULL,
	[Birthdate] [datetime] NOT NULL,
	[Verified] [bit] NOT NULL,
	[VerificationCode] [varchar](5) NULL,
	[ActivationCode] [varchar](5) NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastAuthorizationCodeRequest] [datetime] NOT NULL,
	[PlanId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_homolog_biosite_user] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/* ALTER TABLES */
ALTER TABLE [dbo].[homolog_biosite_biomarker_organ]  WITH CHECK ADD  CONSTRAINT [FK_homolog_biosite_biomarker_organ_homolog_biosite_biomarker_BiomarkerId] FOREIGN KEY([BiomarkerId])
REFERENCES [dbo].[homolog_biosite_biomarker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[homolog_biosite_biomarker_organ] CHECK CONSTRAINT [FK_homolog_biosite_biomarker_organ_homolog_biosite_biomarker_BiomarkerId]
GO
ALTER TABLE [dbo].[homolog_biosite_biomarker_organ]  WITH CHECK ADD  CONSTRAINT [FK_homolog_biosite_biomarker_organ_homolog_biosite_organ_OrganId] FOREIGN KEY([OrganId])
REFERENCES [dbo].[homolog_biosite_organ] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[homolog_biosite_biomarker_organ] CHECK CONSTRAINT [FK_homolog_biosite_biomarker_organ_homolog_biosite_organ_OrganId]
GO
ALTER TABLE [dbo].[homolog_biosite_plan_area]  WITH CHECK ADD  CONSTRAINT [FK_homolog_biosite_plan_area_homolog_biosite_area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[homolog_biosite_area] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[homolog_biosite_plan_area] CHECK CONSTRAINT [FK_homolog_biosite_plan_area_homolog_biosite_area_AreaId]
GO
ALTER TABLE [dbo].[homolog_biosite_plan_area]  WITH CHECK ADD  CONSTRAINT [FK_homolog_biosite_plan_area_homolog_biosite_plan_PlanId] FOREIGN KEY([PlanId])
REFERENCES [dbo].[homolog_biosite_plan] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[homolog_biosite_plan_area] CHECK CONSTRAINT [FK_homolog_biosite_plan_area_homolog_biosite_plan_PlanId]
GO
ALTER TABLE [dbo].[homolog_biosite_user]  WITH CHECK ADD  CONSTRAINT [FK_homolog_biosite_user_homolog_biosite_plan_PlanId] FOREIGN KEY([PlanId])
REFERENCES [dbo].[homolog_biosite_plan] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[homolog_biosite_user] CHECK CONSTRAINT [FK_homolog_biosite_user_homolog_biosite_plan_PlanId]
GO
