PRINT 'Adding Orders'

SET IDENTITY_INSERT [dbo].[Orders] ON

INSERT INTO [dbo].[Orders] 
				(OrderId,	OrderNumber, CreatedBy, CreatedTimestamp)

SELECT			1,			'000100',	'Shrek',	GETDATE()
UNION SELECT	2,			'000200',	'Fiona',	GETDATE()

SET IDENTITY_INSERT [dbo].[Orders] OFF