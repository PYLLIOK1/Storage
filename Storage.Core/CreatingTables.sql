
USE [Storage]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (255) NOT NULL,
    [DateTime] DATETIME2 (7)  NOT NULL,
    [Path]     NVARCHAR (255) NULL,
    [Ico]      NVARCHAR (255) NULL,
    [Author]   NVARCHAR (255) NULL
);
USE [Storage]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL
);
USE [Storage]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[FileAdd](@Name nvarchar(255), @DateTime datetime2(7), @Path nvarchar(255), @Ico nvarchar(255), @Author nvarchar(255)) AS BEGIN INSERT INTO Document(Name, DateTime, Path, Ico, Author)VALUES(@Name, @DateTime, @Path, @Ico, @Author)END





