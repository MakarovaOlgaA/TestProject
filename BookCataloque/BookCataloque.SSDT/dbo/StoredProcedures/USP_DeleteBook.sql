CREATE PROCEDURE [dbo].[USP_DeleteBook] @BookID INT
AS
     DELETE FROM [Books]
     WHERE BookID = @BookID;
GO