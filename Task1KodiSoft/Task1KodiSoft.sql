USE [master]
GO
/****** Object:  Database [Task1Kodi]    Script Date: 28.04.2018 22:55:51 ******/
CREATE DATABASE [Task1Kodi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Task1Kodi_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Task1Kodi_Data.mdf' , SIZE = 9920KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Task1Kodi_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Task1Kodi_Log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 1024KB )
GO
ALTER DATABASE [Task1Kodi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Task1Kodi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Task1Kodi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Task1Kodi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Task1Kodi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Task1Kodi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Task1Kodi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Task1Kodi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Task1Kodi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Task1Kodi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Task1Kodi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Task1Kodi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Task1Kodi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Task1Kodi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Task1Kodi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Task1Kodi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Task1Kodi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Task1Kodi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Task1Kodi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Task1Kodi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Task1Kodi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Task1Kodi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Task1Kodi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Task1Kodi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Task1Kodi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Task1Kodi] SET  MULTI_USER 
GO
ALTER DATABASE [Task1Kodi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Task1Kodi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Task1Kodi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Task1Kodi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Task1Kodi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Task1Kodi] SET QUERY_STORE = OFF
GO
USE [Task1Kodi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Task1Kodi]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItemOrders]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItemOrders](
	[Id] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderItemId] [int] NOT NULL,
	[CurrentPrice] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 28.04.2018 22:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] NOT NULL,
	[Media] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [float] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 28.04.2018 22:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[ClosedDate] [datetime2](7) NOT NULL,
	[ForOne] [bit] NOT NULL,
	[OpenedDate] [datetime2](7) NOT NULL,
	[StateId] [int] NULL,
	[TipsAmount] [float] NOT NULL,
	[isCash] [bit] NOT NULL,
	[TotalPrice] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 28.04.2018 22:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Task1Kodi] SET  READ_WRITE 
GO
