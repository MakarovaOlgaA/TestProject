CREATE TABLE [dbo].[BookAuthors] (
    [BookID]   INT NOT NULL,
    [AuthorID] INT NOT NULL,
    CONSTRAINT [PK_BookAuthors] PRIMARY KEY CLUSTERED ([BookID] ASC, [AuthorID] ASC),
    CONSTRAINT [FK_BookAuthors_Authors] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Authors] ([AuthorID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookAuthors_Books] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Books] ([BookID]) ON DELETE CASCADE
);

