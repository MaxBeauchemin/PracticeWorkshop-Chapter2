PRINT 'Adding Order Line Items'

SET IDENTITY_INSERT [dbo].[OrderLineItems] ON

INSERT INTO [dbo].[OrderLineItems] 
				(OrderLineItemId,	OrderId,	ProductId)

SELECT			1,					1,			1
UNION SELECT	2,					1,			2
UNION SELECT	3,					2,			1
UNION SELECT	4,					2,			1
UNION SELECT	5,					2,			1

SET IDENTITY_INSERT [dbo].[OrderLineItems] OFF