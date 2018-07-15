CREATE PROCEDURE [dbo].[USP_GetAuthors] @FirstName  NVARCHAR(50) = NULL, 
                                        @LastName   NVARCHAR(50) = NULL, 
                                        @PageNumber INT          = 1, 
                                        @PageSize   INT          = 1000
AS
     SELECT [BookAuthors].[AuthorID], 
            [FirstName], 
            [LastName], 
            COUNT(*) AS [NumberOfBooks]
     FROM [BookAuthors]
          INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
     WHERE [FirstName] LIKE('%'+ISNULL(@FirstName, [FirstName])+'%')
           AND [LastName] LIKE('%'+ISNULL(@LastName, [LastName])+'%')
     GROUP BY [BookAuthors].[AuthorID], 
              [FirstName], 
              [LastName]
     ORDER BY [LastName]
     OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY;
GO