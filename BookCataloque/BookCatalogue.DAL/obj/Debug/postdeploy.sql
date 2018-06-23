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
