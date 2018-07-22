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
     SELECT *
     FROM
     (
         SELECT DENSE_RANK() OVER(ORDER BY CASE
                                               WHEN @SortColumn = 'BookID'
                                                    AND @DescendingOrder = 1
                                               THEN [Books].[BookID]
                                           END DESC,
                                           CASE
                                               WHEN @SortColumn = 'BookID'
                                               THEN [Books].[BookID]
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
                [Books].[BookID], 
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
             WHERE [AuthorID] = [Authors].[AuthorID]
         ) AS [NumberOfBooks]
         FROM [Books]
              INNER JOIN [BookAuthors] ON [BookAuthors].[BookID] = [Books].[BookID]
              INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
         WHERE [Title] LIKE('%'+ISNULL(@Title, [Title])+'%')
               AND ([Rating] IS NULL
                    OR ([Rating] >= ISNULL(@RatingLowerBound, [Rating])
                        AND [Rating] <= ISNULL(@RatingUpperBound, [Rating])))
               AND [PublicationDate] >= ISNULL(@PublicationDateLowerBound, [PublicationDate])
               AND [PublicationDate] <= ISNULL(@PublicationDateUpperBound, [PublicationDate])
               AND [Pages] >= ISNULL(@PagesLowerBound, [Pages])
               AND [Pages] <= ISNULL(@PagesUpperBound, [Pages])
     ) t
     WHERE t.[BookNum] BETWEEN(@PageNumber - 1) * (@PageSize + 1) AND @PageNumber * @PageSize;
GO