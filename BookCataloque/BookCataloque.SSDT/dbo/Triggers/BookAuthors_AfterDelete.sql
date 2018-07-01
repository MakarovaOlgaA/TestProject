CREATE TRIGGER [BookAuthors_AfterDelete]
ON [dbo].[BookAuthors]
AFTER DELETE
AS
	UPDATE [Authors]
	SET [NumberOfBooks] = [NumberOfBooks] - [DeletedBooksCount]
	FROM (
		SELECT [AuthorID], COUNT([BookID]) AS [DeletedBooksCount]
		FROM deleted 
		GROUP BY [AuthorID]) [DeleteInfo]
	WHERE [Authors].[AuthorID] = [DeleteInfo].[AuthorID]
GO