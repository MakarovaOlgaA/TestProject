CREATE PROCEDURE [dbo].[USP_UpdateBookAuthors] @BookID  INT, 
                                               @Authors AUTHORSLIST READONLY
AS
     DELETE FROM [BookAuthors]
     WHERE [BookID] = @BookID
           AND [AuthorID] NOT IN
     (
         SELECT *
         FROM @Authors
     );
     MERGE [BookAuthors]
     USING
     (
         SELECT @BookID AS [BookID], 
                [AuthorID]
         FROM @Authors
     ) AS [NewBookAuthors]
     ON([BookAuthors].[BookID] = [NewBookAuthors].[BookID]
        AND [BookAuthors].[AuthorID] = [NewBookAuthors].[AuthorID])
         WHEN NOT MATCHED
         THEN
           INSERT([BookID], 
                  [AuthorID])
           VALUES
     ([NewBookAuthors].[BookID], 
      [NewBookAuthors].[AuthorID]
     );
GO