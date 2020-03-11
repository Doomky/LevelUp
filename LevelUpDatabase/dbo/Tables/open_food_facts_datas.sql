CREATE TABLE [dbo].[open_food_facts_datas] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [code]    INT           NOT NULL,
    [name]    VARCHAR (255) NOT NULL,
    [protein] VARCHAR (255) NOT NULL,
    [glucide] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

