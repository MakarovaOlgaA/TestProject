CREATE PROCEDURE [dbo].[USP_GetAuthorByName] @FirstName NVARCHAR(50), 
                                             @LastName  NVARCHAR(50)
AS
     SELECT [BookAuthors].[AuthorID], 
            [FirstName], 
            [LastName], 
            COUNT(*) AS [NumberOfBooks]
     FROM [BookAuthors]
          INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
     WHERE [FirstName] = @FirstName
           AND [LastName] = @LastName
     GROUP BY [BookAuthors].[AuthorID], 
              [FirstName], 
              [LastName];
     RETURN;
GO