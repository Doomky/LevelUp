CREATE TABLE [dbo].[physical_activites] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [name]          VARCHAR (255) NOT NULL,
    [kcal_per_hour] NUMERIC (18)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

