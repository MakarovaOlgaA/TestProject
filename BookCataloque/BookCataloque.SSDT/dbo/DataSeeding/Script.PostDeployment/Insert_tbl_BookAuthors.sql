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