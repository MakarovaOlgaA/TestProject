CREATE PROCEDURE [dbo].[USP_GetBooks] @Title                     NVARCHAR(100) = NULL, 
                                      @RatingLowerBound          TINYINT       = NULL, 
                                      @RatingUpperBound          TINYINT       = NULL, 
                                      @PublicationDateLowerBound DATE          = NULL, 
                                      @PublicationDateUpperBound DATE          = NULL, 
                                      @PagesLowerBound           SMALLINT      = NULL, 
                                      @PagesUpperBound           SMALLINT      = NULL, 
                                      @PageNumber                INT           = 1, 
                                      @PageSize                  INT           = 1000
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
     ORDER BY [Title]
     OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY;
GO