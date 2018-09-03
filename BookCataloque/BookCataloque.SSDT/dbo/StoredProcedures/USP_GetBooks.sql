CREATE PROCEDURE [dbo].[USP_GetBooks] @Title                     NVARCHAR(100) = NULL, 
                                      @RatingLowerBound          TINYINT       = NULL, 
                                      @RatingUpperBound          TINYINT       = NULL, 
                                      @PublicationDateLowerBound DATE          = NULL, 
                                      @PublicationDateUpperBound DATE          = NULL, 
                                      @PagesLowerBound           SMALLINT      = NULL, 
                                      @PagesUpperBound           SMALLINT      = NULL, 
                                      @PageNumber                INT           = 1, 
                                      @PageSize                  INT           = 1000, 
                                      @Total                     INT OUTPUT, 
                                      @SortColumn                NVARCHAR(50)  = 'BookID', 
                                      @DescendingOrder           BIT           = 0
AS
     SELECT @Total = COUNT(*)
     FROM [Books];

     SELECT [BookID], [Title], [PublicationDate], [Rating], [Pages], [AuthorID], [FirstName], [LastName], [NumberOfBooks]
     FROM
     (
         SELECT DENSE_RANK() OVER(ORDER BY CASE
                                               WHEN @SortColumn = 'BookID'
                                                    AND @DescendingOrder = 1
                                               THEN [b].[BookID]
                                           END DESC,
                                           CASE
                                               WHEN @SortColumn = 'BookID'
                                               THEN [b].[BookID]
                                           END,
                                           CASE
                                               WHEN @SortColumn = 'Title'
                                                    AND @DescendingOrder = 1
                                               THEN [Title]
                                           END DESC,
                                           CASE
                                               WHEN @SortColumn = 'Title'
                                               THEN [Title]
                                           END,
                                           CASE
                                               WHEN @SortColumn = 'PublicationDate'
                                                    AND @DescendingOrder = 1
                                               THEN [PublicationDate]
                                           END DESC,
                                           CASE
                                               WHEN @SortColumn = 'PublicationDate'
                                               THEN [PublicationDate]
                                           END,
                                           CASE
                                               WHEN @SortColumn = 'Rating'
                                                    AND @DescendingOrder = 1
                                               THEN [Rating]
                                           END DESC,
                                           CASE
                                               WHEN @SortColumn = 'Rating'
                                               THEN [Rating]
                                           END,
                                           CASE
                                               WHEN @SortColumn = 'Pages'
                                                    AND @DescendingOrder = 1
                                               THEN [Pages]
                                           END DESC,
                                           CASE
                                               WHEN @SortColumn = 'Pages'
                                               THEN [Pages]
                                           END) AS [BookNum], 
                [b].*, 
                [a].*, 
         (
             SELECT COUNT(*)
             FROM [BookAuthors]
             WHERE [AuthorID] = [a].[AuthorID]
         ) AS [NumberOfBooks]
         FROM [Books] [b]
              INNER JOIN [BookAuthors] [ba] ON [ba].[BookID] = [b].[BookID]
              INNER JOIN [Authors] [a] ON [a].[AuthorID] = [ba].[AuthorID]
         WHERE (@Title IS NULL OR [Title] LIKE '%'+@Title+'%')
               AND (@RatingLowerBound IS NULL OR [Rating] >= @RatingLowerBound)
			   AND (@RatingUpperBound IS NULL OR [Rating] <= @RatingLowerBound)
               AND (@PublicationDateLowerBound IS NULL OR [PublicationDate] >= @PublicationDateLowerBound)
               AND (@PublicationDateUpperBound IS NULL OR [PublicationDate] <= @PublicationDateUpperBound)
               AND (@PagesLowerBound IS NULL OR [Pages] >= @PagesLowerBound)
			   AND (@PagesUpperBound IS NULL OR [Pages] <= @PagesUpperBound)
     ) t
     WHERE t.[BookNum] BETWEEN @PageNumber * (@PageSize + 1) AND (@PageNumber + 1) * @PageSize;
GO