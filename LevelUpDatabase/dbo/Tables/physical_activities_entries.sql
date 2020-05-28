CREATE TABLE [dbo].[physical_activities_entries] (
    [id]                     INT      IDENTITY (1, 1) NOT NULL,
    [user_id]                INT      NOT NULL,
    [physical_activities_id] INT      NOT NULL,
    [datetime_start]         DATETIME NOT NULL,
    [datetime_end]           DATETIME NOT NULL,
    CONSTRAINT [PK__physical__3213E83F943AB4F1] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__physical___physi__4CA06362] FOREIGN KEY ([physical_activities_id]) REFERENCES [dbo].[physical_activities] ([id]),
    CONSTRAINT [FK__physical___user___4BAC3F29] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);



