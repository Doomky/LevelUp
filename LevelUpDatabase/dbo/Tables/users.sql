﻿CREATE TABLE [dbo].[users] (
    [id]                       INT            IDENTITY (1, 1) NOT NULL,
    [login]                    VARCHAR (255)  NOT NULL,
    [firstname]                VARCHAR (255)  NOT NULL,
    [lastname]                 VARCHAR (255)  NOT NULL,
    [gender]                   BIT            NULL,
    [weight_kg]                TINYINT        NOT NULL,
    [email]                    VARCHAR (255)  NOT NULL,
    [last_login_date]          DATETIME       NULL,
    [password_hash]            VARCHAR (255)  NULL,
    [avatar_id]                INT            NOT NULL,
    [google_access_token]      VARCHAR (2048) NULL,
    [google_refresh_token]     VARCHAR (512)  NULL,
    [google_access_expiration] DATETIME       NULL,
    [creation_date]            DATETIME       DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__users__3213E83F2198F0BB]  PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__users__avatar_id__398D8EEE] FOREIGN KEY ([avatar_id]) REFERENCES [dbo].[avatars] ([id])
);









