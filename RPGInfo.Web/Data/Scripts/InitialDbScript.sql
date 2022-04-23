USE [master]
GO
/****** Object:  Database [RpgInfo]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE DATABASE [RpgInfo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RpgInfo', FILENAME = N'C:\Users\nickg\RpgInfo.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RpgInfo_log', FILENAME = N'C:\Users\nickg\RpgInfo_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RpgInfo] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RpgInfo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RpgInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RpgInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RpgInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RpgInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RpgInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [RpgInfo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RpgInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RpgInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RpgInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RpgInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RpgInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RpgInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RpgInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RpgInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RpgInfo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RpgInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RpgInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RpgInfo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RpgInfo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RpgInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RpgInfo] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RpgInfo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RpgInfo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RpgInfo] SET  MULTI_USER 
GO
ALTER DATABASE [RpgInfo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RpgInfo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RpgInfo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RpgInfo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RpgInfo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RpgInfo] SET QUERY_STORE = OFF
GO
USE [RpgInfo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [RpgInfo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/23/2022 6:53:45 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreasOfInterest]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreasOfInterest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](max) NULL,
	[AreaDescription] [nvarchar](max) NULL,
	[AreaImage] [varbinary](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[CharacterId] [int] NULL,
 CONSTRAINT [PK_AreasOfInterest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaWorldEvent]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaWorldEvent](
	[AreaEventsId] [int] NOT NULL,
	[EventLocationsId] [int] NOT NULL,
 CONSTRAINT [PK_AreaWorldEvent] PRIMARY KEY CLUSTERED 
(
	[AreaEventsId] ASC,
	[EventLocationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/23/2022 6:53:45 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/23/2022 6:53:45 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/23/2022 6:53:45 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/23/2022 6:53:45 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Portrait] [varbinary](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Race] [nvarchar](max) NULL,
	[Class] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Backstory] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoteTitle] [nvarchar](40) NOT NULL,
	[NoteDate] [datetime2](7) NOT NULL,
	[NoteContent] [nvarchar](500) NOT NULL,
	[AreaId] [int] NULL,
	[WorldEventId] [int] NULL,
	[CharacterId] [int] NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelatedNpcs]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelatedNpcs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Relationship] [nvarchar](max) NULL,
	[Background] [nvarchar](max) NULL,
	[Race] [nvarchar](max) NULL,
	[Class] [nvarchar](max) NULL,
	[AreaId] [int] NULL,
	[CharacterId] [int] NULL,
	[WorldEventId] [int] NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_RelatedNpcs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorldEvents]    Script Date: 4/23/2022 6:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorldEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventDate] [datetime2](7) NOT NULL,
	[EventName] [nvarchar](max) NULL,
	[EventDescription] [nvarchar](max) NULL,
	[EventImage] [varbinary](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[CharacterId] [int] NULL,
 CONSTRAINT [PK_WorldEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AreaWorldEvent_EventLocationsId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AreaWorldEvent_EventLocationsId] ON [dbo].[AreaWorldEvent]
(
	[EventLocationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notes_AreaId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Notes_AreaId] ON [dbo].[Notes]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notes_CharacterId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Notes_CharacterId] ON [dbo].[Notes]
(
	[CharacterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notes_WorldEventId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_Notes_WorldEventId] ON [dbo].[Notes]
(
	[WorldEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelatedNpcs_AreaId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_RelatedNpcs_AreaId] ON [dbo].[RelatedNpcs]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelatedNpcs_CharacterId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_RelatedNpcs_CharacterId] ON [dbo].[RelatedNpcs]
(
	[CharacterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelatedNpcs_WorldEventId]    Script Date: 4/23/2022 6:53:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_RelatedNpcs_WorldEventId] ON [dbo].[RelatedNpcs]
(
	[WorldEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notes] ADD  DEFAULT (N'') FOR [NoteTitle]
GO
ALTER TABLE [dbo].[AreaWorldEvent]  WITH CHECK ADD  CONSTRAINT [FK_AreaWorldEvent_AreasOfInterest_EventLocationsId] FOREIGN KEY([EventLocationsId])
REFERENCES [dbo].[AreasOfInterest] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AreaWorldEvent] CHECK CONSTRAINT [FK_AreaWorldEvent_AreasOfInterest_EventLocationsId]
GO
ALTER TABLE [dbo].[AreaWorldEvent]  WITH CHECK ADD  CONSTRAINT [FK_AreaWorldEvent_WorldEvents_AreaEventsId] FOREIGN KEY([AreaEventsId])
REFERENCES [dbo].[WorldEvents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AreaWorldEvent] CHECK CONSTRAINT [FK_AreaWorldEvent_WorldEvents_AreaEventsId]
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
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_AreasOfInterest_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[AreasOfInterest] ([Id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_AreasOfInterest_AreaId]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Characters_CharacterId] FOREIGN KEY([CharacterId])
REFERENCES [dbo].[Characters] ([Id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Characters_CharacterId]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_WorldEvents_WorldEventId] FOREIGN KEY([WorldEventId])
REFERENCES [dbo].[WorldEvents] ([Id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_WorldEvents_WorldEventId]
GO
ALTER TABLE [dbo].[RelatedNpcs]  WITH CHECK ADD  CONSTRAINT [FK_RelatedNpcs_AreasOfInterest_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[AreasOfInterest] ([Id])
GO
ALTER TABLE [dbo].[RelatedNpcs] CHECK CONSTRAINT [FK_RelatedNpcs_AreasOfInterest_AreaId]
GO
ALTER TABLE [dbo].[RelatedNpcs]  WITH CHECK ADD  CONSTRAINT [FK_RelatedNpcs_Characters_CharacterId] FOREIGN KEY([CharacterId])
REFERENCES [dbo].[Characters] ([Id])
GO
ALTER TABLE [dbo].[RelatedNpcs] CHECK CONSTRAINT [FK_RelatedNpcs_Characters_CharacterId]
GO
ALTER TABLE [dbo].[RelatedNpcs]  WITH CHECK ADD  CONSTRAINT [FK_RelatedNpcs_WorldEvents_WorldEventId] FOREIGN KEY([WorldEventId])
REFERENCES [dbo].[WorldEvents] ([Id])
GO
ALTER TABLE [dbo].[RelatedNpcs] CHECK CONSTRAINT [FK_RelatedNpcs_WorldEvents_WorldEventId]
GO
USE [master]
GO
ALTER DATABASE [RpgInfo] SET  READ_WRITE 
GO
