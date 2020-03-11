CREATE TABLE [dbo].[advices] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [category_id] INT           NOT NULL,
    [text]        VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[categories] ([id])
);

