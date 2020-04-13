CREATE TABLE [dbo].[categories] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [name]     VARCHAR (255) UNIQUE NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

