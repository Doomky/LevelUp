CREATE TABLE [dbo].[password_recovery_datas]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [user_id] INT NOT NULL, 
    [hash] VARCHAR(50) NOT NULL, 
    [date] DATETIME NOT NULL, 
    CONSTRAINT [FK_password_recovery_user_id_key] FOREIGN KEY ([user_id]) REFERENCES [users]([id])
)
