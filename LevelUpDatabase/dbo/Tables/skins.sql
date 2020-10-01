CREATE TABLE [dbo].[skins] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [name]      VARCHAR (50) NOT NULL,
    [level_min] INT          NULL,
    CONSTRAINT [PK_skins] PRIMARY KEY CLUSTERED ([id] ASC)
);



