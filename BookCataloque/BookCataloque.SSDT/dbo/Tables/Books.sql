CREATE TABLE [dbo].[Books] (
    [BookID]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (100) NOT NULL,
    [PublicationDate] DATE           NOT NULL,
    [Rating]          NUMERIC(4, 2)        NULL,
    [Pages] SMALLINT NOT NULL, 
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookID] ASC)
);

