CREATE TABLE [dbo].[questions]
(
	[id] INT IDENTITY(1, 1) NOT NULL,
	[text] VARCHAR(255) NOT NULL,
	[response_a] VARCHAR(255) NOT NULL,
	[response_b] VARCHAR(255) NOT NULL,
	[response_c] VARCHAR(255) NOT NULL,
	[response_d] VARCHAR(255) NOT NULL,
	[correct_answer] VARCHAR(1) NOT NULL,
)
