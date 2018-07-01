﻿/*
Скрипт развертывания для BookCataloque

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BookCataloque"
:setvar DefaultFilePrefix "BookCataloque"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Выполняется создание [dbo].[BookAuthors]...';


GO
CREATE TABLE [dbo].[BookAuthors] (
    [BookID]   INT NOT NULL,
    [AuthorID] INT NOT NULL,
    CONSTRAINT [PK_BookAuthors] PRIMARY KEY CLUSTERED ([BookID] ASC, [AuthorID] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[FK_BookAuthors_Authors]...';


GO
ALTER TABLE [dbo].[BookAuthors] WITH NOCHECK
    ADD CONSTRAINT [FK_BookAuthors_Authors] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Authors] ([AuthorID]) ON DELETE CASCADE;


GO
PRINT N'Выполняется создание [dbo].[FK_BookAuthors_Books]...';


GO
ALTER TABLE [dbo].[BookAuthors] WITH NOCHECK
    ADD CONSTRAINT [FK_BookAuthors_Books] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Books] ([BookID]);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT 1 FROM [dbo].[Books] )
BEGIN
	SET IDENTITY_INSERT [dbo].[Books] ON 
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating]) VALUES (1, N'BookTitle1', CAST(N'1999-10-27' AS Date), NULL)
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating]) VALUES (2, N'BookTitle2', CAST(N'2016-06-22' AS Date), NULL)
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating]) VALUES (3, N'BookTitle3', CAST(N'2003-05-02' AS Date), NULL)
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating]) VALUES (4, N'BookTitle4', CAST(N'2000-10-07' AS Date), NULL)
	SET IDENTITY_INSERT [dbo].[Books] OFF
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Authors] )
BEGIN
    SET IDENTITY_INSERT [dbo].[Authors] ON 
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (1, N'AuthorFirstName1', N'AuthorLastName1')
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (2, N'AuthorFirstName2', N'AuthorLastName2')
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (3, N'AuthorFirstName3', N'AuthorLastName3')
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (4, N'AuthorFirstName4', N'AuthorLastName4')
	SET IDENTITY_INSERT [dbo].[Authors] OFF
END
IF NOT EXISTS (SELECT 1 FROM [dbo].[BookAuthors] )
BEGIN
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (1, 1)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (1, 2)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (2, 2)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (2, 3)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (2, 4)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (3, 3)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (4, 1)
	INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (4, 4)
END
GO

GO
PRINT N'Существующие данные проверяются относительно вновь созданных ограничений';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[BookAuthors] WITH CHECK CHECK CONSTRAINT [FK_BookAuthors_Authors];

ALTER TABLE [dbo].[BookAuthors] WITH CHECK CHECK CONSTRAINT [FK_BookAuthors_Books];


GO
PRINT N'Обновление завершено.';


GO
