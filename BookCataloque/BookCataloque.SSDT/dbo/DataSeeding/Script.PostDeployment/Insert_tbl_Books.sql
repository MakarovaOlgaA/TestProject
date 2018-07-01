IF NOT EXISTS (SELECT 1 FROM [dbo].[Books] )
BEGIN
	SET IDENTITY_INSERT [dbo].[Books] ON 
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating], [Pages]) VALUES (1, N'BookTitle1', CAST(N'1999-10-27' AS Date), NULL, 500)
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating], [Pages]) VALUES (2, N'BookTitle2', CAST(N'2016-06-22' AS Date), NULL, 200)
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating], [Pages]) VALUES (3, N'BookTitle3', CAST(N'2003-05-02' AS Date), NULL, 300)
	INSERT [dbo].[Books] ([BookID], [Title], [PublicationDate], [Rating], [Pages]) VALUES (4, N'BookTitle4', CAST(N'2000-10-07' AS Date), NULL, 120)
	SET IDENTITY_INSERT [dbo].[Books] OFF
END