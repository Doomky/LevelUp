CREATE TABLE [dbo].[avatars] (
    [id]     INT IDENTITY (1, 1) NOT NULL,
    [level]  INT NOT NULL,
    [xp]     INT NOT NULL,
    [xp_max] INT NOT NULL,
    [size]   INT NOT NULL,
    CONSTRAINT [PK__avatars__3213E83FA3F00BB1] PRIMARY KEY CLUSTERED ([id] ASC)
);



