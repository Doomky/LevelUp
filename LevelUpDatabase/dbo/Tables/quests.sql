CREATE TABLE [dbo].[quests] (
    [id]             INT IDENTITY (1, 1) NOT NULL,
    [category_id]    INT NOT NULL,
    [type_id]        INT NOT NULL,
    [progress_value] INT NOT NULL,
    [progress_count] INT NOT NULL,
    [user_id] INT NOT NULL, 
    [xp_value] INT NULL DEFAULT 100, 
    [creation_date] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP  , 
    [expiration_date] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP   , 
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[categories] ([id]),
    FOREIGN KEY ([type_id]) REFERENCES [dbo].[quests_types] ([id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);