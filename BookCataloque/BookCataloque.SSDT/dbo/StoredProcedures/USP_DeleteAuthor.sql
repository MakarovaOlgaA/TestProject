CREATE PROCEDURE [dbo].[USP_DeleteAuthor] @AuthorID INT
AS
     DELETE FROM [Authors]
     WHERE AuthorID = @AuthorID;
GO