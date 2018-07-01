CREATE TABLE [dbo].[Authors] (
    [AuthorID]  INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [NumberOfBooks] SMALLINT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([AuthorID] ASC)
);

