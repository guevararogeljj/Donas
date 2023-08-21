USE [Donas]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[CreatedAt] [varchar](300) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[Direction] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_DONAS]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_DONAS](
	[Id] [uniqueidentifier] NOT NULL,
	[Visible] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NOT NULL,
	[Code] [varchar](200) NOT NULL,
	[Name] [varchar](250) NOT NULL,
 CONSTRAINT [PK_TIPO_DONAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTAS_DONAS]    Script Date: 20/08/2023 09:57:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTAS_DONAS](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[TypeDonoutsId] [uniqueidentifier] NOT NULL,
	[Amount] [int] NOT NULL,
	[SaleDate] [datetime2](7) NOT NULL,
	[Visible] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NOT NULL,
	[Code] [varchar](200) NOT NULL,
	[Name] [varchar](250) NOT NULL,
 CONSTRAINT [PK_VENTAS_DONAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230820014153_Sales', N'7.0.4')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3382abf0-0a13-413a-9c54-e3c706d9f9d3', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1c80ffed-2e27-4830-a1bb-b12304f35f85', N'3382abf0-0a13-413a-9c54-e3c706d9f9d3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'3382abf0-0a13-413a-9c54-e3c706d9f9d3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [CreatedAt], [ModifiedAt], [Direction], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1c80ffed-2e27-4830-a1bb-b12304f35f85', N'invitadoTI', N'2023-08-20 21:52:49.3272135', CAST(N'2023-08-20T21:52:49.3273218' AS DateTime2), N'cdmx', N'inv', N'INV', N'guevararogeljj@gmail.com', N'GUEVARAROGELJJ@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJwRijZ2bxamY98ISnXvdGzolJuef6I+O/6JjQIJ8q34q/eDrftNFPLeYQy40uU3Yw==', N'5BLJXSKGE5V5GZGNWYDCO6G5PWVTDRKA', N'a71e4e67-2cb6-43e7-83d0-4f7ef09ddaeb', N'5521938494', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [CreatedAt], [ModifiedAt], [Direction], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'jeronimo guevara', N'2023-08-19 19:24:18.4439675', CAST(N'2023-08-19T19:24:18.4440692' AS DateTime2), N'avenida central', N'JJGR', N'JJGR', N'guevararogeljj@icloud.com', N'GUEVARAROGELJJ@ICLOUD.COM', 0, N'AQAAAAIAAYagAAAAEMcmf3S3Y64SSeDQWDwC3xF94eS5kjMdnUMYhwFZIYN2nfUHPsmagKZlXf1Hh/2TRA==', N'45SYCRVM2LGLWSQTRDCREDMFJ7MA444C', N'1612c661-5b69-4cf2-9f38-70cd9dbc9159', N'5521938494', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[TIPO_DONAS] ([Id], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'5d665d35-1650-4f0f-e047-08dba11c3c4a', 1, CAST(N'2023-08-19T19:24:44.5327446' AS DateTime2), CAST(N'2023-08-19T19:24:44.5328460' AS DateTime2), N'', N'Dona con chispas')
GO
INSERT [dbo].[TIPO_DONAS] ([Id], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'6556057a-99f7-4065-e048-08dba11c3c4a', 1, CAST(N'2023-08-19T19:24:51.0345920' AS DateTime2), CAST(N'2023-08-19T19:24:51.0345942' AS DateTime2), N'', N'Dona con chocolate')
GO
INSERT [dbo].[TIPO_DONAS] ([Id], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'1264b3b1-01fe-4dff-e049-08dba11c3c4a', 1, CAST(N'2023-08-19T19:24:55.4531102' AS DateTime2), CAST(N'2023-08-19T19:24:55.4531123' AS DateTime2), N'', N'Dona con chocolate blanco')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'16808f85-7931-4100-252b-08dba12116db', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'5d665d35-1650-4f0f-e047-08dba11c3c4a', 2, CAST(N'2023-08-19T19:59:28.0630857' AS DateTime2), 1, CAST(N'2023-08-19T19:59:27.4741924' AS DateTime2), CAST(N'2023-08-19T19:59:27.7788316' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'1d32da5d-fe31-4e49-4318-08dba121fb1b', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'5d665d35-1650-4f0f-e047-08dba11c3c4a', 3, CAST(N'2023-08-19T20:05:52.1515059' AS DateTime2), 1, CAST(N'2023-08-19T20:05:52.1513674' AS DateTime2), CAST(N'2023-08-19T20:05:52.1514402' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'd5b8bab5-cbeb-4be4-4319-08dba121fb1b', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'6556057a-99f7-4065-e048-08dba11c3c4a', 7, CAST(N'2023-08-19T20:06:20.2081887' AS DateTime2), 1, CAST(N'2023-08-19T20:06:20.2081876' AS DateTime2), CAST(N'2023-08-19T20:06:20.2081886' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'f2c14666-832d-49ac-431a-08dba121fb1b', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'6556057a-99f7-4065-e048-08dba11c3c4a', 20, CAST(N'2023-08-19T20:06:27.0349485' AS DateTime2), 1, CAST(N'2023-08-19T20:06:27.0349470' AS DateTime2), CAST(N'2023-08-19T20:06:27.0349484' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'94f018ca-cd4c-4ec8-431b-08dba121fb1b', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'1264b3b1-01fe-4dff-e049-08dba11c3c4a', 5, CAST(N'2023-08-19T20:06:45.7962533' AS DateTime2), 1, CAST(N'2023-08-19T20:06:45.7962516' AS DateTime2), CAST(N'2023-08-19T20:06:45.7962532' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'7ca139ff-6cbe-4313-431c-08dba121fb1b', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'1264b3b1-01fe-4dff-e049-08dba11c3c4a', 17, CAST(N'2023-08-19T20:06:49.8712355' AS DateTime2), 1, CAST(N'2023-08-19T20:06:49.8712339' AS DateTime2), CAST(N'2023-08-19T20:06:49.8712354' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'ded70b82-6fa8-4cd3-859d-08dba1f91dac', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'5d665d35-1650-4f0f-e047-08dba11c3c4a', 14, CAST(N'2023-08-20T21:45:51.9551503' AS DateTime2), 1, CAST(N'2023-08-20T21:45:51.9550569' AS DateTime2), CAST(N'2023-08-20T21:45:51.9551069' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'8056bd94-dbd3-4909-a865-08dba1f98414', N'e48bb614-70c0-45d2-bb75-f77afd4c809e', N'5d665d35-1650-4f0f-e047-08dba11c3c4a', 2, CAST(N'2023-08-20T21:48:43.7573893' AS DateTime2), 1, CAST(N'2023-08-20T21:48:43.7572602' AS DateTime2), CAST(N'2023-08-20T21:48:43.7573254' AS DateTime2), N'', N'')
GO
INSERT [dbo].[VENTAS_DONAS] ([Id], [UserId], [TypeDonoutsId], [Amount], [SaleDate], [Visible], [CreatedAt], [ModifiedAt], [Code], [Name]) VALUES (N'68681581-ed19-41d6-35c5-08dba1fa5a76', N'1c80ffed-2e27-4830-a1bb-b12304f35f85', N'1264b3b1-01fe-4dff-e049-08dba11c3c4a', 50, CAST(N'2023-08-20T21:54:43.4269713' AS DateTime2), 1, CAST(N'2023-08-20T21:54:43.4268693' AS DateTime2), CAST(N'2023-08-20T21:54:43.4269213' AS DateTime2), N'', N'')
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[VENTAS_DONAS]  WITH CHECK ADD  CONSTRAINT [FK_VENTAS_DONAS_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[VENTAS_DONAS] CHECK CONSTRAINT [FK_VENTAS_DONAS_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[VENTAS_DONAS]  WITH CHECK ADD  CONSTRAINT [FK_VENTAS_DONAS_TIPO_DONAS_TypeDonoutsId] FOREIGN KEY([TypeDonoutsId])
REFERENCES [dbo].[TIPO_DONAS] ([Id])
GO
ALTER TABLE [dbo].[VENTAS_DONAS] CHECK CONSTRAINT [FK_VENTAS_DONAS_TIPO_DONAS_TypeDonoutsId]
GO
