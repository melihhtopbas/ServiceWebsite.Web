USE [master]
GO
/****** Object:  Database [LegalityAnalysis]    Script Date: 28.08.2020 12:21:57 ******/
CREATE DATABASE [LegalityAnalysis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LegalityAnalysis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LegalityAnalysis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LegalityAnalysis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LegalityAnalysis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LegalityAnalysis] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LegalityAnalysis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LegalityAnalysis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET ARITHABORT OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LegalityAnalysis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LegalityAnalysis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LegalityAnalysis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LegalityAnalysis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LegalityAnalysis] SET  MULTI_USER 
GO
ALTER DATABASE [LegalityAnalysis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LegalityAnalysis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LegalityAnalysis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LegalityAnalysis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LegalityAnalysis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LegalityAnalysis] SET QUERY_STORE = OFF
GO
USE [LegalityAnalysis]
GO
/****** Object:  User [mdal]    Script Date: 28.08.2020 12:21:57 ******/
CREATE USER [mdal] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [md]    Script Date: 28.08.2020 12:21:57 ******/
CREATE USER [md] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [md]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [md]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [md]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [md]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [md]
GO
ALTER ROLE [db_datareader] ADD MEMBER [md]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [md]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [md]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [md]
GO
/****** Object:  UserDefinedDataType [dbo].[barkod_str]    Script Date: 28.08.2020 12:21:57 ******/
CREATE TYPE [dbo].[barkod_str] FROM [nvarchar](50) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[belgeno_str]    Script Date: 28.08.2020 12:21:57 ******/
CREATE TYPE [dbo].[belgeno_str] FROM [nvarchar](50) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[evrakseri_str]    Script Date: 28.08.2020 12:21:57 ******/
CREATE TYPE [dbo].[evrakseri_str] FROM [nvarchar](20) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_maxhesapisimno]    Script Date: 28.08.2020 12:21:57 ******/
CREATE TYPE [dbo].[nvarchar_maxhesapisimno] FROM [nvarchar](90) NULL
GO
/****** Object:  Table [dbo].[About]    Script Date: 28.08.2020 12:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[FileName] [nvarchar](80) NULL,
	[Vision] [nvarchar](max) NULL,
	[Mission] [nvarchar](max) NULL,
	[FileName2] [nvarchar](80) NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogCategories]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCategories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Link] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
 CONSTRAINT [PK_BlogCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogImages]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](80) NOT NULL,
	[Alt] [nvarchar](80) NULL,
	[Title] [nvarchar](80) NULL,
	[BlogId] [bigint] NOT NULL,
 CONSTRAINT [PK_BlogImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ShortDescription] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[SeoTitle] [nvarchar](60) NULL,
	[SeoKeywords] [nvarchar](200) NULL,
	[SeoDescription] [nvarchar](300) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTagMapping]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTagMapping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TagId] [bigint] NOT NULL,
	[BlogId] [bigint] NOT NULL,
 CONSTRAINT [PK_BlogTagMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTags]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTags](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](50) NOT NULL,
	[LanguageId] [bigint] NOT NULL,
 CONSTRAINT [PK_BlogTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactForm]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactForm](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Subject] [nvarchar](250) NULL,
	[Mail] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Message] [nvarchar](1000) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_ContactForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAttribute]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAttribute](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ResourceValue] [nvarchar](400) NOT NULL,
	[DefaultValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustomerAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerComments]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerComments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[FileName] [nvarchar](80) NULL,
 CONSTRAINT [PK_CustomerComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerPosPayments]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPosPayments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[CreditCardMaskedNumber] [nvarchar](20) NOT NULL,
	[ExpireYear] [smallint] NOT NULL,
	[ExpireMonth] [tinyint] NOT NULL,
	[ClientIp] [nvarchar](50) NOT NULL,
	[PaymentAmount] [decimal](12, 2) NOT NULL,
	[PaymentResult] [tinyint] NOT NULL,
	[ResultMessage] [nvarchar](500) NULL,
	[TransactionId] [nvarchar](80) NOT NULL,
	[WebsitesId] [bigint] NULL,
 CONSTRAINT [PK_CustomerPosPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CategoryId] [bigint] NULL,
	[LanguageId] [bigint] NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQCategories]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQCategories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[FileName] [nvarchar](80) NULL,
	[SortOrder] [int] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[Link] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_FAQCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FileName] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Keyword]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keyword](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ImageUrl] [nvarchar](250) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DocumentTemplate] [nvarchar](max) NOT NULL,
	[LanguageId] [bigint] NOT NULL,
 CONSTRAINT [PK_Keyword] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ShortName] [nvarchar](5) NOT NULL,
	[CultureInfo] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Link] [nvarchar](100) NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Properties]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Properties](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ShortDescription] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
	[FileName] [nvarchar](80) NULL,
	[Icon] [nvarchar](80) NULL,
	[Active] [bit] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[References]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[References](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[FileName] [nvarchar](80) NULL,
 CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchKeyword]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchKeyword](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[KeywordType] [int] NOT NULL,
	[KeywordId] [bigint] NOT NULL,
 CONSTRAINT [PK_SearchKeyword] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCategories]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ParentId] [bigint] NULL,
	[Link] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[ShowOnHomePage] [bit] NOT NULL,
	[FileName] [nvarchar](80) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceImages]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](80) NOT NULL,
	[Alt] [nvarchar](80) NULL,
	[Title] [nvarchar](80) NULL,
	[ServiceId] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ShortDescription] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CategoryId] [bigint] NULL,
	[Link] [nvarchar](200) NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[SeoTitle] [nvarchar](60) NULL,
	[SeoKeywords] [nvarchar](200) NULL,
	[SeoDescription] [nvarchar](300) NULL,
	[Icon] [nvarchar](80) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Logo] [nvarchar](max) NULL,
	[Favicon] [nvarchar](max) NULL,
	[Meta] [nvarchar](max) NULL,
	[Title] [nvarchar](250) NULL,
	[Keywords] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[Maps] [nvarchar](max) NULL,
	[Facebook] [nvarchar](250) NULL,
	[Twitter] [nvarchar](250) NULL,
	[Instagram] [nvarchar](250) NULL,
	[Youtube] [nvarchar](250) NULL,
	[Gplus] [nvarchar](250) NULL,
	[Adress] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Phone2] [nvarchar](20) NULL,
	[Email] [nvarchar](250) NULL,
	[Analytics] [nvarchar](max) NULL,
	[Copyright] [nvarchar](max) NULL,
	[LanguageId] [bigint] NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](80) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[Title] [nvarchar](80) NULL,
	[Alt] [nvarchar](80) NULL,
	[Active] [bit] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[ButtonText1] [nvarchar](50) NULL,
	[ButtonText2] [nvarchar](50) NULL,
	[ButtonText3] [nvarchar](50) NULL,
	[ButtonText4] [nvarchar](50) NULL,
	[ButtonLink1] [nvarchar](200) NULL,
	[ButtonLink2] [nvarchar](200) NULL,
	[ButtonLink3] [nvarchar](200) NULL,
	[ButtonLink4] [nvarchar](200) NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebsiteFiles]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebsiteFiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nchar](250) NULL,
	[KeywordId] [bigint] NULL,
	[Result] [bit] NULL,
	[WebsiteId] [bigint] NULL,
 CONSTRAINT [PK_WebsiteFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Websites]    Script Date: 28.08.2020 12:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Websites](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Website] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Websites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([Id], [Title], [Description], [LanguageId], [FileName], [Vision], [Mission], [FileName2]) VALUES (1, N'Hakkımızda', N'<p>Kurumsal bir yazılım firması olarak İstanbul ve Kayseri&#39;de ofislerimiz bulunmaktadır. İstanbul, Ankara, İzmir ve Kayseri olmakla birlikte bir&ccedil;ok ilimizde yazılım ve eğitim semineri alanlarında faaliyetler g&ouml;stermekteyiz. Prasoft &uuml;st d&uuml;zey yazılım ve bu sekt&ouml;rde daha &ouml;nce bir&ccedil;ok başarı elde etmiş bir yazılım ekibidir. Prasoft ekibi olarak &ouml;ncelikli hedefimiz sizlerin e-ticaret ve yazılım alanında yaşamış olduğu sorunları &ccedil;&ouml;zebilecek &uuml;r&uuml;nlerin yazılımını yapmaktır. Bu sorunları &ccedil;&ouml;zebilecek uygulamalar tasarlayıp bunları hayata ge&ccedil;irmeyi ve sizleri e-ticaret alanında daha başarılı kılmayı hedef edinmiştir. Sizlerde eğer yazılım ve tasarım alanında sorunlar yaşamakta iseniz Prasoft sizlerin yaşamış olduğu bu sorunları en kısa s&uuml;rede &ccedil;&ouml;zecektir. Sizde Prasoft ile iletişime ge&ccedil;in ve yaşamakta olduğunuz sorunları bizlere iletin. Prasoft sizlerin yaşamakta olduğu bir&ccedil;ok farklı alanda sorunlar i&ccedil;in &ccedil;&ouml;z&uuml;m &ouml;nerileri &uuml;retmektedir. Bu &ccedil;&ouml;z&uuml;m &ouml;nerileri ise sizlerin &ccedil;alıştığı alanda &ccedil;alışma hızınızı ve iş sağlığınızı artıran &ouml;neriler ve uygulamalardır. Sizlerde Prasoft&#39;tun sizler i&ccedil;in yoğun uğraşlar vererek tasarlamış olduğu &uuml;r&uuml;nleri detaylı bir şekilde inceleyin. Beğendiğiniz &uuml;r&uuml;nlerimiz i&ccedil;in bizden demo talep ederek en kısa s&uuml;rede kullanmaya başlayın. Daha sonra ise &ccedil;alışma sisteminize ve b&uuml;t&ccedil;enize uygun paketi se&ccedil;erek sizde ailemizin ve ekibimiz bir par&ccedil;ası olup bize katırın. Prasoft &Uuml;r&uuml;nleri Prasoft yazılım alanında sizlere sıfırdan bir web sitesi tasarlaması yapabilir. Bunun yanı sırada e-ticaret alanında sizlere eğitimler vererek bu alanda başarılı olmanızı sağlamaktadır. G&uuml;n&uuml;m&uuml;zde herkes sanal ağı kullanıp e-ticarettin bir par&ccedil;ası haline gelmiştir. Sizlerde T&uuml;rkiye&#39;de hem e-ticaret alanında yazılımlar &uuml;reten ve eğitim veren tek firmadan bilgiler elde etmek i&ccedil;in en kısa s&uuml;rede iletişime ge&ccedil;in. E-ticaret ile kazan&ccedil; ve kazan&ccedil;lar elde edebilirsiniz. Prasoft ekibinin ilk &uuml;r&uuml;n&uuml;&nbsp;<a href="https://prapazar.com/">Prapazar</a>&nbsp;T&uuml;rkiye&#39;de hi&ccedil;bir entegrasyon sisteminde olmayan &ouml;zellikleri ile e-ticaret alanında &ccedil;alışmaları bulunan bir&ccedil;ok firmanın dikkatini &ccedil;ekmekte. Bunun sebebi ise Prapazar&#39;ın e-ticaret sitenizde satmakta olduğunuz &uuml;r&uuml;nlerinizi n11, gitti gidiyor, hepsi burada, eptt avm, trendyol, sanal pazar, akak&ccedil;e, &ccedil;i&ccedil;ek sepeti gibi platformlarda listeleyebilir ve Prapazar sayesinde tek bir ekran altından y&ouml;netebilirsiniz. Sizde pazar yerlerinde daha pratik ve sorun yaşamadan &uuml;r&uuml;nlerinizi satmak i&ccedil;in Prapazar&#39;ın sizlere &ouml;zel paketlerini inceleyin. Her firmanın en b&uuml;y&uuml;k sorunlarından birisidir muhasebe y&ouml;netimi. &Uuml;st&uuml;nde detaylı bir şekilde durulmadığı zaman ciddi derecede maddi zarar yaşamanıza neden olabilir. Sizlerde artık daha &ccedil;ok firma y&ouml;netimine ve firmanızın daha başarılı olması i&ccedil;in &ccedil;alışmaya fırsat bulabileceksiniz. Pranomi sizlerin yerinize muhasebenizi y&ouml;netecek. Adeta sayıları ve zor fatura işlemleri i&ccedil;in tasarlanmış olan Pranomi herkesi şaşırtmaya geliyor. Şuan test aşamasında olan Pranomi &ccedil;ok yakında piyasada yer alan diğer muhasebe programlarında daha cazip &ouml;zellikleri ile piyasaya &ccedil;ıkmayı bekliyor. Sizlerde Prasoft ekibimiz ile iletişme ge&ccedil;erek Pranomi hakkında daha &ccedil;ok bilgi edinebilirsiniz. Bir başka firma y&ouml;netiminizi ve iş akışınızı kolaylaştıracak &uuml;r&uuml;n ise PraCrm. PraCrm ile m&uuml;şteri bilgileri ve &ccedil;alışan iş y&ouml;netimini ve iş dağıtımını kolaylıkla yapabilirsiniz. PraCrm ile sizde artık daha hızlı kararlar alıp daha hızlı bir şekilde &ccedil;alışanınıza iş dağıtımını yapabileceksiniz. Prasoft sizlerin hayatını kolaylaştırmayı ve &ccedil;alıştığınız alanda daha başarılı olmanız i&ccedil;in &ccedil;&ouml;z&uuml;mler &uuml;retmeyi ama&ccedil;lar. Sizde Prasoft ile iletişime ge&ccedil;erek daha başarılı olabilirsiniz. Sizde başarılı olmak i&ccedil;in Prasoft ekibini yakından tanıyın.</p>
', 1, N'ed9dac709e044b5387b04f8917136c11.png', N'<p>Dinamik, kurumsal ve gelişime &ouml;nem veren yapısıyla, m&uuml;şteri memnuniyet odaklı,&nbsp; kaliteli ve kesintisiz hizmet vermek</p>
', N'<p>Kayseri&#39;de Dijital Pazarlama sekt&ouml;r&uuml;nde İlkeli, doğru, d&uuml;r&uuml;st, kaliteli hizmet sunmak</p>
', N'046203160edf4852a1c919d29523ff99.png')
SET IDENTITY_INSERT [dbo].[About] OFF
SET IDENTITY_INSERT [dbo].[BlogCategories] ON 

INSERT [dbo].[BlogCategories] ([Id], [Name], [Link], [Active], [SortOrder], [LanguageId]) VALUES (1, N'KVKK', N'pradijital', 1, 0, 1)
SET IDENTITY_INSERT [dbo].[BlogCategories] OFF
SET IDENTITY_INSERT [dbo].[BlogImages] ON 

INSERT [dbo].[BlogImages] ([Id], [FileName], [Alt], [Title], [BlogId]) VALUES (7, N'4605a38ae294483681857f6fb60109a8.jpg', N'kisisel-verilerin-korunmasi-kanunu.jpg', NULL, 5)
INSERT [dbo].[BlogImages] ([Id], [FileName], [Alt], [Title], [BlogId]) VALUES (8, N'0bfaf2d069fc4e5baeab417e954c5ea2.jpg', N'kvkk-nedir.jpg', NULL, 6)
INSERT [dbo].[BlogImages] ([Id], [FileName], [Alt], [Title], [BlogId]) VALUES (9, N'f1e87cfc188e4ba5959665ae9b8e152c.png', N'kisiselveri2-675x405.png', NULL, 7)
SET IDENTITY_INSERT [dbo].[BlogImages] OFF
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Id], [Name], [ShortDescription], [Description], [Active], [Link], [LanguageId], [CategoryId], [SeoTitle], [SeoKeywords], [SeoDescription], [Date]) VALUES (5, N'KİŞİSEL VERİLERİN KORUNMASI KANUNU (KVKK) NEDİR?', N'7 Nisan 2016 tarihinde yayımlanarak yürürlüğe giren ‘6698 Sayılı Kişisel Verilerin Korunması Kanunu', N'<p>Uzun yıllardır tasarı halinde bekleyen ve 7 Nisan 2016 tarihinde yayımlanarak y&uuml;r&uuml;rl&uuml;ğe giren &lsquo;6698 Sayılı Kişisel Verilerin Korunması Kanunu&rsquo;, kişisel verilerin işlenmesinde başta &ouml;zel hayatın gizliliği olmak &uuml;zere kişilerin temel hak ve &ouml;zg&uuml;rl&uuml;klerini korumak ve kişisel verileri işleyen ger&ccedil;ek ve t&uuml;zel kişilerin y&uuml;k&uuml;ml&uuml;l&uuml;kleri ile uyacakları kuralları d&uuml;zenleme amacını taşımaktadır.</p>

<p>Kanun&rsquo;da belirtilen istisnalar haricinde, kişisel veriler ilgili kişinin a&ccedil;ık rızası olmaksızın işlenemeyecek; &uuml;&ccedil;&uuml;nc&uuml; kişilere ve yurtdışına aktarılamayacaktır. Kanun&rsquo;da ayrı ayrı maddelerde de belirtilmiş olan bu maddelere uyulmaması halinde, kurumlar idari para cezasına &ccedil;arptırılabileceklerdir.</p>

<p>Kişisel verilerin işlenmesi; kişisel verilerin tamamen veya kısmen otomatik olan ya da herhangi bir veri kayıt sisteminin par&ccedil;ası olmak kaydıyla otomatik olmayan yollarla elde edilmesi, kaydedilmesi, depolanması, muhafaza edilmesi, değiştirilmesi, yeniden d&uuml;zenlenmesi, a&ccedil;ıklanması, aktarılması, devralınması, elde edilebilir h&acirc;le getirilmesi, sınıflandırılması ya da kullanılmasının engellenmesi gibi veriler &uuml;zerinde ger&ccedil;ekleştirilen her t&uuml;rl&uuml; işlemi ifade etmektedir.</p>

<p>Kişisel Verilerin Korunması Kanunu; kişisel veriler, asıl sahipleri tarafından kurum ve kuruluşlara emanet edilen bilgiler olarak değerlendirildiğinde; veriyi işleyen kurumların verinin asıl sahiplerine, emanet aldıkları verilerle ilgili &ldquo;hesap verebilir&rdquo; olması i&ccedil;in zemin oluşturmakta, kuralları tanımlamaktadır. Kanun, kişisel veriyi işleyen kurumlar i&ccedil;in &ouml;nemli bir d&ouml;n&uuml;ş&uuml;m&uuml; de beraberinde getirmektedir.</p>

<p>Bu Kanunun yayımı tarihinden &ouml;nce işlenmiş olan kişisel veriler, yayımı tarihinden itibaren iki yıl i&ccedil;inde bu Kanun h&uuml;k&uuml;mlerine uygun h&acirc;le getirilmeli; bu Kanun h&uuml;k&uuml;mlerine aykırı olduğu tespit edilen kişisel veriler derh&acirc;l silinmeli, yok edilmeli veya anonim h&acirc;le getirilmelidir. Ancak bu Kanunun yayımı tarihinden &ouml;nce hukuka uygun olarak veri sahibinden alınmış rızalar, bir yıl i&ccedil;inde veri sahibi tarafından aksi belirtilmemesi h&acirc;linde, bu Kanuna uygun kabul edilebilecektir.</p>

<p>Kurumları ilgilendiren temel soru ise: &ldquo;Emanet aldığımız kişisel verilerle ilgili hesap verebilir olmak i&ccedil;in neler yapmalıyız?&rdquo; Bu sorunun cevabını verebilen kurumlar, Kişisel Verilerin Korunması Kanunu da uyumlu olacaklardır.</p>

<p>Kurum ve kuruluşların yukarıda belirtilen temel soruya cevap verebilmeleri:</p>

<p>Kişisel verilerin korunması ile ilgili kapsam ve hedefleri belirlemek</p>

<p>Kişisel veri politikası oluşturmak</p>

<p>Kişisel verilerin korunması ile ilgili sorumluluk ve hesap verebilirlik ilkelerini belirlemek</p>

<p>Kişisel veri koruma temsilcileri belirlemek</p>

<p>Kişisel verilerin kanuna uygun şekilde işlenmesini sağlayacak yapı i&ccedil;in &uuml;st y&ouml;netim desteği ve kaynak sağlamak</p>

<p>Kişisel veri envanteri oluşturmak</p>

<p>Kişisel verilerle ilgili riskleri y&ouml;netmek</p>

<p>Kişisel veri toplama, işleme ve paylaşma y&ouml;ntemlerini belirlemek</p>

<p>Kişisel verilerin g&uuml;venliğini sağlamak</p>

<p>Kişisel verilerle ilgili şik&acirc;yetlerin ele alınma y&ouml;ntemlerini belirlemek olarak &ouml;zetleyebileceğimiz Veri Y&ouml;netimi &ccedil;alışmalarının uygulanmasına bağlıdır.</p>

<h3>Kişisel Verilerin Korunması Kanunu&rsquo;na Y&ouml;nelik &Ccedil;&ouml;z&uuml;mler</h3>

<h4>Metodolojik Yaklaşımlar</h4>

<p>Kanunların ve yasal d&uuml;zenlemelerinin isterlerini uzun soluklu ve kurumun gelişmesi, standartların sağlanması ve zamana uyum sağlaması amacıyla kaldıra&ccedil; etkisi ile kullanılan yaklaşımlardır. Bu yaklaşımların Kişisel Verilerin Korunması Kanunu i&ccedil;in işaret ettiği metot Kurumsal Mimaridir.</p>

<h6>Kurumsal Mimari Nedir?</h6>

<p>Milenyum ile hayatımıza giren kurumsal mimari kavramı; kurumun stratejiden iş birimlerine, s&uuml;re&ccedil;lerden aktivitilere, aktivitelerde kullanılan uygulama ve verilerden bunların &uuml;zerinde koştuğu bilgi teknolojileri altyapı bileşenlerine kadar t&uuml;m ilişkileri tanımlamamızı, her t&uuml;rl&uuml; değişim istek ve talebinin etki analizi ile değerlendirilmesini sağlayan bir iş yapış metodolojisidir.</p>

<p>Kurumsal Mimari; ortak dil kullanımı, standartlar ve referanslar, iş yapış y&ouml;ntemi temelleri &uuml;zerine kurulu ve her kurumun kendi dinamiklerine ve ihtiya&ccedil;larına g&ouml;re d&uuml;zenlenmesi gereken karar destek sistemini besleyen ve iş yapış şeklini kurallara bağlayan bir disiplindir.</p>

<p>D&uuml;nyada kurumsal mimari &ccedil;er&ccedil;eveleri (Ing. Enterprise Architecture Frameworks) temel olarak aşağıdaki gibi 3 ana &ccedil;er&ccedil;eve etrafında toplanmıştır :</p>

<p>TOGAF / The Open Group</p>

<p>Zachman Framework / Zachman International</p>

<p>The Federal Enterprise Architecture Framework (FEAF) / Federal Government of the U.S.</p>

<p>Kurumsal mimariyi meydana getiren &ouml;ğeler d&ouml;rt ana grupta toplanmaktadır:</p>

<ol>
	<li>İşletme mimarisi &ouml;ğeleri; iş s&uuml;re&ccedil;lerini tasarlayan kullanım olguları ve g&ouml;rev diyagramlarını i&ccedil;erir. İş akışları sırasında ger&ccedil;ekleşen veri girişlerini, kayıtları, veri &ouml;zetlerini ve y&ouml;netim kararlarını teşkil eden nesneler de işletme mimarisinin birer par&ccedil;asıdır.</li>
	<li>Enformasyon ve veri mimarisi; kurumsal varlıkları, bu varlıklar arasındaki ilişkileri, varlıklar arasındaki veri akışlarını ve iş mantığını tasarlar. Enformasyon ve veri mimarisini teşkil eden &ouml;ğeler bir araya gelerek sistem mimarisini meydana getirir.</li>
	<li>Sistem mimarisi &ouml;ğelerini tasarlamak i&ccedil;in varlık paketleri, ara y&uuml;zler, bileşenler ve mimari yapılardan yararlanılır.</li>
	<li>Teknoloji altyapısı &ouml;ğeleri ise sistemleri meydana getiren uygulama yazılımlarını, sistem yazılımlarını, &ccedil;evre birimlerini, bilgisayar donanımını ve bilgisayar ağlarını ve bu &ouml;ğeler arasındaki ilişkileri a&ccedil;ıklar.</li>
</ol>

<h4>Teknolojik Yaklaşımlar</h4>

<p>6698 sayılı kişisel verilerin korunması kanunu , şirketlerin altyapılarında sakladıkları m&uuml;şteri verilerinin bulunduğu sistemler ve altyapılarda gereken g&uuml;venlik &ouml;nlemlerinin alınmasını ama&ccedil;lamaktadır.</p>

<p>Bu bağlamda şirket ve kurumların saklamakta oldukları kişisel verilere erişim ihlali yapılmasını engellemekle y&uuml;k&uuml;ml&uuml;d&uuml;r. Oluşabilecek bir ihlal durumunda bu erişim adli araştırmalar gerektireceğinden bu adli &ccedil;alışmaların yapılabilmesi i&ccedil;in gerekli altyapı ile kişisel veriler korunmalıdır.</p>

<p>Verilerin sınıflandırılması, etiketlenmesi ve hassasiyetine g&ouml;re erişimlerin en kısıtlı haklarla, takip altına alınarak ve daha sonra raporlanabilir bir şekilde saklanması sağlanmalıdır. Veri ka&ccedil;aklarının &ouml;nlenmesi, kişisel verilerin korunduğu alanlara erişimlerin titizlikle kayıt altına alınması ve s&uuml;rekli raporlanabilir olması &ouml;nemlidir.</p>

<p>Kimlik y&ouml;netimi ve erişim y&ouml;netimi ile verilerin bulunduğu kaynaklara erişim y&ouml;netici hakları olmaksızın, belirli onay mekanizmalarından ge&ccedil;erek sağlanmalıdır. Ayrıca bu kaynaklardaki bilgi g&uuml;venliği testleri titizlikle yapılmalı, gerekli zaafiyet analizleri de ilgili ara&ccedil;larla yapılarak, i&ccedil; denetim ve uyum kurallarına uygun olarak raporlanmalı ve belirli periyodlarla bu analizler ger&ccedil;ekleştirilmelidir.</p>

<p>Bilgi g&uuml;venliği alanında dikkat edilmesi gereken bazı başlıklar :</p>

<p>Hesap, Şifre ve Erişim Denetimi</p>

<p>Veri koruma ve veri ka&ccedil;aklarını engelleme</p>

<p>Veri sınıflandırma ve tasnifleme</p>

<p>Veri gizliliğinin sağlanması</p>

<p>Zafiyet denetimi ve g&uuml;venlik seviyesinin takibi</p>

<p>Gerekli g&uuml;venlik prosed&uuml;rlerinin işletilmesi</p>

<p>İ&ccedil; denetim ve uyum kurallarına uygun raporlama</p>

<h4>Hukuki Yaklaşımlar</h4>

<p>Kurum/İşletme i&ccedil;erisinde hukuki olarak kanunun işaret ettiği maddelerin Bilişim departmanları ile koordinasyonunu sağlanması amacıyla ortak bir komisyon kurulması, y&ouml;netişim yapısının oluşturulması tavsiye edilir. Hukuk bakış a&ccedil;ısıyla atılması gereken adımların isterleri hazırlanmalı, ardından tutarlı, s&uuml;rd&uuml;r&uuml;lebilir bir uygulama politikası oluşturmak gerekir.</p>

<p>Hukuki anlamda &ouml;ncelikle yapılması gereken hususlar şunlardır:</p>

<p>Hukuki tanımların yapılması</p>

<p>Kişisel verilerin işlenme şartlarının a&ccedil;ık ve net olarak tanımlanması</p>

<p>Kişisel verilerin silinmesi, anonimleştirilmesi veya aktarılması s&uuml;re&ccedil;lerinin tanımlanması</p>

<p>Kişisel veri sahibinin haklarının tanımlanması</p>

<p>Veri sorumlusu ve işleticilerinin y&uuml;k&uuml;ml&uuml;l&uuml;klerinin tanımlanması</p>

<p>Su&ccedil;lar ve kabahatlerin neler olduğunun tanımlanması</p>

<p>Yukarıda belirtilen tanımlamalar yapıldıktan sonra, Hukuki olarak kanun maddeleri ile ilişkileri anlaşılabilir ve takip edilebilir şekilde adreslenmelidir.</p>

<p>Paydaş analizi ve iletişim stratejisi &ccedil;alışması yapılmalı ve bu konuların paydaşlar tarafından doğru anlaşıldığı, eylem planlarında g&ouml;rev sorumluluklarının tanımlandığı ve karşılıklı mutabık kalındığı, her t&uuml;rl&uuml; eylem planının paydaşlar ve uygulayıcılar tarafından &ouml;l&ccedil;&uuml;lebilir şekilde metriklerini oluşturulması ve takibinin aşamaları belirlendiği garanti altına alınmalıdır.</p>

<p>Hukuki olarak &ouml;l&ccedil;&uuml;m kriterlerine uygun olarak eylem planlarının periyodik değerlendirme sonu&ccedil;ları &uuml;st y&ouml;netime sunulmalıdır.</p>

<h6>Cezai Durumlar</h6>

<p>Kişisel verilere ilişkin su&ccedil;lar bakımından 26/9/2004 tarihli ve 5237 sayılı T&uuml;rk Ceza Kanununun 135 ila 140 ıncı madde h&uuml;k&uuml;mleri uygulanır.<br />
Kanuna g&ouml;re kişisel verileri ihlal edenlere 1 yıldan 3 yıla kadar hapis cezası &ouml;ng&ouml;r&uuml;lmektedir. Ayrıca bu veriyi ihlal yolu ile ele ge&ccedil;iren kişiye de 2 yıldan 4 yıla kadar hapis cezası verilebilir.</p>

<p>6698 sayılı kişisel verilerin korunması kanunu gereği;</p>

<ul>
	<li>10 uncu maddesinde &ouml;ng&ouml;r&uuml;len aydınlatma y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;n&uuml; yerine getirmeyenler hakkında 5.000 T&uuml;rk lirasından 100.000 T&uuml;rk lirasına kadar,</li>
	<li>12 nci maddesinde &ouml;ng&ouml;r&uuml;len veri g&uuml;venliğine ilişkin y&uuml;k&uuml;ml&uuml;l&uuml;kleri yerine getirmeyenler hakkında 15.000 T&uuml;rk lirasından 1.000.000 T&uuml;rk lirasına kadar,</li>
	<li>15 inci maddesi uyarınca Kurul tarafından verilen kararları yerine getirmeyenler hakkında 25.000 T&uuml;rk lirasından 1.000.000 T&uuml;rk lirasına kadar,</li>
	<li>16 ncı maddesinde &ouml;ng&ouml;r&uuml;len Veri Sorumluları Siciline kayıt ve bildirim y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;ne aykırı hareket edenler hakkında 20.000 T&uuml;rk lirasından 1.000.000 T&uuml;rk lirasına kadar idari para cezası verilir.</li>
</ul>
', 1, N'kssel-verlern-korunmasi-kanunu-kvkk-nedr', 1, 1, NULL, NULL, NULL, CAST(N'2019-07-30T13:28:06.987' AS DateTime))
INSERT [dbo].[Blogs] ([Id], [Name], [ShortDescription], [Description], [Active], [Link], [LanguageId], [CategoryId], [SeoTitle], [SeoKeywords], [SeoDescription], [Date]) VALUES (6, N'KVKK nedir, kapsamında neler bulunur?', N'Bilgi teknolojilerindeki gelişmeler, günümüzde verilerin farklı platformlarda elde edilmesini, işlenmesini ve anlamlı hale getirilerek faydaya dönüştürülmesini sağlıyor. Ancak bu avantaj beraberinde i', N'<p>Kişisel verilerin korunmasına dair duyulan ihtiya&ccedil; doğrultusunda, Avrupa Birliği&rsquo;ne uyum kapsamında Kişisel Verilerin Korunması Kanunu adıyla TBMM&rsquo;ye tasarı sunulmuştur. Tasarı, 24 Mart 2016 tarihinde meclisten onay alarak kanunlaştı; 7 Nisan 2016 tarihinde 29677 sayılı Resm&icirc; Gazetede yayımlandı.</p>

<p>Kişilerin tedirginliğini giderme ve dijital d&uuml;nyada kendilerini g&uuml;vende hissetmeleri a&ccedil;ısından &ouml;nemi b&uuml;y&uuml;k olan bu kanunun ne gibi kavramları ve konuları i&ccedil;erdiğini; gerektirdiklerinin neler olduğunu bu yazımızda sunuyoruz.</p>

<h2>KİŞİSEL VERİLERİN KORUNMASI NEDİR?</h2>

<p>Kişisel verilerin korunması, veri işleme faaliyetlerinin &ouml;nceden belirlenen kurallar g&ouml;zetilerek yapılması ve kişinin temel hak ve &ouml;zg&uuml;rl&uuml;klerinin zarar g&ouml;rmemesi i&ccedil;in bir disiplin sağlanmasıdır. Bu noktada vurgulanması gereken şudur: Veriyi korumak, verinin kullanılmasının yasaklanması değil; verinin kim tarafından hangi amaca y&ouml;nelik olarak ve nasıl kullanacağının kararını, verinin sahibinin vermesini sağlamak ve veri sahibinin bu konuda bilgi talep etme hakkını daimi kılmaktır.</p>

<h2><strong>KVKK&rsquo;NIN DAYANAĞI NEDİR?</strong></h2>

<p>Kişisel verilerin korunması, anayasa ile g&uuml;vence altına alınmıştır. Kişisel verilerin korunması; anayasanın, &ouml;zel hayatın gizliliğini d&uuml;zenleyen 20. maddesinde yapılan değişikliğin gereğidir. Elbette bu sınırsız bir hak değildir. T&uuml;rkiye Cumhuriyeti Anayasası&rsquo;nda meşru ama&ccedil;lara y&ouml;nelik olarak sınırlandırılan bu hak, Avrupa Birliği&rsquo;nde 1995 yılı itibariyle 95/46/EC sayılı direktif ile sağlanmıştır.</p>

<h2><strong>KVKK&rsquo;DA AMA&Ccedil; NEDİR?</strong></h2>

<p>Bilgi teknolojilerinin b&uuml;y&uuml;k bir hızla geliştiği ve resmi işlemlerin de &ccedil;oğunlukla elektronik ortamda yapıldığı &ccedil;ağımızda, kişisel verilerin işlenmesinin pek &ccedil;ok avantajı vardır. &Ouml;rneğin bilgilerinizi verdiğiniz bir kurumdan kampanya ve indirim g&uuml;nlerinde haber alabilirsiniz. Ancak bilgilerinizin k&ouml;t&uuml;ye kullanılması olasılığı da vardır. Kanunun amacı bu olasılığı ortadan kaldırmaktır. KVKK&rsquo;nda ama&ccedil;, verilerin belli bir rejimde işlenmesini sağlamak ve veri işleme faaliyetlerinin şeffaflık ilkesi benimsenerek yapılmasıdır. Bu sayede veri sahibinin verileri &uuml;zerinde s&ouml;z sahibi olmasını sağlanır.</p>

<h2><strong>KVKK KİMLERİ KAPSAR?</strong></h2>

<p>KVKK, hak ehliyeti bulunan t&uuml;m ger&ccedil;ek ve t&uuml;zel kişileri kapsar. Kamu kurumları dahil olmak &uuml;zere her vatandaş, kanunun usul ve esaslarına uymakla y&uuml;k&uuml;ml&uuml;d&uuml;r. Kanunun, milli g&uuml;venliği, &ouml;zel hayatın gizliliğini veya kişilik haklarını ihlal etmemek &ouml;n koşuluna bağlı olarak istisna şeklinde belirttiği haller ş&ouml;yledir:</p>

<ul>
	<li>Verilerin, aynı konutta yaşayan diğer kişilerle ilgili faaliyetlere y&ouml;nelik olarak işlenmesi</li>
	<li>Kişisel verilerin resmi araştırmaya y&ouml;nelik olarak, kanunla yetki verilmiş kamu kurum ve kuruluşlarınca istatistiksel veri olarak kullanılıp anonim hale getirilmesi</li>
	<li>İfade &ouml;zg&uuml;rl&uuml;ğ&uuml; kapsamında; bilim, sanat, tarih ve edebiyat i&ccedil;in işlenmesi</li>
	<li>Kişisel verilerin yargı makamları veya infaz mercileri tarafından işlenmesi</li>
</ul>

<p>Kanunun amacına, temel ilkelerine uygun olma şartıyla kısmi istisna sayılan haller ise; su&ccedil; işlenmesinin &ouml;nlenmesi, disiplin kovuşturması ve soruşturması, devletin mali &ccedil;ıkarlarının korunması ama&ccedil;larına y&ouml;nelik verilerin işlenmesidir.</p>

<h2><strong>KİŞİSEL VERİ NEDİR?</strong></h2>

<p>Ger&ccedil;ek kişilere ait olan her t&uuml;rl&uuml; &ouml;zel bilgi, kişisel veridir. Telefon numarasından ara&ccedil; plakasına, hobilerinden sağlık bilgilerine kadar, kişiyi direkt olarak ya da dolaylı yoldan belirlenebilir kılan her t&uuml;r bilgi, kişisel veri kapsamındadır.</p>

<p>Bir &ouml;rnek verelim: Kalabalığın i&ccedil;inde &ldquo;Burada bulunan Ahmet, Galatasaray takımını tutuyor&rdquo; şeklinde a&ccedil;ıklama yapıldığında, Ahmet ile ilgili kişisel veri paylaşılmış olur ki bu noktada Ahmet&rsquo;in kişisel verisini a&ccedil;ıklayan kişinin, veriye nasıl ve nereden ulaştığı, bu bilgi ile neler yapabileceği ve ihlal durumu s&ouml;z konusu olduysa nasıl cezalandırılacağı gibi s&uuml;re&ccedil;ler kanun ile belirlenmiştir.</p>

<h2><strong>&Ouml;ZEL NİTELİKLİ (HASSAS) VERİ NEDİR?</strong></h2>

<p>&Ouml;zel nitelikli veri, hassas verilerdir. &Ccedil;&uuml;nk&uuml; dini inan&ccedil;, siyasi g&ouml;r&uuml;ş, dernek ya da sendika &uuml;yeliği, ceza mahkumiyeti, cinsel hayat gibi konulara ait veriler; başkaları tarafından &ouml;ğrenildiğinde ilgili kişinin mağduriyetine ya da ilgili kişiye ayrıcalık verilerek diğer insanların mağduriyetine sebebiyet verebilir.</p>

<h2><strong>İLGİLİ KİŞİ KİMDİR?</strong></h2>

<p>İlgili kişi, kişisel verisi ile ilgili faaliyette bulunulan, veri işleme faaliyeti sonucunda ulaşılan kişidir. T&uuml;zel kişilere ait verilerin sonucunda ulaşılan ger&ccedil;ek kişi ise bu veriler de kanun kapsamında değerlendirilir.</p>

<h2><strong>VERİ SORUMLUSU VE VERİ İŞLEYEN NEDİR?</strong></h2>

<p>Veri sorumlusu, kişisel verilerin hangi amaca y&ouml;nelik olarak işleneceğinin, hangi kanallar aracılığıyla veri işleme faaliyeti yapılacağının kararını vererek verinin y&ouml;netilmesinde sorumlu olan kişidir. Dolayısıyla veriler ile ilgili ne yapacağını belirleyen veri sorumlusu olduğundan kanun kapsamında, sorumluluğu en &uuml;st d&uuml;zeyde olan kişidir.&nbsp;&nbsp;Veri sorumlusunun, veri işleyen alt d&uuml;zeydeki sorumluların eylemlerine karşı da tazminata varan sorumluluğu vardır.</p>

<p>Veri sorumlusunun verdiği yetkiye dayanarak veriyi işleme faaliyetini ger&ccedil;ekleştiren kişi veri işleyen kişidir. Bazı durumlarda veri işleyen bağımsız bir veri sorumlusu olabilmektedir. Bu durumu bir &ouml;rnekle a&ccedil;ıklayalım:</p>

<p>Bir i&ccedil;ecek firması, pazarlama y&ouml;ntemi olarak anket yapmayı tercih etmiş ve uzman bir tedarik&ccedil;i ile anlaşmıştır.&nbsp;&nbsp;Tedarik&ccedil;inin yalnızca sokakta anketlerin doldurulması i&ccedil;in işg&uuml;c&uuml; temini yaparak, iletilen formları doldurulduğu şekliyle i&ccedil;ecek şirketine g&ouml;ndermesi, anket şirketinin veri işleyen olduğunu g&ouml;sterir. Anketin ne şekilde yapılacağına, verileri nasıl y&ouml;netebileceğine ilişkin kararı veren anket şirketi olsaydı, veri sorumlusu anket şirketi diyebilirdik.</p>

<h2><strong>KİŞİSEL VERİLERİN İŞLENMESİ NEDİR?</strong></h2>

<p>Bir kişisel verinin; tamamının ya da bir kısmının, manuel olarak elde edilmesi, saklanması, değiştirilmesi, aktarılması, kullanılmasının engellenmesi gibi her t&uuml;rl&uuml; işlem, kişisel verilerin işlenmesi anlamına gelir. Bir başkasına ait bilgiyi, &uuml;zerinde başka herhangi bir işlem yapılmaksızın bir hard diskte, CD&rsquo;de saklamak da veri işleme faaliyetidir.</p>

<h2><strong>KANUNA İLİŞKİN KURALLARI TAKİP EDEN BİR KURUM VAR MI?</strong></h2>

<p>KVKK kapsamında oluşturulan Kişisel Verileri Koruma Kurumu&rsquo;nun y&ouml;netim organı olan Kurul, kişisel verilerin korunması ile ilgili kararları vermekle y&uuml;k&uuml;ml&uuml;d&uuml;r. 9 kişiden oluşan kurum; Kanun&rsquo;da belirtilen hallerin ger&ccedil;ekleşmesi durumunda şikayetleri dinlemek, gerektiğinde maddi yaptırım uygulamak, veri sorumluları sicilini saklamak ile y&uuml;k&uuml;ml&uuml;d&uuml;r. Kurul&rsquo;un 4 &uuml;yesi Cumhurbaşkanı tarafından, 5 &uuml;yesi ise TBMM&rsquo;deki siyasi parti gruplarının &uuml;ye sayısı oranında, parti grupların aday g&ouml;sterdiği kişiler arasında se&ccedil;ilir.</p>
', 1, N'kvkk-nedir-kapsaminda-neler-bulunur', 1, 1, NULL, NULL, NULL, CAST(N'2019-07-30T13:31:38.567' AS DateTime))
INSERT [dbo].[Blogs] ([Id], [Name], [ShortDescription], [Description], [Active], [Link], [LanguageId], [CategoryId], [SeoTitle], [SeoKeywords], [SeoDescription], [Date]) VALUES (7, N'Kişisel Veri Nedir?', N'Kişisel Verilerin Korunması Kanunu’nda da benzer bir tanıma yer verilerek kişisel veri; “kimliği belirli veya belirlenebilir gerçek kişiye ilişkin her türlü bilgi” olarak tanımlanmıştır.', N'<p>İngilizce&nbsp;<em>&ldquo;personal data&rdquo;</em>&nbsp;kavramından gelen kişisel veri, tartışmalı ve sınırları tam &ccedil;izilemeyen bir kavram olup, kısaca insana ait ve bireyi tanımlayabilecek her t&uuml;rl&uuml; bilgi olarak tanımlanması m&uuml;mk&uuml;nd&uuml;r. Doğrudan doğruya ya da dolaylı olarak bir kişi ile ilintili olabilecek ve o kişiyi belirlenebilir kılacak her t&uuml;rl&uuml; bilgiye kişisel veri denilebilir.</p>

<p>Kişisel Verilerin Korunması Kanunu&rsquo;nda da benzer bir tanıma yer verilerek kişisel veri;&nbsp;<em>&ldquo;kimliği belirli veya belirlenebilir ger&ccedil;ek kişiye ilişkin her t&uuml;rl&uuml; bilgi</em>&rdquo; olarak tanımlanmıştır. Dolayısıyla bir verinin kişisel veri olup olmadığının tespitinde &uuml;&ccedil; adet koşul bulunmaktadır. Bunlar:</p>

<h4>1. Bilgi</h4>

<p>Kişisel verinin tanımından yola &ccedil;ıkılarak ulaşılan ilk unsur bilgidir. Kanun&rsquo;da veri kavramı yerine kasıtlı olarak bilgi kavramına yer verilmiştir. Veri ile bilgi kavramlarının arasındaki fark ise kişisel verinin kapsamının belirlenebilmesi a&ccedil;ısından &ouml;nem arz etmektedir. Bilgi kavramı veri kavramını kapsayıcı nitelikte olup, bir verinin bilgi olabilmesi i&ccedil;in veriye bir anlam y&uuml;klenebilmesi gerekmektedir. Bu kapsamda; anlamlandırılamayan veriler kişisel veri olarak kabul edilemeyecektir. &Ouml;rneğin;&nbsp;<em>&ldquo;Mehmet, M&uuml;hendislik, 12&rdquo;&nbsp;</em>şeklinde sıralanan kelimeler bir veriyi ifade etmektedir. Ancak ilgili veritabanında Ahmet ifadesinin &lsquo;isim&rsquo;, M&uuml;hendislik ifadesinin &ldquo;fak&uuml;lte&rdquo; ve 12 ifadesinin ise &lsquo;mezuniyet yılı&rsquo; s&uuml;tunlarında bulunması durumunda ilgili veriler bilgiye d&ouml;n&uuml;şmekte ve kişisel verilerin korunması hukukunun kapsamı alanına girmektedir.</p>

<h4><strong>2. Kimliği Belirli veya Belirlenebilir Ger&ccedil;ek Kişi</strong></h4>

<p>Kanunda yalnızca ger&ccedil;ek kişiler a&ccedil;ısından kişisel verilerin korunacağı kabul edilmiş, t&uuml;zel kişiler (dernek, vakıf, şirket) a&ccedil;ısından kişisel verilerden bahsedilmemiştir. Ancak bir g&ouml;r&uuml;şe g&ouml;re t&uuml;zel kişiler de koruma kapsamına alınmalıdır. Bu g&ouml;r&uuml;ş&uuml; savunanların temel iddiası t&uuml;zel kişilere ilişkin verilerden ger&ccedil;ek kişilere ulaşılabileceğidir.</p>

<p>Kişisel verilerin ger&ccedil;ek kişiye ait olması hususuyla ilgili bir diğer tartışma konusu ise &ouml;len kişilerin verilerinin de bu kapsamda kabul edilip edilmeyeceğidir. T&uuml;rk hukukuna g&ouml;re kişisel tam ve sağ doğumla başlayıp &ouml;l&uuml;mle sona ermektedir. Dolayısıyla &ouml;len kişinin verilerinin kişisel veri olarak kabul edilip korunması m&uuml;mk&uuml;n değildir. Ancak bu durum kişisel sağlık verileri a&ccedil;ısından farklılık g&ouml;stermektedir. Kişinin sağlık verileri kişinin &ouml;l&uuml;m&uuml;nden sonra da hekim tarafından korunmalıdır.</p>

<p>Ayrıca, bu ger&ccedil;ek kişinin kimliğinin belirli ya da belirlenebilir olması gerekmektedir. Kişinin belirli olması, herhangi başka bir veri ile eşleştirmeden kişinin kimliğinin eldeki veri ile saptanabilmesidir. Bu kapsamda kişinin kimlik ya da okul numarasıyla herhangi başkaca bir vasıtaya gerek olmaksızın kişinin kimliği belirlenebilecektir. Kimliğin belirlenebilir olması durumu ise; ancak yardımcı veriler ve vasıtalar aracılığıyla kişinin kimliğinin belirlenebileceği verileri kapsamaktadır. Kişinin aile fertlerinin adı, e-posta adresi gibi veriler kişinin kimliğinin yardımcı veri veya vasıtalarla belirlenebileceği verilerdir. Kanun, sadece ger&ccedil;ek kişinin kimliğinin belirli olması durumunu aramamış, buna ek olarak kişinin kimliğinin belirlenebilir olması durumunu da ekleyerek, makul bir &ccedil;alışma neticesinde eldeki verilerle kişinin kimliğinin belirlenebilir olduğu durumlardaki verileri de kişisel veri olarak kabul etmiştir.</p>

<p>Bu kapsamda anonim veriler, kişiyi belirli ya da belirlenebilir kılmadıklarından kişisel veri olarak nitelendirilemezler. Ancak anonim veriler ile de makul bir &ccedil;aba sonucu kişinin kimliğinin belirlenebilir hale gelmemesi gerekmektedir.</p>

<h4><strong>3. Bilginin Kişiye Ait Olması</strong></h4>

<p><img alt="" src="https://startupnedir.com/wp-content/uploads/2017/09/Ki%C5%9Fisel-Veri-3-300x194.jpg" style="height:194px; width:300px" /></p>

<p>Bilginin kişiye ilişkin olması, genel olarak bir verinin bir kişi hakkında olmasını ifade etmektedir. &Ouml;zel olarak bir verinin bir kişi hakkında olması i&ccedil;in; ama&ccedil;, i&ccedil;erik veya sonu&ccedil; unsurlarından birinin bulunması gerekmektedir. İ&ccedil;erik unsuru veri ile ilgilidir ve verinin i&ccedil;eriğinin kişi ile ilgili olmasını ifade etmektedir. Ama&ccedil; unsuru, ger&ccedil;ek kişinin davranışlarını, performansını ve durumunu&nbsp;değerlendirmek amacıyla toplanan bilgilerin kişiye ilişkin olduğunu ifade eder. Sonu&ccedil; unsuru ise i&ccedil;erik olarak kişisel veri niteliğinde olmayan verilerin kullanılacak olması durumlarında kişisel veriye d&ouml;n&uuml;şt&uuml;ğ&uuml; durumlarda s&ouml;z konusu olmaktadır. &Ouml;rneğin bir otomobil &uuml;reticisi, otomobillerine sens&ouml;r yerleştirerek satılan otomobillerin teknik durumları ile ilgili veriler elde etmeyi ama&ccedil;ladığı durumlarda, veri kullanıldığında otomobil kullanıcısının kişisel verilerine d&ouml;n&uuml;şebilmektedir.</p>

<p>Sonu&ccedil; olarak bu &uuml;&ccedil; şartın bir arada bulunduğu durumlarda kişisel verilerden bahsetmek m&uuml;mk&uuml;n olacaktır ve Kişisel Verilerin Korunması Kanunu ile T&uuml;rk Ceza Kanununun ilgili maddeleri uygulama alanı bulacaktır.</p>
', 1, N'kisisel-veri-nedir', 1, 1, NULL, NULL, NULL, CAST(N'2019-07-31T13:31:16.723' AS DateTime))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
SET IDENTITY_INSERT [dbo].[BlogTags] ON 

INSERT [dbo].[BlogTags] ([Id], [Name], [Link], [LanguageId]) VALUES (1, N'PraDijital', N'pradijital', 1)
SET IDENTITY_INSERT [dbo].[BlogTags] OFF
SET IDENTITY_INSERT [dbo].[ContactForm] ON 

INSERT [dbo].[ContactForm] ([Id], [FullName], [Subject], [Mail], [Phone], [Message], [Date]) VALUES (1, N'Abdülsamet DOĞAN', N'aa', N'asametdogann@gmail.com', N'5365170560', N'agga', CAST(N'2019-07-30T11:23:07.910' AS DateTime))
SET IDENTITY_INSERT [dbo].[ContactForm] OFF
SET IDENTITY_INSERT [dbo].[CustomerAttribute] ON 

INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (5, N'Ünvan', 1, 4, 0, N'%Name%', NULL)
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (6, N'Adres', 1, 10, 0, N'%Adress%', NULL)
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (7, N'Web Adres', 1, 4, 0, N'%WebAdress%', NULL)
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (8, N'Kimlik Bilgisi', 0, 3, 0, N'%IdentityInfo%', N'<p style="margin-left:0in; text-align:left"><strong><span style="color:null"><span style="font-size:10.5pt"><span style="font-family:Calibri">1- Kimlik Bilgisi</span></span></span></strong><br />
<span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">Siteye kayıt olmanız ile beraber &ldquo;Adınız&rdquo;, &ldquo;Soyadınız&rdquo;, &ldquo;Doğum Tarihiniz&rdquo;, &ldquo;Cinsiyetiniz&rdquo;, gibi bilgileri </span><span style="color:black"><strong>%WebAdress% ile</strong></span></span></span> <span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">kendi isteğiniz ile paylaşmaktasınız</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">.</span></span></span></p>

<p style="margin-left:0in; text-align:left"><br />
<span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:black"><strong>%WebAdress% &lsquo;ye </strong></span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">Facebook</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">, </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">Linkedin</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c"> v.b. sosyal ağlarda yer alan hesaplarınız aracılığıyla da isim, soy isim, doğum tarihi, elektronik posta adresi vb. bilgileri girmeden kayıt veya </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">&uuml;ye olmak m&uuml;mk&uuml;nd&uuml;r. İşbu Kişisel Verilerin Korunması ve Veri Politikası kapsamında sosyal ağlar &uuml;zerinden hizmetlerimize kayıt veya &uuml;ye olmayı tercih etmeniz halinde, s&ouml;z konusu </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">sosyal ağlar tarafından tarafımıza g&ouml;nderilen verileri işleme, aktarma, saklama yetkilerini tarafımıza vermiş </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">olursunuz.</span></span></span></p>
')
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (9, N'İletişim Bilgisi', 1, 3, 0, N'%ContactInfo%', N'<p style="margin-left:0in; text-align:left"><span style="font-size:10.5pt"><span style="font-family:Calibri"><span style="color:#002b4c">İletişim Bilgisi</span></span></span><br />
<span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:black"><strong>%WebAdress%&rsquo;ye</strong></span></span></span> <span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">kayıt olmanız ile beraber &ldquo;Elektronik Posta Adresiniz&rdquo;, &ldquo;Adresiniz&rdquo;, &ldquo;Yaşadığınız İl ve İl&ccedil;e&rdquo; ve &ldquo;Cep Telefonu&rdquo; gibi bilgileri </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:black"><strong>ABC.COM.TR ile</strong></span></span></span> <span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">kendi isteğiniz ile paylaşmaktasınız</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">.</span></span></span></p>
')
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (10, N'Beslenme Bilgisi ', 1, 3, 0, N'%NutritionInfo%', N'<p style="margin-left:0in; text-align:left"><span style="font-size:10.5pt"><span style="font-family:Calibri"><span style="color:#002b4c">Beslenme Bilgisi&nbsp;</span></span></span><br />
<span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">G&uuml;n i&ccedil;erisinde t&uuml;ketilen besinler ve buna uygun olarak alınan besin takviyeleri diyet programınızın hazırlanmasında &ouml;nem taşımaktadır. Bu kapsamda t&uuml;ketmekte olduğunuz et grubu &uuml;r&uuml;nler, sebzeler, tahıllar, meyveler ve diğer beslenme alışkanlık bilgilerinizi tarafımızla paylaşmak i&ccedil;in rızanızı vermiş olursunuz</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">.</span></span></span></p>
')
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (11, N'Beden Bilgileri', 1, 3, 0, N'%BdyInfo%', N'<p style="margin-left:0in; text-align:left"><span style="font-size:10.5pt"><span style="font-family:Calibri"><span style="color:#002b4c">Beden Bilgileri</span></span></span><br />
<span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">Diyet programınızın hazırlanması i&ccedil;in yaş, boy, kilo gibi bilgilerinizi tarafımızla paylaşmak i&ccedil;in rızanızı vermiş olursunuz</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">.</span></span></span></p>
')
INSERT [dbo].[CustomerAttribute] ([Id], [Name], [IsRequired], [AttributeControlTypeId], [DisplayOrder], [ResourceValue], [DefaultValue]) VALUES (12, N'Cihaz Bilgisi', 1, 3, 0, N'%DeviceInfo%', N'<p style="margin-left:0in; text-align:left"><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">Kullandığınız elektronik cihazlar (bilgisayar, diz &uuml;st&uuml; bilgisayar, tabletler, akıllı telefonlar, akıllı televizyonlar vb.) &uuml;zerinden cihazınıza ait sizle eşleştirilemeyecek </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">veya eşleştirilebilecek </span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">veriler (&ouml;rn. konum bilgisi gibi) toplayabiliriz. Mobil uygulamalarımız (</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">applications</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">) veya internet sitemizde yer alan anlık bildirimler (</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">push</span></span></span> <span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">notifications</span></span></span><span style="font-size:10.0pt"><span style="font-family:Calibri"><span style="color:#002b4c">) g&ouml;nderebiliriz. Bu mesajlarımızı almak istemiyorsanız cihazınızın veya mobil uygulamanın ayarlarını değiştirerek bu mesajlarımızı reddedebilirsiniz.</span></span></span></p>
')
SET IDENTITY_INSERT [dbo].[CustomerAttribute] OFF
SET IDENTITY_INSERT [dbo].[CustomerComments] ON 

INSERT [dbo].[CustomerComments] ([Id], [Name], [Comment], [FileName]) VALUES (6, N'Jeannette Simon3', N'<p>&quot;Duis autem vel eum iriure dolor in hendrerit vulputate velit esse molestie consequa vel illum dolore feugiat nulla eros accumsan iusto odio dignissim qui blandit praesent luptatum delenit augue duis dolore feugait nulla tempor cum soluta nobis eleifend option congue nihil imperdiet doming quod mazim.&quot;</p>
', N'0a79f49864dd4af3ba9e6724faca4a31.jpg')
INSERT [dbo].[CustomerComments] ([Id], [Name], [Comment], [FileName]) VALUES (7, N'Jeannette Simon2', N'<p>&quot;Duis autem vel eum iriure dolor in hendrerit vulputate velit esse molestie consequa vel illum dolore feugiat nulla eros accumsan iusto odio dignissim qui blandit praesent luptatum delenit augue duis dolore feugait nulla tempor cum soluta nobis eleifend option congue nihil imperdiet doming quod mazim.&quot;</p>
', NULL)
INSERT [dbo].[CustomerComments] ([Id], [Name], [Comment], [FileName]) VALUES (8, N'Jeannette Simon', N'<p>&quot;Duis autem vel eum iriure dolor in hendrerit vulputate velit esse molestie consequa vel illum dolore feugiat nulla eros accumsan iusto odio dignissim qui blandit praesent luptatum delenit augue duis dolore feugait nulla tempor cum soluta nobis eleifend option congue nihil imperdiet doming quod mazim.&quot;</p>
', NULL)
SET IDENTITY_INSERT [dbo].[CustomerComments] OFF
SET IDENTITY_INSERT [dbo].[CustomerPosPayments] ON 

INSERT [dbo].[CustomerPosPayments] ([Id], [PaymentDate], [CreditCardMaskedNumber], [ExpireYear], [ExpireMonth], [ClientIp], [PaymentAmount], [PaymentResult], [ResultMessage], [TransactionId], [WebsitesId]) VALUES (1, CAST(N'2020-02-01T11:10:23.960' AS DateTime), N'5406 67** **** 5403', 2026, 12, N'78.187.168.219', CAST(100.00 AS Decimal(12, 2)), 1, N'', N'20032LKVF18826', 20004)
SET IDENTITY_INSERT [dbo].[CustomerPosPayments] OFF
SET IDENTITY_INSERT [dbo].[FAQ] ON 

INSERT [dbo].[FAQ] ([Id], [Name], [Description], [CategoryId], [LanguageId], [Link]) VALUES (10, N'Veri Sorumluları Sicili Nedir?', N'<p>Veri Sorumluları Sicili (VERBİS), veri sorumlularının kayıt olmak zorunda oldukları ve veri işleme faaliyetleri ile ilgili bilgileri beyan ettikleri bir kayıt sistemidir. Veri sorumlularının, Kurulun g&ouml;zetiminde Başkanlık tarafından tutulmakta olan Veri Sorumluları Siciline kaydolmaları zorunludur. Dolayısıyla veri sorumlularının kimler olduğunun kamuya a&ccedil;ıklanması ve bu y&ouml;ntemle kişisel verilerin korunması hakkının daha etkin şekilde kullanılması hedeflenmektedir.</p>
', 2, 1, N'veri-sorumlulari-sicili-nedir')
INSERT [dbo].[FAQ] ([Id], [Name], [Description], [CategoryId], [LanguageId], [Link]) VALUES (11, N'Veri Sorumluluğu Siciline Kayıt İstisnaları', N'<p>Kural olarak, t&uuml;m veri sorumlularının Veri Sorumluları Siciline kaydolmaları gerekmektedir. S&ouml;z konusu kayıt işleminin, veri işleme faaliyetlerine başlamadan &ouml;nce tamamlanması gerekir.</p>

<p>Bununla birlikte, Kanunun 28. maddesinin 2. fıkrasında sayılan hallerde, Veri Sorumluları Siciline kayıt y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;n&uuml; d&uuml;zenleyen 16. madde h&uuml;k&uuml;mleri uygulanmayacaktır.</p>

<p>Ayrıca, Kanunda Kurula, sicile kayıt zorunluluğuna istisna getirme yetkisi verilmiştir. S&ouml;z konusu istisnanın uygulanmasında; işlenen kişisel verinin niteliği, sayısı, veri işlemenin Kanundan kaynaklanması veya &uuml;&ccedil;&uuml;nc&uuml; kişilere aktarılma durumu gibi Kurulca belirlenecek objektif kriterler g&ouml;z &ouml;n&uuml;ne alınmaktadır.</p>

<p>Sicile kayıt olma konusundaki y&uuml;k&uuml;ml&uuml;l&uuml;k; kişisel verilerin işlenmesi faaliyetleri bakımından a&ccedil;ıklık sağlanması ve veri sorumlarının mevzuata uyumlu hareket etmeleri konusunda daha g&uuml;venli bir ortam oluşturulması amacını taşımaktadır.</p>
', 2, 1, N'veri-sorumlulugu-siciline-kayit-stisnalari')
INSERT [dbo].[FAQ] ([Id], [Name], [Description], [CategoryId], [LanguageId], [Link]) VALUES (12, N'Veri Sorumluları Siciline Kayıt Bildiriminin Kapsamı', N'<p>Veri Sorumluları Siciline kayıt olmak i&ccedil;in başvuru, aşağıdaki bilgileri i&ccedil;eren bir bildirim ile yapılacaktır. S&ouml;z konusu bilgiler şunlardır:</p>

<ul>
	<li>Veri sorumlusu ve varsa temsilcisinin kimlik ve adres bilgileri,</li>
	<li>Kişisel verilerin hangi ama&ccedil;la işleneceği,</li>
	<li>Veri konusu kişi grubu ve grupları ile bu kişilere ait veri kategorileri hakkındaki a&ccedil;ıklamalar,</li>
	<li>Kişisel verilerin aktarılabileceği alıcı veya alıcı grupları,</li>
	<li>Yabancı &uuml;lkelere aktarımı &ouml;ng&ouml;r&uuml;len kişisel veriler,</li>
	<li>Kişisel veri g&uuml;venliğine ilişkin alınan tedbirler,</li>
	<li>Kişisel verilerin işlendikleri ama&ccedil; i&ccedil;in gerekli olan azami s&uuml;re.</li>
</ul>

<p>Yukarıda listelenen bilgilerde herhangi bir değişiklik olması halinde, s&ouml;z konusu değişikliklerin derhal Kuruma bildirilmesi gerekmektedir. B&ouml;ylelikle, Sicilin g&uuml;ncelliğinin sağlanması hedeflenmiştir.</p>
', 2, 1, N'veri-sorumlulari-siciline-kayit-bildiriminin-kapsami')
INSERT [dbo].[FAQ] ([Id], [Name], [Description], [CategoryId], [LanguageId], [Link]) VALUES (13, N'Kvkk Cezası Ne kadar?', N'<p>Farklı başlıklarda 5.000 TL ile 1.000.000 TL arasındaki tutarlarda idari para cezaları uygulanmaktadır.</p>
', 1, 1, N'kvkk-cezasi-ne-kadar')
INSERT [dbo].[FAQ] ([Id], [Name], [Description], [CategoryId], [LanguageId], [Link]) VALUES (14, N'Kişisel Verileri Korunması Kanunu'' nun Amaçları', N'<p>1- Kişisel verilerin şşlenme şartları</p>

<p>2- Kişisel verilerin işlenmesinde kişilerin temel hak ve &ouml;zg&uuml;rl&uuml;klerinin korunmasını</p>

<p>3- Kişisel verilerin işleyen ger&ccedil;ek ve t&uuml;zel kişilerin y&uuml;k&uuml;ml&uuml;l&uuml;kleri ile uyacakları usul ve esasları d&uuml;zenlemektir.</p>
', 1, 1, N'kisisel-verileri-korunmasi-kanunu-nun-amaclari')
SET IDENTITY_INSERT [dbo].[FAQ] OFF
SET IDENTITY_INSERT [dbo].[FAQCategories] ON 

INSERT [dbo].[FAQCategories] ([Id], [Name], [Active], [FileName], [SortOrder], [LanguageId], [Link]) VALUES (1, N'Kvkk', 1, NULL, 1, 1, N'test')
INSERT [dbo].[FAQCategories] ([Id], [Name], [Active], [FileName], [SortOrder], [LanguageId], [Link]) VALUES (2, N'Veri Sorumluları Sicili', 1, NULL, 2, 1, N'bbbb')
SET IDENTITY_INSERT [dbo].[FAQCategories] OFF
SET IDENTITY_INSERT [dbo].[Gallery] ON 

INSERT [dbo].[Gallery] ([Id], [Name], [Description], [FileName]) VALUES (5, N'test', NULL, N'42cb34231a5946b68543be638a616a2a.jpg')
SET IDENTITY_INSERT [dbo].[Gallery] OFF
SET IDENTITY_INSERT [dbo].[Keyword] ON 

INSERT [dbo].[Keyword] ([Id], [Name], [ImageUrl], [Price], [DocumentTemplate], [LanguageId]) VALUES (2, N'Çerez politikası', N'https://cdn.sstatic.net/Sites/stackoverflow/img/favicon.ico?v=4f32ecc8f43d', CAST(100.00 AS Decimal(18, 2)), N'<p style="margin-left:0cm; margin-right:0cm"><span style="font-size:11pt"><span style="font-family:Calibri,sans-serif"><span style="font-size:10.0pt"><span style="font-family:&quot;Arial&quot;,sans-serif"><span style="color:black"><strong>%Adress%&nbsp;</strong>adresinde mukim&nbsp; <strong>%Name%</strong>&#39; nin web sayfası olan <strong>%WebAdress%&nbsp;</strong>olarak kişisel verilerinizin g&uuml;venliği hususuna azami hassasiyet g&ouml;stermekteyiz.</span></span></span></span></span></p>

<p style="margin-left:0cm; margin-right:0cm"><span style="font-size:11pt"><span style="font-family:Calibri,sans-serif"><span style="font-size:10.0pt"><span style="font-family:&quot;Arial&quot;,sans-serif"><span style="color:black">Kişisel verileriniz 6698 sayılı Kişisel Verilerin Korunması Kanunu&#39;na (bundan b&ouml;yle <strong>&quot;KVKK&quot;</strong> olarak anılacaktır) uygun olarak işlenmekte ve muhafaza edilmektedir. Kişisel Verilerin Korunması Kanunu 7 Nisan 2016 tarihli ve 29677 sayılı Resmi Gazetede yayımlanmıştır. KVKK, kişisel verileri işlenen ger&ccedil;ek kişilerin Anayasamız ve T&uuml;rk Ceza Kanunlarımız tarafından da korunan &ouml;zel hayatın gizliliği de dahil olmak &uuml;zere ger&ccedil;ek kişilerin temel hak ve &ouml;zg&uuml;rl&uuml;klerini korumak ve kişisel verileri işleyen ger&ccedil;ek ve t&uuml;zel kişilerin y&uuml;k&uuml;ml&uuml;l&uuml;klerini belirlemek i&ccedil;in d&uuml;zenlenmiştir. Bu politikanın amacı <strong>%Name%</strong>&#39;nin ilgili kişilere ait kişisel verilerinin KVKK&#39;ya uyumlu bir şekilde işlenmesini ve korunmasını sağlamak i&ccedil;in y&ouml;netim talimatlarını, prosed&uuml;r şartlarını ve teknik bir politikasını oluşturmaktır. Kişisel verileriniz bu sayfada a&ccedil;ıklandığı &ccedil;er&ccedil;evede; kaydedilecek, saklanacak, g&uuml;ncellenecek, mevzuatın izin verdiği durumlarda 3. Kişilere a&ccedil;ıklanabilecek/devredilebilecek, sınıflandırılabilecek ve KVKK&#39;da sayılan şekillerde işlenebilecektir.</span></span></span></span></span></p>

<p><br />
%IdentityInfo%</p>

<p>&nbsp;</p>

<p>%ContactInfo%<br />
&nbsp;</p>

<p>&nbsp;</p>

<p>%NutritionInfo%</p>

<p>&nbsp;</p>

<p>%DeviceInfo%</p>

<p><br />
%BdyInfo%</p>
', 1)
SET IDENTITY_INSERT [dbo].[Keyword] OFF
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [Name], [ShortName], [CultureInfo]) VALUES (1, N'Türkçe', N'tr', N'tr-TR')
SET IDENTITY_INSERT [dbo].[Languages] OFF
SET IDENTITY_INSERT [dbo].[Pages] ON 

INSERT [dbo].[Pages] ([Id], [Name], [Link], [LanguageId], [Description]) VALUES (1, N'Gizlilik Sözleşmesi	', N'gizlilik-sozlesmesi', 1, N'<p>Bu beyan pradijital.com (Sahir Yazılım M&uuml;hendislik San.veTic. A.Ş.)&rsquo;un gizlilik politikasını i&ccedil;erir. pradijital.com web sitesini ziyaret ederek aşağıdaki şartları ve kuralları uygulamayı kabul etmiş sayılmaktasınız.</p>

<p>pradijital.com &uuml;yelik aşamasında ve daha sonrasında sizden bazı kişisel bilgilerinizi talep eder. Kişisel bilgilerinizin korunması ve gizliliğinizin s&uuml;rd&uuml;r&uuml;lebilmesi, pradijital.com ekibi olarak birinci &ouml;nceliğimizdir. Bu nedenle vermiş olduğunuz bilgiler, &Uuml;yelik S&ouml;zleşmesi&rsquo;nde belirtilen kurallar ve ama&ccedil;lar dışında herhangi bir kapsamda kullanılmayacak, &uuml;&ccedil;&uuml;nc&uuml; şahıslarla paylaşılmayacaktır.</p>

<p>Sistemle ilgili sorunların tespiti ve s&ouml;z konusu sorunların en hızlı şekilde giderilebilmesi i&ccedil;in, pradijital.com, gerektiğinde kullanıcıların IP adresini tespit etmekte ve bunu kullanmaktadır. IP adresleri, kullanıcıları genel bir şekilde tanımlamak ve kapsamlı demografik bilgi toplamak amacıyla da kullanılabilir.</p>

<p>Sitemizdeki kayıt formları, sipariş formları ve anketlerde irtibat bilgilerinizi (adınız, soyadınız, e-posta adresiniz, telefon numaralarınız, posta adresiniz ve y&uuml;kleme yapacağınız sitelerden size verilen api erişim bilgileriniz vb.) vermeniz talep edilmektedir. Ayrıca, satın alma formunda kredi kartı bilgileriniz kaydedilmeden, bir defaya mahsus kullanılmak &uuml;zere talep edilecektir. Yukarıda bahsedilen kişisel bilgileriniz; &uuml;yeliğinizi başlatmak, &uuml;r&uuml;n ve hizmetlerimizi sunmak, &ouml;demelerinizi ger&ccedil;ekleştirmek, entegrasyon hizmetleriniz ile ilgili bilgi vermek, &uuml;r&uuml;nler ve hizmetler hakkında pazarlama amacıyla sizinle irtibata ge&ccedil;mek, bilgilerinizi g&uuml;ncellemek, &uuml;yeliğinizi y&ouml;netmek ve s&uuml;rd&uuml;rmek, ilginizi &ccedil;ekebilecek &uuml;r&uuml;n ve hizmetleri &ouml;nermek ve 3. şahısların teknik, lojistik ve benzeri diğer işlevlerini bizim adımıza yerine getirmelerini sağlamak amacıyla kullanılmaktadır.</p>

<p>pradijital.com &uuml;yesi olduğunuz andan itibaren, tarafınızdan aksi talep edilmediği s&uuml;rece, g&uuml;nl&uuml;k ve haftalık bilgilendirme e-postaları, e-posta adresinize g&ouml;nderilecektir. Dilediğiniz zaman bu e-postalarla ilgili değişiklik yapma, hizmetten vazge&ccedil;me ve yeniden başlatma hakkınız bulunmaktadır. Bu e-postaların i&ccedil;eriği; satın almış olduğunuz paketle ilgili bilgiler, ilgileneceğinizi d&uuml;ş&uuml;nd&uuml;ğ&uuml;m&uuml;z diğer &uuml;r&uuml;nler, entegrasyonlarınızla ilgili bilgiler, 3. kişilerin reklamlarını ve benzeri bilgileri i&ccedil;erebilir. Demografik bilgiler, sitemizi kullanıcılarımızın ilgi alanlarına g&ouml;re uyarlamak i&ccedil;in kullanılmaktadır. Bu bilgiler, reklamların hedef kitleye uyarlanabilmesini temin etmek maksadıyla ve yalnızca diğer kullanıcılara ait bilgilerle birlikte olmak &uuml;zere, reklam verenlerle paylaşılabilir. Bu bilgilerde herhangi bir şekilde kişisel bilgi verilmez, sadece grup olarak kullanıcı eğilimleri ile ilgili bir takım &ccedil;ıkarımlar yapmak ve sınıflandırma amacıyla kullanılır.</p>

<p>&Ouml;deme sayfasında istenen kredi kartı bilgileriniz, siteden alışveriş yapan siz değerli m&uuml;şterilerimizin g&uuml;venliğini en &uuml;st seviyede tutmak amacıyla hi&ccedil;bir şekilde pradijital.com veya ona hizmet veren şirketlerin sunucularında tutulmamaktadır. Bu şekilde &ouml;demeye y&ouml;nelik t&uuml;m işlemlerin pradijital.com aray&uuml;z&uuml; &uuml;zerinden banka ve bilgisayarınız arasında ger&ccedil;ekleşmesi sağlanmaktadır.</p>

<p>T&uuml;m kredi kartı ve kişisel bilgileriniz, internet g&uuml;venlik standardı olan SSL Secure sistemi ile 128bit şifrelenmiştir. Bu şekilde, internet &uuml;zerindeki dolaşımları sırasında herhangi bir şekilde bu bilgilerinizin istenilmeyen kişi veya kurumlar tarafından ele ge&ccedil;irilmesi &ouml;nlenmiştir.</p>

<p>Bu gizlilik s&ouml;zleşmesinin i&ccedil;eriği kullanıcı tarafından kabul edilmektedir. Kullanıcı, bu gizlilik s&ouml;zleşmesi ve Pradijital Kullanıcı S&ouml;zleşmesi i&ccedil;eriğinde belirtildiği şekilde bilgilerinin kullanılmasını ve her t&uuml;rl&uuml; bilgilendirme e-postasının e-posta hesabına g&ouml;nderilmesini kabul etmektedir.</p>

<p>Gizlilik politikamız ile ilgili her t&uuml;rl&uuml; soru ve &ouml;neriniz i&ccedil;in sitemizdeki iletişim b&ouml;l&uuml;m&uuml;nden bize e-posta g&ouml;nderebilirsiniz.</p>

<p>pradijital.com &uuml;yelik iptal işleminizi panel.pradijital.com&rsquo;da &uuml;yelik iptali se&ccedil;eneği &uuml;zerinden işlem yaparak ger&ccedil;ekleştirebilirsiniz.</p>
')
INSERT [dbo].[Pages] ([Id], [Name], [Link], [LanguageId], [Description]) VALUES (2, N'Kişisel Verilerin Korunması ve İşlenmesi Politikası	', N'kisisel-verilerin-korunmasi-ve-slenmesi-politikasi', 1, N'<ol>
	<li><strong>Giriş</strong></li>
</ol>

<p><strong>1.1. Politikanın Amacı</strong></p>

<p>6698 sayılı Kişisel Verilerin Korunması Kanunu (&ldquo;Kanun&rdquo;) kapsamında</p>

<p>Sahir Yazılım M&uuml;hendislik San.ve Tic. Anonim Şirketi (&ldquo;Pradijital&rdquo; ve &ldquo;Şirket&rdquo;) olarak, kişisel verilerin yasalara uygun olarak işlenmesi ve korunması en m&uuml;him &ouml;nceliklerimiz arasındadır. T&uuml;m planlama ve iş faaliyetlerimizde de aynı &ouml;nceliği takip etmekteyiz. Bu &ccedil;er&ccedil;evede Kanun&rsquo;un 10. maddesi gereğince sizleri aydınlatmak; kişisel verilerin işlenmesi ve korunması kapsamında uygulayacağımız b&uuml;t&uuml;n idari ve teknik tedbirleri bildirmek amacıyla işbu Kişisel Verilerin İşlenmesi ve Korunması Politikası&rsquo;nı (&ldquo;Politika&rdquo;) sizlerin bilgisine sunarız.</p>

<p>&nbsp;</p>

<p><strong>1.2 Kapsamı</strong></p>

<p>İşbu Politika, kişisel verilerin işlenme şartlarını belirlemekte ve Pradijital tarafından kişisel verilerin işlenmesinde benimsenen prensipleri ortaya koymaktadır. Bu bağlamda Politika; Pradijital tarafından ger&ccedil;ekleştirilen Kanun kapsamındaki b&uuml;t&uuml;n kişisel veri işleme faaliyetlerini, işlenen t&uuml;m kişisel verileri ve bu verilerin sahiplerini kapsamaktadır.</p>

<p>&nbsp;</p>

<p><strong>1.3 Tanımlar</strong></p>

<p><strong>A&ccedil;ık Rıza:&nbsp;</strong>Belirli bir konuya ilişkin, bilgilendirilmeye dayanan ve &ouml;zg&uuml;r iradeyle a&ccedil;ıklanan rıza.</p>

<p><strong>Anonim Hale Getirme:</strong>&nbsp;Daha &ouml;ncesinde bir kişiyle ilişkilendirilmiş olan verilerin, başka verilerle eşleştirilerek dahi hi&ccedil;bir surette kimliği belirli veya belirlenebilir ger&ccedil;ek bir kişiyle ilişkilendirilemeyecek hale getirilmesi.</p>

<p><strong>&Ccedil;alışan Adayı:&nbsp;</strong>Pradijital b&uuml;nyesinde &ccedil;alışmayan ancak &ccedil;alışan adayı stat&uuml;s&uuml;nde olan ger&ccedil;ek kişiler.</p>

<p><strong>Kişisel Veri:</strong>&nbsp;Kimliği belirli veya belirlenebilir ger&ccedil;ek kişiye ilişkin her t&uuml;rl&uuml; bilgi.</p>

<p><strong>Veri Sahibi:&nbsp;</strong>Kişisel verisi işlenen ger&ccedil;ek kişi.</p>

<p><strong>Kişisel Verilerin İşlenmesi:</strong>Kişisel verilerin tamamen veya kısmen otomatik olan ya da herhangi bir veri kayıt sisteminin par&ccedil;ası olmak kaydıyla otomatik olmayan yollarla elde edilmesi, kaydedilmesi, depolanması, muhafaza edilmesi, değiştirilmesi, yeniden d&uuml;zenlenmesi, a&ccedil;ıklanması, aktarılması, devralınması, elde edilebilir hale getirilmesi, sınıflandırılması ya da kullanılmasının engellenmesi gibi veriler &uuml;zerinde ger&ccedil;ekleştirilen her t&uuml;rl&uuml; işlem.</p>

<p>Kanun&nbsp;7 Nisan 2016 tarihli ve 29677 sayılı Resmi Gazete&rsquo;de yayımlanan 6698 sayılı Kişisel Verilerin Korunması Kanunu.</p>

<p><strong>&Ouml;zel Nitelikli Kişisel Veri:</strong>&nbsp;Irk, etnik k&ouml;ken, siyasi d&uuml;ş&uuml;nce, felsefi inan&ccedil;, din, mezhep veya diğer inan&ccedil;lar, kılık kıyafet, dernek vakıf ya da sendika &uuml;yeliği, sağlık, cinsel hayat, ceza mahkumiyeti ve g&uuml;venlik tedbirleriyle ilgili veriler ile biyometrik ve genetik veriler.</p>

<p><strong>Politika:</strong>&nbsp;Sahir Yazılım M&uuml;hendislik San.ve Tic. Anonim Şirketi Kişisel Verilerin İşlenmesi ve Korunması Politikası</p>

<p><strong>Şirket/Pradijital</strong><strong>:</strong>&nbsp;Sahir Yazılım M&uuml;hendislik San.ve Tic. Anonim Şirketi</p>

<p><strong>Veri İşleyen:&nbsp;</strong>Veri sorumlusunun verdiği yetkiye dayanarak onun adına kişisel veri işleyen ger&ccedil;ek ve t&uuml;zel kişidir.</p>

<p><strong>Veri Sorumlusu:</strong>&nbsp;Kişisel verilerin işlenme ama&ccedil;larını ve vasıtalarını belirleyen, verilerin sistematik bir şekilde tutulduğu yeri y&ouml;neten kişidir.</p>

<p><strong>Veri Kayıt Sistemi:&nbsp;</strong>Kişisel verilerin belirli kriterlere g&ouml;re yapılandırılarak işlendiği kayıt sistemidir.</p>

<p><strong>İş Ortakları:&nbsp;</strong>Pradijital&rsquo;ın ticari faaliyetleri &ccedil;er&ccedil;evesinde s&ouml;zleşmesel ilişkiler kapsamında ortaklık kurduğu kişiler.</p>

<p><strong>1.4 Politikanın Y&uuml;r&uuml;rl&uuml;ğ&uuml;</strong></p>

<p>Pradijital tarafından d&uuml;zenlenen bu Politika 25 Mayıs tarihinde y&uuml;r&uuml;rl&uuml;ğe girmiş ve kamuoyuna sunulmuştur. Başta Kanun olmak &uuml;zere y&uuml;r&uuml;rl&uuml;kteki mevzuat ile bu Politika&rsquo;da yer verilen d&uuml;zenlemelerin &ccedil;elişmesi halinde mevzuat h&uuml;k&uuml;mleri uygulanır.</p>

<p>&nbsp;</p>

<p>Pradijital, yasal d&uuml;zenlemelere paralel olarak Politika&rsquo;da değişiklik yapma hakkını saklı tutar. Politika&rsquo;nın g&uuml;ncel haline Pradijital (www.pradijital.com) web sitesinden erişilebilirsiniz.</p>

<p>&nbsp;</p>

<ol start="2">
	<li><strong>Pradijital&rsquo;ın Y&uuml;r&uuml;tt&uuml;ğ&uuml; Kişisel Veri İşleme Faaliyetlerine Y&ouml;nelik Bilgiler</strong></li>
</ol>

<p><strong>2.1 Veri Sahipleri</strong></p>

<p>Politika kapsamındaki veri sahipleri, Pradijital tarafından kişisel verileri işlenen, Pradijital &ccedil;alışanları dışındaki t&uuml;m ger&ccedil;ek kişilerdir. Genel olarak veri sahipleri aşağıdaki şekilde sıralanabilir:</p>

<p>&nbsp;</p>

<p>Veri Sahibi Kategorileri&nbsp; A&ccedil;ıklama</p>

<p><strong>M&uuml;şteriler:&nbsp;</strong>Pradijital&rsquo;ın sunduğu &uuml;r&uuml;n ve hizmetlerden yararlanan ger&ccedil;ek kişileri ifade eder.</p>

<p><strong>Potansiyel M&uuml;şteriler:&nbsp;</strong>Pradijital&rsquo;ın sunduğu &uuml;r&uuml;n ve hizmetlere ilgi g&ouml;steren, m&uuml;şteriye d&ouml;n&uuml;şme potansiyeli olan ger&ccedil;ek kişileri ifade eder.</p>

<p><strong>&Ccedil;alışan Adayları:&nbsp;</strong>Pradijital&rsquo;a CV g&ouml;ndererek veya başka y&ouml;ntemlerle iş başvurusu yapan ger&ccedil;ek kişileri ifade eder.</p>

<p><strong>&Uuml;&ccedil;&uuml;nc&uuml; Kişiler:</strong>&nbsp;Yukarıda yer verilen veri sahibi kategorileri ile Pradijital &ccedil;alışanları hari&ccedil; ger&ccedil;ek kişileri ifade etmektedir.</p>

<p>Yukarıdaki tabloda a&ccedil;ıklanan veri sahibi kategorileri genel bilgi paylaşımı amacıyla belirtilmiştir. Veri sahibinin bu kategorilerden herhangi birinin kapsamına girmemesi, Kanun&rsquo;da belirtildiği şekilde veri sahibi niteliğini ortadan kaldırmamaktadır.</p>

<p>&nbsp;</p>

<p><strong>2.2 Kişisel Verilerin İşlenme Ama&ccedil;ları</strong></p>

<p><strong>2.2.1</strong>&nbsp;Pradijital&rsquo;ın sunduğu &uuml;r&uuml;n ve hizmetlerden ilgili kişileri faydalandırmak i&ccedil;in gerekli &ccedil;alışmaların ilgili birimler tarafından yapılması ve iş s&uuml;re&ccedil;lerinin y&uuml;r&uuml;t&uuml;lmesi:</p>

<p>&nbsp;</p>

<p>&Uuml;r&uuml;n ve/veya hizmetlerin satış s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>Satış sonrası destek hizmetleri aktivitelerinin planlanması ve/veya icra edilmesi,</p>

<p>M&uuml;şteri ilişkileri y&ouml;netimi s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>S&ouml;zleşme s&uuml;re&ccedil;lerinin ve/veya hukuki taleplerin takibi,</p>

<p>M&uuml;şteri talep ve/veya şikayetlerinin takibi.</p>

<p><strong>2.2.2 Pradijital</strong><strong> insan kaynakları politikaları ve s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi:</strong></p>

<p>Yetenek- kariyer gelişimi faaliyetlerinin planlanması ve icrası,</p>

<p>Şirket &ccedil;alışanları i&ccedil;in iş akdi ve/veya mevzuattan kaynaklı y&uuml;k&uuml;ml&uuml;l&uuml;klerin yerine getirilmesi,</p>

<p>&Ccedil;alışanlar i&ccedil;in yan haklar ve menfaatlerin planlanması ve icra edilmesi,</p>

<p>Şirket i&ccedil;i oryantasyon aktivitelerinin planlanması ve icra edilmesi,</p>

<p>Personel &ccedil;ıkış işlemlerinin planlanması ve icra edilmesi,</p>

<p>&Uuml;cret y&ouml;netimi</p>

<p>İnsan kaynakları s&uuml;re&ccedil;lerinin planlanması,</p>

<p>Personel temin s&uuml;re&ccedil;lerinin y&ouml;netilmesi,</p>

<p>Şirket i&ccedil;in atama-terfi ve işten ayrılma s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>&Ccedil;alışanların performans değerlendirme s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>&Ccedil;alışanların iş faaliyetlerinin takibi ve/veya denetimi,</p>

<p>Şirket i&ccedil;i eğitim faaliyetlerinin planlanması ve/veya icra edilmesi,</p>

<p>&Ccedil;alışan memnuniyetinin ve/veya bağlılığı s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>&Ccedil;alışanların iş ve/veya &uuml;retim s&uuml;re&ccedil;lerinin iyileştirilmesine y&ouml;nelik &ouml;nerilerin alınması ve değerlendirilmesi s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>Stajyer ve/veya &ouml;ğrenci temin, yerleştirilmesi ve operasyon s&uuml;re&ccedil;lerinin planlanması ve/veya icra edilmesi.</p>

<p><strong>2.2.3 Pradijital</strong><strong> tarafından y&uuml;r&uuml;t&uuml;len ticari faaliyetlerin ger&ccedil;ekleştirilmesi i&ccedil;in ilgili iş birimleri tarafından gerekli &ccedil;alışmaların yapılması ve buna bağlı iş s&uuml;re&ccedil;lerinin y&uuml;r&uuml;t&uuml;lmesi:</strong></p>

<p>&nbsp;</p>

<p>Etkinlik y&ouml;netimi,</p>

<p>İş faaliyetlerinin planlanması ve icra edilmesi,</p>

<p>Kurumsal iletişim faaliyetlerinin planlanması ve icra edilmesi,</p>

<p>Tedarik zinciri y&ouml;netimi s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>&Uuml;retim ve/veya operasyon s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>Bilgi g&uuml;venliği s&uuml;re&ccedil;lerinin planlanması, denetimi ve icra edilmesi,</p>

<p>Bilgi teknolojileri altyapısının oluşturulması ve y&ouml;netilmesi,</p>

<p>İş ortaklarının bilgiye erişim yetkilerinin planlanması ve icra edilmesi,</p>

<p>Finans ve/veya muhasebe işlerinin takibi,</p>

<p>Kurumsal s&uuml;rd&uuml;r&uuml;lebilirlik faaliyetlerin planlanması ve icra edilmesi,</p>

<p>Kurumsal y&ouml;netim faaliyetlerin planlanması ve icra edilmesi,</p>

<p>İş s&uuml;rekliliğinin sağlanması faaliyetlerinin planlanması ve/veya icra edilmesi,</p>

<p>Lojistik faaliyetlerinin planlanması ve icra edilmesi.</p>

<p><strong>2.2.4 Pradijital</strong><strong> tarafından sunulan &uuml;r&uuml;n ve hizmetlerin beğeni, kullanım alışkanlıkları ve ihtiya&ccedil;larına g&ouml;re &ouml;zelleştirilerek ilgili kişilere &ouml;nerilmesi ve tanıtılması i&ccedil;in gerekli olan aktivitelerin planlanması ve icra edilmesi:</strong></p>

<p>&nbsp;</p>

<p>Pazarlama faaliyetlerine konu edilecek kişilerin, t&uuml;ketici davranışı kriterleri doğrultusunda tespiti ve/veya değerlendirilmesi,</p>

<p>Kişiye &ouml;zel pazarlama ve/veya tanıtım aktivitelerinin tasarlanması ve/veya icra edilmesi,</p>

<p>Dijital ve/veya diğer mecralarda reklam ve/veya tanıtım ve/veya pazarlama aktivitelerinin tasarlanması ve/veya icra edilmesi,</p>

<p>Dijital ve/veya diğer mecralarda m&uuml;şteri kazanım ve/veya mevcut m&uuml;şterilerde değer yaratımı &uuml;zerine geliştirilecek aktivitelerin tasarlanması ve/veya icra edilmesi,</p>

<p>Pazarlama amacıyla veri analitiği &ccedil;alışmalarının planlanması ve/veya icra edilmesi,</p>

<p>&Uuml;r&uuml;n ve/veya hizmetlerin pazarlama s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>Şirketin sunduğu &uuml;r&uuml;n ve/veya hizmetlere bağlılık oluşturulması ve/veya arttırılması s&uuml;re&ccedil;lerinin planlanması ve/veya icra edilmesi.</p>

<p><strong>2.2.5 Pradijital</strong><strong>&rsquo;ın ticari ve/veya iş stratejilerinin planlanması ve icra edilmesi:</strong></p>

<p>İş ortakları ile olan ilişkilerin y&ouml;netilmesi.</p>

<p>&nbsp;</p>

<p><strong>2.2.6 Pradijital&rsquo;ın ve Pradijital</strong><strong> ile iş ilişkisi i&ccedil;erisinde olan ilgili kişilerin hukuki, teknik ve ticari iş g&uuml;venliğinin temini:</strong></p>

<p>&nbsp;</p>

<p><strong>Hukuk işlerinin takibi</strong></p>

<p>Şirket faaliyetlerinin şirket prosed&uuml;rleri ve/veya ilgili mevzuata uygun olarak y&uuml;r&uuml;t&uuml;lmesinin temini i&ccedil;in gerekli operasyonel faaliyetlerinin planlanması ve icra edilmesi,</p>

<p>Yetkili kuruluşlara mevzuattan kaynaklı bilgi verilmesi,</p>

<p>Ziyaret&ccedil;i kayıtlarının oluşturulması ve takibi,</p>

<p>Acil durum y&ouml;netimi s&uuml;re&ccedil;lerinin planlanması ve icra edilmesi,</p>

<p>Şirketler ve ortaklık hukuku işlemlerinin ger&ccedil;ekleştirilmesi,</p>

<p>Şirket denetim faaliyetlerinin planlanması ve icra edilmesi,</p>

<p>İş sağlığı ve/veya g&uuml;venliği s&uuml;re&ccedil;lerinin planlanması ve/veya icra edilmesi,</p>

<p>Kredi s&uuml;re&ccedil;leri risk y&ouml;netiminin ger&ccedil;ekleştirilmesi,</p>

<p>Şirket yerleşkeleri ve/veya tesislerinin g&uuml;venliğinin temini,</p>

<p>Şirket operasyonlarının g&uuml;venliğinin temini,</p>

<p>Şirketin finansal risk s&uuml;re&ccedil;lerinin planlanması ve/veya icra edilmesi,</p>

<p>Şirket demirbaşlarının ve/veya kaynaklarının g&uuml;venliğinin temini.</p>

<p><strong>2.3 Kişisel Veri Kategorileri</strong></p>

<p>Pradijital tarafından aşağıdaki şekilde kategorize edilen kişisel veriler, Kanun&rsquo;da ve ilgili mevzuatta yer alan kişisel veri işleme şartlarına uygun olarak işlenmektedir:</p>

<p>&nbsp;</p>

<p>Veri Kategorisi&nbsp; A&ccedil;ıklama</p>

<p><strong>Kimlik bilgisi:</strong>&nbsp;&nbsp;&nbsp; Ehliyet, n&uuml;fus c&uuml;zdanı, ikametg&acirc;h, pasaport, avukatlık kimliği, evlilik c&uuml;zdanı gibi belgelerde yer alan bilgiler.</p>

<p><strong>İletişim bilgisi:&nbsp;</strong>Kişiyle iletişim kurmak i&ccedil;in kullanılan bilgiler (&ouml;rn. e-mail adresi, telefon numarası, cep telefonu numarası, adres).</p>

<p><strong>Lokasyon bilgisi&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</strong>Veri sahibinin konumunu tespit etmeye yarayan bilgiler (&ouml;rn. ara&ccedil; kullanımı sırasında edinilen konum bilgileri).</p>

<p><strong>M&uuml;şteri bilgisi:</strong>&nbsp;&Uuml;r&uuml;n ve hizmetlerimizden faydalanan m&uuml;şterilere ait bilgiler (&ouml;rn. m&uuml;şteri no, meslek bilgisi, vb.).</p>

<p><strong>M&uuml;şteri işlem bilgisi:</strong>&nbsp;&nbsp;&nbsp;&nbsp; &Uuml;r&uuml;n ve hizmetlerimizden faydalanan m&uuml;şteriler tarafından ger&ccedil;ekleştirilen her t&uuml;rl&uuml; işleme ilişkin bilgiler.</p>

<p><strong>Fiziksel mek&acirc;n g&uuml;venlik bilgisi:&nbsp;</strong>Fiziksel mek&acirc;na girişte, fiziksel mek&acirc;nın i&ccedil;erisinde kalış sırasında alınan kamera kayıtları, parmak izi kayıtları gibi kayıtlar ve belgelere ilişkin kişisel veriler.</p>

<p><strong>İşlem g&uuml;venliği bilgisi:</strong>&nbsp; Pradijital&rsquo;ın ticari faaliyetlerini y&uuml;r&uuml;t&uuml;rken teknik, idari, hukuki ve ticari g&uuml;venliği sağlamak i&ccedil;in işlenen kişisel veriler.</p>

<p><strong>Finansal bilgi:</strong>&nbsp;&nbsp;Pradijital&rsquo;ın kişisel veri sahibi ile kurmuş olduğu hukuki ilişkinin tipine g&ouml;re yaratılan her t&uuml;rl&uuml; finansal sonucu g&ouml;steren bilgi, belge ve kayıtlara ilişkin işlenen kişisel veriler.</p>

<p><strong>&Ccedil;alışan adayı bilgisi:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pradijital&rsquo;ın &ccedil;alışanı olmak i&ccedil;in başvuruda bulunmuş veya ticari team&uuml;l ve d&uuml;r&uuml;stl&uuml;k kuralları gereği insan kaynakları ihtiya&ccedil;ları doğrultusunda &ccedil;alışan adayı olarak değerlendirilmiş veya Pradijital ile &ccedil;alışma ilişkisi i&ccedil;erisinde olan bireylerle ilgili işlenen kişisel veriler.</p>

<p><strong>Hukuki işlem ve uyum bilgisi:</strong>Pradijital&rsquo;ın hukuki alacak ve haklarının tespiti, takibi ve bor&ccedil;larının ifası ile kanuni y&uuml;k&uuml;ml&uuml;l&uuml;kleri ve şirketin politikalarına uyum kapsamında işlenen kişisel veriler.</p>

<p><strong>Denetim ve teftiş bilgisi:</strong>Pradijital&rsquo;ın kanuni y&uuml;k&uuml;ml&uuml;l&uuml;kleri ve şirket politikalarına uyumu kapsamında işlenen kişisel veriler.</p>

<p><strong>&Ouml;zel nitelikli veri:</strong>Kişilerin ırkı, etnik k&ouml;keni, siyasi d&uuml;ş&uuml;ncesi, felsefi inancı, dini, mezhebi veya diğer inan&ccedil;ları, kılık ve kıyafeti, dernek, vakıf ya da sendika &uuml;yeliği, sağlığı, cinsel hayatı, ceza mahk&ucirc;miyeti ve g&uuml;venlik tedbirleriyle ilgili verileri ile biyometrik ve genetik verileri.</p>

<p><strong>Pazarlama bilgisi:</strong>Pradijital&rsquo;ın sunduğu &uuml;r&uuml;n ve hizmetlerin kişisel veri sahibinin kullanım alışkanlıkları, beğenisi ve ihtiya&ccedil;ları doğrultusunda &ouml;zelleştirilerek pazarlamasının yapılmasına y&ouml;nelik işlenen kişisel veriler ve bu işleme sonu&ccedil;ları neticesinde yaratılan rapor ve değerlendirmeler.</p>

<p><strong>Talep/şikayet y&ouml;netimi bilgisi:</strong>Pradijital&rsquo;a y&ouml;neltilmiş olan her t&uuml;rl&uuml; talep veya şikayetin alınması ve değerlendirilmesine ilişkin kişisel veriler.</p>

<p><strong>İtibar y&ouml;netimi bilgisi:</strong>Pradijital&rsquo;ın ticari itibarını korumak maksatlı toplanan bilgiler ve buna ilişkin oluşturulan değerlendirme raporları ile alınan aksiyonlarla ilgili bilgiler.</p>

<p><strong>Olay y&ouml;netimi bilgisi:</strong>&nbsp;Pradijital&rsquo;ın ticari hak ve menfaatleri ile m&uuml;şterilerinin hak ve menfaatlerini korumak maksatlı gelişen olaylara karşı gerekli hukuki, teknik ve idari tedbirlerin alınmasına y&ouml;nelik olarak işlenen kişisel veriler.</p>

<ol start="3">
	<li><strong>Kişisel Verilerin İşlenmesine İlişkin İlke ve Şartlar</strong></li>
</ol>

<p>Pradijital, Kanun&rsquo;un 4. maddesine uygun olarak kişisel verilerin işlenmesi konusunda; hukuka ve d&uuml;r&uuml;stl&uuml;k kurallarına uygun, doğru ve gerektiğinde g&uuml;ncel, belirli, a&ccedil;ık ve meşru ama&ccedil;lar g&uuml;derek, ama&ccedil; ile bağlantılı, sınırlı ve &ouml;l&ccedil;&uuml;l&uuml; bir bi&ccedil;imde kişisel veri işleme faaliyetinde bulunmaktadır. Pradijital, kanunlarda &ouml;ng&ouml;r&uuml;len veya kişisel veri işleme amacının gerektirdiği s&uuml;re kadar kişisel verileri muhafaza eder.</p>

<p>&nbsp;</p>

<p><strong>&nbsp;</strong></p>

<p><strong>3.1 Kişisel Verilerin İşlenmesine İlişkin İlkeler</strong></p>

<p>Pradijital, KVK Kanunu&rsquo;nun 10. maddesine uygun olarak veri sahiplerini aydınlatmaktır ve rıza alınması gereken durumlarda veri sahiplerinden rızalarını talep ederek bu kişisel verileri aşağıda belirtilen ilkeleri esas alarak işler.</p>

<p>&nbsp;</p>

<p><strong>3.1.1 Verilerin Hukuka ve D&uuml;r&uuml;stl&uuml;k Kuralına Uygun İşlenmesi</strong></p>

<p>&nbsp;</p>

<p>Pradijital, kişisel verilerin işlenmesinde hukuksal d&uuml;zenlemelerle getirilen ilkeler ile genel g&uuml;ven ve d&uuml;r&uuml;stl&uuml;k kuralına uygun hareket etmektedir. D&uuml;r&uuml;stl&uuml;k kuralına uygun olma ilkesi uyarınca Pradijital veri işlemedeki hedeflerine ulaşmaya &ccedil;alışırken, ilgili kişilerin &ccedil;ıkarlarını ve makul beklentilerini dikkate almaktadır.</p>

<p>&nbsp;</p>

<p><strong>3.1.2 Kişisel Verilerin Doğru ve Gerektiğinde G&uuml;ncel Olmasının Sağlanması</strong></p>

<p>&nbsp;</p>

<p>Kişisel verilerin doğru ve g&uuml;ncel bir şekilde tutulması, Pradijital a&ccedil;ısından ilgili kişinin temel hak ve &ouml;zg&uuml;rl&uuml;klerinin korunması i&ccedil;in gereklidir. Kişisel verilerin doğru ve gerektiğinde g&uuml;ncel olmasının sağlanması noktasında Pradijital&rsquo;ın aktif &ouml;zen y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; bulunmaktadır. Bu sebeple Pradijital tarafından veri sahibi olan ilgili kişinin bilgilerinin doğru ve g&uuml;ncel olarak tutulması i&ccedil;in b&uuml;t&uuml;n iletişim kanalları a&ccedil;ıktır.</p>

<p>&nbsp;</p>

<p><strong>3.1.3 Verilerin Belirli, A&ccedil;ık ve Meşru Ama&ccedil;larla İşlenmesi</strong></p>

<p>&nbsp;</p>

<p>Pradijital, meşru ve hukuka uygun olan kişisel veri işleme amacını a&ccedil;ık ve kesin olarak belirlemektedir. Y&uuml;r&uuml;tmekte olduğu ticari faaliyet ile bağlantılı ve bunlar i&ccedil;in gerekli olan kadar kişisel veriyi işlemektedir.</p>

<p>&nbsp;</p>

<p><strong>3.1.4 Verilerin İşlendikleri Ama&ccedil;la Bağlantılı, Sınırlı ve &Ouml;l&ccedil;&uuml;l&uuml; Olması</strong></p>

<p>&nbsp;</p>

<p>Pradijital; kişisel verileri, iştigal konusu ile ilgili ve işinin y&uuml;r&uuml;t&uuml;lmesi i&ccedil;in gerekli olan ama&ccedil;lar dahilinde işlemektedir. Bu sebeple, kişisel verileri belirlenen ama&ccedil;ların ger&ccedil;ekleştirilebilmesine elverişli bir bi&ccedil;imde işlemekte ve amacın ger&ccedil;ekleştirilmesiyle ilgili olmayan veya ihtiya&ccedil; duyulmayan kişisel verilerin işlenmesinden ka&ccedil;ınmaktadır.</p>

<p>&nbsp;</p>

<p><strong>3.1.5 Verilerin İlgili Mevzuatta &Ouml;ng&ouml;r&uuml;len veya İşlendikleri Ama&ccedil; i&ccedil;in Gerekli Olan S&uuml;re Kadar Muhafaza Edilmesi</strong></p>

<p>&nbsp;</p>

<p>Pradijital, kişisel verileri ancak ilgili mevzuatta belirtildiği veya işlendikleri ama&ccedil; i&ccedil;in gerekli olan s&uuml;re kadar muhafaza etmektedir. Bu kapsamda; &ouml;ncelikle ilgili mevzuatta kişisel verilerin saklanması i&ccedil;in bir s&uuml;re &ouml;ng&ouml;r&uuml;l&uuml;p &ouml;ng&ouml;r&uuml;lmediğini tespit etmekte, bir s&uuml;re belirlenmişse bu s&uuml;reye uygun davranmakta, bir s&uuml;re belirlenmemişse kişisel verileri işlendikleri ama&ccedil; i&ccedil;in gerekli olan s&uuml;re kadar saklamaktadır. Kişisel veri işleme amacının ortadan kalkmasından sonra ya da mevzuatta &ouml;ng&ouml;r&uuml;len s&uuml;renin dolması ile birlikte kişisel veriler Pradijital tarafından silinmekte, yok edilmekte veya anonimleştirilmektedir.</p>

<p>&nbsp;</p>

<p><strong>&nbsp;</strong></p>

<p><strong>&nbsp;</strong></p>

<p><strong>3.2 Kişisel Verilerin İşlenmesine İlişkin Şartlar</strong></p>

<p>Kanun&rsquo;un 5. Maddesinde yer alan kişisel veri işleme şartlarından en az birinin varlığı halinde kişisel verileriniz Pradijital tarafından işlenmektedir.</p>

<p>&nbsp;</p>

<p><strong>3.2.1 Kişisel veri sahibinin a&ccedil;ık rızasının olması</strong></p>

<p>&nbsp;</p>

<p>Kişisel verilerin işlenme şartlarından biri sahibinin a&ccedil;ık rızasıdır. Kişisel veri sahibinin a&ccedil;ık rızası belirli bir konuya ilişkin, bilgilendirilmeye dayalı olarak ve &ouml;zg&uuml;r iradeyle a&ccedil;ıklanmalıdır.</p>

<p>&nbsp;</p>

<p>Kişisel verilerin, kişisel veri sahibinin a&ccedil;ık rıza vermesine bağlı olarak işlenmesi i&ccedil;in, m&uuml;şteri, potansiyel m&uuml;şteri ve ziyaret&ccedil;ilerden ilgili y&ouml;ntemler ile a&ccedil;ık rızaları alınmaktadır.</p>

<p>&nbsp;</p>

<p><strong>3.2.2 Kişisel veri işleme faaliyetlerinin kanunlarda a&ccedil;ık&ccedil;a &ouml;n g&ouml;r&uuml;lmesi</strong></p>

<p>Veri sahibinin kişisel verileri, kanunda a&ccedil;ık&ccedil;a &ouml;ng&ouml;r&uuml;lmesi halinde veri sahibinin a&ccedil;ık rızası olmadan da hukuka uygun olarak işlenebilmektedir.</p>

<p>&nbsp;</p>

<p><strong>3.2.3 Fiili imkansızlık sebebiyle kişinin a&ccedil;ık rızasının alınamaması</strong></p>

<p>Fiili imkansızlık nedeniyle rızasını a&ccedil;ıklayamayacak durumda olan veya rızasına ge&ccedil;erlilik tanınmayacak olan kişinin kendisinin veya başka bir kişinin hayatı ya da beden b&uuml;t&uuml;nl&uuml;ğ&uuml;n&uuml; korumak i&ccedil;in kişisel verisinin işlenmesinin zorunlu olması halinde veri sahibinin kişisel verileri işlenebilmektedir.</p>

<p>&nbsp;</p>

<p><strong>3.2.4 Kişisel verinin, bir s&ouml;zleşmenin kurulması veya ifasıyla doğrudan ilgisi olması</strong></p>

<p>Bir s&ouml;zleşmenin kurulması veya ifasıyla doğrudan doğruya ilgili olması kaydıyla, s&ouml;zleşmenin taraflarına ait kişisel verilerin işlenmesinin gerekli olması halinde kişisel verilerin işlenmesi m&uuml;mk&uuml;nd&uuml;r.</p>

<p>&nbsp;</p>

<p><strong>3.2.5 Pradijital</strong><strong>&rsquo;ın hukuki y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;n&uuml; yerine getirmesi</strong></p>

<p>Prapazar&rsquo;ın veri sorumlusu olarak hukuki y&uuml;k&uuml;ml&uuml;l&uuml;klerini yerine getirmesi i&ccedil;in işlenmenin zorunlu olması durumunda veri sahibinin kişisel verileri işlenebilmektedir.</p>

<p>&nbsp;</p>

<p><strong>3.2.6 Veri sahibinin kişisel verilerinin alenileştirilmesi</strong></p>

<p>Veri sahibinin, kişisel verisini kendisi tarafından alenileştirilmiş olması halinde ilgili kişisel veriler işlenebilecektir.</p>

<p>&nbsp;</p>

<p><strong>3.2.7 Bir hakkın tesisi veya korunması i&ccedil;in veri işlemenin zorunlu olması</strong></p>

<p>Bir hakkın tesisi, kullanılması veya korunması i&ccedil;in veri işlemenin zorunlu olması halinde veri sahibinin kişisel verileri işlenebilecektir.</p>

<p><strong>3.2.8 Pradijital</strong><strong>&rsquo;ın meşru menfaati i&ccedil;in veri işlemenin zorunlu olması</strong></p>

<p>Kişisel veri sahibinin temel hak ve &ouml;zg&uuml;rl&uuml;klerine zarar vermemek kaydıyla, Prapazar&rsquo;ın meşru menfaatleri i&ccedil;in veri işlemesinin zorunlu olması halinde veri sahibinin kişisel verileri işlenebilecektir.</p>

<p>&nbsp;</p>

<p><strong>3.3 &Ouml;zel Nitelikli Kişisel Verilerin İşlenmesi</strong></p>

<p>Pradijital tarafından, KVK Kanunu ile &ldquo;&ouml;zel nitelikli&rdquo; olarak belirlenen kişisel verilerin işlenmesinde, KVK Kanunu&rsquo;nda &ouml;ng&ouml;r&uuml;len d&uuml;zenlemelere hassasiyetle uygun davranılmaktadır.</p>

<p>&nbsp;</p>

<p>Pradijital tarafından; &ouml;zel nitelikli kişisel veriler, KVK Kurulu tarafından belirlenecek olan yeterli &ouml;nlemlerin alınması kaydıyla aşağıdaki durumlarda işlenmektedir:</p>

<p>&nbsp;</p>

<p>Kişisel veri sahibinin a&ccedil;ık rızası var ise veya</p>

<p>Kişisel veri sahibinin a&ccedil;ık rızası yok ise;</p>

<p>Kişisel veri sahibinin sağlığı ve cinsel hayatı dışındaki &ouml;zel nitelikli kişisel veriler, kanunlarda &ouml;ng&ouml;r&uuml;len hallerde,</p>

<p>Kişisel veri sahibinin sağlığına ve cinsel hayatına ilişkin &ouml;zel nitelikli kişisel verileri ise ancak kamu sağlığının korunması, koruyucu hekimlik, tıbbi teşhis, tedavi ve bakım hizmetlerinin y&uuml;r&uuml;t&uuml;lmesi, sağlık hizmetleri ile finansmanının planlanması ve y&ouml;netimi amacıyla, sır saklama y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; altında bulunan kişiler veya yetkili kurum ve kuruluşlar tarafından işlenmektedir.</p>

<ol start="4">
	<li><strong>Kişisel Verilerin Aktarılması</strong></li>
</ol>

<p>Pradijital hukuka uygun olan kişisel veri işleme ama&ccedil;ları doğrultusunda gerekli g&uuml;venlik &ouml;nlemlerini alarak veri sahibinin kişisel verilerini ve &ouml;zel nitelikli kişisel verilerini yurt i&ccedil;i veya yurt dışındaki &uuml;&ccedil;&uuml;nc&uuml; kişilere aktarabilmektedir. Pradijital bu doğrultuda KVK Kanunu&rsquo;nun 8. maddesinde &ouml;ng&ouml;r&uuml;len d&uuml;zenlemelere uygun hareket etmektedir.</p>

<p>&nbsp;</p>

<p><strong>4.1 Kişisel verilerin yurt i&ccedil;indeki &uuml;&ccedil;&uuml;nc&uuml; kişilere aktarımı</strong></p>

<p>Kanun&rsquo;un 5. ve 6. maddesinde yer alan ve bu Politika&rsquo;nın 3. Başlığı altında a&ccedil;ıklanmış olan veri işleme şartlarından en az birinin varlığı halinde ve veri işleme şartlarına ilişkin temel ilkelere uymak şartıyla kişisel verileriniz Pradijital tarafından aktarılabilmektedir.</p>

<p>&nbsp;</p>

<p><strong>4.2 Kişisel verilerin yurt dışındaki &uuml;&ccedil;&uuml;nc&uuml; kişilere aktarımı</strong></p>

<p>Pradijital bu Politika&rsquo;nın 3. Başlığı altında a&ccedil;ıklanmış olan veri işleme şartlarından en az birinin varlığı halinde ve gerekli g&uuml;venlik &ouml;nlemlerini alarak kişisel veri sahibinin kişisel verilerini ve &ouml;zel nitelikli kişisel verilerini yurt dışındaki &uuml;&ccedil;&uuml;nc&uuml; kişilere aktarabilmektedir. Pradijital tarafından kişisel veriler; KVK Kurulu tarafından yeterli korumaya sahip olduğu ilan edilen yabancı &uuml;lkelere (&ldquo;Yeterli Korumaya Sahip Yabancı &Uuml;lke&rdquo;) veya yeterli korumanın bulunmaması durumunda T&uuml;rkiye&rsquo;deki ve ilgili yabancı &uuml;lkedeki veri sorumlularının yeterli bir korumayı yazılı olarak taahh&uuml;t ettiği ve KVK Kurulu&rsquo;nun izninin bulunduğu yabancı &uuml;lkelere (&ldquo;Yeterli Korumayı Taahh&uuml;t Eden Veri Sorumlusunun Bulunduğu Yabancı &Uuml;lke&rdquo;) aktarılmaktadır. Pradijital bu doğrultuda KVK Kanunu&rsquo;nun 9. maddesinde &ouml;ng&ouml;r&uuml;len d&uuml;zenlemelere uygun hareket etmektedir.</p>

<p>&nbsp;</p>

<p><strong>&nbsp;</strong></p>

<p><strong>&nbsp;</strong></p>

<p><strong>&nbsp;</strong></p>

<p><strong>&nbsp;</strong></p>

<p><strong>&nbsp;</strong></p>

<p><strong>4.3 Kişisel verilerin aktarıldığı &uuml;&ccedil;&uuml;nc&uuml; kişiler ve aktarılma ama&ccedil;ları</strong></p>

<p>Kanunun genel ilkeleri ile 8. ve 9. maddelerinde yer alan veri işleme şartları dahilinde Pradijital, aşağıdaki tabloda kategorizasyonu yapılmış taraflara veri aktarımı ger&ccedil;ekleştirebilmektedir:</p>

<table>
	<tbody>
		<tr>
			<td>
			<p><strong>Veri Aktarımı Yapılabilecek Kişiler</strong></p>
			</td>
			<td>
			<p><strong>Tanım</strong></p>
			</td>
			<td>
			<p><strong>Ama&ccedil;</strong></p>
			</td>
		</tr>
		<tr>
			<td>
			<p>İş Ortağı</p>
			</td>
			<td>
			<p>Pradijital&rsquo;ın ticari faaliyetlerini y&uuml;r&uuml;t&uuml;rken iş ortaklığı kurduğu taraflar</p>
			</td>
			<td>
			<p>İş ortaklığının kurulma ama&ccedil;larının yerine getirilmesini temin etmek amacıyla sınırlı olarak kişisel verilerin paylaşımı</p>
			</td>
		</tr>
		<tr>
			<td>
			<p>Hissedarlar</p>
			</td>
			<td>
			<p>İlgili mevzuat h&uuml;k&uuml;mlerine g&ouml;re Pradijital&rsquo;ın ticari faaliyetlerine ilişkin stratejilerinin ve denetim faaliyetlerinin tasarlanması konusunda yetkili olan hissedarlar</p>
			</td>
			<td>
			<p>Pradijital&rsquo;ın ticari faaliyetlerine ilişkin stratejilerin tasarlanması ve denetim ama&ccedil;larıyla sınırlı olarak kişisel verilerin paylaşımı</p>
			</td>
		</tr>
		<tr>
			<td>
			<p>Şirket Yetkilileri</p>
			</td>
			<td>
			<p>Y&ouml;netim kurulu &uuml;yeleri ve diğer yetkilendirilen kişiler</p>
			</td>
			<td>
			<p>Pradijital&rsquo;ın ticari faaliyetlerine ilişkin stratejilerin tasarlanması, en &uuml;st d&uuml;zeyde y&ouml;netiminin sağlanması ve denetim ama&ccedil;larıyla sınırlı olarak kişisel verilerin paylaşımı</p>
			</td>
		</tr>
		<tr>
			<td>
			<p>Hukuken Yetkili Kamu Kurum ve Kuruluşları</p>
			</td>
			<td>
			<p>Hukuken Pradijital&rsquo;dan bilgi ve belge almaya yetkili kamu kurum ve kuruluşları</p>
			</td>
			<td>
			<p>İlgili kamu kurum ve kuruluşlarının bilgi talep etme amacıyla sınırlı olarak kişisel veri paylaşımı</p>
			</td>
		</tr>
		<tr>
			<td>
			<p>Hukuken Yetkili &Ouml;zel Hukuk Kişileri</p>
			</td>
			<td>
			<p>Hukuken Pradijital&rsquo;dan bilgi ve belge almaya yetkili &ouml;zel hukuk kişileri</p>
			</td>
			<td>
			<p>İlgili &ouml;zel hukuk kişilerinin hukuki yetkisi dahilin de talep ettiği ama&ccedil;la sınırlı olarak verilerin paylaşımı</p>
			</td>
		</tr>
	</tbody>
</table>

<ol start="5">
	<li><strong>Veri Sahibinin Hakları ve İlgili Hakların Kullanılması</strong></li>
</ol>

<p><strong>5.1 Kişisel veri sahibinin hakları:</strong></p>

<p>Kişisel verilerinin işlenip işlenmediğini &ouml;ğrenme,</p>

<p>Kişisel verileri işlenmişse buna ilişkin bilgi talep etme,</p>

<p>Kişisel verilerin işlenme amacını ve bunların amacına uygun kullanılıp kullanılmadığını &ouml;ğrenme,</p>

<p>Yurt i&ccedil;inde veya yurt dışında kişisel verilerin aktarıldığı &uuml;&ccedil;&uuml;nc&uuml; kişileri bilme,</p>

<p>Kişisel verilerin eksik veya yanlış işlenmiş olması h&acirc;linde bunların d&uuml;zeltilmesini isteme ve bu kapsamda yapılan işlemin kişisel verilerin aktarıldığı &uuml;&ccedil;&uuml;nc&uuml; kişilere bildirilmesini isteme,</p>

<p>KVK Kanunu ve ilgili diğer kanun h&uuml;k&uuml;mlerine uygun olarak işlenmiş olmasına rağmen, işlenmesini gerektiren sebeplerin ortadan kalkması h&acirc;linde kişisel verilerin silinmesini veya yok edilmesini isteme ve bu kapsamda yapılan işlemin kişisel verilerin aktarıldığı &uuml;&ccedil;&uuml;nc&uuml; kişilere bildirilmesini isteme,</p>

<p>İşlenen verilerin m&uuml;nhasıran otomatik sistemler vasıtasıyla analiz edilmesi suretiyle kişinin kendisi aleyhine bir sonucun ortaya &ccedil;ıkması halinde bu sonuca itiraz etme,</p>

<p>Kişisel verilerin kanuna aykırı olarak işlenmesi sebebiyle zarara uğraması h&acirc;linde zararın giderilmesini talep etme.</p>

<p>Kişisel verilerin doğrudan veri sahibinden elde edilmemesi halinde; Pradijital tarafından (1) kişisel verilerin elde edilmesinden itibaren makul bir s&uuml;re i&ccedil;erisinde, (2) kişisel verilerin veri sahipleri kişi ile iletişim amacıyla kullanılacak olması durumunda, ilk iletişim kurulması esnasında, (3) kişisel verilerin aktarılacak olması halinde, en ge&ccedil; kişisel verilerin ilk kez aktarımının yapılacağı esnada veri sahiplerinin aydınlatılmasına ilişkin faaliyetler y&uuml;r&uuml;t&uuml;lmektedir.</p>

<p>&nbsp;</p>

<p><strong>5.2 Kişisel veri sahibinin haklarını ileri s&uuml;remeyeceği haller:</strong></p>

<p>Kişisel veri sahipleri, KVK Kanunu&rsquo;nun 28. maddesi gereğince aşağıdaki haller KVK Kanunu kapsamı dışında tutulduğundan, bu konularda 5.1&rsquo;de sayılan haklarını ileri s&uuml;remezler:</p>

<p>&nbsp;</p>

<p>Kişisel verilerin, &uuml;&ccedil;&uuml;nc&uuml; kişilere verilmemek ve veri güvenliğine ilişkin yükümlülüklere uyulmak kaydıyla gerçek kişiler tarafından tamamen kendisiyle veya aynı konutta yaşayan aile fertleriyle ilgili faaliyetler kapsamında işlenmesi,</p>

<p>Kişisel verilerin resmi istatistik ile anonim h&acirc;le getirilmek suretiyle araştırma, planlama ve istatistik gibi ama&ccedil;larla işlenmesi,</p>

<p>Kişisel verilerin mill&icirc; savunmayı, mill&icirc; g&uuml;venliği, kamu g&uuml;venliğini, kamu d&uuml;zenini, ekonomik g&uuml;venliği, &ouml;zel hayatın gizliliğini veya kişilik haklarını ihlal etmemek ya da su&ccedil; teşkil etmemek kaydıyla, sanat, tarih, edebiyat veya bilimsel ama&ccedil;larla ya da ifade &ouml;zg&uuml;rl&uuml;ğ&uuml; kapsamında işlenmesi,</p>

<p>Kişisel verilerin mill&icirc; savunmayı, mill&icirc; g&uuml;venliği, kamu g&uuml;venliğini, kamu d&uuml;zenini veya ekonomik g&uuml;venliği sağlamaya y&ouml;nelik olarak kanunla g&ouml;rev ve yetki verilmiş kamu kurum ve kuruluşları tarafından y&uuml;r&uuml;t&uuml;len &ouml;nleyici, koruyucu ve istihbari faaliyetler kapsamında işlenmesi,</p>

<p>Kişisel verilerin soruşturma, kovuşturma, yargılama veya infaz işlemlerine ilişkin olarak yargı makamları veya infaz mercileri tarafından işlenmesi.</p>

<p>KVK Kanunu&rsquo;nun 28.2. maddesi gereğince; aşağıda sıralanan hallerde kişisel veri sahipleri zararın giderilmesini talep etme hakkı hari&ccedil;, 5.1&rsquo;de sayılan diğer haklarını ileri s&uuml;remezler:</p>

<p>&nbsp;</p>

<p>Kişisel veri işlemenin su&ccedil; işlenmesinin &ouml;nlenmesi veya su&ccedil; soruşturması i&ccedil;in gerekli olması,</p>

<p>Kişisel veri sahibinin kendisi tarafından alenileştirilmiş kişisel verilerin işlenmesi,</p>

<p>Kişisel veri işlemenin kanunun verdiği yetkiye dayanılarak g&ouml;revli ve yetkili kamu kurum ve kuruluşları ile kamu kurumu niteliğindeki meslek kuruluşlarınca, denetleme veya d&uuml;zenleme g&ouml;revlerinin y&uuml;r&uuml;t&uuml;lmesi ile disiplin soruşturma veya kovuşturması i&ccedil;in gerekli olması,</p>

<p>Kişisel veri işlemenin b&uuml;t&ccedil;e, vergi ve mali konulara ilişkin olarak Devletin ekonomik ve mali &ccedil;ıkarlarının korunması i&ccedil;in gerekli olması.</p>

<ol start="6">
	<li><strong>Kişisel Verilerin Silinmesi, Yok Edilmesi, Anonim Hale Getirilmesi</strong></li>
</ol>

<p>T&uuml;rk Ceza Kanunu&rsquo;nun 138. maddesinde ve KVK Kanunu&rsquo;nun 7. maddesinde d&uuml;zenlendiği &uuml;zere ilgili kanun h&uuml;k&uuml;mlerine uygun olarak işlenmiş olmasına rağmen, işlenmesini gerektiren sebeplerin ortadan kalkması h&acirc;linde Pradijital&rsquo;ın kararına istinaden veya kişisel veri sahibinin talebi &uuml;zerine kişisel veriler silinir, yok edilir veya anonim h&acirc;le getirilir. Bu kapsamda Pradijital ilgili y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;n&uuml; yerine getirmek &uuml;zere Şirket i&ccedil;erisinde gerekli teknik ve idari tedbirleri alarak; bu konuda gerekli işleyiş mekanizmaları geliştirmiş olup; bu y&uuml;k&uuml;ml&uuml;l&uuml;klerine uygun davranmak &uuml;zere ilgili iş birimlerini eğitmekte, g&ouml;revlendirme ve farkındalıklarını sağlamaktadır.</p>

<p>&nbsp;</p>

<p>Bizimle İletişime Ge&ccedil;in</p>

<p>Kişisel Verilerin Korunması Politikası ile ilgili t&uuml;m soru ve g&ouml;r&uuml;şlerinizi iletmek i&ccedil;in bize ulaşın!</p>

<p>&nbsp;</p>

<p><strong>https://www.pradijital.com/iletisim</strong></p>
')
INSERT [dbo].[Pages] ([Id], [Name], [Link], [LanguageId], [Description]) VALUES (3, N'Prasoft Çerez Politikası	', N'pradijital-cerez-politikasi', 1, N'<p>&Ccedil;erez Politikası</p>

<p>Prasoft (Sahir Yazılım A.Ş.) farklı sebeplerden &ouml;t&uuml;r&uuml; web sitelerinde &ccedil;erezler ve benzer teknolojiler kullanmaktadır. Bu politika &ldquo;&ccedil;erezler&rdquo;e atıfta bulunduğunda hem &ccedil;erezlere hem de &ccedil;erezlerle aynı şekilde &ccedil;alışan benzer teknolojilere atıfta bulunmaktadır. Bu politika &ldquo;bilgisayarlar&rdquo;a atıfta bulunduğunda bilgisayarlara, akıllı telefonlara ve internete erişim i&ccedil;in kullanılan b&uuml;t&uuml;n diğer cihazlara atıfta bulunmaktadır. Bu &Ccedil;erez Politikası Pradijital ya da onun adına işletilen, ağa nasıl girdiğinizden bağımsız olarak b&uuml;t&uuml;n web siteleri ya da mobil uygulamalar anlamına gelen t&uuml;m web sitelerimiz (&ldquo;Web sitesi&rdquo;, &ldquo;Web siteleri&rdquo;) i&ccedil;in ge&ccedil;erlidir.</p>

<p>Pradijital web sitelerini kullanarak, &ccedil;erezlerin bu &Ccedil;erez Politikası ile uyumlu şekilde kullanılmasına onay vermiş olursunuz. Eğer &ccedil;erezlerin bu şekilde kullanılmasını istemiyorsanız, tarayıcınızın ayarlarını d&uuml;zenlemeli veya Pradijital web sitelerini kullanmamalısınız. Kullandığımız &ccedil;erezleri devre dışı bırakmak, Pradijital web sitelerindeki kullanıcı deneyiminizi etkileyebilir.</p>

<p>Bu Politika &ccedil;erezlerin Pradijital web sitelerinde genel olarak nasıl kullanıldığını ve bu sitede kullanılabilen &ccedil;erezleri nasıl kontrol edebileceğinizi a&ccedil;ıklamaktadır.</p>

<p><strong>&Ccedil;erez Nedir?</strong></p>

<p>&Ccedil;erez genelde bir web sitesi tarafından bilgisayarınızın tarayıcısına g&ouml;nderilen ve bilgisayarınızın sabit diskinde depolanan &ouml;zel bir tanımlayıcı i&ccedil;eren ufak boyutlardaki verilerdir. Her web sitesi ya da web sitesi tarafından kullanılan &uuml;&ccedil;&uuml;nc&uuml; taraf hizmet sağlayıcısı, tarayıcınızın tercihleri izin veriyorsa kendi &ccedil;erezini tarayıcınıza g&ouml;nderebilir; ancak (gizliliğinizi korumak i&ccedil;in) tarayıcınız bir web sitesine ya da &uuml;&ccedil;&uuml;nc&uuml; taraf hizmet sağlayıcısına, size başka siteler ya da &uuml;&ccedil;&uuml;nc&uuml; taraf hizmet sağlayıcıları tarafından g&ouml;nderilen &ccedil;erezlere değil, yalnızca size g&ouml;ndermiş olduğu &ccedil;erezlere erişim imk&acirc;nı verir. &Ccedil;erez, &ouml;zel tanımlayıcı, site adı ve bazı rakam ve sayılar gibi birtakım anonim bilgiler i&ccedil;erir. Web sitelerine tercihleriniz ya da alışveriş sepetinizde neler olduğu gibi şeyleri hatırlama imk&acirc;nı verir. &Ccedil;erez, belli bir web sayfasına giriş yaptığınızda tarayıcınızda kalan, tarayıcınızı kapattığınızda ise kaybolan oturum &ccedil;erezi ya da tarayıcınız &uuml;zerinde belli bir s&uuml;re kalan kalıcı &ccedil;erez olabilir.</p>

<p>&Ccedil;erezler hakkında daha fazla bilgi almak i&ccedil;in www.allaboutcookies.org adresini ziyaret edebilirsiniz.</p>

<p><strong>Tarayıcı Nedir?</strong></p>

<p>Tarayıcı size internette s&ouml;rf yapma imk&acirc;nı veren bir uygulamadır. En yaygın İnternet tarayıcıları Chrome, Internet Explorer, Firefox ve Safari&#39;dir. Bir&ccedil;ok tarayıcı g&uuml;venlidir ve &ccedil;erezler gibi bilgileri silmenin &ccedil;abuk ve kolay yollarını sunmaktadır.</p>

<p>&Ccedil;erezlerin cihazlarınız tarafından nasıl ele alınacağını tarayıcı ayarları yoluyla se&ccedil;ebilirsiniz. En pop&uuml;ler tarayıcılar kullanıcıların</p>

<ol>
	<li>a) b&uuml;t&uuml;n &ccedil;erezleri kabul etmelerine,</li>
	<li>b) bir &ccedil;erez g&ouml;nderildiğinde sizi uyarmalarına ya da</li>
	<li>c) hi&ccedil;bir zaman &ccedil;erez almamalarına imk&acirc;n tanır.</li>
</ol>

<p>Hi&ccedil;bir zaman &ccedil;erez almamayı se&ccedil;erseniz web sayfası d&uuml;zg&uuml;n işlemeyebilir ve bazı hizmetler sağlanmaz. Bu y&uuml;zden de web sitesi deneyiminiz k&ouml;t&uuml; sonu&ccedil;lanır. Her tarayıcı farklıdır; bu y&uuml;zden &ccedil;erez tercihlerinizi nasıl değiştireceğinizi &ouml;ğrenmek i&ccedil;in tarayıcınızın &#39;Yardım&#39; men&uuml;s&uuml;n&uuml; kontrol edin.</p>

<p>&nbsp;</p>

<p><strong>&Ccedil;erezler ve Kişisel Bilgiler</strong></p>

<p>&Ccedil;erezler, siz &ouml;rneğin sitelerimizden birine kaydolarak kişisel bilgilerinizi bize vermeyi se&ccedil;medik&ccedil;e e-posta adresinizi ya da diğer kişisel bilgileri bize vermez. Bir web sayfasına kişisel bilgilerinizi vermeyi se&ccedil;tiğinizde bu bilgiler &ccedil;erezde depolanan verilere bağlanabilir. &Ccedil;erez bir kimlik kartı gibidir. Bilgisayarınıza &ouml;zeldir ve yalnızca bunu size veren sunucu tarafından okunabilir.</p>

<p>Bizim &ccedil;erezlerimiz ve bizler &ccedil;erezleri nasıl kullanıyoruz?</p>

<p>Bizler &ccedil;erezleri web sayfalarının işlevselliğini, sitelerin kullanımının anlaşılmasını arttırmak, i&ccedil;eriği geliştirmek ve web sayfalarımızın performansı ile sitelerimizdeki tekliflerimizi ilerletmek i&ccedil;in kullanıyoruz. &Ccedil;erezleri ayrıca size &uuml;r&uuml;n ve hizmet sunmak i&ccedil;in de kullanabiliriz.</p>

<p>&Ccedil;erezleri genelde, web sitelerimizin sayfaları yoluyla şu hizmetleri sağlamak i&ccedil;in kullanıyoruz:</p>

<ul>
	<li>Sizler web sitemizi kullanırken ve sayfa sayfa dolaşırken g&uuml;venliğinizi muhafaza etmek ve detaylarınızı doğrulamak. (Bu sizleri yeni bir sayfaya her girişinizde bilgilerinizi tekrar girme zahmetinden kurtarır.)</li>
	<li>Siteyi her ziyaret edişinizde bilgilerinizi tekrar tekrar girmemek i&ccedil;in kullanıcı adınız ve şifrenizi hatırlamamızı istemiş olabileceğinizi anlamak.</li>
	<li>İlgi alanınız dışındaki siteleri revize ederek ya da kaldırarak sizler i&ccedil;in hangi i&ccedil;eriğin &ouml;nemli olduğunu, hangisinin &ouml;nemli olmadığı &ouml;ğrenmek ve enerjimizi istediğiniz i&ccedil;erik &uuml;zerine yoğunlaştırmak.</li>
	<li>Web sitelerimiz yoluyla bir &uuml;r&uuml;n ya da hizmet alıyorsanız deneyiminizin akıcı ve g&uuml;venli olmasını sağlamak.</li>
	<li>Kullanıcıların web sitesini nasıl kullandıklarını anlamamıza ve web sitemizin yapısını geliştirmemize yardımcı olması i&ccedil;in istatistiki ama&ccedil;lar ve değerlendirme amacıyla isimsiz, toplu bilgiler toplamak ve derlemek.</li>
</ul>

<p>Web sitelerimizde oturum &ccedil;erezleri ve kalıcı &ccedil;erezlerin herhangi birini ya da her ikisini kullanıyoruz.</p>

<p>Ad ile kullanılan her &ccedil;erezi listelemiyoruz; ama her &ccedil;erez t&uuml;r&uuml; i&ccedil;in kullanımını nasıl kontrol edebileceğinizi anlatıyoruz.</p>

<p>Web sitelerine ziyaretiniz esnasında kullanılabilecek &ccedil;erez t&uuml;rleri:</p>

<p>Kişiselleştirme &ccedil;erezleri: Bu &ccedil;erezler web sitesine tekrar tekrar giriş yapan ziyaret&ccedil;ileri tanımak amacıyla ve belirli arama bilgilerini kaydetme amacıyla tutmaya &ccedil;alıştığımız diğer bilgiler (yani web sitesine giriş yolunuz, g&ouml;r&uuml;nt&uuml;lediğiniz sayfalar, tercih ettiğiniz se&ccedil;enekler, girdiğiniz bilgiler ve web sitesinde izlediğiniz yol) ile bağlantılı olarak kullanılır.</p>

<p>Site y&ouml;netim &ccedil;erezleri: Bunlar web sitesi &uuml;zerinde kimliğinizi ya da oturumu muhafaza etmek i&ccedil;in kullanılır. &Ouml;rneğin web sitelerimizin birden fazla sunucu &uuml;zerinde &ccedil;alıştığı yerlerde belirli tek bir sunucu tarafından sizlere bilgi g&ouml;nderilmesini sağlamak i&ccedil;in bir &ccedil;erez kullanıyoruz (aksi takdirde beklenmedik şekilde giriş ya da &ccedil;ıkış yapabilirsiniz). Fikir oylamalarında yalnızca tek oy kullanmanızı sağlamak ve giriş yapmamışken yorum işlevimizi kullanabilmenizi sağlamak (&ouml;rneğin k&ouml;t&uuml; niyetli olarak bildirdiğiniz yorumları g&ouml;rmemenizi ya da birden fazla olumlu/olumsuz oy kullanmamanızı sağlamak) i&ccedil;in benzer &ccedil;erezler kullanabiliriz. Bu &ccedil;erezler tek tek kapatılamaz; ancak bunları kabul etmek istemiyorsanız b&uuml;t&uuml;n &ccedil;erezleri reddetmek i&ccedil;in tarayıcı ayarlarınızı değiştirebilirsiniz.</p>

<p>&Uuml;&ccedil;&uuml;nc&uuml; taraf hizmet &ccedil;erezleri: Sunduğumuz sosyal paylaşım, video ve diğer hizmetler başka şirketler tarafından y&uuml;r&uuml;t&uuml;lmektedir. Bu şirketler onları sitemizde kullandığınızda ya da ya da onlara h&acirc;lihazırda giriş yapmışsanız bilgisayarınıza &ccedil;erez bırakabilir.</p>

<p>Kullanabileceğimiz hizmetler ve bunların &ccedil;erez kullanımı hakkında daha fazla bilgi edinebileceğiniz yerlerin listesi:</p>

<ul>
	<li>Facebook veri kullanım politikası:&nbsp;<u><a href="http://www.facebook.com/about/privacy/your-info-on-other">http://www.facebook.com/about/privacy/your-info-on-other</a></u></li>
	<li>AddThis (sosyal paylaşım tuşlarımızın bazılarını &ccedil;alıştıran hizmet):&nbsp;<u><a href="http://www.addthis.com/privacy#.T6j--usS0bw">http://www.addthis.com/privacy#.T6j--usS0bw</a></u></li>
	<li>Twitter gizlilik politikası:&nbsp;<u><a href="https://twitter.com/privacy">https://twitter.com/privacy</a></u></li>
	<li>Storify (bazen bir dizi tweet yerleştirmek i&ccedil;in kullanılan bir hizmet) hizmet koşulları:&nbsp;<u><a href="http://storify.com/tos">http://storify.com/tos</a></u></li>
	<li>YouTube video oynatıcı &ccedil;erez politikası:&nbsp;<u><a href="http://www.google.com/intl/en/policies/privacy/faq/#toc-cookies">http://www.google.com/intl/en/policies/privacy/faq/#toc-cookies</a></u>&nbsp;(Google&#39;ın standart h&uuml;k&uuml;mleri).</li>
</ul>

<p>Analitik &ccedil;erezleri: Google Analytics bizlere isimsiz istatistiki bilgiler sağlamaktadır. IP adreslerini ve &ccedil;erezlerden gelen bilgileri web sayfalarımızı esas alarak işler, b&ouml;ylece ka&ccedil; sayfaya sahip olduğumuzu, ka&ccedil; kullanıcıya sahip olduğumuzu, hangi tarayıcıları kullandıklarını (b&ouml;ylelikle kullanıcılarımızın &ccedil;oğunluğu i&ccedil;in uyumluluğu maksimize etmek adına kaynaklarımızı doğru y&ouml;nde hedeflendirebiliriz) ve bazı durumlarda hangi &uuml;lke, şehir ya da b&ouml;lgede bulunduklarını biliriz.</p>

<p>Analitik &ccedil;erezlerden ayrılmayı istiyorsanız l&uuml;tfen aşağıdaki linke tıklayın:</p>

<p>Google Analytics:&nbsp;<u><a href="https://tools.google.com/dlpage/gaoptout">https://tools.google.com/dlpage/gaoptout</a></u></p>

<p><strong>&Ccedil;erezleri Engelleme</strong></p>

<p>Bir&ccedil;ok tarayıcı size &ccedil;erezleri kabul&uuml; reddetme imk&acirc;nı tanır. Bu linkler &ccedil;erezleri internet tarayıcınız yoluyla nasıl kontrol edebileceğinizi a&ccedil;ıklar. Tarayıcınızda &ccedil;erezleri kapatırsanız bu ayarların yalnızca bu site i&ccedil;in değil, b&uuml;t&uuml;n web siteleri i&ccedil;in ge&ccedil;erli olacağını unutmayın.</p>

<ul>
	<li>Internet Explorer&nbsp;<u><a href="http://support.microsoft.com/kb/278835">http://support.microsoft.com/kb/278835</a></u></li>
	<li>Chrome:&nbsp;<u><a href="http://support.google.com/chrome/bin/answer.py?hl=en-GB&amp;answer=95647">http://support.google.com/chrome/bin/answer.py?hl=en-GB&amp;answer=95647</a></u></li>
	<li>Safari:&nbsp;<u><a href="http://docs.info.apple.com/article.html?path=Safari/5.0/en/9277.html">http://docs.info.apple.com/article.html?path=Safari/5.0/en/9277.html</a></u>&nbsp;(veya&nbsp;<u><a href="http://support.apple.com/kb/HT1677">http://support.apple.com/kb/HT1677</a></u>&nbsp;mobil versiyonlar i&ccedil;in)</li>
	<li>Firefox:&nbsp;<u><a href="http://support.mozilla.org/en-US/kb/Enabling%20and%20disabling%20cookies">http://support.mozilla.org/en-US/kb/Enabling%20and%20disabling%20cookies</a></u>&nbsp;</li>
	<li>Opera:&nbsp;<u><a href="http://www.opera.com/browser/tutorials/security/privacy/">http://www.opera.com/browser/tutorials/security/privacy/</a></u></li>
</ul>

<p>Ancak b&uuml;t&uuml;n &ccedil;erezlerin engellenmesi, bir&ccedil;ok web sitesinin kullanılabilirliği &uuml;zerinde olumsuz etkiye sahip olacaktır.</p>

<p><strong>&Ccedil;erezleri Silme</strong></p>

<p>Tarayıcınız tarafından sağlanan talimatları takip ederek bilgisayarınızda depolanan &ccedil;erezleri de silebilirsiniz. Yine, bunun yapılması bir&ccedil;ok web sitesinin kullanılabilirliği &uuml;zerinde olumsuz etkiye sahip olabilir.</p>

<p><u><a href="http://www.aboutcookies.org/page-2">http://www.aboutcookies.org/page-2</a></u>&nbsp;adresinden &ccedil;erezlerin silinmesi ile ilgili daha detaylı bilgi edinebilirsiniz.</p>

<p><strong>Daha Fazla Bilgi</strong></p>

<p>&Ccedil;erez politikamız uyarıda bulunmaksızın d&ouml;nem d&ouml;nem değiştirilebilir; bu y&uuml;zden değişiklikler ve g&uuml;ncellemelerin tam olarak farkında olabilmeniz i&ccedil;in bu politikayı d&uuml;zenli olarak kontrol etmeniz &ouml;nemlidir.</p>
')
SET IDENTITY_INSERT [dbo].[Pages] OFF
SET IDENTITY_INSERT [dbo].[Properties] ON 

INSERT [dbo].[Properties] ([Id], [Name], [ShortDescription], [Description], [Link], [FileName], [Icon], [Active], [LanguageId]) VALUES (29, N'KVKK Nedir?', N'Kişisel Verilerin Korunması Kanunu', N'<p>7 Nisan 2016 tarihinde yayımlanarak y&uuml;r&uuml;rl&uuml;ğe giren &lsquo;6698 sayılı Kişisel Verilerin Korunması Kanunu&rsquo;; kişisel verilerin işlenmesinde başta &ouml;zel hayatın gizliliği olmak &uuml;zere kişilerin temel hak ve &ouml;zg&uuml;rl&uuml;klerini korumak ve kişisel verileri işleyen ger&ccedil;ek ve t&uuml;zel kişilerin y&uuml;k&uuml;ml&uuml;l&uuml;kleri ve uyacakları kuralları d&uuml;zenleme amacını taşımaktadır.</p>

<p>Kişisel verilerin elde edilmesi, kaydedilmesi, depolanması, muhafaza edilmesi, değiştirilmesi, yeniden d&uuml;zenlenmesi, a&ccedil;ıklanması, aktarılması, devralınması veya sınıflandırılması gibi her t&uuml;rl&uuml; işlem kişisel veri işleme olarak kabul edilmektedir ve kanunda d&uuml;zenlenen kurallara uygun olmalıdır.</p>

<p>İnternet &uuml;zerinden iş ve işlemler ger&ccedil;ekleştiren her kurum 5651 sayılı kanuna; kişisel bir bilgi tutan her kurum ise KVKK&rsquo; na tabidir.</p>
', N'kvkk-nedir', N'd50f8961abdd4722b5b9604175de5f3a.png', N'11040ebe66cc484c9d44c9d17c2b3e8c.png', 1, 1)
INSERT [dbo].[Properties] ([Id], [Name], [ShortDescription], [Description], [Link], [FileName], [Icon], [Active], [LanguageId]) VALUES (30, N'Kişisel Veri Nedir?', N'Kimliği belirli veya belirlenebilir gerçek kişiye ilişkin her türlü bilgiyi ifade etmektedir.', N'<p>Kanundaki tanımıyla; kimliği belirli veya belirlenebilir ger&ccedil;ek kişiye ilişkin her t&uuml;rl&uuml; bilgiyi ifade etmektedir. Kişinin adı, soyadı, vatandaşlık numarası, banka bilgileri gibi pek &ccedil;ok başlıkta sınıflandırılmaktadır.</p>
', N'kisisel-veri-nedir', N'c5e788c64bd64f3489f873b0a0f415a0.png', N'1a770f0ea4c949249d6ca909fe1f567a.png', 1, 1)
INSERT [dbo].[Properties] ([Id], [Name], [ShortDescription], [Description], [Link], [FileName], [Icon], [Active], [LanguageId]) VALUES (31, N'Kimler Kişisel Verileri Koruma Kanuna Tabidir?', N'Kişisel veri bulunduran', N'<p>Kişisel veri bulunduran, aktaran ya da saklayan her ger&ccedil;ek ya da t&uuml;zel kişi kanuna uymakla y&uuml;k&uuml;ml&uuml;d&uuml;r.</p>
', N'kimler-kisisel-verileri-koruma-kanuna-tabidir', N'32681241fba044c996a8f50548375efb.png', N'13d029397e8f4761b3ad161136e60747.png', 1, 1)
INSERT [dbo].[Properties] ([Id], [Name], [ShortDescription], [Description], [Link], [FileName], [Icon], [Active], [LanguageId]) VALUES (32, N'Kanuna Göre Belirlenen Cezalar Nelerdir?', N'5.000 TL ile 1.000.000 TL', N'<p>Farklı başlıklarda 5.000 TL ile 1.000.000 TL arasındaki tutarlarda idari para cezaları uygulanmaktadır.</p>
', N'kanuna-gore-belirlenen-cezalar-nelerdir', N'bd0bb42e8ce34b95a5fd52106a5f0231.png', N'e2e2765253b7404bb2cbe4ba84c33b32.png', 1, 1)
SET IDENTITY_INSERT [dbo].[Properties] OFF
SET IDENTITY_INSERT [dbo].[References] ON 

INSERT [dbo].[References] ([Id], [Name], [FileName]) VALUES (12, N'Prasoft', N'92c2bae5c307412bbd14c8d72ab9ad8a.png')
INSERT [dbo].[References] ([Id], [Name], [FileName]) VALUES (13, N'Prapazar', N'b6a284e13cad4f72a31a8a48aa31720c.png')
INSERT [dbo].[References] ([Id], [Name], [FileName]) VALUES (14, N'Pranomi', N'b7b5e71707b5425fae4f87a9a67dd62f.png')
INSERT [dbo].[References] ([Id], [Name], [FileName]) VALUES (15, N'Prasoft2', N'c2865410973743329f35608703071db8.png')
INSERT [dbo].[References] ([Id], [Name], [FileName]) VALUES (16, N'Pradijital', N'1068d95f657942a8a089e37a324052af.png')
SET IDENTITY_INSERT [dbo].[References] OFF
SET IDENTITY_INSERT [dbo].[SearchKeyword] ON 

INSERT [dbo].[SearchKeyword] ([Id], [Name], [KeywordType], [KeywordId]) VALUES (10004, N'çerez', 2, 2)
INSERT [dbo].[SearchKeyword] ([Id], [Name], [KeywordType], [KeywordId]) VALUES (10005, N'cerez', 1, 2)
SET IDENTITY_INSERT [dbo].[SearchKeyword] OFF
SET IDENTITY_INSERT [dbo].[ServiceCategories] ON 

INSERT [dbo].[ServiceCategories] ([Id], [Name], [ParentId], [Link], [Active], [SortOrder], [LanguageId], [ShowOnHomePage], [FileName]) VALUES (1, N'KVKK', NULL, N'pradijital', 1, 0, 1, 0, NULL)
INSERT [dbo].[ServiceCategories] ([Id], [Name], [ParentId], [Link], [Active], [SortOrder], [LanguageId], [ShowOnHomePage], [FileName]) VALUES (2, N'hh', NULL, N'hh', 0, 0, 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[ServiceCategories] OFF
SET IDENTITY_INSERT [dbo].[ServiceImages] ON 

INSERT [dbo].[ServiceImages] ([Id], [FileName], [Alt], [Title], [ServiceId]) VALUES (19, N'7e202fe1198e45a0ad9d57b70dc6729b.png', N'KVKK_logo2.png', NULL, 31)
INSERT [dbo].[ServiceImages] ([Id], [FileName], [Alt], [Title], [ServiceId]) VALUES (20, N'4647fbaeabe34a6b96d5f9df00a41503.png', N'KVKK_logo2.png', NULL, 27)
INSERT [dbo].[ServiceImages] ([Id], [FileName], [Alt], [Title], [ServiceId]) VALUES (21, N'c64ff031fcef457e9b8f876c09a53930.png', N'KVKK_logo2.png', NULL, 28)
INSERT [dbo].[ServiceImages] ([Id], [FileName], [Alt], [Title], [ServiceId]) VALUES (22, N'9d640e4c3c0c46948a89a3c11d740102.png', N'KVKK_logo2.png', NULL, 32)
INSERT [dbo].[ServiceImages] ([Id], [FileName], [Alt], [Title], [ServiceId]) VALUES (23, N'295c60e3a4ca4678a8e93bd334b838aa.png', N'KVKK_logo2.png', NULL, 33)
SET IDENTITY_INSERT [dbo].[ServiceImages] OFF
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Name], [ShortDescription], [Description], [Active], [SortOrder], [CategoryId], [Link], [LanguageId], [SeoTitle], [SeoKeywords], [SeoDescription], [Icon]) VALUES (27, N'KVKK DANIŞMANLIĞI', N'İhtiyacınıza göre, kısmi süreli ya da sürekli KVKK danışmanlığı hizmeti sunmaktayız.', N'<p>İhtiyacınıza g&ouml;re, kısmi s&uuml;reli ya da s&uuml;rekli KVKK danışmanlığı hizmeti sunmaktayız.</p>

<p>6698 sayılı Kişisel Verilerin Korunması Kanunu kapsamındaki idari ve teknik tedbirler &ccedil;er&ccedil;evesinde; kanuna tabi ger&ccedil;ek ve t&uuml;zel kişilerin hazırlanması gereken d&ouml;k&uuml;manlar olduğu gibi, g&uuml;nl&uuml;k iş s&uuml;re&ccedil;lerinin de idari tedbirlerdeki başlıklara uygun hale getirilmesi ya da mevcut hazırlık &ccedil;alışmalarının da bu başlıklara ve kurumun taleplerine uygun hale olarak g&uuml;ncellenmesi gerekmektedir.</p>
', 1, 0, 1, N'kvkk-danismanligi', 1, NULL, NULL, NULL, N'625aa3e6871e48848b88268a11b72142.png')
INSERT [dbo].[Services] ([Id], [Name], [ShortDescription], [Description], [Active], [SortOrder], [CategoryId], [Link], [LanguageId], [SeoTitle], [SeoKeywords], [SeoDescription], [Icon]) VALUES (28, N'KVKK EĞİTİMİ', N'Kanun kapsamında kurum personeline KVKK eğitimlerinin verilmesi zorunludur.', N'<p><strong>Kanun kapsamında kurum personeline KVKK eğitimlerinin verilmesi zorunludur</strong>. Rasyotek hukuki ve teknik tedbirleri b&uuml;t&uuml;nleşik olarak tek bir farkındalık eğitiminde sunmaktadır. Hukuk ve bilişim uzmanlarının verdiği eğitimlerimizde, ilgili idari ve teknik tedbirler t&uuml;m y&ouml;nleriyle değerlendirilmekte, dikkat edilmesi gereken başlıkları ile detaylı anlatılmakta, farklı yorumlanabilen konularda g&uuml;nl&uuml;k hayatta yaşanan olaylardan &ouml;rnekler verilmektedir.</p>

<p><strong>Kurumsal KVKK Eğitimi (Firma personelinin KVKK s&uuml;re&ccedil;leri ile ilgili bilgilendirilmesi):</strong>.</p>

<p><strong>&ldquo;KVKK Danışmanlığı / Veri G&uuml;venliği&rdquo;&nbsp;</strong>konusunda kanunu ve size &ouml;zel s&uuml;re&ccedil;leri detaylandırmak &uuml;zere dilediğiniz zaman bizimle iletişime ge&ccedil;ebilirsiniz.</p>

<ul>
	<li>- 6698 sayılı KVKK kapsamında yer alan kavramlar ( Kişisel Veri &ndash; &Ouml;zel Nitelikli Kişisel Veri &ndash; Veri Sorumlusu &ndash; Veri İşleyen &ndash;A&ccedil;ık Rıza &ndash; İlgili Kişi vs.)</li>
	<li>- Veri Sorumlusu ve Veri İşleyen&rsquo; in Sorumlulukları</li>
	<li>- Verilerin İşlenme S&uuml;re&ccedil;leri - Alınması Gereken &Ouml;nlemler</li>
	<li>- A&ccedil;ık Rıza &ndash; Rıza Alırken Dikkat Edilecek Hususlar - İstisna Halleri)</li>
	<li>- Verilerin Silinmesi - Yok Edilmesi - Anonim Hale Getirilmesi</li>
	<li>- Verilerin Yurti&ccedil;i ve Yurtdışına Aktarılması</li>
	<li>- VERBİS ( Veri Sorumluları Sicili)</li>
	<li>- Y&uuml;k&uuml;ml&uuml;l&uuml;klere - KVKK ve T&uuml;rk Ceza Kanunu kapsamında -uyulmayan hallerde uygulanacak adli ve idari yaptırımlar</li>
	<li>- Yetkilendirme Matrisi ve Yetki Kontrol&uuml; S&uuml;re&ccedil;lerinin Y&ouml;netimi</li>
	<li>- Loglama Sisteminin Kontrol&uuml;</li>
	<li>- Ağ G&uuml;venliğine İlişkin Teknik Tedbirler</li>
	<li>- Veri G&uuml;venliğinin Sağlanamaması Riski</li>
	<li>- Veri Sızıntısı &Ouml;rnek Vaka İncelemeleri</li>
	<li>- Siber G&uuml;venlik</li>
	<li>- KVKK ve Reg&uuml;lasyonlar i&ccedil;in Doğru Teknoloji Yatırımı</li>
	<li>- Kişisel Veri G&uuml;venliğini Sağlamaya Y&ouml;nelik Tedbirler</li>
	<li>- Silme, Yok Etme, Anonim Hale Getirme nedir?</li>
	<li>- Sızma Testi, Veri Maskeleme, G&uuml;venlik Duvarları ve Anti Vir&uuml;s Yazılımları Hakkında Bilgilendirmeler</li>
</ul>
', 1, 0, 1, N'kvkk-egtm', 1, NULL, NULL, NULL, N'371370255c3945faa0ba687ebb62e533.png')
INSERT [dbo].[Services] ([Id], [Name], [ShortDescription], [Description], [Active], [SortOrder], [CategoryId], [Link], [LanguageId], [SeoTitle], [SeoKeywords], [SeoDescription], [Icon]) VALUES (31, N'KVKK DENETİMİ', N'Kişisel Verileri Koruma Kanunu', N'<p>Kişisel Verileri Koruma Kanunu kapsamında bir&ccedil;ok kurum idari ve teknik tedbir başlıklarında belli başlı hazırlıklarını yapmış bulunmaktadır. Yapılan bu &ccedil;alışmaların tedbirlerin genel yapısına uygunluğunun ve mevcut s&uuml;re&ccedil;lerin kanun kapsamına girip girmediği konusunda denetim hizmeti sunmaktayız.</p>
', 1, 0, 1, N'kvkk-denetm', 1, NULL, NULL, NULL, N'84d0cc10b8b04c78aef2d8f8e7fcc01a.png')
INSERT [dbo].[Services] ([Id], [Name], [ShortDescription], [Description], [Active], [SortOrder], [CategoryId], [Link], [LanguageId], [SeoTitle], [SeoKeywords], [SeoDescription], [Icon]) VALUES (32, N'KVKK Süreç Danışmanlığı', N'Hukuk profesyonellerinin oluşturduğu politikalar doğrultusunda', N'<p>Hukuk profesyonellerinin oluşturduğu politikalar doğrultusunda i&ccedil; s&uuml;re&ccedil;lerin tasarlanması ve d&uuml;zenlenmesi safhasıdır. Teknik olarak gerekli olan t&uuml;m s&uuml;re&ccedil;ler de bu aşamada tespit edilmektedir.</p>

<p>Veri envanter raporu detaylı şekilde oluşturulmalı, oluşturulan rapor doğrultusunda veriler sınıflandırılmaya hazır hale getirilmelidir.</p>

<p>Kurum ya da kuruluşun yayıma alması gereken kişisel verilerin korunması ile ilgili saklama silme vb. politikaların i&ccedil;eriğinin hazırlanması, kurumun sahip olduğu hukuki anlaşmaların, formların vb. dok&uuml;manların g&ouml;zden ge&ccedil;irilerek KVKK uyumlu hale getirilmesi, a&ccedil;ık rıza metinlerinin ve aydınlatma metinlerinin oluşturulması gibi s&uuml;re&ccedil;ler de son hale getirilmektedir.</p>

<p>Son olarak tıpkı ISO27001 &lsquo;de olduğu gibi gerekli t&uuml;m dok&uuml;mantasyon sağlanarak teknik aşmaya ge&ccedil;ilecek hale getirilecektir.</p>
', 1, 0, 1, N'kvkk-surec-danismanligi', 1, NULL, NULL, NULL, N'112d1a77a90e434085eadaa171983113.png')
INSERT [dbo].[Services] ([Id], [Name], [ShortDescription], [Description], [Active], [SortOrder], [CategoryId], [Link], [LanguageId], [SeoTitle], [SeoKeywords], [SeoDescription], [Icon]) VALUES (33, N'KVKK Teknik Danışmanlık', N'Hukuk ve Süreç danışmanlığı safhalarında oluşturulan tüm ilke', N'<p>Hukuk ve S&uuml;re&ccedil; danışmanlığı safhalarında oluşturulan t&uuml;m ilke ve politikaların ilgili otomasyonlar ile kullanıcı hatalarından bağımsız hale getirilmesi aşamasıdır. Bu aşamanın en b&uuml;y&uuml;k &ouml;zelliği tamamen teknik bilgi gerektiriyor ve tamamlayıcı rol oynuyor olmasıdır.<img alt="kvkk-teknik-tedbirler" src="https://datakey.com.tr/uploads/kvkk-teknik-tedbirler.png" /></p>

<p>Zira oluşturulan ilke ve politikalar, insan denetimine bırakıldığında g&ouml;zden ka&ccedil;maya ve sızıntılar yaratmaya mahkumdur. Sebebi ise şirketlerdeki en dinamik yapının veri olmasıdır.</p>

<p>Maksimum d&uuml;zeyde dinamik hareket eden verilerinizin tespiti ve sızmaların &ouml;nlenmesi bu aşamanın ne kadar doğru implemente edileceğine bağlıdır. Teknik danışmanlığın ka&ccedil;ınılmaz hale geldiğini ise yine kanunun şu maddesinden &ouml;ğreniyoruz.</p>

<blockquote>
<p>&quot;Bir veri sorumlusu nezdinde bulundukları pozisyon veya g&ouml;rev itibarıyla kişisel verilere erişme yetkisi olanlar tarafından, yetkileri aşmak ve/veya yetkilerini k&ouml;t&uuml;ye kullanmak suretiyle, kişisel ama&ccedil;lara veya nedenlere bağlı olarak işleme amacı dışında s&ouml;z konusu kişisel verilerin işlenmesi ve/veya bu verilerin &uuml;&ccedil;&uuml;nc&uuml; kişilerle paylaşılması, 6698 sayılı Kişisel Verilerin Korunması Kanunu&#39;na aykırılık teşkil edeceğinden, bu kapsamdaki eylemlerin &ouml;nlenmesi amacıyla veri sorumlularınca uygun g&uuml;venlik d&uuml;zeyini temin etmeye y&ouml;nelik gerekli her t&uuml;rl&uuml; teknik ve idari tedbirin alınması gerektiği hususunda veri sorumlularının bilgilendirilmesine oy birliğiyle karar verilmiştir.&quot;</p>
</blockquote>
', 1, 0, 1, N'kvkk-teknik-danismanlik', 1, NULL, NULL, NULL, N'c5630e32eb644cee86ca27edc3580dd2.png')
SET IDENTITY_INSERT [dbo].[Services] OFF
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Logo], [Favicon], [Meta], [Title], [Keywords], [Description], [Maps], [Facebook], [Twitter], [Instagram], [Youtube], [Gplus], [Adress], [Phone], [Phone2], [Email], [Analytics], [Copyright], [LanguageId]) VALUES (1, N'/uploads/KVKK_logo2.png', N'/uploads/Favicon.png', NULL, N'KVKK', N'KVKK', N'KVKK', NULL, N'd', N'd', N'd', NULL, N'd', N'Evliya Çelebi Mahallesi Meşrutiyet Caddesi No: 94/7 D:7 Beyoğlu', N'0 (212) 909 18 63', N'0 (212) 909 18 63', N'info@pradijital.com', N'PraDijital', NULL, 1)
SET IDENTITY_INSERT [dbo].[Settings] OFF
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [FileName], [SortOrder], [Title], [Alt], [Active], [LanguageId], [ButtonText1], [ButtonText2], [ButtonText3], [ButtonText4], [ButtonLink1], [ButtonLink2], [ButtonLink3], [ButtonLink4]) VALUES (1, N'b7780d016f7246f0af0ed5c0602138ee.png', 0, NULL, NULL, 1, 1, N'Kişisel Verileri Koruma Kanunu', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sliders] ([Id], [FileName], [SortOrder], [Title], [Alt], [Active], [LanguageId], [ButtonText1], [ButtonText2], [ButtonText3], [ButtonText4], [ButtonLink1], [ButtonLink2], [ButtonLink3], [ButtonLink4]) VALUES (3, N'18a5c70952874e348eb43344baae431c.png', 0, NULL, NULL, 1, 1, N'Kişisel Verilerin Korunması', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sliders] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (1, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[WebsiteFiles] ON 

INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (1, N'                                                                                                                                                                                                                                                          ', 2, 1, 1)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (2, N'                                                                                                                                                                                                                                                          ', 2, 1, 2)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (3, N'                                                                                                                                                                                                                                                          ', 2, 1, 3)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (4, N'                                                                                                                                                                                                                                                          ', 2, 1, 4)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (5, N'3ea4f5973fd441219c0192b2ce059a65                                                                                                                                                                                                                          ', 2, 1, 5)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10002, N'CustomerReport_6aa83858328442f2a1d64046237b66d9.docx                                                                                                                                                                                                      ', 2, 1, 10002)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10003, N'                                                                                                                                                                                                                                                          ', 2, 1, 10003)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10004, N'                                                                                                                                                                                                                                                          ', 2, 0, 10004)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10005, N'                                                                                                                                                                                                                                                          ', 2, 0, 10005)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10006, N'                                                                                                                                                                                                                                                          ', 2, 0, 10006)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10007, N'                                                                                                                                                                                                                                                          ', 2, 0, 10007)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10008, N'                                                                                                                                                                                                                                                          ', 2, 1, 10008)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10009, N'                                                                                                                                                                                                                                                          ', 2, 0, 10009)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10010, N'                                                                                                                                                                                                                                                          ', 2, 0, 10010)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10011, N'                                                                                                                                                                                                                                                          ', 2, 0, 10011)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10012, N'                                                                                                                                                                                                                                                          ', 2, 0, 10012)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10013, N'                                                                                                                                                                                                                                                          ', 2, 0, 10013)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10014, N'                                                                                                                                                                                                                                                          ', 2, 0, 10014)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10015, N'                                                                                                                                                                                                                                                          ', 2, 0, 10015)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10016, N'                                                                                                                                                                                                                                                          ', 2, 0, 10016)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10017, N'                                                                                                                                                                                                                                                          ', 2, 0, 10017)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10018, N'                                                                                                                                                                                                                                                          ', 2, 0, 10018)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10019, N'                                                                                                                                                                                                                                                          ', 2, 0, 10019)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10020, N'                                                                                                                                                                                                                                                          ', 2, 0, 10020)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10021, N'                                                                                                                                                                                                                                                          ', 2, 0, 10021)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10022, N'                                                                                                                                                                                                                                                          ', 2, 0, 10022)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10023, N'                                                                                                                                                                                                                                                          ', 2, 1, 10023)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (10024, N'                                                                                                                                                                                                                                                          ', 2, 1, 10024)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (20002, N'CustomerReport_47ceea23b7d943e28c611d183589105d.docx                                                                                                                                                                                                      ', 2, 1, 20002)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (20003, N'CustomerReport_34000b039bf64fc19deeb2052a4e7029.docx                                                                                                                                                                                                      ', 2, 1, 20003)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (20004, N'CustomerReport_4756166350bc4ec5aa4563e981d90b2e.docx                                                                                                                                                                                                      ', 2, 1, 20004)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (20005, N'CustomerReport_7cdfeed594704192a201239f2b92f8f2.docx                                                                                                                                                                                                      ', 2, 1, 20005)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (30002, N'CustomerReport_72c5a65e6c064a429e83ab6f5f250171.docx                                                                                                                                                                                                      ', 2, 1, 30002)
INSERT [dbo].[WebsiteFiles] ([Id], [FileName], [KeywordId], [Result], [WebsiteId]) VALUES (30003, N'                                                                                                                                                                                                                                                          ', 2, 0, 30003)
SET IDENTITY_INSERT [dbo].[WebsiteFiles] OFF
SET IDENTITY_INSERT [dbo].[Websites] ON 

INSERT [dbo].[Websites] ([Id], [Website]) VALUES (1, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (2, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (3, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (4, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (5, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10002, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10003, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10004, N'http://abdulsametdogan.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10005, N'http://abdulsametdogan.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10006, N'http://abdulsametdogan.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10007, N'http://abdulsametdogan.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10008, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10009, N'http://abdulsametdogan.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10010, N'https://ayhankaraman.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10011, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10012, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10013, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10014, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10015, N'https://abdulsametdogan.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10016, N'https://abdulsametdogan.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10017, N'https://prasoftakademi.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10018, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10019, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10020, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10021, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10022, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10023, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (10024, N'https://prasoftakademi.com/')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (20002, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (20003, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (20004, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (20005, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (30002, N'https://prapazar.com')
INSERT [dbo].[Websites] ([Id], [Website]) VALUES (30003, N'https://prapazar.com/')
SET IDENTITY_INSERT [dbo].[Websites] OFF
/****** Object:  Index [IX_FK_CustomerPosPaymentsWebsites]    Script Date: 28.08.2020 12:21:58 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CustomerPosPaymentsWebsites] ON [dbo].[CustomerPosPayments]
(
	[WebsitesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_SearchKeyword_Keyword]    Script Date: 28.08.2020 12:21:58 ******/
CREATE NONCLUSTERED INDEX [IX_FK_SearchKeyword_Keyword] ON [dbo].[SearchKeyword]
(
	[KeywordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_WebsiteFiles_Keyword]    Script Date: 28.08.2020 12:21:58 ******/
CREATE NONCLUSTERED INDEX [IX_FK_WebsiteFiles_Keyword] ON [dbo].[WebsiteFiles]
(
	[KeywordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_WebsiteFiles_Websites]    Script Date: 28.08.2020 12:21:58 ******/
CREATE NONCLUSTERED INDEX [IX_FK_WebsiteFiles_Websites] ON [dbo].[WebsiteFiles]
(
	[WebsiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[About]  WITH CHECK ADD  CONSTRAINT [FK_About_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[About] CHECK CONSTRAINT [FK_About_Languages]
GO
ALTER TABLE [dbo].[BlogCategories]  WITH CHECK ADD  CONSTRAINT [FK_BlogCategories_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[BlogCategories] CHECK CONSTRAINT [FK_BlogCategories_Languages]
GO
ALTER TABLE [dbo].[BlogImages]  WITH CHECK ADD  CONSTRAINT [FK_BlogImages_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogImages] CHECK CONSTRAINT [FK_BlogImages_Blogs]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_BlogCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BlogCategories] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_BlogCategories]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Languages]
GO
ALTER TABLE [dbo].[BlogTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_BlogTagMapping_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogTagMapping] CHECK CONSTRAINT [FK_BlogTagMapping_Blogs]
GO
ALTER TABLE [dbo].[BlogTagMapping]  WITH CHECK ADD  CONSTRAINT [FK_BlogTagMapping_BlogTags] FOREIGN KEY([TagId])
REFERENCES [dbo].[BlogTags] ([Id])
GO
ALTER TABLE [dbo].[BlogTagMapping] CHECK CONSTRAINT [FK_BlogTagMapping_BlogTags]
GO
ALTER TABLE [dbo].[BlogTags]  WITH CHECK ADD  CONSTRAINT [FK_BlogTags_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[BlogTags] CHECK CONSTRAINT [FK_BlogTags_Languages]
GO
ALTER TABLE [dbo].[FAQ]  WITH CHECK ADD  CONSTRAINT [FK_FAQ_FAQCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[FAQCategories] ([Id])
GO
ALTER TABLE [dbo].[FAQ] CHECK CONSTRAINT [FK_FAQ_FAQCategories]
GO
ALTER TABLE [dbo].[FAQ]  WITH CHECK ADD  CONSTRAINT [FK_FAQ_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[FAQ] CHECK CONSTRAINT [FK_FAQ_Languages]
GO
ALTER TABLE [dbo].[FAQCategories]  WITH CHECK ADD  CONSTRAINT [FK_FAQCategories_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[FAQCategories] CHECK CONSTRAINT [FK_FAQCategories_Languages]
GO
ALTER TABLE [dbo].[Keyword]  WITH CHECK ADD  CONSTRAINT [FK_Keyword_Keyword] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Keyword] CHECK CONSTRAINT [FK_Keyword_Keyword]
GO
ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Pages] CHECK CONSTRAINT [FK_Pages_Languages]
GO
ALTER TABLE [dbo].[Properties]  WITH CHECK ADD  CONSTRAINT [FK_Properties_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Properties] CHECK CONSTRAINT [FK_Properties_Languages]
GO
ALTER TABLE [dbo].[SearchKeyword]  WITH CHECK ADD  CONSTRAINT [FK_SearchKeyword_Keyword] FOREIGN KEY([KeywordId])
REFERENCES [dbo].[Keyword] ([Id])
GO
ALTER TABLE [dbo].[SearchKeyword] CHECK CONSTRAINT [FK_SearchKeyword_Keyword]
GO
ALTER TABLE [dbo].[ServiceCategories]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCategories_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[ServiceCategories] CHECK CONSTRAINT [FK_ServiceCategories_Languages]
GO
ALTER TABLE [dbo].[ServiceCategories]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCategories_ServiceCategories] FOREIGN KEY([ParentId])
REFERENCES [dbo].[ServiceCategories] ([Id])
GO
ALTER TABLE [dbo].[ServiceCategories] CHECK CONSTRAINT [FK_ServiceCategories_ServiceCategories]
GO
ALTER TABLE [dbo].[ServiceImages]  WITH CHECK ADD  CONSTRAINT [FK_ServiceImages_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[ServiceImages] CHECK CONSTRAINT [FK_ServiceImages_Services]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Languages]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_ServiceCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ServiceCategories] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_ServiceCategories]
GO
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_Settings_Languages]
GO
ALTER TABLE [dbo].[Sliders]  WITH CHECK ADD  CONSTRAINT [FK_Sliders_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Sliders] CHECK CONSTRAINT [FK_Sliders_Languages]
GO
ALTER TABLE [dbo].[WebsiteFiles]  WITH CHECK ADD  CONSTRAINT [FK_WebsiteFiles_Keyword] FOREIGN KEY([KeywordId])
REFERENCES [dbo].[Keyword] ([Id])
GO
ALTER TABLE [dbo].[WebsiteFiles] CHECK CONSTRAINT [FK_WebsiteFiles_Keyword]
GO
ALTER TABLE [dbo].[WebsiteFiles]  WITH CHECK ADD  CONSTRAINT [FK_WebsiteFiles_Websites] FOREIGN KEY([WebsiteId])
REFERENCES [dbo].[Websites] ([Id])
GO
ALTER TABLE [dbo].[WebsiteFiles] CHECK CONSTRAINT [FK_WebsiteFiles_Websites]
GO
USE [master]
GO
ALTER DATABASE [LegalityAnalysis] SET  READ_WRITE 
GO
