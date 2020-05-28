CREATE TABLE [dbo].[food_entries] (
    [id]                      INT      IDENTITY (1, 1) NOT NULL,
    [user_id]                 INT      NOT NULL,
    [open_food_facts_data_id] INT      NOT NULL,
    [datetime]                DATETIME NOT NULL,
    [servings] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK__food_ent__3213E83FF1858C3B] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__food_entr__open___46E78A0C] FOREIGN KEY ([open_food_facts_data_id]) REFERENCES [dbo].[open_food_facts_datas] ([id]),
    CONSTRAINT [FK__food_entr__user___45F365D3] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);



