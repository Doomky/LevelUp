CREATE TABLE [dbo].[open_food_facts_datas_categories]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [category_id] INT NOT NULL, 
    [data_id] INT NOT NULL, 
    CONSTRAINT [FK_open_food_facts_categories_ToTable] FOREIGN KEY ([category_id]) REFERENCES [open_food_facts_categories]([id]), 
    CONSTRAINT [FK_open_food_facts_categories_ToTable_1] FOREIGN KEY ([data_id]) REFERENCES [open_food_facts_datas]([id]),
)