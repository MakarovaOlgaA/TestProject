CREATE PROCEDURE [dbo].[USP_InsertBookAuthors] @BookID  INT, 
                                               @Authors AUTHORSLIST READONLY
AS
     INSERT INTO [BookAuthors]
     ([BookID], 
      [AuthorID]
     )
            SELECT @BookID, 
                   [AuthorID]
            FROM [Authors];
GO