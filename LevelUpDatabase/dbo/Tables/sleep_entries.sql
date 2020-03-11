CREATE TABLE [dbo].[sleep_entries] (
    [id]               INT          IDENTITY (1, 1) NOT NULL,
    [user_id]          INT          NOT NULL,
    [duration_minutes] NUMERIC (18) NOT NULL,
    [date]             ROWVERSION   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__sleep_ent__user___4F7CD00D] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

