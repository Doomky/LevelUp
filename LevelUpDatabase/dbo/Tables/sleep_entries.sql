CREATE TABLE [dbo].[sleep_entries] (
    [id]               INT          IDENTITY (1, 1) NOT NULL,
    [user_id]          INT          NOT NULL,
    [duration_minutes] NUMERIC (18) NOT NULL,
    [datetime]         DATETIME     NULL,
    CONSTRAINT [PK__sleep_en__3213E83F5717447C] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__sleep_ent__user___4F7CD00D] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);



