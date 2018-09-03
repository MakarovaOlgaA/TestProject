CREATE PROCEDURE [dbo].[USP_GetAuthors] @FirstName       NVARCHAR(50) = NULL, 
                                        @LastName        NVARCHAR(50) = NULL, 
                                        @PageNumber      INT          = 1, 
                                        @PageSize        INT          = 1000, 
                                        @Total           INT OUTPUT, 
                                        @SortColumn      NVARCHAR(50) = 'AuthorID', 
                                        @DescendingOrder BIT          = 0
AS	
     SELECT @Total = COUNT(*)
     FROM [Authors];
     SELECT *
     FROM
     (
         SELECT [BookAuthors].[AuthorID], 
                [FirstName], 
                [LastName], 
                COUNT(*) AS [NumberOfBooks]
         FROM [BookAuthors]
              INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
         WHERE (@FirstName IS NULL OR [FirstName] LIKE '%'+@FirstName+'%')
               AND (@LastName IS NULL OR [LastName] LIKE '%'+@LastName+'%')
         GROUP BY [BookAuthors].[AuthorID], 
                  [FirstName], 
                  [LastName]
     ) t
     ORDER BY CASE
                  WHEN @SortColumn = 'AuthorID'
                       AND @DescendingOrder = 1
                  THEN [AuthorID]
              END DESC,
              CASE
                  WHEN @SortColumn = 'AuthorID'
                  THEN [AuthorID]
              END,
              CASE
                  WHEN @SortColumn = 'FirstName'
                       AND @DescendingOrder = 1
                  THEN [FirstName]
              END DESC,
              CASE
                  WHEN @SortColumn = 'FirstName'
                  THEN [FirstName]
              END,
              CASE
                  WHEN @SortColumn = 'LastName'
                       AND @DescendingOrder = 1
                  THEN [LastName]
              END DESC,
              CASE
                  WHEN @SortColumn = 'LastName'
                  THEN [LastName]
              END,
              CASE
                  WHEN @SortColumn = 'NumberOfBooks'
                       AND @DescendingOrder = 1
                  THEN [NumberOfBooks]
              END DESC,
              CASE
                  WHEN @SortColumn = 'NumberOfBooks'
                  THEN [NumberOfBooks]
              END
     OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY;
GO