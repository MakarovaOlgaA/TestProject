CREATE PROCEDURE [dbo].[USP_GetAuthor] @AuthorID INT
AS
     SELECT [BookAuthors].[AuthorID], 
            [FirstName], 
            [LastName], 
            COUNT(*) AS [NumberOfBooks]
     FROM [BookAuthors]
          INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
     WHERE [BookAuthors].[AuthorID] = @AuthorID
     GROUP BY [BookAuthors].[AuthorID], 
              [FirstName], 
              [LastName];
     RETURN;
GO