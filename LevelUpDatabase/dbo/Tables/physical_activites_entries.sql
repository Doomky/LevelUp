CREATE TABLE [dbo].[physical_activites_entries] (
    [id]                    INT        IDENTITY (1, 1) NOT NULL,
    [user_id]               INT        NOT NULL,
    [physical_activites_id] INT        NOT NULL,
    [date]                  ROWVERSION NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([physical_activites_id]) REFERENCES [dbo].[physical_activites] ([id]),
    CONSTRAINT [FK__physical___user___4BAC3F29] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

