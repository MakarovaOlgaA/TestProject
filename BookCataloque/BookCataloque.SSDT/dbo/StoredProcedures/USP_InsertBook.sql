CREATE PROCEDURE [dbo].[USP_InsertBook] @Title           NVARCHAR(50), 
                                        @PublicationDate DATE, 
                                        @Pages           SMALLINT, 
                                        @Rating          TINYINT NULL, 
                                        @Authors         AUTHORSLIST READONLY, 
                                        @BookID          INT NULL
AS
     INSERT INTO [Books]
     ([Title], 
      [PublicationDate], 
      [Pages], 
      [Rating]
     )
     VALUES
     (@Title, 
      @PublicationDate, 
      @Pages, 
      @Rating
     );
     SET @BookID = SCOPE_IDENTITY();
     EXEC [USP_InsertBookAuthors] 
          @BookID, 
          @Authors;
GO