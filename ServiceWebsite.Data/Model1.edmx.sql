
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2020 10:30:33
-- Generated from EDMX file: C:\Users\mdal5\source\repos\ServiceWebsite.Web\ServiceWebsite.Data\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LegalityAnalysis];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_About_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[About] DROP CONSTRAINT [FK_About_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogCategories_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogCategories] DROP CONSTRAINT [FK_BlogCategories_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Blogs_BlogCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blogs] DROP CONSTRAINT [FK_Blogs_BlogCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogImages_Blogs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogImages] DROP CONSTRAINT [FK_BlogImages_Blogs];
GO
IF OBJECT_ID(N'[dbo].[FK_Blogs_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blogs] DROP CONSTRAINT [FK_Blogs_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogTagMapping_Blogs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogTagMapping] DROP CONSTRAINT [FK_BlogTagMapping_Blogs];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogTagMapping_BlogTags]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogTagMapping] DROP CONSTRAINT [FK_BlogTagMapping_BlogTags];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogTags_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogTags] DROP CONSTRAINT [FK_BlogTags_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_FAQ_FAQCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQ] DROP CONSTRAINT [FK_FAQ_FAQCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_FAQ_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQ] DROP CONSTRAINT [FK_FAQ_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_FAQCategories_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQCategories] DROP CONSTRAINT [FK_FAQCategories_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Keyword_Keyword]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Keyword] DROP CONSTRAINT [FK_Keyword_Keyword];
GO
IF OBJECT_ID(N'[dbo].[FK_SearchKeyword_Keyword]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SearchKeyword] DROP CONSTRAINT [FK_SearchKeyword_Keyword];
GO
IF OBJECT_ID(N'[dbo].[FK_WebsiteFiles_Keyword]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WebsiteFiles] DROP CONSTRAINT [FK_WebsiteFiles_Keyword];
GO
IF OBJECT_ID(N'[dbo].[FK_Pages_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pages] DROP CONSTRAINT [FK_Pages_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Properties_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Properties] DROP CONSTRAINT [FK_Properties_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceCategories_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceCategories] DROP CONSTRAINT [FK_ServiceCategories_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Services_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_Services_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Settings_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [FK_Settings_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Sliders_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sliders] DROP CONSTRAINT [FK_Sliders_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceCategories_ServiceCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceCategories] DROP CONSTRAINT [FK_ServiceCategories_ServiceCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_Services_ServiceCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_Services_ServiceCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceImages_Services]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceImages] DROP CONSTRAINT [FK_ServiceImages_Services];
GO
IF OBJECT_ID(N'[dbo].[FK_WebsiteFiles_Websites]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WebsiteFiles] DROP CONSTRAINT [FK_WebsiteFiles_Websites];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerPosPaymentsWebsites]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerPosPayments] DROP CONSTRAINT [FK_CustomerPosPaymentsWebsites];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[About]', 'U') IS NOT NULL
    DROP TABLE [dbo].[About];
GO
IF OBJECT_ID(N'[dbo].[BlogCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogCategories];
GO
IF OBJECT_ID(N'[dbo].[BlogImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogImages];
GO
IF OBJECT_ID(N'[dbo].[Blogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blogs];
GO
IF OBJECT_ID(N'[dbo].[BlogTagMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogTagMapping];
GO
IF OBJECT_ID(N'[dbo].[BlogTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogTags];
GO
IF OBJECT_ID(N'[dbo].[ContactForm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactForm];
GO
IF OBJECT_ID(N'[dbo].[CustomerAttribute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerAttribute];
GO
IF OBJECT_ID(N'[dbo].[CustomerComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerComments];
GO
IF OBJECT_ID(N'[dbo].[FAQ]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQ];
GO
IF OBJECT_ID(N'[dbo].[FAQCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQCategories];
GO
IF OBJECT_ID(N'[dbo].[Gallery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gallery];
GO
IF OBJECT_ID(N'[dbo].[Keyword]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Keyword];
GO
IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[Pages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pages];
GO
IF OBJECT_ID(N'[dbo].[Properties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Properties];
GO
IF OBJECT_ID(N'[dbo].[References]', 'U') IS NOT NULL
    DROP TABLE [dbo].[References];
GO
IF OBJECT_ID(N'[dbo].[SearchKeyword]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SearchKeyword];
GO
IF OBJECT_ID(N'[dbo].[ServiceCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceCategories];
GO
IF OBJECT_ID(N'[dbo].[ServiceImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceImages];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Settings];
GO
IF OBJECT_ID(N'[dbo].[Sliders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sliders];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[WebsiteFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WebsiteFiles];
GO
IF OBJECT_ID(N'[dbo].[Websites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Websites];
GO
IF OBJECT_ID(N'[dbo].[CustomerPosPayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerPosPayments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'About'
CREATE TABLE [dbo].[About] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [FileName] nvarchar(80)  NULL,
    [Vision] nvarchar(max)  NULL,
    [Mission] nvarchar(max)  NULL,
    [FileName2] nvarchar(80)  NULL
);
GO

-- Creating table 'BlogCategories'
CREATE TABLE [dbo].[BlogCategories] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Link] nvarchar(100)  NOT NULL,
    [Active] bit  NOT NULL,
    [SortOrder] int  NOT NULL,
    [LanguageId] bigint  NOT NULL
);
GO

-- Creating table 'BlogImages'
CREATE TABLE [dbo].[BlogImages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(80)  NOT NULL,
    [Alt] nvarchar(80)  NULL,
    [Title] nvarchar(80)  NULL,
    [BlogId] bigint  NOT NULL
);
GO

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [ShortDescription] nvarchar(200)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL,
    [Link] nvarchar(200)  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [CategoryId] bigint  NOT NULL,
    [SeoTitle] nvarchar(60)  NULL,
    [SeoKeywords] nvarchar(200)  NULL,
    [SeoDescription] nvarchar(300)  NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'BlogTagMapping'
CREATE TABLE [dbo].[BlogTagMapping] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TagId] bigint  NOT NULL,
    [BlogId] bigint  NOT NULL
);
GO

-- Creating table 'BlogTags'
CREATE TABLE [dbo].[BlogTags] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Link] nvarchar(50)  NOT NULL,
    [LanguageId] bigint  NOT NULL
);
GO

-- Creating table 'ContactForm'
CREATE TABLE [dbo].[ContactForm] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NULL,
    [Subject] nvarchar(250)  NULL,
    [Mail] nvarchar(100)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Message] nvarchar(1000)  NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'CustomerAttribute'
CREATE TABLE [dbo].[CustomerAttribute] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL,
    [IsRequired] bit  NOT NULL,
    [AttributeControlTypeId] int  NOT NULL,
    [DisplayOrder] int  NOT NULL,
    [ResourceValue] nvarchar(400)  NOT NULL,
    [DefaultValue] nvarchar(max)  NULL
);
GO

-- Creating table 'CustomerComments'
CREATE TABLE [dbo].[CustomerComments] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Comment] nvarchar(500)  NOT NULL,
    [FileName] nvarchar(80)  NULL
);
GO

-- Creating table 'FAQ'
CREATE TABLE [dbo].[FAQ] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CategoryId] bigint  NULL,
    [LanguageId] bigint  NOT NULL,
    [Link] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'FAQCategories'
CREATE TABLE [dbo].[FAQCategories] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Active] bit  NOT NULL,
    [FileName] nvarchar(80)  NULL,
    [SortOrder] int  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [Link] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Gallery'
CREATE TABLE [dbo].[Gallery] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [FileName] nvarchar(80)  NOT NULL
);
GO

-- Creating table 'Keyword'
CREATE TABLE [dbo].[Keyword] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [ImageUrl] nvarchar(250)  NULL,
    [Price] decimal(18,2)  NOT NULL,
    [DocumentTemplate] nvarchar(max)  NOT NULL,
    [LanguageId] bigint  NOT NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ShortName] nvarchar(5)  NOT NULL,
    [CultureInfo] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'Pages'
CREATE TABLE [dbo].[Pages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Link] nvarchar(100)  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [ShortDescription] nvarchar(100)  NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Link] nvarchar(200)  NOT NULL,
    [FileName] nvarchar(80)  NULL,
    [Icon] nvarchar(80)  NULL,
    [Active] bit  NOT NULL,
    [LanguageId] bigint  NOT NULL
);
GO

-- Creating table 'References'
CREATE TABLE [dbo].[References] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [FileName] nvarchar(80)  NULL
);
GO

-- Creating table 'SearchKeyword'
CREATE TABLE [dbo].[SearchKeyword] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [KeywordType] int  NOT NULL,
    [KeywordId] bigint  NOT NULL
);
GO

-- Creating table 'ServiceCategories'
CREATE TABLE [dbo].[ServiceCategories] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [ParentId] bigint  NULL,
    [Link] nvarchar(100)  NOT NULL,
    [Active] bit  NOT NULL,
    [SortOrder] int  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [ShowOnHomePage] bit  NOT NULL,
    [FileName] nvarchar(80)  NULL
);
GO

-- Creating table 'ServiceImages'
CREATE TABLE [dbo].[ServiceImages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(80)  NOT NULL,
    [Alt] nvarchar(80)  NULL,
    [Title] nvarchar(80)  NULL,
    [ServiceId] bigint  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [ShortDescription] nvarchar(100)  NULL,
    [Description] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [SortOrder] int  NOT NULL,
    [CategoryId] bigint  NULL,
    [Link] nvarchar(200)  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [SeoTitle] nvarchar(60)  NULL,
    [SeoKeywords] nvarchar(200)  NULL,
    [SeoDescription] nvarchar(300)  NULL,
    [Icon] nvarchar(80)  NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Logo] nvarchar(max)  NULL,
    [Favicon] nvarchar(max)  NULL,
    [Meta] nvarchar(max)  NULL,
    [Title] nvarchar(250)  NULL,
    [Keywords] nvarchar(500)  NULL,
    [Description] nvarchar(500)  NULL,
    [Maps] nvarchar(max)  NULL,
    [Facebook] nvarchar(250)  NULL,
    [Twitter] nvarchar(250)  NULL,
    [Instagram] nvarchar(250)  NULL,
    [Youtube] nvarchar(250)  NULL,
    [Gplus] nvarchar(250)  NULL,
    [Adress] nvarchar(max)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Phone2] nvarchar(20)  NULL,
    [Email] nvarchar(250)  NULL,
    [Analytics] nvarchar(max)  NULL,
    [Copyright] nvarchar(max)  NULL,
    [LanguageId] bigint  NOT NULL
);
GO

-- Creating table 'Sliders'
CREATE TABLE [dbo].[Sliders] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(80)  NOT NULL,
    [SortOrder] int  NOT NULL,
    [Title] nvarchar(80)  NULL,
    [Alt] nvarchar(80)  NULL,
    [Active] bit  NOT NULL,
    [LanguageId] bigint  NOT NULL,
    [ButtonText1] nvarchar(50)  NULL,
    [ButtonText2] nvarchar(50)  NULL,
    [ButtonText3] nvarchar(50)  NULL,
    [ButtonText4] nvarchar(50)  NULL,
    [ButtonLink1] nvarchar(200)  NULL,
    [ButtonLink2] nvarchar(200)  NULL,
    [ButtonLink3] nvarchar(200)  NULL,
    [ButtonLink4] nvarchar(200)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'WebsiteFiles'
CREATE TABLE [dbo].[WebsiteFiles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FileName] nchar(250)  NULL,
    [KeywordId] bigint  NULL,
    [Result] bit  NULL,
    [WebsiteId] bigint  NULL
);
GO

-- Creating table 'Websites'
CREATE TABLE [dbo].[Websites] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Website] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'CustomerPosPayments'
CREATE TABLE [dbo].[CustomerPosPayments] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [CreditCardMaskedNumber] nvarchar(20)  NOT NULL,
    [ExpireYear] smallint  NOT NULL,
    [ExpireMonth] tinyint  NOT NULL,
    [ClientIp] nvarchar(50)  NOT NULL,
    [PaymentAmount] decimal(12,2)  NOT NULL,
    [PaymentResult] tinyint  NOT NULL,
    [ResultMessage] nvarchar(500)  NULL,
    [TransactionId] nvarchar(80)  NOT NULL,
    [WebsitesId] bigint  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'About'
ALTER TABLE [dbo].[About]
ADD CONSTRAINT [PK_About]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogCategories'
ALTER TABLE [dbo].[BlogCategories]
ADD CONSTRAINT [PK_BlogCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogImages'
ALTER TABLE [dbo].[BlogImages]
ADD CONSTRAINT [PK_BlogImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogTagMapping'
ALTER TABLE [dbo].[BlogTagMapping]
ADD CONSTRAINT [PK_BlogTagMapping]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogTags'
ALTER TABLE [dbo].[BlogTags]
ADD CONSTRAINT [PK_BlogTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactForm'
ALTER TABLE [dbo].[ContactForm]
ADD CONSTRAINT [PK_ContactForm]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerAttribute'
ALTER TABLE [dbo].[CustomerAttribute]
ADD CONSTRAINT [PK_CustomerAttribute]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerComments'
ALTER TABLE [dbo].[CustomerComments]
ADD CONSTRAINT [PK_CustomerComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FAQ'
ALTER TABLE [dbo].[FAQ]
ADD CONSTRAINT [PK_FAQ]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FAQCategories'
ALTER TABLE [dbo].[FAQCategories]
ADD CONSTRAINT [PK_FAQCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Gallery'
ALTER TABLE [dbo].[Gallery]
ADD CONSTRAINT [PK_Gallery]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Keyword'
ALTER TABLE [dbo].[Keyword]
ADD CONSTRAINT [PK_Keyword]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [PK_Pages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'References'
ALTER TABLE [dbo].[References]
ADD CONSTRAINT [PK_References]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SearchKeyword'
ALTER TABLE [dbo].[SearchKeyword]
ADD CONSTRAINT [PK_SearchKeyword]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceCategories'
ALTER TABLE [dbo].[ServiceCategories]
ADD CONSTRAINT [PK_ServiceCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceImages'
ALTER TABLE [dbo].[ServiceImages]
ADD CONSTRAINT [PK_ServiceImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sliders'
ALTER TABLE [dbo].[Sliders]
ADD CONSTRAINT [PK_Sliders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WebsiteFiles'
ALTER TABLE [dbo].[WebsiteFiles]
ADD CONSTRAINT [PK_WebsiteFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Websites'
ALTER TABLE [dbo].[Websites]
ADD CONSTRAINT [PK_Websites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerPosPayments'
ALTER TABLE [dbo].[CustomerPosPayments]
ADD CONSTRAINT [PK_CustomerPosPayments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LanguageId] in table 'About'
ALTER TABLE [dbo].[About]
ADD CONSTRAINT [FK_About_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_About_Languages'
CREATE INDEX [IX_FK_About_Languages]
ON [dbo].[About]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'BlogCategories'
ALTER TABLE [dbo].[BlogCategories]
ADD CONSTRAINT [FK_BlogCategories_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogCategories_Languages'
CREATE INDEX [IX_FK_BlogCategories_Languages]
ON [dbo].[BlogCategories]
    ([LanguageId]);
GO

-- Creating foreign key on [CategoryId] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [FK_Blogs_BlogCategories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[BlogCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Blogs_BlogCategories'
CREATE INDEX [IX_FK_Blogs_BlogCategories]
ON [dbo].[Blogs]
    ([CategoryId]);
GO

-- Creating foreign key on [BlogId] in table 'BlogImages'
ALTER TABLE [dbo].[BlogImages]
ADD CONSTRAINT [FK_BlogImages_Blogs]
    FOREIGN KEY ([BlogId])
    REFERENCES [dbo].[Blogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogImages_Blogs'
CREATE INDEX [IX_FK_BlogImages_Blogs]
ON [dbo].[BlogImages]
    ([BlogId]);
GO

-- Creating foreign key on [LanguageId] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [FK_Blogs_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Blogs_Languages'
CREATE INDEX [IX_FK_Blogs_Languages]
ON [dbo].[Blogs]
    ([LanguageId]);
GO

-- Creating foreign key on [BlogId] in table 'BlogTagMapping'
ALTER TABLE [dbo].[BlogTagMapping]
ADD CONSTRAINT [FK_BlogTagMapping_Blogs]
    FOREIGN KEY ([BlogId])
    REFERENCES [dbo].[Blogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogTagMapping_Blogs'
CREATE INDEX [IX_FK_BlogTagMapping_Blogs]
ON [dbo].[BlogTagMapping]
    ([BlogId]);
GO

-- Creating foreign key on [TagId] in table 'BlogTagMapping'
ALTER TABLE [dbo].[BlogTagMapping]
ADD CONSTRAINT [FK_BlogTagMapping_BlogTags]
    FOREIGN KEY ([TagId])
    REFERENCES [dbo].[BlogTags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogTagMapping_BlogTags'
CREATE INDEX [IX_FK_BlogTagMapping_BlogTags]
ON [dbo].[BlogTagMapping]
    ([TagId]);
GO

-- Creating foreign key on [LanguageId] in table 'BlogTags'
ALTER TABLE [dbo].[BlogTags]
ADD CONSTRAINT [FK_BlogTags_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogTags_Languages'
CREATE INDEX [IX_FK_BlogTags_Languages]
ON [dbo].[BlogTags]
    ([LanguageId]);
GO

-- Creating foreign key on [CategoryId] in table 'FAQ'
ALTER TABLE [dbo].[FAQ]
ADD CONSTRAINT [FK_FAQ_FAQCategories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[FAQCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQ_FAQCategories'
CREATE INDEX [IX_FK_FAQ_FAQCategories]
ON [dbo].[FAQ]
    ([CategoryId]);
GO

-- Creating foreign key on [LanguageId] in table 'FAQ'
ALTER TABLE [dbo].[FAQ]
ADD CONSTRAINT [FK_FAQ_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQ_Languages'
CREATE INDEX [IX_FK_FAQ_Languages]
ON [dbo].[FAQ]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'FAQCategories'
ALTER TABLE [dbo].[FAQCategories]
ADD CONSTRAINT [FK_FAQCategories_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQCategories_Languages'
CREATE INDEX [IX_FK_FAQCategories_Languages]
ON [dbo].[FAQCategories]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'Keyword'
ALTER TABLE [dbo].[Keyword]
ADD CONSTRAINT [FK_Keyword_Keyword]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Keyword_Keyword'
CREATE INDEX [IX_FK_Keyword_Keyword]
ON [dbo].[Keyword]
    ([LanguageId]);
GO

-- Creating foreign key on [KeywordId] in table 'SearchKeyword'
ALTER TABLE [dbo].[SearchKeyword]
ADD CONSTRAINT [FK_SearchKeyword_Keyword]
    FOREIGN KEY ([KeywordId])
    REFERENCES [dbo].[Keyword]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SearchKeyword_Keyword'
CREATE INDEX [IX_FK_SearchKeyword_Keyword]
ON [dbo].[SearchKeyword]
    ([KeywordId]);
GO

-- Creating foreign key on [KeywordId] in table 'WebsiteFiles'
ALTER TABLE [dbo].[WebsiteFiles]
ADD CONSTRAINT [FK_WebsiteFiles_Keyword]
    FOREIGN KEY ([KeywordId])
    REFERENCES [dbo].[Keyword]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WebsiteFiles_Keyword'
CREATE INDEX [IX_FK_WebsiteFiles_Keyword]
ON [dbo].[WebsiteFiles]
    ([KeywordId]);
GO

-- Creating foreign key on [LanguageId] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [FK_Pages_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pages_Languages'
CREATE INDEX [IX_FK_Pages_Languages]
ON [dbo].[Pages]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [FK_Properties_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Properties_Languages'
CREATE INDEX [IX_FK_Properties_Languages]
ON [dbo].[Properties]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'ServiceCategories'
ALTER TABLE [dbo].[ServiceCategories]
ADD CONSTRAINT [FK_ServiceCategories_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceCategories_Languages'
CREATE INDEX [IX_FK_ServiceCategories_Languages]
ON [dbo].[ServiceCategories]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_Services_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Services_Languages'
CREATE INDEX [IX_FK_Services_Languages]
ON [dbo].[Services]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [FK_Settings_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Settings_Languages'
CREATE INDEX [IX_FK_Settings_Languages]
ON [dbo].[Settings]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'Sliders'
ALTER TABLE [dbo].[Sliders]
ADD CONSTRAINT [FK_Sliders_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sliders_Languages'
CREATE INDEX [IX_FK_Sliders_Languages]
ON [dbo].[Sliders]
    ([LanguageId]);
GO

-- Creating foreign key on [ParentId] in table 'ServiceCategories'
ALTER TABLE [dbo].[ServiceCategories]
ADD CONSTRAINT [FK_ServiceCategories_ServiceCategories]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[ServiceCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceCategories_ServiceCategories'
CREATE INDEX [IX_FK_ServiceCategories_ServiceCategories]
ON [dbo].[ServiceCategories]
    ([ParentId]);
GO

-- Creating foreign key on [CategoryId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_Services_ServiceCategories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[ServiceCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Services_ServiceCategories'
CREATE INDEX [IX_FK_Services_ServiceCategories]
ON [dbo].[Services]
    ([CategoryId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceImages'
ALTER TABLE [dbo].[ServiceImages]
ADD CONSTRAINT [FK_ServiceImages_Services]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceImages_Services'
CREATE INDEX [IX_FK_ServiceImages_Services]
ON [dbo].[ServiceImages]
    ([ServiceId]);
GO

-- Creating foreign key on [WebsiteId] in table 'WebsiteFiles'
ALTER TABLE [dbo].[WebsiteFiles]
ADD CONSTRAINT [FK_WebsiteFiles_Websites]
    FOREIGN KEY ([WebsiteId])
    REFERENCES [dbo].[Websites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WebsiteFiles_Websites'
CREATE INDEX [IX_FK_WebsiteFiles_Websites]
ON [dbo].[WebsiteFiles]
    ([WebsiteId]);
GO

-- Creating foreign key on [WebsitesId] in table 'CustomerPosPayments'
ALTER TABLE [dbo].[CustomerPosPayments]
ADD CONSTRAINT [FK_CustomerPosPaymentsWebsites]
    FOREIGN KEY ([WebsitesId])
    REFERENCES [dbo].[Websites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerPosPaymentsWebsites'
CREATE INDEX [IX_FK_CustomerPosPaymentsWebsites]
ON [dbo].[CustomerPosPayments]
    ([WebsitesId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------