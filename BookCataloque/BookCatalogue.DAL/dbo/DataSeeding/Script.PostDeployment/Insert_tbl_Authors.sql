IF NOT EXISTS (SELECT 1 FROM [dbo].[Authors] )
BEGIN
    SET IDENTITY_INSERT [dbo].[Authors] ON 
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (1, N'AuthorFirstName1', N'AuthorLastName1')
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (2, N'AuthorFirstName2', N'AuthorLastName2')
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (3, N'AuthorFirstName3', N'AuthorLastName3')
	INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (4, N'AuthorFirstName4', N'AuthorLastName4')
	SET IDENTITY_INSERT [dbo].[Authors] OFF
END