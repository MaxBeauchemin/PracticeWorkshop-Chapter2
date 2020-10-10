PRINT 'Adding Products'

SET IDENTITY_INSERT [dbo].[Products] ON

INSERT INTO [dbo].[Products] 
				(ProductId, Code,		[Description],				CurrentPrice)

SELECT			1,			'XBCTRL',	'Xbox One Controller',		40.00
UNION SELECT	2,			'XBX',		'Xbox One',					250.00
UNION SELECT	3,			'PS4CTRL',	'Playstation 4 Controller',	40.00

SET IDENTITY_INSERT [dbo].[Products] OFF