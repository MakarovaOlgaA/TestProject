CREATE PROCEDURE [dbo].[USP_UpdateAuthor] @FirstName NVARCHAR(50), 
                                          @LastName  NVARCHAR(50), 
                                          @AuthorID  INT
AS
     UPDATE [Authors]
       SET 
           [FirstName] = @FirstName, 
           [LastName] = @LastName
     WHERE [AuthorID] = @AuthorID;
GO