CREATE PROCEDURE [dbo].[USP_GetBook] @BookID INT
AS
     SELECT [Books].[BookID], 
            [Title], 
            [PublicationDate], 
            [Rating], 
            [Pages], 
            [Authors].[AuthorID], 
            [FirstName], 
            [LastName], 
     (
         SELECT COUNT(*)
         FROM [BookAuthors]
         WHERE [AuthorID] = [BookAuthors].[AuthorID]
     ) AS [NumberOfBooks]
     FROM [Books]
          INNER JOIN [BookAuthors] ON [BookAuthors].[BookID] = [Books].[BookID]
          INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
     WHERE [Books].[BookID] = @BookID;
GO