CREATE TABLE [dbo].[Orders]
(
	[OrderId]			INT				NOT NULL		IDENTITY(1,1)		PRIMARY KEY,
	[OrderNumber]		NVARCHAR(50)	NOT NULL,
	[CreatedTimestamp]	DATETIME		NOT NULL,
	[CreatedBy]			NVARCHAR(50)	NOT NULL
)