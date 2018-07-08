CREATE PROCEDURE [dbo].[USP_UpdateBook] @BookID          INT, 
                                        @Title           NVARCHAR(50), 
                                        @PublicationDate DATE, 
                                        @Pages           SMALLINT, 
                                        @Rating          TINYINT NULL, 
                                        @Authors         AUTHORSLIST READONLY
AS
     UPDATE [Books]
       SET 
           [Title] = @Title, 
           [PublicationDate] = @PublicationDate, 
           [Pages] = @Pages, 
           [Rating] = @Rating
     WHERE BookID = @BookID;
     EXEC [USP_UpdateBookAuthors] 
          @BookID, 
          @Authors;
GO