CREATE TABLE [dbo].[avatars] (
    [id]     INT NOT NULL,
    [level]  INT NOT NULL,
    [xp]     INT NOT NULL,
    [xp_max] INT NOT NULL,
    [size]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

