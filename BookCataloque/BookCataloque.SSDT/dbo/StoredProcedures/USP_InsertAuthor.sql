CREATE PROCEDURE [dbo].[USP_InsertAuthor] @FirstName NVARCHAR(50), 
                                          @LastName  NVARCHAR(50)
AS
     INSERT INTO [Authors]
     ([FirstName], 
      [LastName]
     )
     VALUES
     (@FirstName, 
      @LastName
     );
GO