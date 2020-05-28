CREATE TABLE [dbo].[physical_activities] (
    [id]                  INT             IDENTITY (1, 1) NOT NULL,
    [name]                VARCHAR (255)   NOT NULL,
    [cal_per_kg_per_hour] NUMERIC (5, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);



