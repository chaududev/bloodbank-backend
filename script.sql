USE [master]
GO
/****** Object:  Database [Blood1]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE DATABASE [Blood1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blood1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Blood1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blood1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Blood1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Blood1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blood1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blood1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blood1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blood1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blood1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blood1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blood1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blood1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blood1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blood1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blood1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blood1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blood1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blood1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blood1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blood1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blood1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blood1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blood1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blood1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blood1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blood1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blood1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blood1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blood1] SET  MULTI_USER 
GO
ALTER DATABASE [Blood1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blood1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blood1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blood1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blood1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blood1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Blood1] SET QUERY_STORE = ON
GO
ALTER DATABASE [Blood1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Blood1]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Birthday] [datetime2](7) NULL,
	[Address] [nvarchar](100) NULL,
	[HospitalId] [int] NULL,
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 22/03/2023 3:48:29 CH ******/
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
/****** Object:  Table [dbo].[Blogs]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ImageId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BloodGroups]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BloodGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospitals]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospitals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Hospitals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[ContentType] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registers]    Script Date: 22/03/2023 3:48:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[BloodId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[TimeSign] [datetime2](7) NOT NULL,
	[QR] [int] NOT NULL,
	[HospitalId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Registers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230315090335_db_blood_v1.6', N'6.0.14')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0d4492c3-c15e-4986-bbd6-d6157c06dbe1', N'ADMIN', N'ADMIN', N'76e5d9c3-2d98-4619-88af-a1b354adc515')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3c84e231-ddb0-4794-8c48-3dbf4ed01d1c', N'USER', N'USER', N'7996dbe1-7c8e-48c6-948f-9bb210061eda')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4f077375-71ce-4b2c-88cc-96d3fc60ecf5', N'STAFF', N'STAFF', N'0f3e32f0-cdc2-4e20-a1fa-0ffc71d14f3a')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9fd9a17b-59d2-4e0d-996a-00014aba94d8', N'HOSPITAL', N'HOSPITAL', N'e1931f65-ef88-4c89-97ae-6050f0d2cdbb')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'875b5a7a-a492-41d8-af3f-dfe8022ca461', N'0d4492c3-c15e-4986-bbd6-d6157c06dbe1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9be0325-7f1b-4a55-85e6-62edc9478eb0', N'0d4492c3-c15e-4986-bbd6-d6157c06dbe1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'23ba1d27-0638-48ce-a968-d03d6dee5d41', N'3c84e231-ddb0-4794-8c48-3dbf4ed01d1c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3341f9a5-53c5-4a39-9b6c-5dde0166a851', N'3c84e231-ddb0-4794-8c48-3dbf4ed01d1c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7cfc404b-8ce4-4f6e-9822-c3ad5d4a98bd', N'3c84e231-ddb0-4794-8c48-3dbf4ed01d1c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b486a4a6-e6c8-47ea-869c-4a37ea0aad40', N'3c84e231-ddb0-4794-8c48-3dbf4ed01d1c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e5a519ae-002b-4895-8df2-4335e3af1eee', N'3c84e231-ddb0-4794-8c48-3dbf4ed01d1c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a199e0be-88dc-4485-bd87-74037f2497b9', N'4f077375-71ce-4b2c-88cc-96d3fc60ecf5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2a19cb78-940d-43ba-b7a6-b648664681fe', N'9fd9a17b-59d2-4e0d-996a-00014aba94d8')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c4d091fe-347b-4369-8fe0-ce5fb5732d82', N'9fd9a17b-59d2-4e0d-996a-00014aba94d8')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4f3da58-6591-4fd6-8450-fd517fb9d8cb', N'9fd9a17b-59d2-4e0d-996a-00014aba94d8')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'23ba1d27-0638-48ce-a968-d03d6dee5d41', N'Chau Du', CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), N'Huế', 1, N'chauudu1234324', N'CHAUUDU1234324', N'chaudu301@gmail.com', N'CHAUDU301@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEO2EIXOfc2gqbs002yrOgdnsbN0eAJ3iRW62TaQI0QE9ypO4uh53NpHAYimDjz0VhQ==', N'HD67JVONSEZJHZKRMHIFQHNCV7U4DTVM', N'5b8f2292-b0f0-49d6-9a95-cd7ceec9267a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2a19cb78-940d-43ba-b7a6-b648664681fe', N'Duyen Chau', CAST(N'2023-02-28T17:00:00.0000000' AS DateTime2), N'Unknown', 2, N'duyenhuhuhihi', N'DUYENHUHUHIHI', N'du@gmail.com', N'DU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEPUwE1mT2j8Mb6dLNCldNsda1kv+n2jus8/eJg+SOYIdHMFytjGLMI7gxSOhi7zZaw==', N'BDV2L6YAODM6EZWVNMHNS4AH4HW6U4GZ', N'852df28b-3ede-4a59-b5b9-f234354be27b', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3341f9a5-53c5-4a39-9b6c-5dde0166a851', N'Chau Du', CAST(N'2023-03-15T15:42:21.1110000' AS DateTime2), N'', 1, N'chauudu', N'CHAUUDU', N'user@example.com', N'USER@EXAMPLE.COM', 1, N'AQAAAAEAACcQAAAAEK+RyyrbvZdFQYWNO9oR3b5tF5XAtFSbJ3ocUDnWstB9HVGy6IxlGso+HOi7X3ACQA==', N'AKMZLDVQDMJAX4AKBITZL5OOVZB6SHPN', N'e26d8cb5-e3ce-4e0c-9588-ffd39ee998b1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7cfc404b-8ce4-4f6e-9822-c3ad5d4a98bd', N'Du Chau', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), N'69 Nguyễn Huệ', 1, N'test011@gmail.com', N'TEST011@GMAIL.COM', N'chaudu301@gmail.com', N'CHAUDU301@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEYh2bTgbMQOutbuJFpFWP2S9J+GAMU9NkGwkfHuSpLuauP57bkp1cbIZ6xazSg+Dw==', N'XFXLBKX5RSHBFO4QIQNTGMMXSNJAVCWT', N'cf97972c-a7d9-43b8-94bc-cb76c3a61f2e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'875b5a7a-a492-41d8-af3f-dfe8022ca461', N'Quan tri', CAST(N'2000-03-21T03:50:59.3090000' AS DateTime2), N'Hue', 1, N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAELkjeYnQSOtPVUuxGoQO+N9T70j9bsESmCM571pUj8cPcOLf5lFR39twvW0fP8ui4w==', N'MWQPTRCV7VHRIXDZEZTUDEIMTRUZ5TIN', N'657309d2-f494-4ef0-8312-c374043fbb59', NULL, 0, 0, NULL, 1, 1)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a199e0be-88dc-4485-bd87-74037f2497b9', N'My Duyen', CAST(N'2023-02-28T17:00:00.0000000' AS DateTime2), N'Hue', 2, N'myudyen', N'MYUDYEN', N'duyen@gmail.com', N'DUYEN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAENKb41aZLsPaNRJT+UKCLmuP5jPdLL3MeZ+1GQeg24pKKAxpKl5dxJKfZa8xd4g8GA==', N'CPJHLTWM2XNC5E6JZKFCSIWOQ2ASTUNW', N'e1cf3ace-18ae-4693-a8b4-bd0bfc95d25d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b486a4a6-e6c8-47ea-869c-4a37ea0aad40', N'chau du', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Unknown', 1, N'chaudu12324', N'CHAUDU12324', N'chaud@gmail.com', N'CHAUD@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEIwHNu4ZxY0K3nnBy0HMPIh86lkZ3mFGkpAc34bu5PRMpgYDFKkgsc9zJ5dATNUJTw==', N'BSCDEV4G54RO3FJP4GMEC36L2O7P6JE6', N'b0fcedff-2755-4f10-b64a-e25a50724b6a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b9be0325-7f1b-4a55-85e6-62edc9478eb0', N'tung le', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Unknown', 1, N'tungut', N'TUNGUT', N'tung@gmail.com', N'TUNG@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEII2E5bFWbLINKD2mIVOq48yAzJSPJlTX34u4+4PcoEqHYRizrNIgMefNc7sQFo0Ag==', N'SZPJYW2WSWRQKUOCGDVPJ6UUINLPOPJY', N'958e755f-866d-44b9-9a0c-ba0764317a3a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c4d091fe-347b-4369-8fe0-ce5fb5732d82', N'duyen duyenhi', CAST(N'2023-03-04T17:00:00.0000000' AS DateTime2), N'69 Nguyễn Huệ', 3, N'duyen123', N'DUYEN123', N'chaudu301@gmail.com', N'CHAUDU301@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDxAScGr7BBmIGsbEDY4SdkKMu2BsgpN++3bnq+wUUCXWo8Gsfgwp5avrrcjfu+WDg==', N'VKIQCB6F2GCLWRNN4GOUKCNPATMTDP2S', N'ae9b279b-ad72-4516-b665-213b226de2ef', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e4f3da58-6591-4fd6-8450-fd517fb9d8cb', N'Chau Thi My Duyen', CAST(N'1997-03-21T03:14:49.8690000' AS DateTime2), N'Hue', 2, N'myduyen', N'MYDUYEN', N'uses1@example.com', N'USES1@EXAMPLE.COM', 1, N'AQAAAAEAACcQAAAAEK3bxyaVaMnBM98pUxsb2iQ7wZYQg0082dCP3xKhlgfx2wpn+SzT8YhRb/e/96y0xg==', N'CJLAIAPJEPIZEIAPV2JYZA36OKRX3VI2', N'442397f6-c1dc-4a7b-94f7-ba87a1463ab5', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Birthday], [Address], [HospitalId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e5a519ae-002b-4895-8df2-4335e3af1eee', N'Du Ni', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), N'69 Nguyễn Huệ', 1, N'testduni', N'TESTDUNI', N'chaudu301@gmail.com', N'CHAUDU301@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEBsusv9LmkS5kXTKzyRjkpFx2wK1WPgfpgc993ycLKZN9deS3OosI2kw6OvRVaVrog==', N'4VZUQPKT7ZF2K5DTDXNBACLDKRVYLUZ6', N'3233a23c-5523-4370-b42b-c4e08a954df0', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Id], [Title], [Description], [Content], [ImageId], [CreatedAt], [UpdatedAt]) VALUES (2, N'Lisa', N'Lisa xinh đẹp', N'Lisa là idol Kpop. Cô lớn lên ở Thái Lan.
Quá xinh đẹpppp.
Lisa của tui', 5, CAST(N'2023-03-16T14:03:51.8314564' AS DateTime2), CAST(N'2023-03-20T15:01:32.4723462' AS DateTime2))
INSERT [dbo].[Blogs] ([Id], [Title], [Description], [Content], [ImageId], [CreatedAt], [UpdatedAt]) VALUES (6, N'Lisa', N'Lili', N'ahihihêttw', 19, CAST(N'2023-03-20T14:22:19.0648458' AS DateTime2), CAST(N'2023-03-20T15:01:44.3428365' AS DateTime2))
INSERT [dbo].[Blogs] ([Id], [Title], [Description], [Content], [ImageId], [CreatedAt], [UpdatedAt]) VALUES (7, N'Lilies', N'Lilies là những đóa hoa', N'Lilies là fandom Lisa Manboban', 27, CAST(N'2023-03-20T16:45:23.9839879' AS DateTime2), CAST(N'2023-03-20T16:45:53.3983543' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[BloodGroups] ON 

INSERT [dbo].[BloodGroups] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (2, N'B', N'Nhóm máu B', CAST(N'2023-03-17T17:29:30.9898548' AS DateTime2), CAST(N'2023-03-20T08:28:10.3996542' AS DateTime2))
INSERT [dbo].[BloodGroups] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (5, N'A', N'Nhóm máu A', CAST(N'2023-03-20T08:28:19.8299485' AS DateTime2), CAST(N'2023-03-20T08:28:19.8299511' AS DateTime2))
INSERT [dbo].[BloodGroups] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (7, N'AB', N'Nhóm máu AB', CAST(N'2023-03-20T08:28:46.2240815' AS DateTime2), CAST(N'2023-03-20T08:28:46.2240864' AS DateTime2))
INSERT [dbo].[BloodGroups] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (8, N'O', N'Nhóm máu O', CAST(N'2023-03-22T11:30:16.3711363' AS DateTime2), CAST(N'2023-03-22T11:30:23.2842084' AS DateTime2))
INSERT [dbo].[BloodGroups] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (10, N'Rh', N'Nhóm máu Rh+', CAST(N'2023-03-22T11:38:27.5482294' AS DateTime2), CAST(N'2023-03-22T11:38:39.9110418' AS DateTime2))
SET IDENTITY_INSERT [dbo].[BloodGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [EventName], [Description], [Content], [StartTime], [EndTime], [Status], [ImageId], [CreatedAt], [UpdatedAt]) VALUES (1, N'Hiến máu', N'Ở Đà Nẵng', N'Hiến thận ở Đà Nẵng', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-04T00:00:00.0000000' AS DateTime2), 2, 6, CAST(N'2023-03-16T14:05:12.5258879' AS DateTime2), CAST(N'2023-03-20T16:27:28.4234105' AS DateTime2))
INSERT [dbo].[Events] ([Id], [EventName], [Description], [Content], [StartTime], [EndTime], [Status], [ImageId], [CreatedAt], [UpdatedAt]) VALUES (4, N'Hiến máu hiếm Rh+', N'Có 2 người ở Đà Nẵng cần hỗ trợ gấp', N'Có 2 người ở Đà Nẵng cần hỗ trợ gấp. Nên cần hiến máu Rh+', CAST(N'2023-03-14T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-01T00:00:00.0000000' AS DateTime2), 1, 48, CAST(N'2023-03-22T15:29:56.2604224' AS DateTime2), CAST(N'2023-03-22T15:29:56.2604246' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Hospitals] ON 

INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (1, N'None', N'None', CAST(N'2023-03-15T16:17:15.5793880' AS DateTime2), CAST(N'2023-03-21T14:29:37.3929925' AS DateTime2))
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (2, N'Bệnh viện quốc tế', N'4 Lê Lợi, Huế', CAST(N'2023-03-15T16:17:27.6144489' AS DateTime2), CAST(N'2023-03-15T16:18:02.4564688' AS DateTime2))
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (3, N'Bệnh viện Medic 2', N'42 Nguyễn Huệ, Huế, Việt Nam', CAST(N'2023-03-20T16:52:30.7822574' AS DateTime2), CAST(N'2023-03-20T16:52:56.8899133' AS DateTime2))
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (4, N'Bệnh viện trung ương', N'06 Ngô Quyền, Huế', CAST(N'2023-03-21T14:29:23.4759044' AS DateTime2), CAST(N'2023-03-21T16:27:31.4738120' AS DateTime2))
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (5, N'Bệnh viện Nhi', N'32 Nguyễn Văn Cừ - TP Huế', CAST(N'2023-03-22T11:49:44.4519017' AS DateTime2), CAST(N'2023-03-22T11:49:44.4519036' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Hospitals] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (1, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'uploads\anh-20230315165402tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (2, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'C:\Users\Admin\source\repos\BloodBank\BloodBank\wwwroot\uploads\posts\anh-20230316114759tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (3, N'anh-1-9607.jpg', N'image/jpeg', N'/uploads/posts/20230316115653-anh-1-9607.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (4, N'Untitled.png', N'image/png', N'/uploads/posts/Post-20230316120525-Untitled.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (5, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'/uploads/posts/Post-20230316140345-tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (6, N'tải xuống.png', N'image/png', N'/uploads/posts/Post-20230316140512-tải xuống.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (7, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'/uploads/posts/Post-20230320112803-tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (8, N'Untitled.png', N'image/png', N'/uploads/posts/Post-20230320115047-Untitled.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (11, N'anh-1-9607.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320142121-anh-1-9607.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (12, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'/uploads/posts/Post-20230320142150-tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (13, N'photo-3.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320142219-photo-3.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (14, N'photo-3.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320142258-photo-3.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (15, N'photo-2.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320142324-photo-2.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (16, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'/uploads/posts/Post-20230320142348-tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (17, N'Untitled.png', N'image/png', N'/uploads/posts/Post-20230320142359-Untitled.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (18, N'tải xuống.png', N'image/png', N'/uploads/posts/Post-20230320142832-tải xuống.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (19, N'photo-3.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320143433-photo-3.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (22, N'banner.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320161933-banner.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (23, N'banner.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320161942-banner.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (25, N'DuChau-MFA-Done.JPG', N'image/jpeg', N'/uploads/posts/Post-20230320164246-DuChau-MFA-Done.JPG')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (26, N'anh-1-9607.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320164523-anh-1-9607.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (27, N'anh-1-9607.jpg', N'image/jpeg', N'/uploads/posts/Post-20230320164553-anh-1-9607.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (28, N'Qrcode-21142023220331.png', N'file/image', N'/QrCode/Qrcode-21142023220331.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (30, N'Qrcode-21232023220322.png', N'image/png', N'/uploads/qrcode/Qrcode-21232023220322.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (31, N'anh-1-9607.jpg', N'image/jpeg', N'/uploads/posts/Post-21232023220337-anh-1-9607.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (33, N'tieu-su-ca-si-lisa-blackpink-3.jpeg', N'image/jpeg', N'/uploads/posts/Post-21242023220345-tieu-su-ca-si-lisa-blackpink-3.jpeg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (35, N'banner.jpg', N'image/jpeg', N'/uploads/posts/Post-21262023220332-banner.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (36, N'lisa_blackpink_la_ngoi_sao_co_luong_fan_quoc_te_hung_hau_nhat_han_quoc_112605.jpg', N'image/jpeg', N'/uploads/posts/Post-21272023220331-lisa_blackpink_la_ngoi_sao_co_luong_fan_quoc_te_hung_hau_nhat_han_quoc_112605.jpg')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (37, N'Qrcode-22462023080326.png', N'image/png', N'/uploads/qrcode/Qrcode-22462023080326.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (38, N'Qrcode-22472023080340.png', N'image/png', N'/uploads/qrcode/Qrcode-22472023080340.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (39, N'Qrcode-22552023080351.png', N'image/png', N'/uploads/qrcode/Qrcode-22552023080351.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (40, N'Qrcode-22562023080345.png', N'image/png', N'/uploads/qrcode/Qrcode-22562023080345.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (41, N'Qrcode-22592023080345.png', N'image/png', N'/uploads/qrcode/Qrcode-22592023080345.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (42, N'Qrcode-22032023090334.png', N'image/png', N'/uploads/qrcode/Qrcode-22032023090334.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (43, N'Qrcode-22052023090359.png', N'image/png', N'/uploads/qrcode/Qrcode-22052023090359.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (44, N'Qrcode-22152023090312.png', N'image/png', N'/uploads/qrcode/Qrcode-22152023090312.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (45, N'Qrcode-22162023090326.png', N'image/png', N'/uploads/qrcode/Qrcode-22162023090326.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (46, N'Qrcode-22472023100303.png', N'image/png', N'/uploads/qrcode/Qrcode-22472023100303.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (47, N'Qrcode-22452023110351.png', N'image/png', N'/uploads/qrcode/Qrcode-22452023110351.png')
INSERT [dbo].[Images] ([Id], [FileName], [ContentType], [Url]) VALUES (48, N'Capture.JPG', N'image/jpeg', N'/uploads/posts/Post-22292023150356-Capture.JPG')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Registers] ON 

INSERT [dbo].[Registers] ([Id], [Note], [Status], [BloodId], [UserId], [TimeSign], [QR], [HospitalId], [CreatedAt], [UpdatedAt]) VALUES (39, N'Hiến hiih', 1, 5, N'23ba1d27-0638-48ce-a968-d03d6dee5d41', CAST(N'2023-03-08T00:00:00.0000000' AS DateTime2), 46, 2, CAST(N'2023-03-22T10:47:03.7270764' AS DateTime2), CAST(N'2023-03-22T10:47:03.7270778' AS DateTime2))
INSERT [dbo].[Registers] ([Id], [Note], [Status], [BloodId], [UserId], [TimeSign], [QR], [HospitalId], [CreatedAt], [UpdatedAt]) VALUES (40, N'200ml', 2, 5, N'23ba1d27-0638-48ce-a968-d03d6dee5d41', CAST(N'2023-03-31T00:00:00.0000000' AS DateTime2), 47, 3, CAST(N'2023-03-22T11:45:52.0233522' AS DateTime2), CAST(N'2023-03-22T11:46:07.5575032' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Registers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_HospitalId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_HospitalId] ON [dbo].[AspNetUsers]
(
	[HospitalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Blogs_ImageId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Blogs_ImageId] ON [dbo].[Blogs]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_ImageId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Events_ImageId] ON [dbo].[Events]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Registers_BloodId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_Registers_BloodId] ON [dbo].[Registers]
(
	[BloodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Registers_HospitalId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_Registers_HospitalId] ON [dbo].[Registers]
(
	[HospitalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Registers_QR]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Registers_QR] ON [dbo].[Registers]
(
	[QR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Registers_UserId]    Script Date: 22/03/2023 3:48:29 CH ******/
CREATE NONCLUSTERED INDEX [IX_Registers_UserId] ON [dbo].[Registers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Hospitals_HospitalId] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Hospitals_HospitalId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Images_ImageId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Images_ImageId]
GO
ALTER TABLE [dbo].[Registers]  WITH CHECK ADD  CONSTRAINT [FK_Registers_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registers] CHECK CONSTRAINT [FK_Registers_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Registers]  WITH CHECK ADD  CONSTRAINT [FK_Registers_BloodGroups_BloodId] FOREIGN KEY([BloodId])
REFERENCES [dbo].[BloodGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registers] CHECK CONSTRAINT [FK_Registers_BloodGroups_BloodId]
GO
ALTER TABLE [dbo].[Registers]  WITH CHECK ADD  CONSTRAINT [FK_Registers_Hospitals_HospitalId] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registers] CHECK CONSTRAINT [FK_Registers_Hospitals_HospitalId]
GO
ALTER TABLE [dbo].[Registers]  WITH CHECK ADD  CONSTRAINT [FK_Registers_Images_QR] FOREIGN KEY([QR])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registers] CHECK CONSTRAINT [FK_Registers_Images_QR]
GO
USE [master]
GO
ALTER DATABASE [Blood1] SET  READ_WRITE 
GO
