CREATE TABLE [dbo].[food_entries] (
    [id]                      INT        IDENTITY (1, 1) NOT NULL,
    [user_id]                 INT        NOT NULL,
    [open_food_facts_data_id] INT        NOT NULL,
    [date]                    ROWVERSION NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([open_food_facts_data_id]) REFERENCES [dbo].[open_food_facts_datas] ([id]),
    CONSTRAINT [FK__food_entr__user___45F365D3] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

