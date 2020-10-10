CREATE TABLE [dbo].[Products]
(
	[ProductId]		INT				NOT NULL		IDENTITY(1,1)		PRIMARY KEY,
	[Code]			NVARCHAR(50)	NOT NULL,
	[Description]	NVARCHAR(100)	NOT NULL,
	[CurrentPrice]	DECIMAL(10,4)	NOT NULL
)