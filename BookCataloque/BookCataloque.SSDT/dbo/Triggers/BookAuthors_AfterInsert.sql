CREATE TRIGGER [BookAuthors_AfterInsert]
ON [dbo].[BookAuthors]
AFTER INSERT
AS
	UPDATE [Authors]
	SET [NumberOfBooks] = [NumberOfBooks] + [AddedBooksCount]
	FROM (
		SELECT [AuthorID], COUNT([BookID]) AS [AddedBooksCount]
		FROM inserted 
		GROUP BY [AuthorID]) [InsertInfo]
	WHERE [Authors].[AuthorID] = [InsertInfo].[AuthorID]
GO